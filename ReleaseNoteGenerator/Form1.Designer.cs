namespace ReleaseNoteGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_RepoPath = new Label();
            txt_RepoPath = new TextBox();
            label_BaseTag = new Label();
            txt_BaseTag = new TextBox();
            label_RelTag = new Label();
            txt_RelTag = new TextBox();
            txt_LogViewer = new RichTextBox();
            btn_Run = new Button();
            SuspendLayout();
            // 
            // label_RepoPath
            // 
            label_RepoPath.AutoSize = true;
            label_RepoPath.Location = new Point(10, 13);
            label_RepoPath.Name = "label_RepoPath";
            label_RepoPath.Size = new Size(78, 15);
            label_RepoPath.TabIndex = 5;
            label_RepoPath.Text = "Repo Folder :";
            // 
            // txt_RepoPath
            // 
            txt_RepoPath.Location = new Point(110, 10);
            txt_RepoPath.Name = "txt_RepoPath";
            txt_RepoPath.Size = new Size(382, 23);
            txt_RepoPath.TabIndex = 4;
            txt_RepoPath.Text = "C:\\Users\\binar\\source\\repos\\CopyMachine";
            // 
            // label_BaseTag
            // 
            label_BaseTag.AutoSize = true;
            label_BaseTag.Location = new Point(10, 44);
            label_BaseTag.Name = "label_BaseTag";
            label_BaseTag.Size = new Size(57, 15);
            label_BaseTag.TabIndex = 7;
            label_BaseTag.Text = "BaseTag :";
            // 
            // txt_BaseTag
            // 
            txt_BaseTag.Location = new Point(73, 41);
            txt_BaseTag.Name = "txt_BaseTag";
            txt_BaseTag.Size = new Size(500, 23);
            txt_BaseTag.TabIndex = 9;
            txt_BaseTag.Text = "f7e957e";
            // 
            // label_RelTag
            // 
            label_RelTag.AutoSize = true;
            label_RelTag.Location = new Point(10, 75);
            label_RelTag.Name = "label_RelTag";
            label_RelTag.Size = new Size(49, 15);
            label_RelTag.TabIndex = 6;
            label_RelTag.Text = "RelTag :";
            // 
            // txt_RelTag
            // 
            txt_RelTag.Location = new Point(73, 72);
            txt_RelTag.Name = "txt_RelTag";
            txt_RelTag.Size = new Size(500, 23);
            txt_RelTag.TabIndex = 8;
            txt_RelTag.Text = "adfadd6";
            // 
            // txt_LogViewer
            // 
            txt_LogViewer.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_LogViewer.Location = new Point(10, 108);
            txt_LogViewer.Name = "txt_LogViewer";
            txt_LogViewer.Size = new Size(563, 169);
            txt_LogViewer.TabIndex = 3;
            txt_LogViewer.Text = "";
            // 
            // btn_Run
            // 
            btn_Run.Location = new Point(498, 10);
            btn_Run.Name = "btn_Run";
            btn_Run.Size = new Size(75, 23);
            btn_Run.TabIndex = 1;
            btn_Run.Text = "시작";
            btn_Run.Click += btn_Run_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 289);
            Controls.Add(btn_Run);
            Controls.Add(txt_LogViewer);
            Controls.Add(txt_RepoPath);
            Controls.Add(label_RepoPath);
            Controls.Add(label_RelTag);
            Controls.Add(label_BaseTag);
            Controls.Add(txt_RelTag);
            Controls.Add(txt_BaseTag);
            Name = "Form1";
            Text = "Release Note Generator (TERRA4.X)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label_RepoPath;
        private System.Windows.Forms.TextBox txt_RepoPath;
        private System.Windows.Forms.TextBox txt_BaseTag;
        private System.Windows.Forms.Label label_BaseTag;
        private System.Windows.Forms.TextBox txt_RelTag;
        private System.Windows.Forms.Label label_RelTag;
        private System.Windows.Forms.RichTextBox txt_LogViewer;
        private System.Windows.Forms.Button btn_Run;
    }
}
