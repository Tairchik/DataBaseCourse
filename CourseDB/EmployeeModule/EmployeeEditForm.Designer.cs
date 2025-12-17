namespace EmployeeModule
{
    partial class EmployeeEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainTableLayout;
        private Panel personalDataPanel;
        private Label personalDataLabel;
        private TableLayoutPanel personalDataTableLayout;
        private Label surnameLabel;
        private TextBox surnameTextBox;
        private Label nameLabel;
        private TextBox nameTextBox;
        private Label patronymicLabel;
        private TextBox patronymicTextBox;
        private Label genderLabel;
        private ComboBox genderComboBox;
        private Label birthdayLabel;
        private DateTimePicker birthdayPicker;
        private Panel addressPanel;
        private Label addressLabel;
        private TableLayoutPanel addressTableLayout;
        private Label streetLabel;
        private TextBox streetTextBox;
        private Label houseLabel;
        private TextBox houseTextBox;
        private Label apartmentLabel;
        private TextBox apartmentTextBox;
        private Panel workDataPanel;
        private Label workDataLabel;
        private TableLayoutPanel workDataTableLayout;
        private Label timeWorkLabel;
        private NumericUpDown timeWorkNumeric;
        private Label positionLabel;
        private ComboBox positionComboBox;
        private Label classDriverLabel;
        private NumericUpDown classDriverNumeric;
        private Label bonusLabel;
        private NumericUpDown bonusNumeric;
        private Panel buttonsPanel;
        private FlowLayoutPanel buttonsFlowLayout;
        private Button cancelButton;
        private Button applyButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainTableLayout = new TableLayoutPanel();
            personalDataPanel = new Panel();
            personalDataLabel = new Label();
            personalDataTableLayout = new TableLayoutPanel();
            surnameLabel = new Label();
            surnameTextBox = new TextBox();
            nameLabel = new Label();
            nameTextBox = new TextBox();
            patronymicLabel = new Label();
            patronymicTextBox = new TextBox();
            genderLabel = new Label();
            genderComboBox = new ComboBox();
            birthdayLabel = new Label();
            birthdayPicker = new DateTimePicker();
            addressPanel = new Panel();
            addressLabel = new Label();
            addressTableLayout = new TableLayoutPanel();
            streetLabel = new Label();
            streetTextBox = new TextBox();
            houseLabel = new Label();
            houseTextBox = new TextBox();
            apartmentLabel = new Label();
            apartmentTextBox = new TextBox();
            workDataPanel = new Panel();
            workDataLabel = new Label();
            workDataTableLayout = new TableLayoutPanel();
            timeWorkLabel = new Label();
            timeWorkNumeric = new NumericUpDown();
            positionLabel = new Label();
            positionComboBox = new ComboBox();
            classDriverLabel = new Label();
            classDriverNumeric = new NumericUpDown();
            bonusLabel = new Label();
            bonusNumeric = new NumericUpDown();
            buttonsPanel = new Panel();
            buttonsFlowLayout = new FlowLayoutPanel();
            cancelButton = new Button();
            applyButton = new Button();

            mainTableLayout.SuspendLayout();
            personalDataPanel.SuspendLayout();
            personalDataTableLayout.SuspendLayout();
            addressPanel.SuspendLayout();
            addressTableLayout.SuspendLayout();
            workDataPanel.SuspendLayout();
            workDataTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeWorkNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classDriverNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bonusNumeric).BeginInit();
            buttonsPanel.SuspendLayout();
            buttonsFlowLayout.SuspendLayout();
            SuspendLayout();

            // 
            // mainTableLayout
            // 
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.Controls.Add(personalDataPanel, 0, 0);
            mainTableLayout.Controls.Add(addressPanel, 0, 1);
            mainTableLayout.Controls.Add(workDataPanel, 0, 2);
            mainTableLayout.Controls.Add(buttonsPanel, 0, 3);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 4;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTableLayout.Size = new Size(800, 600);
            mainTableLayout.TabIndex = 0;

            // 
            // personalDataPanel
            // 
            personalDataPanel.Controls.Add(personalDataLabel);
            personalDataPanel.Controls.Add(personalDataTableLayout);
            personalDataPanel.Dock = DockStyle.Fill;
            personalDataPanel.Location = new Point(3, 3);
            personalDataPanel.Name = "personalDataPanel";
            personalDataPanel.Padding = new Padding(10);
            personalDataPanel.Size = new Size(794, 174);
            personalDataPanel.TabIndex = 0;

            // 
            // personalDataLabel
            // 
            personalDataLabel.AutoSize = true;
            personalDataLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            personalDataLabel.Location = new Point(10, 10);
            personalDataLabel.Name = "personalDataLabel";
            personalDataLabel.Size = new Size(124, 19);
            personalDataLabel.TabIndex = 0;
            personalDataLabel.Text = "Личные данные:";

            // 
            // personalDataTableLayout
            // 
            personalDataTableLayout.ColumnCount = 4;
            personalDataTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            personalDataTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            personalDataTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            personalDataTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            personalDataTableLayout.Controls.Add(surnameLabel, 0, 0);
            personalDataTableLayout.Controls.Add(surnameTextBox, 0, 1);
            personalDataTableLayout.Controls.Add(nameLabel, 1, 0);
            personalDataTableLayout.Controls.Add(nameTextBox, 1, 1);
            personalDataTableLayout.Controls.Add(patronymicLabel, 2, 0);
            personalDataTableLayout.Controls.Add(patronymicTextBox, 2, 1);
            personalDataTableLayout.Controls.Add(genderLabel, 3, 0);
            personalDataTableLayout.Controls.Add(genderComboBox, 3, 1);
            personalDataTableLayout.Controls.Add(birthdayLabel, 0, 2);
            personalDataTableLayout.Controls.Add(birthdayPicker, 0, 3);
            personalDataTableLayout.Dock = DockStyle.Bottom;
            personalDataTableLayout.Location = new Point(10, 40);
            personalDataTableLayout.Name = "personalDataTableLayout";
            personalDataTableLayout.RowCount = 4;
            personalDataTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            personalDataTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            personalDataTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            personalDataTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            personalDataTableLayout.Size = new Size(774, 124);
            personalDataTableLayout.TabIndex = 1;

            // 
            // surnameLabel
            // 
            surnameLabel.Anchor = AnchorStyles.Left;
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new Point(3, 5);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(61, 15);
            surnameLabel.TabIndex = 0;
            surnameLabel.Text = "Фамилия:";

            // 
            // surnameTextBox
            // 
            surnameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            surnameTextBox.Location = new Point(3, 28);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(187, 23);
            surnameTextBox.TabIndex = 1;

            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Left;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(196, 5);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(34, 15);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Имя:";

            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nameTextBox.Location = new Point(196, 28);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(187, 23);
            nameTextBox.TabIndex = 3;

            // 
            // patronymicLabel
            // 
            patronymicLabel.Anchor = AnchorStyles.Left;
            patronymicLabel.AutoSize = true;
            patronymicLabel.Location = new Point(389, 5);
            patronymicLabel.Name = "patronymicLabel";
            patronymicLabel.Size = new Size(61, 15);
            patronymicLabel.TabIndex = 4;
            patronymicLabel.Text = "Отчество:";

            // 
            // patronymicTextBox
            // 
            patronymicTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            patronymicTextBox.Location = new Point(389, 28);
            patronymicTextBox.Name = "patronymicTextBox";
            patronymicTextBox.Size = new Size(187, 23);
            patronymicTextBox.TabIndex = 5;

            // 
            // genderLabel
            // 
            genderLabel.Anchor = AnchorStyles.Left;
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(582, 5);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(33, 15);
            genderLabel.TabIndex = 6;
            genderLabel.Text = "Пол:";

            // 
            // genderComboBox
            // 
            genderComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            genderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Location = new Point(582, 28);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(189, 23);
            genderComboBox.TabIndex = 7;

            // 
            // birthdayLabel
            // 
            birthdayLabel.Anchor = AnchorStyles.Left;
            birthdayLabel.AutoSize = true;
            birthdayLabel.Location = new Point(3, 60);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new Size(93, 15);
            birthdayLabel.TabIndex = 8;
            birthdayLabel.Text = "Дата рождения:";

            // 
            // birthdayPicker
            // 
            birthdayPicker.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            birthdayPicker.Format = DateTimePickerFormat.Short;
            birthdayPicker.Location = new Point(3, 83);
            birthdayPicker.Name = "birthdayPicker";
            birthdayPicker.Size = new Size(187, 23);
            birthdayPicker.TabIndex = 9;

            // 
            // addressPanel
            // 
            addressPanel.Controls.Add(addressLabel);
            addressPanel.Controls.Add(addressTableLayout);
            addressPanel.Dock = DockStyle.Fill;
            addressPanel.Location = new Point(3, 183);
            addressPanel.Name = "addressPanel";
            addressPanel.Padding = new Padding(10);
            addressPanel.Size = new Size(794, 114);
            addressPanel.TabIndex = 1;

            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            addressLabel.Location = new Point(10, 10);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(149, 19);
            addressLabel.TabIndex = 0;
            addressLabel.Text = "Адрес проживания:";

            // 
            // addressTableLayout
            // 
            addressTableLayout.ColumnCount = 3;
            addressTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            addressTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            addressTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            addressTableLayout.Controls.Add(streetLabel, 0, 0);
            addressTableLayout.Controls.Add(streetTextBox, 0, 1);
            addressTableLayout.Controls.Add(houseLabel, 1, 0);
            addressTableLayout.Controls.Add(houseTextBox, 1, 1);
            addressTableLayout.Controls.Add(apartmentLabel, 2, 0);
            addressTableLayout.Controls.Add(apartmentTextBox, 2, 1);
            addressTableLayout.Dock = DockStyle.Bottom;
            addressTableLayout.Location = new Point(10, 40);
            addressTableLayout.Name = "addressTableLayout";
            addressTableLayout.RowCount = 2;
            addressTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            addressTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            addressTableLayout.Size = new Size(774, 64);
            addressTableLayout.TabIndex = 1;

            // 
            // streetLabel
            // 
            streetLabel.Anchor = AnchorStyles.Left;
            streetLabel.AutoSize = true;
            streetLabel.Location = new Point(3, 5);
            streetLabel.Name = "streetLabel";
            streetLabel.Size = new Size(46, 15);
            streetLabel.TabIndex = 0;
            streetLabel.Text = "Улица:";

            // 
            // streetTextBox
            // 
            streetTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            streetTextBox.Location = new Point(3, 28);
            streetTextBox.Name = "streetTextBox";
            streetTextBox.Size = new Size(303, 23);
            streetTextBox.TabIndex = 1;

            // 
            // houseLabel
            // 
            houseLabel.Anchor = AnchorStyles.Left;
            houseLabel.AutoSize = true;
            houseLabel.Location = new Point(312, 5);
            houseLabel.Name = "houseLabel";
            houseLabel.Size = new Size(35, 15);
            houseLabel.TabIndex = 2;
            houseLabel.Text = "Дом:";

            // 
            // houseTextBox
            // 
            houseTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            houseTextBox.Location = new Point(312, 28);
            houseTextBox.Name = "houseTextBox";
            houseTextBox.Size = new Size(226, 23);
            houseTextBox.TabIndex = 3;

            // 
            // apartmentLabel
            // 
            apartmentLabel.Anchor = AnchorStyles.Left;
            apartmentLabel.AutoSize = true;
            apartmentLabel.Location = new Point(544, 5);
            apartmentLabel.Name = "apartmentLabel";
            apartmentLabel.Size = new Size(60, 15);
            apartmentLabel.TabIndex = 4;
            apartmentLabel.Text = "Квартира:";

            // 
            // apartmentTextBox
            // 
            apartmentTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            apartmentTextBox.Location = new Point(544, 28);
            apartmentTextBox.Name = "apartmentTextBox";
            apartmentTextBox.Size = new Size(227, 23);
            apartmentTextBox.TabIndex = 5;

            // 
            // workDataPanel
            // 
            workDataPanel.Controls.Add(workDataLabel);
            workDataPanel.Controls.Add(workDataTableLayout);
            workDataPanel.Dock = DockStyle.Fill;
            workDataPanel.Location = new Point(3, 303);
            workDataPanel.Name = "workDataPanel";
            workDataPanel.Padding = new Padding(10);
            workDataPanel.Size = new Size(794, 174);
            workDataPanel.TabIndex = 2;

            // 
            // workDataLabel
            // 
            workDataLabel.AutoSize = true;
            workDataLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            workDataLabel.Location = new Point(10, 10);
            workDataLabel.Name = "workDataLabel";
            workDataLabel.Size = new Size(143, 19);
            workDataLabel.TabIndex = 0;
            workDataLabel.Text = "Рабочие данные:";

            // 
            // workDataTableLayout
            // 
            workDataTableLayout.ColumnCount = 4;
            workDataTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            workDataTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            workDataTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            workDataTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            workDataTableLayout.Controls.Add(timeWorkLabel, 0, 0);
            workDataTableLayout.Controls.Add(timeWorkNumeric, 0, 1);
            workDataTableLayout.Controls.Add(positionLabel, 1, 0);
            workDataTableLayout.Controls.Add(positionComboBox, 1, 1);
            workDataTableLayout.Controls.Add(classDriverLabel, 2, 0);
            workDataTableLayout.Controls.Add(classDriverNumeric, 2, 1);
            workDataTableLayout.Controls.Add(bonusLabel, 3, 0);
            workDataTableLayout.Controls.Add(bonusNumeric, 3, 1);
            workDataTableLayout.Dock = DockStyle.Bottom;
            workDataTableLayout.Location = new Point(10, 40);
            workDataTableLayout.Name = "workDataTableLayout";
            workDataTableLayout.RowCount = 2;
            workDataTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            workDataTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            workDataTableLayout.Size = new Size(774, 124);
            workDataTableLayout.TabIndex = 1;

            // 
            // timeWorkLabel
            // 
            timeWorkLabel.Anchor = AnchorStyles.Left;
            timeWorkLabel.AutoSize = true;
            timeWorkLabel.Location = new Point(3, 5);
            timeWorkLabel.Name = "timeWorkLabel";
            timeWorkLabel.Size = new Size(153, 15);
            timeWorkLabel.TabIndex = 0;
            timeWorkLabel.Text = "Трудовой стаж в компании:";

            // 
            // timeWorkNumeric
            // 
            timeWorkNumeric.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timeWorkNumeric.Location = new Point(3, 28);
            timeWorkNumeric.Maximum = new decimal(new int[] { 80, 0, 0, 0 });
            timeWorkNumeric.Name = "timeWorkNumeric";
            timeWorkNumeric.Size = new Size(187, 23);
            timeWorkNumeric.TabIndex = 1;

            // 
            // positionLabel
            // 
            positionLabel.Anchor = AnchorStyles.Left;
            positionLabel.AutoSize = true;
            positionLabel.Location = new Point(196, 5);
            positionLabel.Name = "positionLabel";
            positionLabel.Size = new Size(120, 15);
            positionLabel.TabIndex = 2;
            positionLabel.Text = "Должность в компании:";

            // 
            // positionComboBox
            // 
            positionComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            positionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            positionComboBox.FormattingEnabled = true;
            positionComboBox.Location = new Point(196, 28);
            positionComboBox.Name = "positionComboBox";
            positionComboBox.Size = new Size(187, 23);
            positionComboBox.TabIndex = 3;

            // 
            // classDriverLabel
            // 
            classDriverLabel.Anchor = AnchorStyles.Left;
            classDriverLabel.AutoSize = true;
            classDriverLabel.Location = new Point(389, 5);
            classDriverLabel.Name = "classDriverLabel";
            classDriverLabel.Size = new Size(99, 15);
            classDriverLabel.TabIndex = 4;
            classDriverLabel.Text = "Класс водителя:";

            // 
            // classDriverNumeric
            // 
            classDriverNumeric.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            classDriverNumeric.Location = new Point(389, 28);
            classDriverNumeric.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            classDriverNumeric.Name = "classDriverNumeric";
            classDriverNumeric.Size = new Size(187, 23);
            classDriverNumeric.TabIndex = 5;

            // 
            // bonusLabel
            // 
            bonusLabel.Anchor = AnchorStyles.Left;
            bonusLabel.AutoSize = true;
            bonusLabel.Location = new Point(582, 5);
            bonusLabel.Name = "bonusLabel";
            bonusLabel.Size = new Size(53, 15);
            bonusLabel.TabIndex = 6;
            bonusLabel.Text = "Премия:";

            // 
            // bonusNumeric
            // 
            bonusNumeric.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bonusNumeric.DecimalPlaces = 2;
            bonusNumeric.Location = new Point(582, 28);
            bonusNumeric.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            bonusNumeric.Name = "bonusNumeric";
            bonusNumeric.Size = new Size(189, 23);
            bonusNumeric.TabIndex = 7;

            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(buttonsFlowLayout);
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.Location = new Point(3, 483);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(10);
            buttonsPanel.Size = new Size(794, 114);
            buttonsPanel.TabIndex = 3;

            // 
            // buttonsFlowLayout
            // 
            buttonsFlowLayout.AutoSize = true;
            buttonsFlowLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonsFlowLayout.Controls.Add(cancelButton);
            buttonsFlowLayout.Controls.Add(applyButton);
            buttonsFlowLayout.Dock = DockStyle.Fill;
            buttonsFlowLayout.FlowDirection = FlowDirection.RightToLeft;
            buttonsFlowLayout.Location = new Point(10, 10);
            buttonsFlowLayout.Name = "buttonsFlowLayout";
            buttonsFlowLayout.Size = new Size(774, 94);
            buttonsFlowLayout.TabIndex = 0;

            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.AutoSize = true;
            cancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cancelButton.Location = new Point(691, 3);
            cancelButton.MinimumSize = new Size(80, 35);
            cancelButton.Name = "cancelButton";
            cancelButton.Padding = new Padding(10, 5, 10, 5);
            cancelButton.Size = new Size(80, 35);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;

            // 
            // applyButton
            // 
            applyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            applyButton.AutoSize = true;
            applyButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            applyButton.Location = new Point(585, 3);
            applyButton.MinimumSize = new Size(80, 35);
            applyButton.Name = "applyButton";
            applyButton.Padding = new Padding(10, 5, 10, 5);
            applyButton.Size = new Size(100, 35);
            applyButton.TabIndex = 0;
            applyButton.Text = "Применить";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += ApplyButton_Click;

            // 
            // EmployeeEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(mainTableLayout);
            MinimumSize = new Size(816, 639);
            Name = "EmployeeEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Сотрудник";
            mainTableLayout.ResumeLayout(false);
            personalDataPanel.ResumeLayout(false);
            personalDataPanel.PerformLayout();
            personalDataTableLayout.ResumeLayout(false);
            personalDataTableLayout.PerformLayout();
            addressPanel.ResumeLayout(false);
            addressPanel.PerformLayout();
            addressTableLayout.ResumeLayout(false);
            addressTableLayout.PerformLayout();
            workDataPanel.ResumeLayout(false);
            workDataPanel.PerformLayout();
            workDataTableLayout.ResumeLayout(false);
            workDataTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeWorkNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)classDriverNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)bonusNumeric).EndInit();
            buttonsPanel.ResumeLayout(false);
            buttonsPanel.PerformLayout();
            buttonsFlowLayout.ResumeLayout(false);
            buttonsFlowLayout.PerformLayout();
            ResumeLayout(false);
        }
    }
}