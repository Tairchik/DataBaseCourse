using System.Drawing;
using System.Windows.Forms;

namespace OtherModule
{
    partial class SettingsForm
    {
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            lblFontFamily = new Label();
            cmbFontFamily = new ComboBox();
            lblFontSize = new Label();
            cmbFontSize = new ComboBox();
            btnApply = new Button();
            btnCancel = new Button();
            grpFontSettings = new GroupBox();
            tblSettingsLayout = new TableLayoutPanel();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            mainLayoutFlow = new FlowLayoutPanel();
            grpFontSettings.SuspendLayout();
            tblSettingsLayout.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            mainLayoutFlow.SuspendLayout();
            SuspendLayout();
            // 
            // lblFontFamily
            // 
            lblFontFamily.Anchor = AnchorStyles.Left;
            lblFontFamily.AutoSize = true;
            lblFontFamily.Location = new Point(3, 7);
            lblFontFamily.Name = "lblFontFamily";
            lblFontFamily.Size = new Size(49, 15);
            lblFontFamily.TabIndex = 0;
            lblFontFamily.Text = "Шрифт:";
            // 
            // cmbFontFamily
            // 
            cmbFontFamily.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbFontFamily.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFontFamily.Location = new Point(59, 3);
            cmbFontFamily.Name = "cmbFontFamily";
            cmbFontFamily.Size = new Size(244, 23);
            cmbFontFamily.TabIndex = 1;
            // 
            // lblFontSize
            // 
            lblFontSize.Anchor = AnchorStyles.Left;
            lblFontSize.AutoSize = true;
            lblFontSize.Location = new Point(3, 36);
            lblFontSize.Name = "lblFontSize";
            lblFontSize.Size = new Size(50, 15);
            lblFontSize.TabIndex = 2;
            lblFontSize.Text = "Размер:";
            // 
            // cmbFontSize
            // 
            cmbFontSize.Anchor = AnchorStyles.Left;
            cmbFontSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFontSize.Location = new Point(59, 32);
            cmbFontSize.Name = "cmbFontSize";
            cmbFontSize.Size = new Size(98, 23);
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
            grpFontSettings.AutoSize = true;
            grpFontSettings.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpFontSettings.Controls.Add(tblSettingsLayout);
            grpFontSettings.Location = new Point(3, 3);
            grpFontSettings.Name = "grpFontSettings";
            grpFontSettings.Padding = new Padding(10);
            grpFontSettings.Size = new Size(326, 94);
            grpFontSettings.TabIndex = 6;
            grpFontSettings.TabStop = false;
            grpFontSettings.Text = "Настройки шрифта";
            // 
            // tblSettingsLayout
            // 
            tblSettingsLayout.AutoSize = true;
            tblSettingsLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tblSettingsLayout.ColumnCount = 2;
            tblSettingsLayout.ColumnStyles.Add(new ColumnStyle());
            tblSettingsLayout.ColumnStyles.Add(new ColumnStyle());
            tblSettingsLayout.Controls.Add(lblFontFamily, 0, 0);
            tblSettingsLayout.Controls.Add(cmbFontFamily, 1, 0);
            tblSettingsLayout.Controls.Add(lblFontSize, 0, 1);
            tblSettingsLayout.Controls.Add(cmbFontSize, 1, 1);
            tblSettingsLayout.Dock = DockStyle.Fill;
            tblSettingsLayout.Location = new Point(10, 26);
            tblSettingsLayout.Name = "tblSettingsLayout";
            tblSettingsLayout.RowCount = 2;
            tblSettingsLayout.RowStyles.Add(new RowStyle());
            tblSettingsLayout.RowStyles.Add(new RowStyle());
            tblSettingsLayout.Size = new Size(306, 58);
            tblSettingsLayout.TabIndex = 7;
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
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(btnApply);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 103);
            flowLayoutPanel1.Margin = new Padding(3, 3, 3, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(284, 31);
            flowLayoutPanel1.TabIndex = 8;
            flowLayoutPanel1.WrapContents = false;
            // 
            // mainLayoutFlow
            // 
            mainLayoutFlow.AutoSize = true;
            mainLayoutFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainLayoutFlow.Controls.Add(grpFontSettings);
            mainLayoutFlow.Controls.Add(flowLayoutPanel1);
            mainLayoutFlow.Dock = DockStyle.Fill;
            mainLayoutFlow.FlowDirection = FlowDirection.TopDown;
            mainLayoutFlow.Location = new Point(0, 0);
            mainLayoutFlow.Name = "mainLayoutFlow";
            mainLayoutFlow.Size = new Size(336, 131);
            mainLayoutFlow.TabIndex = 9;
            mainLayoutFlow.WrapContents = false;
            // 
            // SettingsForm
            // 
            AcceptButton = btnApply;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = btnCancel;
            ClientSize = new Size(336, 131);
            Controls.Add(mainLayoutFlow);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Разное: Настройки";
            grpFontSettings.ResumeLayout(false);
            grpFontSettings.PerformLayout();
            tblSettingsLayout.ResumeLayout(false);
            tblSettingsLayout.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            mainLayoutFlow.ResumeLayout(false);
            mainLayoutFlow.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblFontFamily;
        private System.Windows.Forms.ComboBox cmbFontFamily;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpFontSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel mainLayoutFlow;
        private System.Windows.Forms.TableLayoutPanel tblSettingsLayout;
    }
} 