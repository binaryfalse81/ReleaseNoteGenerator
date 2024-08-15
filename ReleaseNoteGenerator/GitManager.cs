using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace ReleaseNoteGenerator
{
    internal class CommitInfo
    {
        public string Sha { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }

    internal class GitManager
    {
        private IList<CommitInfo> m_Commits;

        public void MakeLog(string strPath, string strFileName, string strBaseTag, string strRelTag)
        {
            try
            {
                // Git 명령어로 로그 가져오기
                m_Commits = GetCommits(strPath, strBaseTag, strRelTag);

                // 엑셀 파일 생성
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Commits");

                    int row = 1;

                    // Headers
                    worksheet.Cell(row, 1).Value = "Date";
                    worksheet.Cell(row, 2).Value = "SHA";
                    worksheet.Cell(row, 3).Value = "Author";
                    worksheet.Cell(row, 4).Value = "Message";

                    row++;
                    // 각 커밋을 시간순으로 엑셀에 작성
                    foreach (var commit in m_Commits)
                    {
                        worksheet.Cell(row, 1).Value = commit.Date;
                        worksheet.Cell(row, 2).Value = commit.Sha;
                        worksheet.Cell(row, 3).Value = commit.Author;
                        worksheet.Cell(row, 4).Value = commit.Message;
                        row++;
                    }

                    // 열 너비 자동 조정
                    worksheet.Columns().AdjustToContents();

                    // 엑셀 파일 저장
                    workbook.SaveAs(Path.Combine(strPath, strFileName));
                }
            }
            catch (Exception ex)
            {
                // 예외 처리 코드 추가 (예: 로그 기록, 사용자 알림 등)
                throw new ApplicationException($"Error : {ex.Message}", ex);
            }
        }

        private IList<CommitInfo> GetCommits(string repoPath, string strBaseTag, string strRelTag)
        {
            var commits = new List<CommitInfo>();

            // git 명령어를 사용하여 로그를 가져옴
            var startInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = $"log {strBaseTag}..{strRelTag} --pretty=format:\"%H|%an|%ad|\"%B\"\" --date=iso",
                WorkingDirectory = repoPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = System.Text.Encoding.UTF8
            };

            using (var process = Process.Start(startInfo))
            using (var reader = process.StandardOutput)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        commits.Add(new CommitInfo
                        {
                            Sha = parts[0],
                            Author = parts[1],
                            Date = DateTime.Parse(parts[2]),
                            Message = parts[3]
                        });
                    }
                }
            }

            return commits;
        }

        public bool CheckTagsLineage(string repoPath, string strBaseTag, string strRelTag)
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = $"rev-list --ancestry-path {strBaseTag}..{strRelTag}",
                    WorkingDirectory = repoPath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(startInfo))
                {
                    if (process == null)
                        throw new InvalidOperationException("Failed to start Git process.");

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        Console.WriteLine($"Error: {error}");
                        return false;
                    }

                    // Check if output contains any commit hashes
                    var commits = output.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    return commits.Length > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }

        public bool TagExists(string repoPath, string tagName)
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = $"rev-parse --verify {tagName}",
                    WorkingDirectory = repoPath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(startInfo))
                {
                    if (process == null)
                        throw new InvalidOperationException("Failed to start Git process.");

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    // ExitCode 0 means the tag exists
                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }
    }
}
