namespace OtherModule
{
    partial class SettingsForm
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
            lblFontFamily = new Label();
            cmbFontFamily = new ComboBox();
            lblFontSize = new Label();
            cmbFontSize = new ComboBox();
            btnApply = new Button();
            btnCancel = new Button();
            grpFontSettings = new GroupBox();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            grpFontSettings.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblFontFamily
            // 
            lblFontFamily.AutoSize = true;
            lblFontFamily.Location = new Point(20, 30);
            lblFontFamily.Name = "lblFontFamily";
            lblFontFamily.Size = new Size(49, 15);
            lblFontFamily.TabIndex = 0;
            lblFontFamily.Text = "Шрифт:";
            // 
            // cmbFontFamily
            // 
            cmbFontFamily.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbFontFamily.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFontFamily.FormattingEnabled = true;
            cmbFontFamily.Location = new Point(120, 27);
            cmbFontFamily.Name = "cmbFontFamily";
            cmbFontFamily.Size = new Size(194, 23);
            cmbFontFamily.TabIndex = 1;
            // 
            // lblFontSize
            // 
            lblFontSize.AutoSize = true;
            lblFontSize.Location = new Point(20, 70);
            lblFontSize.Name = "lblFontSize";
            lblFontSize.Size = new Size(50, 15);
            lblFontSize.TabIndex = 2;
            lblFontSize.Text = "Размер:";
            // 
            // cmbFontSize
            // 
            cmbFontSize.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbFontSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFontSize.FormattingEnabled = true;
            cmbFontSize.Location = new Point(120, 67);
            cmbFontSize.Name = "cmbFontSize";
            cmbFontSize.Size = new Size(104, 23);
            cmbFontSize.TabIndex = 3;
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.Bottom;
            btnApply.AutoSize = true;
            btnApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnApply.Location = new Point(201, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(80, 25);
            btnApply.TabIndex = 4;
            btnApply.Text = "Применить";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.AutoSize = true;
            btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(136, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(59, 25);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // grpFontSettings
            // 
            grpFontSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFontSettings.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpFontSettings.Controls.Add(cmbFontFamily);
            grpFontSettings.Controls.Add(lblFontFamily);
            grpFontSettings.Controls.Add(lblFontSize);
            grpFontSettings.Controls.Add(cmbFontSize);
            grpFontSettings.Location = new Point(15, 17);
            grpFontSettings.Name = "grpFontSettings";
            grpFontSettings.Size = new Size(320, 109);
            grpFontSettings.TabIndex = 6;
            grpFontSettings.TabStop = false;
            grpFontSettings.Text = "Настройки шрифта";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.AutoSize = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(127, 25);
            button1.TabIndex = 7;
            button1.Text = "Применить и выйти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnApply);
            flowLayoutPanel1.Location = new Point(0, 170);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(332, 31);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // SettingsForm
            // 
            AcceptButton = btnApply;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = btnCancel;
            ClientSize = new Size(344, 209);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(grpFontSettings);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройки приложения";
            grpFontSettings.ResumeLayout(false);
            grpFontSettings.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblFontFamily;
        private System.Windows.Forms.ComboBox cmbFontFamily;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpFontSettings;
        #endregion

        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
