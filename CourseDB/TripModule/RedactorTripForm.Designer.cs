namespace TripModule
{
    partial class RedactorTripForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Panel upperPanel;
        private Panel lowerPanel;
        private Panel bottomButtonPanel;
        private TableLayoutPanel upperTableLayout;
        private Label lblRoute;
        private ComboBox routeComboBox;
        private Label lblDepartureDate;
        private DateTimePicker dateDepartureDate;
        private Label lblDepartureTime;
        private DateTimePicker timeDepartureTime;
        private Label lblBus;
        private TextBox txtBus;
        private Button btnSelectBus;
        private Label lblDriver;
        private TextBox txtDriver;
        private Button btnSelectDriver;
        private Label lblConductor;
        private TextBox txtConductor;
        private Button btnSelectConductor;
        private Label lblDirection;
        private RadioButton rbDirectDirection;
        private RadioButton rbReturnDirection;
        private GroupBox gbDirection;
        private Panel scheduleControlPanel;
        private TableLayoutPanel scheduleControlLayout;
        private Label lblArrivalTime;
        private DateTimePicker timeArrivalTime;
        private Label lblRemovalTime;
        private CheckBox chkHasRemovalTime;
        private DateTimePicker timeRemovalTime;
        private Label lblRemovalReason;
        private TextBox txtRemovalReason;
        private Label lblTripCount;
        private TextBox txtTripCount;
        private Button btnAddSchedule;
        private Button btnRemoveSchedule;
        private DataGridView scheduleDataGridView;
        private Button btnSave;
        private Button btnCancel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedactorTripForm));
            mainLayout = new TableLayoutPanel();
            upperPanel = new Panel();
            upperTableLayout = new TableLayoutPanel();
            lblRoute = new Label();
            routeComboBox = new ComboBox();
            lblDepartureDate = new Label();
            dateDepartureDate = new DateTimePicker();
            lblDepartureTime = new Label();
            timeDepartureTime = new DateTimePicker();
            lblBus = new Label();
            txtBus = new TextBox();
            btnSelectBus = new Button();
            lblDriver = new Label();
            txtDriver = new TextBox();
            btnSelectDriver = new Button();
            lblConductor = new Label();
            txtConductor = new TextBox();
            btnSelectConductor = new Button();
            lblDirection = new Label();
            gbDirection = new GroupBox();
            rbReturnDirection = new RadioButton();
            rbDirectDirection = new RadioButton();
            lowerPanel = new Panel();
            scheduleDataGridView = new DataGridView();
            scheduleControlPanel = new Panel();
            scheduleControlLayout = new TableLayoutPanel();
            lblTripCount = new Label();
            txtTripCount = new TextBox();
            txtRemovalReason = new TextBox();
            lblRemovalTime = new Label();
            timeRemovalTime = new DateTimePicker();
            timeArrivalTime = new DateTimePicker();
            lblArrivalTime = new Label();
            lblRemovalReason = new Label();
            btnRemoveSchedule = new Button();
            btnAddSchedule = new Button();
            chkHasRemovalTime = new CheckBox();
            bottomButtonPanel = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            mainLayout.SuspendLayout();
            upperPanel.SuspendLayout();
            upperTableLayout.SuspendLayout();
            gbDirection.SuspendLayout();
            lowerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scheduleDataGridView).BeginInit();
            scheduleControlPanel.SuspendLayout();
            scheduleControlLayout.SuspendLayout();
            bottomButtonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(upperPanel, 0, 0);
            mainLayout.Controls.Add(lowerPanel, 0, 1);
            mainLayout.Controls.Add(bottomButtonPanel, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            mainLayout.Size = new Size(1000, 700);
            mainLayout.TabIndex = 0;
            // 
            // upperPanel
            // 
            upperPanel.Controls.Add(upperTableLayout);
            upperPanel.Dock = DockStyle.Fill;
            upperPanel.Location = new Point(3, 3);
            upperPanel.Name = "upperPanel";
            upperPanel.Padding = new Padding(10);
            upperPanel.Size = new Size(994, 274);
            upperPanel.TabIndex = 0;
            // 
            // upperTableLayout
            // 
            upperTableLayout.ColumnCount = 4;
            upperTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            upperTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            upperTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            upperTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            upperTableLayout.Controls.Add(lblRoute, 0, 0);
            upperTableLayout.Controls.Add(routeComboBox, 1, 0);
            upperTableLayout.Controls.Add(lblDepartureDate, 0, 1);
            upperTableLayout.Controls.Add(dateDepartureDate, 1, 1);
            upperTableLayout.Controls.Add(lblDepartureTime, 2, 1);
            upperTableLayout.Controls.Add(timeDepartureTime, 3, 1);
            upperTableLayout.Controls.Add(lblBus, 0, 2);
            upperTableLayout.Controls.Add(txtBus, 1, 2);
            upperTableLayout.Controls.Add(btnSelectBus, 3, 2);
            upperTableLayout.Controls.Add(lblDriver, 0, 3);
            upperTableLayout.Controls.Add(txtDriver, 1, 3);
            upperTableLayout.Controls.Add(btnSelectDriver, 3, 3);
            upperTableLayout.Controls.Add(lblConductor, 0, 4);
            upperTableLayout.Controls.Add(txtConductor, 1, 4);
            upperTableLayout.Controls.Add(btnSelectConductor, 3, 4);
            upperTableLayout.Controls.Add(lblDirection, 0, 5);
            upperTableLayout.Controls.Add(gbDirection, 1, 5);
            upperTableLayout.Dock = DockStyle.Fill;
            upperTableLayout.Location = new Point(10, 10);
            upperTableLayout.Name = "upperTableLayout";
            upperTableLayout.RowCount = 6;
            upperTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            upperTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            upperTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            upperTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            upperTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            upperTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            upperTableLayout.Size = new Size(974, 254);
            upperTableLayout.TabIndex = 0;
            // 
            // lblRoute
            // 
            lblRoute.Anchor = AnchorStyles.Left;
            lblRoute.AutoSize = true;
            lblRoute.Location = new Point(3, 12);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(108, 15);
            lblRoute.TabIndex = 0;
            lblRoute.Text = "Номер маршрута:";
            // 
            // routeComboBox
            // 
            routeComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            routeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            routeComboBox.FormattingEnabled = true;
            routeComboBox.Location = new Point(153, 8);
            routeComboBox.Name = "routeComboBox";
            routeComboBox.Size = new Size(263, 23);
            routeComboBox.TabIndex = 1;
            // 
            // lblDepartureDate
            // 
            lblDepartureDate.Anchor = AnchorStyles.Left;
            lblDepartureDate.AutoSize = true;
            lblDepartureDate.Location = new Point(3, 52);
            lblDepartureDate.Name = "lblDepartureDate";
            lblDepartureDate.Size = new Size(76, 15);
            lblDepartureDate.TabIndex = 2;
            lblDepartureDate.Text = "Дата выезда:";
            // 
            // dateDepartureDate
            // 
            dateDepartureDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dateDepartureDate.Format = DateTimePickerFormat.Short;
            dateDepartureDate.Location = new Point(153, 48);
            dateDepartureDate.Name = "dateDepartureDate";
            dateDepartureDate.Size = new Size(263, 23);
            dateDepartureDate.TabIndex = 3;
            // 
            // lblDepartureTime
            // 
            lblDepartureTime.Anchor = AnchorStyles.Left;
            lblDepartureTime.AutoSize = true;
            lblDepartureTime.Location = new Point(422, 52);
            lblDepartureTime.Name = "lblDepartureTime";
            lblDepartureTime.Size = new Size(86, 15);
            lblDepartureTime.TabIndex = 4;
            lblDepartureTime.Text = "Время выезда:";
            // 
            // timeDepartureTime
            // 
            timeDepartureTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timeDepartureTime.CustomFormat = "HH:mm";
            timeDepartureTime.Format = DateTimePickerFormat.Custom;
            timeDepartureTime.Location = new Point(572, 48);
            timeDepartureTime.Name = "timeDepartureTime";
            timeDepartureTime.ShowUpDown = true;
            timeDepartureTime.Size = new Size(399, 23);
            timeDepartureTime.TabIndex = 5;
            // 
            // lblBus
            // 
            lblBus.Anchor = AnchorStyles.Left;
            lblBus.AutoSize = true;
            lblBus.Location = new Point(3, 92);
            lblBus.Name = "lblBus";
            lblBus.Size = new Size(55, 15);
            lblBus.TabIndex = 6;
            lblBus.Text = "Автобус:";
            // 
            // txtBus
            // 
            txtBus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBus.Location = new Point(153, 88);
            txtBus.Name = "txtBus";
            txtBus.ReadOnly = true;
            txtBus.Size = new Size(263, 23);
            txtBus.TabIndex = 7;
            // 
            // btnSelectBus
            // 
            btnSelectBus.Anchor = AnchorStyles.Left;
            btnSelectBus.Location = new Point(572, 88);
            btnSelectBus.Name = "btnSelectBus";
            btnSelectBus.Size = new Size(100, 23);
            btnSelectBus.TabIndex = 8;
            btnSelectBus.Text = "Выбрать";
            btnSelectBus.UseVisualStyleBackColor = true;
            btnSelectBus.Click += btnSelectBus_Click;
            // 
            // lblDriver
            // 
            lblDriver.Anchor = AnchorStyles.Left;
            lblDriver.AutoSize = true;
            lblDriver.Location = new Point(3, 132);
            lblDriver.Name = "lblDriver";
            lblDriver.Size = new Size(61, 15);
            lblDriver.TabIndex = 9;
            lblDriver.Text = "Водитель:";
            // 
            // txtDriver
            // 
            txtDriver.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDriver.Location = new Point(153, 128);
            txtDriver.Name = "txtDriver";
            txtDriver.ReadOnly = true;
            txtDriver.Size = new Size(263, 23);
            txtDriver.TabIndex = 10;
            // 
            // btnSelectDriver
            // 
            btnSelectDriver.Anchor = AnchorStyles.Left;
            btnSelectDriver.Location = new Point(572, 128);
            btnSelectDriver.Name = "btnSelectDriver";
            btnSelectDriver.Size = new Size(100, 23);
            btnSelectDriver.TabIndex = 11;
            btnSelectDriver.Text = "Выбрать";
            btnSelectDriver.UseVisualStyleBackColor = true;
            btnSelectDriver.Click += btnSelectDriver_Click;
            // 
            // lblConductor
            // 
            lblConductor.Anchor = AnchorStyles.Left;
            lblConductor.AutoSize = true;
            lblConductor.Location = new Point(3, 172);
            lblConductor.Name = "lblConductor";
            lblConductor.Size = new Size(68, 15);
            lblConductor.TabIndex = 12;
            lblConductor.Text = "Кондуктор:";
            // 
            // txtConductor
            // 
            txtConductor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtConductor.Location = new Point(153, 168);
            txtConductor.Name = "txtConductor";
            txtConductor.ReadOnly = true;
            txtConductor.Size = new Size(263, 23);
            txtConductor.TabIndex = 13;
            // 
            // btnSelectConductor
            // 
            btnSelectConductor.Anchor = AnchorStyles.Left;
            btnSelectConductor.Location = new Point(572, 168);
            btnSelectConductor.Name = "btnSelectConductor";
            btnSelectConductor.Size = new Size(100, 23);
            btnSelectConductor.TabIndex = 14;
            btnSelectConductor.Text = "Выбрать";
            btnSelectConductor.UseVisualStyleBackColor = true;
            btnSelectConductor.Click += btnSelectConductor_Click;
            // 
            // lblDirection
            // 
            lblDirection.Anchor = AnchorStyles.Left;
            lblDirection.AutoSize = true;
            lblDirection.Location = new Point(3, 219);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(119, 15);
            lblDirection.TabIndex = 15;
            lblDirection.Text = "Направление рейса:";
            // 
            // gbDirection
            // 
            gbDirection.Anchor = AnchorStyles.Left;
            gbDirection.Controls.Add(rbReturnDirection);
            gbDirection.Controls.Add(rbDirectDirection);
            gbDirection.Location = new Point(153, 203);
            gbDirection.Name = "gbDirection";
            gbDirection.Size = new Size(150, 48);
            gbDirection.TabIndex = 18;
            gbDirection.TabStop = false;
            // 
            // rbReturnDirection
            // 
            rbReturnDirection.AutoSize = true;
            rbReturnDirection.Location = new Point(3, 28);
            rbReturnDirection.Name = "rbReturnDirection";
            rbReturnDirection.Size = new Size(82, 19);
            rbReturnDirection.TabIndex = 17;
            rbReturnDirection.Text = "Обратный";
            rbReturnDirection.UseVisualStyleBackColor = true;
            // 
            // rbDirectDirection
            // 
            rbDirectDirection.AutoSize = true;
            rbDirectDirection.Checked = true;
            rbDirectDirection.Location = new Point(3, 3);
            rbDirectDirection.Name = "rbDirectDirection";
            rbDirectDirection.Size = new Size(70, 19);
            rbDirectDirection.TabIndex = 16;
            rbDirectDirection.TabStop = true;
            rbDirectDirection.Text = "Прямой";
            rbDirectDirection.UseVisualStyleBackColor = true;
            // 
            // lowerPanel
            // 
            lowerPanel.Controls.Add(scheduleDataGridView);
            lowerPanel.Controls.Add(scheduleControlPanel);
            lowerPanel.Dock = DockStyle.Fill;
            lowerPanel.Location = new Point(3, 283);
            lowerPanel.Name = "lowerPanel";
            lowerPanel.Padding = new Padding(10);
            lowerPanel.Size = new Size(994, 344);
            lowerPanel.TabIndex = 1;
            // 
            // scheduleDataGridView
            // 
            scheduleDataGridView.AllowUserToAddRows = false;
            scheduleDataGridView.AllowUserToDeleteRows = false;
            scheduleDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            scheduleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            scheduleDataGridView.Dock = DockStyle.Fill;
            scheduleDataGridView.Location = new Point(10, 130);
            scheduleDataGridView.Name = "scheduleDataGridView";
            scheduleDataGridView.ReadOnly = true;
            scheduleDataGridView.RowHeadersVisible = false;
            scheduleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            scheduleDataGridView.Size = new Size(974, 204);
            scheduleDataGridView.TabIndex = 1;
            // 
            // scheduleControlPanel
            // 
            scheduleControlPanel.Controls.Add(scheduleControlLayout);
            scheduleControlPanel.Dock = DockStyle.Top;
            scheduleControlPanel.Location = new Point(10, 10);
            scheduleControlPanel.Name = "scheduleControlPanel";
            scheduleControlPanel.Size = new Size(974, 120);
            scheduleControlPanel.TabIndex = 0;
            // 
            // scheduleControlLayout
            // 
            scheduleControlLayout.ColumnCount = 7;
            scheduleControlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            scheduleControlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            scheduleControlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            scheduleControlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            scheduleControlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            scheduleControlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            scheduleControlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            scheduleControlLayout.Controls.Add(lblTripCount, 0, 2);
            scheduleControlLayout.Controls.Add(txtTripCount, 1, 2);
            scheduleControlLayout.Controls.Add(txtRemovalReason, 5, 1);
            scheduleControlLayout.Controls.Add(lblRemovalTime, 2, 1);
            scheduleControlLayout.Controls.Add(timeRemovalTime, 3, 1);
            scheduleControlLayout.Controls.Add(timeArrivalTime, 1, 1);
            scheduleControlLayout.Controls.Add(lblArrivalTime, 0, 1);
            scheduleControlLayout.Controls.Add(lblRemovalReason, 4, 1);
            scheduleControlLayout.Controls.Add(btnRemoveSchedule, 6, 2);
            scheduleControlLayout.Controls.Add(btnAddSchedule, 6, 1);
            scheduleControlLayout.Controls.Add(chkHasRemovalTime, 3, 0);
            scheduleControlLayout.Dock = DockStyle.Fill;
            scheduleControlLayout.Location = new Point(0, 0);
            scheduleControlLayout.Name = "scheduleControlLayout";
            scheduleControlLayout.RowCount = 3;
            scheduleControlLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            scheduleControlLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            scheduleControlLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            scheduleControlLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            scheduleControlLayout.Size = new Size(974, 120);
            scheduleControlLayout.TabIndex = 0;
            // 
            // lblTripCount
            // 
            lblTripCount.Anchor = AnchorStyles.Left;
            lblTripCount.AutoSize = true;
            lblTripCount.Location = new Point(3, 91);
            lblTripCount.Name = "lblTripCount";
            lblTripCount.Size = new Size(78, 15);
            lblTripCount.TabIndex = 6;
            lblTripCount.Text = "Число ездок:";
            // 
            // txtTripCount
            // 
            txtTripCount.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTripCount.Location = new Point(163, 87);
            txtTripCount.Name = "txtTripCount";
            txtTripCount.Size = new Size(72, 23);
            txtTripCount.TabIndex = 7;
            txtTripCount.Text = "1";
            // 
            // txtRemovalReason
            // 
            txtRemovalReason.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRemovalReason.Location = new Point(639, 42);
            txtRemovalReason.Name = "txtRemovalReason";
            scheduleControlLayout.SetRowSpan(txtRemovalReason, 2);
            txtRemovalReason.Size = new Size(230, 23);
            txtRemovalReason.TabIndex = 5;
            // 
            // lblRemovalTime
            // 
            lblRemovalTime.Anchor = AnchorStyles.Left;
            lblRemovalTime.AutoSize = true;
            lblRemovalTime.Location = new Point(241, 51);
            lblRemovalTime.Name = "lblRemovalTime";
            lblRemovalTime.Size = new Size(137, 15);
            lblRemovalTime.TabIndex = 2;
            lblRemovalTime.Text = "Время снятия (ЧЧ:ММ):";
            // 
            // timeRemovalTime
            // 
            timeRemovalTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timeRemovalTime.CustomFormat = "HH:mm";
            timeRemovalTime.Enabled = false;
            timeRemovalTime.Format = DateTimePickerFormat.Custom;
            timeRemovalTime.Location = new Point(401, 47);
            timeRemovalTime.Name = "timeRemovalTime";
            timeRemovalTime.ShowUpDown = true;
            timeRemovalTime.Size = new Size(72, 23);
            timeRemovalTime.TabIndex = 3;
            // 
            // timeArrivalTime
            // 
            timeArrivalTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timeArrivalTime.CustomFormat = "HH:mm";
            timeArrivalTime.Format = DateTimePickerFormat.Custom;
            timeArrivalTime.Location = new Point(163, 47);
            timeArrivalTime.Name = "timeArrivalTime";
            timeArrivalTime.ShowUpDown = true;
            timeArrivalTime.Size = new Size(72, 23);
            timeArrivalTime.TabIndex = 1;
            // 
            // lblArrivalTime
            // 
            lblArrivalTime.Anchor = AnchorStyles.Left;
            lblArrivalTime.AutoSize = true;
            lblArrivalTime.Location = new Point(3, 43);
            lblArrivalTime.Name = "lblArrivalTime";
            lblArrivalTime.Size = new Size(103, 30);
            lblArrivalTime.TabIndex = 0;
            lblArrivalTime.Text = "Время прибытия (ЧЧ:ММ):";
            // 
            // lblRemovalReason
            // 
            lblRemovalReason.Anchor = AnchorStyles.Left;
            lblRemovalReason.AutoSize = true;
            lblRemovalReason.Location = new Point(479, 43);
            lblRemovalReason.Name = "lblRemovalReason";
            lblRemovalReason.Size = new Size(109, 30);
            lblRemovalReason.TabIndex = 4;
            lblRemovalReason.Text = "Причина снятия с маршрута:";
            // 
            // btnRemoveSchedule
            // 
            btnRemoveSchedule.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnRemoveSchedule.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnRemoveSchedule.Location = new Point(875, 82);
            btnRemoveSchedule.Name = "btnRemoveSchedule";
            btnRemoveSchedule.Size = new Size(96, 33);
            btnRemoveSchedule.TabIndex = 9;
            btnRemoveSchedule.Text = "-";
            btnRemoveSchedule.UseVisualStyleBackColor = true;
            btnRemoveSchedule.Click += btnRemoveSchedule_Click;
            // 
            // btnAddSchedule
            // 
            btnAddSchedule.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnAddSchedule.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddSchedule.Location = new Point(875, 42);
            btnAddSchedule.Name = "btnAddSchedule";
            btnAddSchedule.Size = new Size(96, 33);
            btnAddSchedule.TabIndex = 8;
            btnAddSchedule.Text = "+ Добавить";
            btnAddSchedule.UseVisualStyleBackColor = true;
            btnAddSchedule.Click += btnAddSchedule_Click;
            // 
            // chkHasRemovalTime
            // 
            chkHasRemovalTime.Anchor = AnchorStyles.Left;
            chkHasRemovalTime.AutoSize = true;
            chkHasRemovalTime.Location = new Point(401, 10);
            chkHasRemovalTime.Name = "chkHasRemovalTime";
            chkHasRemovalTime.Size = new Size(67, 19);
            chkHasRemovalTime.TabIndex = 10;
            chkHasRemovalTime.Text = "Указать";
            chkHasRemovalTime.UseVisualStyleBackColor = true;
            chkHasRemovalTime.CheckedChanged += chkHasRemovalTime_CheckedChanged;
            // 
            // bottomButtonPanel
            // 
            bottomButtonPanel.Controls.Add(btnCancel);
            bottomButtonPanel.Controls.Add(btnSave);
            bottomButtonPanel.Dock = DockStyle.Fill;
            bottomButtonPanel.Location = new Point(3, 633);
            bottomButtonPanel.Name = "bottomButtonPanel";
            bottomButtonPanel.Padding = new Padding(10);
            bottomButtonPanel.Size = new Size(994, 64);
            bottomButtonPanel.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.Location = new Point(890, 20);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 35);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Выйти";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Right;
            btnSave.Location = new Point(794, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 35);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // RedactorTripForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(mainLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1016, 739);
            Name = "RedactorTripForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактор рейса";
            mainLayout.ResumeLayout(false);
            upperPanel.ResumeLayout(false);
            upperTableLayout.ResumeLayout(false);
            upperTableLayout.PerformLayout();
            gbDirection.ResumeLayout(false);
            gbDirection.PerformLayout();
            lowerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scheduleDataGridView).EndInit();
            scheduleControlPanel.ResumeLayout(false);
            scheduleControlLayout.ResumeLayout(false);
            scheduleControlLayout.PerformLayout();
            bottomButtonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}