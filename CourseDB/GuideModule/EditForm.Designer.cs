using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GuideModule
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            tableLayoutPanel = new TableLayoutPanel();
            labelName = new Label();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonApply = new Button();
            textBox = new TextBox();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel.Controls.Add(labelName, 0, 0);
            tableLayoutPanel.Controls.Add(flowLayoutPanelButtons, 0, 1);
            tableLayoutPanel.Controls.Add(textBox, 1, 0);
            tableLayoutPanel.Location = new Point(7, 13);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(0, 0, 0, 10);
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(480, 102);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.Anchor = AnchorStyles.Left;
            labelName.AutoSize = true;
            labelName.Location = new Point(3, 10);
            labelName.Margin = new Padding(3, 10, 3, 10);
            labelName.Name = "labelName";
            labelName.Size = new Size(101, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Название улицы:";
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.SetColumnSpan(flowLayoutPanelButtons, 2);
            flowLayoutPanelButtons.Controls.Add(buttonCancel);
            flowLayoutPanelButtons.Controls.Add(buttonApply);
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(3, 38);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Padding = new Padding(0, 10, 0, 0);
            flowLayoutPanelButtons.Size = new Size(474, 51);
            flowLayoutPanelButtons.TabIndex = 8;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.AutoSize = true;
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.Location = new Point(391, 13);
            buttonCancel.MinimumSize = new Size(80, 30);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(10, 5, 10, 5);
            buttonCancel.Size = new Size(80, 35);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonApply.AutoSize = true;
            buttonApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApply.Location = new Point(285, 13);
            buttonApply.MinimumSize = new Size(90, 30);
            buttonApply.Name = "buttonApply";
            buttonApply.Padding = new Padding(10, 5, 10, 5);
            buttonApply.Size = new Size(100, 35);
            buttonApply.TabIndex = 9;
            buttonApply.Text = "Применить";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // textBox
            // 
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox.Location = new Point(195, 6);
            textBox.Name = "textBox";
            textBox.Size = new Size(282, 23);
            textBox.TabIndex = 10;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(500, 122);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(400, 100);
            Name = "EditForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Модель";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            flowLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private NumericUpDown numericSalary;
        private TextBox textBox;
    }
}