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

            txt_LogViewer.AppendText("Release Note ���� ����...\n");

            var git = new GitManager();

            if (false == git.TagExists(Path, strBaseTag))
            {
                txt_LogViewer.AppendText("Base Tag �� �������� �ʽ��ϴ�. �ٽ� �Է��ϼ���.\n");
                return;
            }

            txt_LogViewer.AppendText("Base Tag ���� Ȯ��....OK\n");

            if (false == git.TagExists(Path, strRelTag))
            {
                txt_LogViewer.AppendText("Release Tag �� �������� �ʽ��ϴ�. �ٽ� �Է��ϼ���.\n");
                return;
            }

            txt_LogViewer.AppendText("Release Tag ���� Ȯ��....OK\n");

            if (false == git.CheckTagsLineage(Path, strBaseTag, strRelTag))
            {
                txt_LogViewer.AppendText("Base Tag �� Release Tag �� �ϳ��� Line ���� ����Ǿ�� �մϴ�. �ٽ� �Է��ϼ���.\n");
                return;
            }

            txt_LogViewer.AppendText("Base Tag �� Release Tag �� �ϳ��� Line ���� ����....OK\n");

            git.MakeLog(Path, FileName, strBaseTag, strRelTag);

            txt_LogViewer.AppendText($"File Path : {Path}\\{FileName}\n");
            txt_LogViewer.AppendText("Release Note ���� �Ϸ�");
        }
    }
}
