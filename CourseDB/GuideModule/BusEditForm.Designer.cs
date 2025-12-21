using System.Windows.Forms.VisualStyles;

namespace GuideModule
{
    partial class BusEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusEditForm));
            tableLayoutPanel = new TableLayoutPanel();
            labelModel = new Label();
            comboBoxModel = new ComboBox();
            labelBrand = new Label();
            textBoxBrand = new TextBox();
            labelRegNumber = new Label();
            textBoxRegNumber = new TextBox();
            labelInventoryNumber = new Label();
            textBoxInventoryNumber = new TextBox();
            labelColor = new Label();
            textBoxColor = new TextBox();
            labelState = new Label();
            comboBoxState = new ComboBox();
            labelNumberEngine = new Label();
            textBoxNumberEngine = new TextBox();
            labelNumberBody = new Label();
            textBoxNumberBody = new TextBox();
            labelNumberChassis = new Label();
            textBoxNumberChassis = new TextBox();
            labelMileage = new Label();
            textBoxMileage = new TextBox();
            labelDateLastOverhaul = new Label();
            dateTimePickerLastOverhaul = new DateTimePicker();
            labelDateRelease = new Label();
            dateTimePickerRelease = new DateTimePicker();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonApply = new Button();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.Controls.Add(labelModel, 0, 0);
            tableLayoutPanel.Controls.Add(comboBoxModel, 1, 0);
            tableLayoutPanel.Controls.Add(labelBrand, 2, 0);
            tableLayoutPanel.Controls.Add(textBoxBrand, 3, 0);
            tableLayoutPanel.Controls.Add(labelRegNumber, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxRegNumber, 1, 1);
            tableLayoutPanel.Controls.Add(labelInventoryNumber, 2, 1);
            tableLayoutPanel.Controls.Add(textBoxInventoryNumber, 3, 1);
            tableLayoutPanel.Controls.Add(labelColor, 0, 2);
            tableLayoutPanel.Controls.Add(textBoxColor, 1, 2);
            tableLayoutPanel.Controls.Add(labelState, 2, 2);
            tableLayoutPanel.Controls.Add(comboBoxState, 3, 2);
            tableLayoutPanel.Controls.Add(labelNumberEngine, 0, 3);
            tableLayoutPanel.Controls.Add(textBoxNumberEngine, 1, 3);
            tableLayoutPanel.Controls.Add(labelNumberBody, 2, 3);
            tableLayoutPanel.Controls.Add(textBoxNumberBody, 3, 3);
            tableLayoutPanel.Controls.Add(labelNumberChassis, 0, 4);
            tableLayoutPanel.Controls.Add(textBoxNumberChassis, 1, 4);
            tableLayoutPanel.Controls.Add(labelMileage, 2, 4);
            tableLayoutPanel.Controls.Add(textBoxMileage, 3, 4);
            tableLayoutPanel.Controls.Add(labelDateLastOverhaul, 0, 5);
            tableLayoutPanel.Controls.Add(dateTimePickerLastOverhaul, 1, 5);
            tableLayoutPanel.Controls.Add(labelDateRelease, 2, 5);
            tableLayoutPanel.Controls.Add(dateTimePickerRelease, 3, 5);
            tableLayoutPanel.Controls.Add(flowLayoutPanelButtons, 0, 6);
            tableLayoutPanel.Location = new Point(10, 10);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 7;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel.Size = new Size(595, 300);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelModel
            // 
            labelModel.Anchor = AnchorStyles.Left;
            labelModel.AutoSize = true;
            labelModel.Location = new Point(3, 12);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(105, 15);
            labelModel.TabIndex = 0;
            labelModel.Text = "Модель автобуса:";
            // 
            // comboBoxModel
            // 
            comboBoxModel.Anchor = AnchorStyles.Left;
            comboBoxModel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxModel.FormattingEnabled = true;
            comboBoxModel.Location = new Point(186, 8);
            comboBoxModel.Name = "comboBoxModel";
            comboBoxModel.Size = new Size(146, 23);
            comboBoxModel.TabIndex = 1;
            comboBoxModel.SelectedIndexChanged += comboBoxModel_SelectedIndexChanged;
            // 
            // labelBrand
            // 
            labelBrand.Anchor = AnchorStyles.Left;
            labelBrand.AutoSize = true;
            labelBrand.Location = new Point(338, 12);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(46, 15);
            labelBrand.TabIndex = 4;
            labelBrand.Text = "Марка:";
            // 
            // textBoxBrand
            // 
            textBoxBrand.Anchor = AnchorStyles.Left;
            textBoxBrand.Location = new Point(446, 8);
            textBoxBrand.Name = "textBoxBrand";
            textBoxBrand.ReadOnly = true;
            textBoxBrand.Size = new Size(146, 23);
            textBoxBrand.TabIndex = 5;
            // 
            // labelRegNumber
            // 
            labelRegNumber.Anchor = AnchorStyles.Left;
            labelRegNumber.AutoSize = true;
            labelRegNumber.Location = new Point(3, 52);
            labelRegNumber.Name = "labelRegNumber";
            labelRegNumber.Size = new Size(71, 15);
            labelRegNumber.TabIndex = 2;
            labelRegNumber.Text = "Гос. номер:";
            // 
            // textBoxRegNumber
            // 
            textBoxRegNumber.Anchor = AnchorStyles.Left;
            textBoxRegNumber.Location = new Point(186, 48);
            textBoxRegNumber.Name = "textBoxRegNumber";
            textBoxRegNumber.Size = new Size(146, 23);
            textBoxRegNumber.TabIndex = 2;
            // 
            // labelInventoryNumber
            // 
            labelInventoryNumber.Anchor = AnchorStyles.Left;
            labelInventoryNumber.AutoSize = true;
            labelInventoryNumber.Location = new Point(338, 52);
            labelInventoryNumber.Name = "labelInventoryNumber";
            labelInventoryNumber.Size = new Size(102, 15);
            labelInventoryNumber.TabIndex = 6;
            labelInventoryNumber.Text = "Инвентарный №:";
            // 
            // textBoxInventoryNumber
            // 
            textBoxInventoryNumber.Anchor = AnchorStyles.Left;
            textBoxInventoryNumber.Location = new Point(446, 48);
            textBoxInventoryNumber.Name = "textBoxInventoryNumber";
            textBoxInventoryNumber.Size = new Size(146, 23);
            textBoxInventoryNumber.TabIndex = 3;
            // 
            // labelColor
            // 
            labelColor.Anchor = AnchorStyles.Left;
            labelColor.AutoSize = true;
            labelColor.Location = new Point(3, 92);
            labelColor.Name = "labelColor";
            labelColor.Size = new Size(36, 15);
            labelColor.TabIndex = 8;
            labelColor.Text = "Цвет:";
            // 
            // textBoxColor
            // 
            textBoxColor.Anchor = AnchorStyles.Left;
            textBoxColor.Location = new Point(186, 88);
            textBoxColor.Name = "textBoxColor";
            textBoxColor.Size = new Size(146, 23);
            textBoxColor.TabIndex = 4;
            // 
            // labelState
            // 
            labelState.Anchor = AnchorStyles.Left;
            labelState.AutoSize = true;
            labelState.Location = new Point(338, 92);
            labelState.Name = "labelState";
            labelState.Size = new Size(69, 15);
            labelState.TabIndex = 10;
            labelState.Text = "Состояние:";
            // 
            // comboBoxState
            // 
            comboBoxState.Anchor = AnchorStyles.Left;
            comboBoxState.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxState.FormattingEnabled = true;
            comboBoxState.Location = new Point(446, 88);
            comboBoxState.Name = "comboBoxState";
            comboBoxState.Size = new Size(146, 23);
            comboBoxState.TabIndex = 5;
            // 
            // labelNumberEngine
            // 
            labelNumberEngine.Anchor = AnchorStyles.Left;
            labelNumberEngine.AutoSize = true;
            labelNumberEngine.Location = new Point(3, 132);
            labelNumberEngine.Name = "labelNumberEngine";
            labelNumberEngine.Size = new Size(105, 15);
            labelNumberEngine.TabIndex = 12;
            labelNumberEngine.Text = "Номер двигателя:";
            // 
            // textBoxNumberEngine
            // 
            textBoxNumberEngine.Anchor = AnchorStyles.Left;
            textBoxNumberEngine.Location = new Point(186, 128);
            textBoxNumberEngine.Name = "textBoxNumberEngine";
            textBoxNumberEngine.Size = new Size(146, 23);
            textBoxNumberEngine.TabIndex = 6;
            // 
            // labelNumberBody
            // 
            labelNumberBody.Anchor = AnchorStyles.Left;
            labelNumberBody.AutoSize = true;
            labelNumberBody.Location = new Point(338, 132);
            labelNumberBody.Name = "labelNumberBody";
            labelNumberBody.Size = new Size(87, 15);
            labelNumberBody.TabIndex = 14;
            labelNumberBody.Text = "Номер кузова:";
            // 
            // textBoxNumberBody
            // 
            textBoxNumberBody.Anchor = AnchorStyles.Left;
            textBoxNumberBody.Location = new Point(446, 128);
            textBoxNumberBody.Name = "textBoxNumberBody";
            textBoxNumberBody.Size = new Size(146, 23);
            textBoxNumberBody.TabIndex = 7;
            // 
            // labelNumberChassis
            // 
            labelNumberChassis.Anchor = AnchorStyles.Left;
            labelNumberChassis.AutoSize = true;
            labelNumberChassis.Location = new Point(3, 172);
            labelNumberChassis.Name = "labelNumberChassis";
            labelNumberChassis.Size = new Size(87, 15);
            labelNumberChassis.TabIndex = 16;
            labelNumberChassis.Text = "Номер шасси:";
            // 
            // textBoxNumberChassis
            // 
            textBoxNumberChassis.Anchor = AnchorStyles.Left;
            textBoxNumberChassis.Location = new Point(186, 168);
            textBoxNumberChassis.Name = "textBoxNumberChassis";
            textBoxNumberChassis.Size = new Size(146, 23);
            textBoxNumberChassis.TabIndex = 8;
            // 
            // labelMileage
            // 
            labelMileage.Anchor = AnchorStyles.Left;
            labelMileage.AutoSize = true;
            labelMileage.Location = new Point(338, 172);
            labelMileage.Name = "labelMileage";
            labelMileage.Size = new Size(51, 15);
            labelMileage.TabIndex = 18;
            labelMileage.Text = "Пробег:";
            // 
            // textBoxMileage
            // 
            textBoxMileage.Anchor = AnchorStyles.Left;
            textBoxMileage.Location = new Point(446, 168);
            textBoxMileage.Name = "textBoxMileage";
            textBoxMileage.Size = new Size(146, 23);
            textBoxMileage.TabIndex = 9;
            // 
            // labelDateLastOverhaul
            // 
            labelDateLastOverhaul.Anchor = AnchorStyles.Left;
            labelDateLastOverhaul.AutoSize = true;
            labelDateLastOverhaul.Location = new Point(3, 212);
            labelDateLastOverhaul.Name = "labelDateLastOverhaul";
            labelDateLastOverhaul.Size = new Size(177, 15);
            labelDateLastOverhaul.TabIndex = 20;
            labelDateLastOverhaul.Text = "Дата последнего кап. ремонта:";
            // 
            // dateTimePickerLastOverhaul
            // 
            dateTimePickerLastOverhaul.Anchor = AnchorStyles.Left;
            dateTimePickerLastOverhaul.Format = DateTimePickerFormat.Short;
            dateTimePickerLastOverhaul.Location = new Point(186, 208);
            dateTimePickerLastOverhaul.Name = "dateTimePickerLastOverhaul";
            dateTimePickerLastOverhaul.Size = new Size(146, 23);
            dateTimePickerLastOverhaul.TabIndex = 10;
            // 
            // labelDateRelease
            // 
            labelDateRelease.Anchor = AnchorStyles.Left;
            labelDateRelease.AutoSize = true;
            labelDateRelease.Location = new Point(338, 212);
            labelDateRelease.Name = "labelDateRelease";
            labelDateRelease.Size = new Size(84, 15);
            labelDateRelease.TabIndex = 22;
            labelDateRelease.Text = "Дата выпуска:";
            // 
            // dateTimePickerRelease
            // 
            dateTimePickerRelease.Anchor = AnchorStyles.Left;
            dateTimePickerRelease.Format = DateTimePickerFormat.Short;
            dateTimePickerRelease.Location = new Point(446, 208);
            dateTimePickerRelease.Name = "dateTimePickerRelease";
            dateTimePickerRelease.Size = new Size(146, 23);
            dateTimePickerRelease.TabIndex = 11;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.SetColumnSpan(flowLayoutPanelButtons, 4);
            flowLayoutPanelButtons.Controls.Add(buttonCancel);
            flowLayoutPanelButtons.Controls.Add(buttonApply);
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(3, 243);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Padding = new Padding(0, 10, 0, 0);
            flowLayoutPanelButtons.Size = new Size(589, 51);
            flowLayoutPanelButtons.TabIndex = 24;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.AutoSize = true;
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.Location = new Point(506, 13);
            buttonCancel.MinimumSize = new Size(80, 30);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(10, 5, 10, 5);
            buttonCancel.Size = new Size(80, 35);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonApply.AutoSize = true;
            buttonApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApply.Location = new Point(400, 13);
            buttonApply.MinimumSize = new Size(90, 30);
            buttonApply.Name = "buttonApply";
            buttonApply.Padding = new Padding(10, 5, 10, 5);
            buttonApply.Size = new Size(100, 35);
            buttonApply.TabIndex = 12;
            buttonApply.Text = "Применить";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // BusEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(604, 306);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(620, 345);
            Name = "BusEditForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Автобус";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            flowLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelRegNumber;
        private System.Windows.Forms.Label labelBrand;
        private System.Windows.Forms.Label labelInventoryNumber;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label labelNumberEngine;
        private System.Windows.Forms.Label labelNumberBody;
        private System.Windows.Forms.Label labelNumberChassis;
        private System.Windows.Forms.Label labelMileage;
        private System.Windows.Forms.Label labelDateLastOverhaul;
        private System.Windows.Forms.Label labelDateRelease;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.TextBox textBoxInventoryNumber;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.TextBox textBoxNumberEngine;
        private System.Windows.Forms.TextBox textBoxNumberBody;
        private System.Windows.Forms.TextBox textBoxNumberChassis;
        private System.Windows.Forms.TextBox textBoxMileage;
        private System.Windows.Forms.DateTimePicker dateTimePickerLastOverhaul;
        private System.Windows.Forms.DateTimePicker dateTimePickerRelease;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.TextBox textBoxRegNumber;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
    }
}