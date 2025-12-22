namespace HelpModule
{
    partial class AboutProgramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutProgramForm));
            lblTitle = new Label();
            lblVersion = new Label();
            lblCopyright = new Label();
            txtDescription = new TextBox();
            btnOk = new Button();
            pbIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbIcon).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(100, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(244, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "АИС «Автобусный парк»";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(103, 50);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(64, 15);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "Версия 1.0";
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Location = new Point(20, 200);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(191, 30);
            lblCopyright.TabIndex = 2;
            lblCopyright.Text = "© 2025 Разработка студента: \r\nБикмухаметова Таира Олеговича";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(20, 90);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(390, 100);
            txtDescription.TabIndex = 3;
            txtDescription.Text = resources.GetString("txtDescription.Text");
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(335, 220);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // pbIcon
            // 
            pbIcon.Image = Properties.Resources.NSTU_Logo_eng_violet;
            pbIcon.Location = new Point(20, 15);
            pbIcon.Name = "pbIcon";
            pbIcon.Size = new Size(74, 69);
            pbIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIcon.TabIndex = 5;
            pbIcon.TabStop = false;
            // 
            // AboutProgramForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 261);
            Controls.Add(pbIcon);
            Controls.Add(btnOk);
            Controls.Add(txtDescription);
            Controls.Add(lblCopyright);
            Controls.Add(lblVersion);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutProgramForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Справка: О программе";
            ((System.ComponentModel.ISupportInitialize)pbIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox pbIcon;
    }
}