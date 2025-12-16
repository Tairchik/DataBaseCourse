namespace GuideModule
{
    partial class ModelEditForm
    {
        private System.ComponentModel.IContainer components = null;

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
            tableLayoutPanel = new TableLayoutPanel();
            labelBrandName = new Label();
            comboBoxBrand = new ComboBox();
            labelModelName = new Label();
            textBoxModelName = new TextBox();
            labelSeatCapacity = new Label();
            numericUpDownSeatCapacity = new NumericUpDown();
            labelFullCapacity = new Label();
            numericUpDownFullCapacity = new NumericUpDown();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonApply = new Button();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeatCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFullCapacity).BeginInit();
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
            tableLayoutPanel.Controls.Add(labelBrandName, 0, 0);
            tableLayoutPanel.Controls.Add(comboBoxBrand, 1, 0);
            tableLayoutPanel.Controls.Add(labelModelName, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxModelName, 1, 1);
            tableLayoutPanel.Controls.Add(labelSeatCapacity, 0, 2);
            tableLayoutPanel.Controls.Add(numericUpDownSeatCapacity, 1, 2);
            tableLayoutPanel.Controls.Add(labelFullCapacity, 0, 3);
            tableLayoutPanel.Controls.Add(numericUpDownFullCapacity, 1, 3);
            tableLayoutPanel.Controls.Add(flowLayoutPanelButtons, 0, 4);
            tableLayoutPanel.Location = new Point(7, 13);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(0, 0, 0, 10);
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Size = new Size(480, 239);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelBrandName
            // 
            labelBrandName.Anchor = AnchorStyles.Left;
            labelBrandName.AutoSize = true;
            labelBrandName.Location = new Point(3, 14);
            labelBrandName.Margin = new Padding(3, 10, 3, 10);
            labelBrandName.Name = "labelBrandName";
            labelBrandName.Size = new Size(104, 15);
            labelBrandName.TabIndex = 0;
            labelBrandName.Text = "Название бренда:";
            // 
            // comboBoxBrand
            // 
            comboBoxBrand.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBrand.FormattingEnabled = true;
            comboBoxBrand.Location = new Point(195, 10);
            comboBoxBrand.Margin = new Padding(3, 10, 3, 10);
            comboBoxBrand.Name = "comboBoxBrand";
            comboBoxBrand.Size = new Size(282, 23);
            comboBoxBrand.TabIndex = 4;
            // 
            // labelModelName
            // 
            labelModelName.Anchor = AnchorStyles.Left;
            labelModelName.AutoSize = true;
            labelModelName.Location = new Point(3, 57);
            labelModelName.Margin = new Padding(3, 10, 3, 10);
            labelModelName.Name = "labelModelName";
            labelModelName.Size = new Size(107, 15);
            labelModelName.TabIndex = 1;
            labelModelName.Text = "Название модели:";
            // 
            // textBoxModelName
            // 
            textBoxModelName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxModelName.Location = new Point(195, 53);
            textBoxModelName.Margin = new Padding(3, 10, 3, 10);
            textBoxModelName.Name = "textBoxModelName";
            textBoxModelName.Size = new Size(282, 23);
            textBoxModelName.TabIndex = 5;
            // 
            // labelSeatCapacity
            // 
            labelSeatCapacity.Anchor = AnchorStyles.Left;
            labelSeatCapacity.AutoSize = true;
            labelSeatCapacity.Location = new Point(3, 100);
            labelSeatCapacity.Margin = new Padding(3, 10, 3, 10);
            labelSeatCapacity.Name = "labelSeatCapacity";
            labelSeatCapacity.Size = new Size(144, 15);
            labelSeatCapacity.TabIndex = 2;
            labelSeatCapacity.Text = "Число посадочных мест:";
            // 
            // numericUpDownSeatCapacity
            // 
            numericUpDownSeatCapacity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownSeatCapacity.Location = new Point(195, 96);
            numericUpDownSeatCapacity.Margin = new Padding(3, 10, 3, 10);
            numericUpDownSeatCapacity.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericUpDownSeatCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSeatCapacity.Name = "numericUpDownSeatCapacity";
            numericUpDownSeatCapacity.Size = new Size(282, 23);
            numericUpDownSeatCapacity.TabIndex = 6;
            numericUpDownSeatCapacity.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // labelFullCapacity
            // 
            labelFullCapacity.Anchor = AnchorStyles.Left;
            labelFullCapacity.AutoSize = true;
            labelFullCapacity.Location = new Point(3, 143);
            labelFullCapacity.Margin = new Padding(3, 10, 3, 10);
            labelFullCapacity.Name = "labelFullCapacity";
            labelFullCapacity.Size = new Size(127, 15);
            labelFullCapacity.TabIndex = 3;
            labelFullCapacity.Text = "Полная вместимость:";
            // 
            // numericUpDownFullCapacity
            // 
            numericUpDownFullCapacity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownFullCapacity.Location = new Point(195, 139);
            numericUpDownFullCapacity.Margin = new Padding(3, 10, 3, 10);
            numericUpDownFullCapacity.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericUpDownFullCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownFullCapacity.Name = "numericUpDownFullCapacity";
            numericUpDownFullCapacity.Size = new Size(282, 23);
            numericUpDownFullCapacity.TabIndex = 7;
            numericUpDownFullCapacity.Value = new decimal(new int[] { 50, 0, 0, 0 });
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
            flowLayoutPanelButtons.Location = new Point(3, 175);
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
            // ModelEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(500, 265);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(400, 300);
            Name = "ModelEditForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Модель";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeatCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFullCapacity).EndInit();
            flowLayoutPanelButtons.ResumeLayout(false);
            flowLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelBrandName;
        private System.Windows.Forms.Label labelModelName;
        private System.Windows.Forms.Label labelSeatCapacity;
        private System.Windows.Forms.Label labelFullCapacity;
        private System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.TextBox textBoxModelName;
        private System.Windows.Forms.NumericUpDown numericUpDownSeatCapacity;
        private System.Windows.Forms.NumericUpDown numericUpDownFullCapacity;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
    }
}