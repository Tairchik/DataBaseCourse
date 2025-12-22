namespace HelpModule
{
    partial class ContentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentForm));
            splitContainer = new SplitContainer();
            treeViewTopics = new TreeView();
            richTextBoxContent = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(treeViewTopics);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(richTextBoxContent);
            splitContainer.Size = new Size(800, 450);
            splitContainer.SplitterDistance = 266;
            splitContainer.TabIndex = 0;
            // 
            // treeViewTopics
            // 
            treeViewTopics.Dock = DockStyle.Fill;
            treeViewTopics.Location = new Point(0, 0);
            treeViewTopics.Name = "treeViewTopics";
            treeViewTopics.Size = new Size(266, 450);
            treeViewTopics.TabIndex = 0;
            treeViewTopics.AfterSelect += TreeViewTopics_AfterSelect;
            // 
            // richTextBoxContent
            // 
            richTextBoxContent.BackColor = Color.White;
            richTextBoxContent.Dock = DockStyle.Fill;
            richTextBoxContent.Font = new Font("Segoe UI", 10F);
            richTextBoxContent.Location = new Point(0, 0);
            richTextBoxContent.Name = "richTextBoxContent";
            richTextBoxContent.ReadOnly = true;
            richTextBoxContent.Size = new Size(530, 450);
            richTextBoxContent.TabIndex = 0;
            richTextBoxContent.Text = "";
            // 
            // ContentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ContentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Справка: Содержание";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeViewTopics;
        private System.Windows.Forms.RichTextBox richTextBoxContent;
    }
}
