namespace ReleaseNoteGenerator
{
    public partial class Form1 : Form
    {
        private string strBaseTag;
        private string strRelTag;
        private string Path
        {
            get { return txt_RepoPath.Text; }
            set { txt_RepoPath.Text = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            string FileName = "ReleaseNote.xlsx";
            strBaseTag = txt_BaseTag.Text;
            strRelTag = txt_RelTag.Text;
            txt_LogViewer.Text = "";

            txt_LogViewer.AppendText("Release Note 생성 시작...\n");

            var git = new GitManager();

            if (false == git.TagExists(Path, strBaseTag))
            {
                txt_LogViewer.AppendText("Base Tag 가 존재하지 않습니다. 다시 입력하세요.\n");
                return;
            }

            txt_LogViewer.AppendText("Base Tag 존재 확인....OK\n");

            if (false == git.TagExists(Path, strRelTag))
            {
                txt_LogViewer.AppendText("Release Tag 가 존재하지 않습니다. 다시 입력하세요.\n");
                return;
            }

            txt_LogViewer.AppendText("Release Tag 존재 확인....OK\n");

            if (false == git.CheckTagsLineage(Path, strBaseTag, strRelTag))
            {
                txt_LogViewer.AppendText("Base Tag 와 Release Tag 가 하나의 Line 으로 연결되어야 합니다. 다시 입력하세요.\n");
                return;
            }

            txt_LogViewer.AppendText("Base Tag 와 Release Tag 가 하나의 Line 으로 연결....OK\n");

            git.MakeLog(Path, FileName, strBaseTag, strRelTag);

            txt_LogViewer.AppendText($"File Path : {Path}\\{FileName}\n");
            txt_LogViewer.AppendText("Release Note 생성 완료");
        }
    }
}
