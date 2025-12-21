namespace GuideModule
{
    partial class RoutEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoutEditForm));
            mainTableLayout = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            leftPanel = new Panel();
            tableLayoutPanelLeft = new TableLayoutPanel();
            labelName = new Label();
            textBoxName = new TextBox();
            labelTimeRoute = new Label();
            panelTimeRoute = new Panel();
            numericHoursTimeRoute = new NumericUpDown();
            labelHoursTimeRoute = new Label();
            numericMinutesTimeRoute = new NumericUpDown();
            labelMinutesTimeRoute = new Label();
            labelDistance = new Label();
            numericDistance = new NumericUpDown();
            labelRevenue = new Label();
            numericRevenue = new NumericUpDown();
            labelStartTimeDirect = new Label();
            timePickerStartDirect = new DateTimePicker();
            labelEndTimeDirect = new Label();
            timePickerEndDirect = new DateTimePicker();
            labelStartTimeReverse = new Label();
            timePickerStartReverse = new DateTimePicker();
            labelEndTimeReverse = new Label();
            timePickerEndReverse = new DateTimePicker();
            rightPanel = new Panel();
            tableLayoutPanelRight = new TableLayoutPanel();
            groupBoxSchedule = new GroupBox();
            tableLayoutPanelSchedule = new TableLayoutPanel();
            panelScheduleControls = new Panel();
            labelFromHour = new Label();
            numericFromHour = new NumericUpDown();
            labelToHour = new Label();
            numericToHour = new NumericUpDown();
            labelInterval = new Label();
            numericInterval = new NumericUpDown();
            buttonAddSchedule = new Button();
            buttonRemoveSchedule = new Button();
            dataGridViewSchedule = new DataGridView();
            colScheduleNumber = new DataGridViewTextBoxColumn();
            colScheduleStartHour = new DataGridViewTextBoxColumn();
            colScheduleEndHour = new DataGridViewTextBoxColumn();
            colScheduleInterval = new DataGridViewTextBoxColumn();
            groupBoxStations = new GroupBox();
            tableLayoutPanelStations = new TableLayoutPanel();
            panelStationsControls = new Panel();
            comboBoxStations = new ComboBox();
            buttonAddStation = new Button();
            buttonRemoveStation = new Button();
            buttonMoveUp = new Button();
            buttonMoveDown = new Button();
            dataGridViewStations = new DataGridView();
            colStationNumber = new DataGridViewTextBoxColumn();
            colStationName = new DataGridViewTextBoxColumn();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonApply = new Button();
            mainTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            leftPanel.SuspendLayout();
            tableLayoutPanelLeft.SuspendLayout();
            panelTimeRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericHoursTimeRoute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMinutesTimeRoute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericRevenue).BeginInit();
            rightPanel.SuspendLayout();
            tableLayoutPanelRight.SuspendLayout();
            groupBoxSchedule.SuspendLayout();
            tableLayoutPanelSchedule.SuspendLayout();
            panelScheduleControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericFromHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericToHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedule).BeginInit();
            groupBoxStations.SuspendLayout();
            tableLayoutPanelStations.SuspendLayout();
            panelStationsControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStations).BeginInit();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.Controls.Add(splitContainer1, 0, 0);
            mainTableLayout.Controls.Add(flowLayoutPanelButtons, 0, 1);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 2;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainTableLayout.Size = new Size(1000, 700);
            mainTableLayout.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(leftPanel);
            splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(rightPanel);
            splitContainer1.Panel2MinSize = 400;
            splitContainer1.Size = new Size(994, 634);
            splitContainer1.SplitterDistance = 497;
            splitContainer1.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(tableLayoutPanelLeft);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(10);
            leftPanel.Size = new Size(497, 634);
            leftPanel.TabIndex = 0;
            // 
            // tableLayoutPanelLeft
            // 
            tableLayoutPanelLeft.ColumnCount = 2;
            tableLayoutPanelLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelLeft.Controls.Add(labelName, 0, 0);
            tableLayoutPanelLeft.Controls.Add(textBoxName, 1, 0);
            tableLayoutPanelLeft.Controls.Add(labelTimeRoute, 0, 1);
            tableLayoutPanelLeft.Controls.Add(panelTimeRoute, 1, 1);
            tableLayoutPanelLeft.Controls.Add(labelDistance, 0, 2);
            tableLayoutPanelLeft.Controls.Add(numericDistance, 1, 2);
            tableLayoutPanelLeft.Controls.Add(labelRevenue, 0, 3);
            tableLayoutPanelLeft.Controls.Add(numericRevenue, 1, 3);
            tableLayoutPanelLeft.Controls.Add(labelStartTimeDirect, 0, 4);
            tableLayoutPanelLeft.Controls.Add(timePickerStartDirect, 1, 4);
            tableLayoutPanelLeft.Controls.Add(labelEndTimeDirect, 0, 5);
            tableLayoutPanelLeft.Controls.Add(timePickerEndDirect, 1, 5);
            tableLayoutPanelLeft.Controls.Add(labelStartTimeReverse, 0, 6);
            tableLayoutPanelLeft.Controls.Add(timePickerStartReverse, 1, 6);
            tableLayoutPanelLeft.Controls.Add(labelEndTimeReverse, 0, 7);
            tableLayoutPanelLeft.Controls.Add(timePickerEndReverse, 1, 7);
            tableLayoutPanelLeft.Dock = DockStyle.Fill;
            tableLayoutPanelLeft.Location = new Point(10, 10);
            tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            tableLayoutPanelLeft.RowCount = 9;
            tableLayoutPanelLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelLeft.Size = new Size(477, 614);
            tableLayoutPanelLeft.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.Anchor = AnchorStyles.Right;
            labelName.AutoSize = true;
            labelName.Location = new Point(106, 12);
            labelName.Margin = new Padding(3, 0, 10, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(122, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Название маршрута:";
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.Location = new Point(241, 8);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(233, 23);
            textBoxName.TabIndex = 1;
            // 
            // labelTimeRoute
            // 
            labelTimeRoute.Anchor = AnchorStyles.Right;
            labelTimeRoute.AutoSize = true;
            labelTimeRoute.Location = new Point(116, 52);
            labelTimeRoute.Margin = new Padding(3, 0, 10, 0);
            labelTimeRoute.Name = "labelTimeRoute";
            labelTimeRoute.Size = new Size(112, 15);
            labelTimeRoute.TabIndex = 2;
            labelTimeRoute.Text = "Время оборота (ч):";
            // 
            // panelTimeRoute
            // 
            panelTimeRoute.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panelTimeRoute.Controls.Add(numericHoursTimeRoute);
            panelTimeRoute.Controls.Add(labelHoursTimeRoute);
            panelTimeRoute.Controls.Add(numericMinutesTimeRoute);
            panelTimeRoute.Controls.Add(labelMinutesTimeRoute);
            panelTimeRoute.Location = new Point(241, 48);
            panelTimeRoute.Name = "panelTimeRoute";
            panelTimeRoute.Size = new Size(233, 23);
            panelTimeRoute.TabIndex = 3;
            // 
            // numericHoursTimeRoute
            // 
            numericHoursTimeRoute.Location = new Point(0, 0);
            numericHoursTimeRoute.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            numericHoursTimeRoute.Name = "numericHoursTimeRoute";
            numericHoursTimeRoute.Size = new Size(60, 23);
            numericHoursTimeRoute.TabIndex = 0;
            // 
            // labelHoursTimeRoute
            // 
            labelHoursTimeRoute.AutoSize = true;
            labelHoursTimeRoute.Location = new Point(66, 3);
            labelHoursTimeRoute.Name = "labelHoursTimeRoute";
            labelHoursTimeRoute.Size = new Size(17, 15);
            labelHoursTimeRoute.TabIndex = 1;
            labelHoursTimeRoute.Text = "ч.";
            // 
            // numericMinutesTimeRoute
            // 
            numericMinutesTimeRoute.Location = new Point(89, 0);
            numericMinutesTimeRoute.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            numericMinutesTimeRoute.Name = "numericMinutesTimeRoute";
            numericMinutesTimeRoute.Size = new Size(60, 23);
            numericMinutesTimeRoute.TabIndex = 2;
            // 
            // labelMinutesTimeRoute
            // 
            labelMinutesTimeRoute.AutoSize = true;
            labelMinutesTimeRoute.Location = new Point(155, 3);
            labelMinutesTimeRoute.Name = "labelMinutesTimeRoute";
            labelMinutesTimeRoute.Size = new Size(33, 15);
            labelMinutesTimeRoute.TabIndex = 3;
            labelMinutesTimeRoute.Text = "мин.";
            // 
            // labelDistance
            // 
            labelDistance.Anchor = AnchorStyles.Right;
            labelDistance.AutoSize = true;
            labelDistance.Location = new Point(155, 92);
            labelDistance.Margin = new Padding(3, 0, 10, 0);
            labelDistance.Name = "labelDistance";
            labelDistance.Size = new Size(73, 15);
            labelDistance.TabIndex = 4;
            labelDistance.Text = "Расстояние:";
            // 
            // numericDistance
            // 
            numericDistance.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericDistance.Location = new Point(241, 88);
            numericDistance.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericDistance.Name = "numericDistance";
            numericDistance.Size = new Size(233, 23);
            numericDistance.TabIndex = 5;
            // 
            // labelRevenue
            // 
            labelRevenue.Anchor = AnchorStyles.Right;
            labelRevenue.AutoSize = true;
            labelRevenue.Location = new Point(114, 132);
            labelRevenue.Margin = new Padding(3, 0, 10, 0);
            labelRevenue.Name = "labelRevenue";
            labelRevenue.Size = new Size(114, 15);
            labelRevenue.TabIndex = 6;
            labelRevenue.Text = "Плановая выручка:";
            // 
            // numericRevenue
            // 
            numericRevenue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericRevenue.DecimalPlaces = 2;
            numericRevenue.Location = new Point(241, 128);
            numericRevenue.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericRevenue.Name = "numericRevenue";
            numericRevenue.Size = new Size(233, 23);
            numericRevenue.TabIndex = 7;
            // 
            // labelStartTimeDirect
            // 
            labelStartTimeDirect.Anchor = AnchorStyles.Right;
            labelStartTimeDirect.AutoSize = true;
            labelStartTimeDirect.Location = new Point(35, 172);
            labelStartTimeDirect.Margin = new Padding(3, 0, 10, 0);
            labelStartTimeDirect.Name = "labelStartTimeDirect";
            labelStartTimeDirect.Size = new Size(193, 15);
            labelStartTimeDirect.TabIndex = 8;
            labelStartTimeDirect.Text = "Начало прямого маршрута (ч:м):";
            // 
            // timePickerStartDirect
            // 
            timePickerStartDirect.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timePickerStartDirect.Format = DateTimePickerFormat.Time;
            timePickerStartDirect.Location = new Point(241, 168);
            timePickerStartDirect.Name = "timePickerStartDirect";
            timePickerStartDirect.ShowUpDown = true;
            timePickerStartDirect.Size = new Size(233, 23);
            timePickerStartDirect.TabIndex = 9;
            // 
            // labelEndTimeDirect
            // 
            labelEndTimeDirect.Anchor = AnchorStyles.Right;
            labelEndTimeDirect.AutoSize = true;
            labelEndTimeDirect.Location = new Point(43, 212);
            labelEndTimeDirect.Margin = new Padding(3, 0, 10, 0);
            labelEndTimeDirect.Name = "labelEndTimeDirect";
            labelEndTimeDirect.Size = new Size(185, 15);
            labelEndTimeDirect.TabIndex = 10;
            labelEndTimeDirect.Text = "Конец прямого маршрута (ч:м):";
            // 
            // timePickerEndDirect
            // 
            timePickerEndDirect.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timePickerEndDirect.Format = DateTimePickerFormat.Time;
            timePickerEndDirect.Location = new Point(241, 208);
            timePickerEndDirect.Name = "timePickerEndDirect";
            timePickerEndDirect.ShowUpDown = true;
            timePickerEndDirect.Size = new Size(233, 23);
            timePickerEndDirect.TabIndex = 11;
            // 
            // labelStartTimeReverse
            // 
            labelStartTimeReverse.Anchor = AnchorStyles.Right;
            labelStartTimeReverse.AutoSize = true;
            labelStartTimeReverse.Location = new Point(25, 252);
            labelStartTimeReverse.Margin = new Padding(3, 0, 10, 0);
            labelStartTimeReverse.Name = "labelStartTimeReverse";
            labelStartTimeReverse.Size = new Size(203, 15);
            labelStartTimeReverse.TabIndex = 12;
            labelStartTimeReverse.Text = "Начало обратного маршрута (ч:м):";
            // 
            // timePickerStartReverse
            // 
            timePickerStartReverse.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timePickerStartReverse.Format = DateTimePickerFormat.Time;
            timePickerStartReverse.Location = new Point(241, 248);
            timePickerStartReverse.Name = "timePickerStartReverse";
            timePickerStartReverse.ShowUpDown = true;
            timePickerStartReverse.Size = new Size(233, 23);
            timePickerStartReverse.TabIndex = 13;
            // 
            // labelEndTimeReverse
            // 
            labelEndTimeReverse.Anchor = AnchorStyles.Right;
            labelEndTimeReverse.AutoSize = true;
            labelEndTimeReverse.Location = new Point(33, 292);
            labelEndTimeReverse.Margin = new Padding(3, 0, 10, 0);
            labelEndTimeReverse.Name = "labelEndTimeReverse";
            labelEndTimeReverse.Size = new Size(195, 15);
            labelEndTimeReverse.TabIndex = 14;
            labelEndTimeReverse.Text = "Конец обратного маршрута (ч:м):";
            // 
            // timePickerEndReverse
            // 
            timePickerEndReverse.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timePickerEndReverse.Format = DateTimePickerFormat.Time;
            timePickerEndReverse.Location = new Point(241, 288);
            timePickerEndReverse.Name = "timePickerEndReverse";
            timePickerEndReverse.ShowUpDown = true;
            timePickerEndReverse.Size = new Size(233, 23);
            timePickerEndReverse.TabIndex = 15;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(tableLayoutPanelRight);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(0, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(10);
            rightPanel.Size = new Size(493, 634);
            rightPanel.TabIndex = 0;
            // 
            // tableLayoutPanelRight
            // 
            tableLayoutPanelRight.ColumnCount = 1;
            tableLayoutPanelRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelRight.Controls.Add(groupBoxSchedule, 0, 0);
            tableLayoutPanelRight.Controls.Add(groupBoxStations, 0, 1);
            tableLayoutPanelRight.Dock = DockStyle.Fill;
            tableLayoutPanelRight.Location = new Point(10, 10);
            tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            tableLayoutPanelRight.RowCount = 2;
            tableLayoutPanelRight.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelRight.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelRight.Size = new Size(473, 614);
            tableLayoutPanelRight.TabIndex = 0;
            // 
            // groupBoxSchedule
            // 
            groupBoxSchedule.Controls.Add(tableLayoutPanelSchedule);
            groupBoxSchedule.Dock = DockStyle.Fill;
            groupBoxSchedule.Location = new Point(3, 3);
            groupBoxSchedule.Name = "groupBoxSchedule";
            groupBoxSchedule.Size = new Size(467, 301);
            groupBoxSchedule.TabIndex = 0;
            groupBoxSchedule.TabStop = false;
            groupBoxSchedule.Text = "График движения";
            // 
            // tableLayoutPanelSchedule
            // 
            tableLayoutPanelSchedule.ColumnCount = 1;
            tableLayoutPanelSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelSchedule.Controls.Add(panelScheduleControls, 0, 0);
            tableLayoutPanelSchedule.Controls.Add(dataGridViewSchedule, 0, 1);
            tableLayoutPanelSchedule.Dock = DockStyle.Fill;
            tableLayoutPanelSchedule.Location = new Point(3, 19);
            tableLayoutPanelSchedule.Name = "tableLayoutPanelSchedule";
            tableLayoutPanelSchedule.RowCount = 2;
            tableLayoutPanelSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanelSchedule.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelSchedule.Size = new Size(461, 279);
            tableLayoutPanelSchedule.TabIndex = 0;
            // 
            // panelScheduleControls
            // 
            panelScheduleControls.Controls.Add(labelFromHour);
            panelScheduleControls.Controls.Add(numericFromHour);
            panelScheduleControls.Controls.Add(labelToHour);
            panelScheduleControls.Controls.Add(numericToHour);
            panelScheduleControls.Controls.Add(labelInterval);
            panelScheduleControls.Controls.Add(numericInterval);
            panelScheduleControls.Controls.Add(buttonAddSchedule);
            panelScheduleControls.Controls.Add(buttonRemoveSchedule);
            panelScheduleControls.Dock = DockStyle.Fill;
            panelScheduleControls.Location = new Point(3, 3);
            panelScheduleControls.Name = "panelScheduleControls";
            panelScheduleControls.Size = new Size(455, 54);
            panelScheduleControls.TabIndex = 0;
            // 
            // labelFromHour
            // 
            labelFromHour.AutoSize = true;
            labelFromHour.Location = new Point(3, 18);
            labelFromHour.Name = "labelFromHour";
            labelFromHour.Size = new Size(13, 15);
            labelFromHour.TabIndex = 0;
            labelFromHour.Text = "с";
            // 
            // numericFromHour
            // 
            numericFromHour.Location = new Point(24, 15);
            numericFromHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            numericFromHour.Name = "numericFromHour";
            numericFromHour.Size = new Size(50, 23);
            numericFromHour.TabIndex = 1;
            // 
            // labelToHour
            // 
            labelToHour.AutoSize = true;
            labelToHour.Location = new Point(80, 18);
            labelToHour.Name = "labelToHour";
            labelToHour.Size = new Size(21, 15);
            labelToHour.TabIndex = 2;
            labelToHour.Text = "по";
            // 
            // numericToHour
            // 
            numericToHour.Location = new Point(104, 15);
            numericToHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            numericToHour.Name = "numericToHour";
            numericToHour.Size = new Size(50, 23);
            numericToHour.TabIndex = 3;
            numericToHour.Value = new decimal(new int[] { 23, 0, 0, 0 });
            // 
            // labelInterval
            // 
            labelInterval.AutoSize = true;
            labelInterval.Location = new Point(183, 18);
            labelInterval.Name = "labelInterval";
            labelInterval.Size = new Size(61, 15);
            labelInterval.TabIndex = 4;
            labelInterval.Text = "интервал:";
            // 
            // numericInterval
            // 
            numericInterval.Location = new Point(264, 15);
            numericInterval.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericInterval.Name = "numericInterval";
            numericInterval.Size = new Size(50, 23);
            numericInterval.TabIndex = 5;
            numericInterval.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // buttonAddSchedule
            // 
            buttonAddSchedule.Location = new Point(365, 13);
            buttonAddSchedule.Name = "buttonAddSchedule";
            buttonAddSchedule.Size = new Size(35, 25);
            buttonAddSchedule.TabIndex = 6;
            buttonAddSchedule.Text = "+";
            buttonAddSchedule.UseVisualStyleBackColor = true;
            buttonAddSchedule.Click += buttonAddSchedule_Click;
            // 
            // buttonRemoveSchedule
            // 
            buttonRemoveSchedule.Location = new Point(406, 13);
            buttonRemoveSchedule.Name = "buttonRemoveSchedule";
            buttonRemoveSchedule.Size = new Size(35, 25);
            buttonRemoveSchedule.TabIndex = 7;
            buttonRemoveSchedule.Text = "-";
            buttonRemoveSchedule.UseVisualStyleBackColor = true;
            buttonRemoveSchedule.Click += buttonRemoveSchedule_Click;
            // 
            // dataGridViewSchedule
            // 
            dataGridViewSchedule.AllowUserToAddRows = false;
            dataGridViewSchedule.AllowUserToDeleteRows = false;
            dataGridViewSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSchedule.Columns.AddRange(new DataGridViewColumn[] { colScheduleNumber, colScheduleStartHour, colScheduleEndHour, colScheduleInterval });
            dataGridViewSchedule.Dock = DockStyle.Fill;
            dataGridViewSchedule.Location = new Point(3, 63);
            dataGridViewSchedule.Name = "dataGridViewSchedule";
            dataGridViewSchedule.ReadOnly = true;
            dataGridViewSchedule.RowHeadersVisible = false;
            dataGridViewSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSchedule.Size = new Size(455, 213);
            dataGridViewSchedule.TabIndex = 1;
            // 
            // colScheduleNumber
            // 
            colScheduleNumber.HeaderText = "№";
            colScheduleNumber.Name = "colScheduleNumber";
            colScheduleNumber.ReadOnly = true;
            // 
            // colScheduleStartHour
            // 
            colScheduleStartHour.HeaderText = "Начальный час";
            colScheduleStartHour.Name = "colScheduleStartHour";
            colScheduleStartHour.ReadOnly = true;
            // 
            // colScheduleEndHour
            // 
            colScheduleEndHour.HeaderText = "Конечный час";
            colScheduleEndHour.Name = "colScheduleEndHour";
            colScheduleEndHour.ReadOnly = true;
            // 
            // colScheduleInterval
            // 
            colScheduleInterval.HeaderText = "Интервал (мин.)";
            colScheduleInterval.Name = "colScheduleInterval";
            colScheduleInterval.ReadOnly = true;
            // 
            // groupBoxStations
            // 
            groupBoxStations.Controls.Add(tableLayoutPanelStations);
            groupBoxStations.Dock = DockStyle.Fill;
            groupBoxStations.Location = new Point(3, 310);
            groupBoxStations.Name = "groupBoxStations";
            groupBoxStations.Size = new Size(467, 301);
            groupBoxStations.TabIndex = 1;
            groupBoxStations.TabStop = false;
            groupBoxStations.Text = "Остановки маршрута";
            // 
            // tableLayoutPanelStations
            // 
            tableLayoutPanelStations.ColumnCount = 1;
            tableLayoutPanelStations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelStations.Controls.Add(panelStationsControls, 0, 0);
            tableLayoutPanelStations.Controls.Add(dataGridViewStations, 0, 1);
            tableLayoutPanelStations.Dock = DockStyle.Fill;
            tableLayoutPanelStations.Location = new Point(3, 19);
            tableLayoutPanelStations.Name = "tableLayoutPanelStations";
            tableLayoutPanelStations.RowCount = 2;
            tableLayoutPanelStations.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanelStations.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelStations.Size = new Size(461, 279);
            tableLayoutPanelStations.TabIndex = 0;
            // 
            // panelStationsControls
            // 
            panelStationsControls.Controls.Add(comboBoxStations);
            panelStationsControls.Controls.Add(buttonAddStation);
            panelStationsControls.Controls.Add(buttonRemoveStation);
            panelStationsControls.Controls.Add(buttonMoveUp);
            panelStationsControls.Controls.Add(buttonMoveDown);
            panelStationsControls.Dock = DockStyle.Fill;
            panelStationsControls.Location = new Point(3, 3);
            panelStationsControls.Name = "panelStationsControls";
            panelStationsControls.Size = new Size(455, 54);
            panelStationsControls.TabIndex = 0;
            // 
            // comboBoxStations
            // 
            comboBoxStations.FormattingEnabled = true;
            comboBoxStations.Location = new Point(3, 15);
            comboBoxStations.Name = "comboBoxStations";
            comboBoxStations.Size = new Size(200, 23);
            comboBoxStations.TabIndex = 0;
            // 
            // buttonAddStation
            // 
            buttonAddStation.Location = new Point(209, 14);
            buttonAddStation.Name = "buttonAddStation";
            buttonAddStation.Size = new Size(35, 25);
            buttonAddStation.TabIndex = 1;
            buttonAddStation.Text = "+";
            buttonAddStation.UseVisualStyleBackColor = true;
            buttonAddStation.Click += buttonAddStation_Click;
            // 
            // buttonRemoveStation
            // 
            buttonRemoveStation.Location = new Point(250, 14);
            buttonRemoveStation.Name = "buttonRemoveStation";
            buttonRemoveStation.Size = new Size(35, 25);
            buttonRemoveStation.TabIndex = 2;
            buttonRemoveStation.Text = "-";
            buttonRemoveStation.UseVisualStyleBackColor = true;
            buttonRemoveStation.Click += buttonRemoveStation_Click;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.Location = new Point(291, 14);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(35, 25);
            buttonMoveUp.TabIndex = 3;
            buttonMoveUp.Text = "↑";
            buttonMoveUp.UseVisualStyleBackColor = true;
            buttonMoveUp.Click += buttonMoveUp_Click;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Location = new Point(332, 14);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(35, 25);
            buttonMoveDown.TabIndex = 4;
            buttonMoveDown.Text = "↓";
            buttonMoveDown.UseVisualStyleBackColor = true;
            buttonMoveDown.Click += buttonMoveDown_Click;
            // 
            // dataGridViewStations
            // 
            dataGridViewStations.AllowUserToAddRows = false;
            dataGridViewStations.AllowUserToDeleteRows = false;
            dataGridViewStations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStations.Columns.AddRange(new DataGridViewColumn[] { colStationNumber, colStationName });
            dataGridViewStations.Dock = DockStyle.Fill;
            dataGridViewStations.Location = new Point(3, 63);
            dataGridViewStations.Name = "dataGridViewStations";
            dataGridViewStations.ReadOnly = true;
            dataGridViewStations.RowHeadersVisible = false;
            dataGridViewStations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStations.Size = new Size(455, 213);
            dataGridViewStations.TabIndex = 1;
            // 
            // colStationNumber
            // 
            colStationNumber.HeaderText = "№";
            colStationNumber.Name = "colStationNumber";
            colStationNumber.ReadOnly = true;
            // 
            // colStationName
            // 
            colStationName.HeaderText = "Название остановки";
            colStationName.Name = "colStationName";
            colStationName.ReadOnly = true;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelButtons.Controls.Add(buttonCancel);
            flowLayoutPanelButtons.Controls.Add(buttonApply);
            flowLayoutPanelButtons.Dock = DockStyle.Fill;
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(3, 643);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Padding = new Padding(0, 10, 0, 0);
            flowLayoutPanelButtons.Size = new Size(994, 54);
            flowLayoutPanelButtons.TabIndex = 1;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.AutoSize = true;
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.Location = new Point(911, 13);
            buttonCancel.MinimumSize = new Size(80, 30);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(10, 5, 10, 5);
            buttonCancel.Size = new Size(80, 35);
            buttonCancel.TabIndex = 16;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonApply.AutoSize = true;
            buttonApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApply.Location = new Point(805, 13);
            buttonApply.MinimumSize = new Size(90, 30);
            buttonApply.Name = "buttonApply";
            buttonApply.Padding = new Padding(10, 5, 10, 5);
            buttonApply.Size = new Size(100, 35);
            buttonApply.TabIndex = 15;
            buttonApply.Text = "Применить";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // RoutEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(mainTableLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1016, 739);
            Name = "RoutEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Маршрут";
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            tableLayoutPanelLeft.ResumeLayout(false);
            tableLayoutPanelLeft.PerformLayout();
            panelTimeRoute.ResumeLayout(false);
            panelTimeRoute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericHoursTimeRoute).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMinutesTimeRoute).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericRevenue).EndInit();
            rightPanel.ResumeLayout(false);
            tableLayoutPanelRight.ResumeLayout(false);
            groupBoxSchedule.ResumeLayout(false);
            tableLayoutPanelSchedule.ResumeLayout(false);
            panelScheduleControls.ResumeLayout(false);
            panelScheduleControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericFromHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericToHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedule).EndInit();
            groupBoxStations.ResumeLayout(false);
            tableLayoutPanelStations.ResumeLayout(false);
            panelStationsControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStations).EndInit();
            flowLayoutPanelButtons.ResumeLayout(false);
            flowLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private SplitContainer splitContainer1;
        private Panel leftPanel;
        private Panel rightPanel;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button buttonCancel;
        private Button buttonApply;
        private TableLayoutPanel tableLayoutPanelLeft;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelTimeRoute;
        private Panel panelTimeRoute;
        private NumericUpDown numericHoursTimeRoute;
        private Label labelHoursTimeRoute;
        private NumericUpDown numericMinutesTimeRoute;
        private Label labelMinutesTimeRoute;
        private Label labelDistance;
        private NumericUpDown numericDistance;
        private Label labelRevenue;
        private NumericUpDown numericRevenue;
        private Label labelStartTimeDirect;
        private DateTimePicker timePickerStartDirect;
        private Label labelEndTimeDirect;
        private DateTimePicker timePickerEndDirect;
        private Label labelStartTimeReverse;
        private DateTimePicker timePickerStartReverse;
        private Label labelEndTimeReverse;
        private DateTimePicker timePickerEndReverse;
        private TableLayoutPanel tableLayoutPanelRight;
        private GroupBox groupBoxSchedule;
        private TableLayoutPanel tableLayoutPanelSchedule;
        private Panel panelScheduleControls;
        private Label labelFromHour;
        private NumericUpDown numericFromHour;
        private Label labelToHour;
        private NumericUpDown numericToHour;
        private Label labelInterval;
        private NumericUpDown numericInterval;
        private Button buttonAddSchedule;
        private Button buttonRemoveSchedule;
        private DataGridView dataGridViewSchedule;
        private DataGridViewTextBoxColumn colScheduleNumber;
        private DataGridViewTextBoxColumn colScheduleStartHour;
        private DataGridViewTextBoxColumn colScheduleEndHour;
        private DataGridViewTextBoxColumn colScheduleInterval;
        private GroupBox groupBoxStations;
        private TableLayoutPanel tableLayoutPanelStations;
        private Panel panelStationsControls;
        private ComboBox comboBoxStations;
        private Button buttonAddStation;
        private Button buttonRemoveStation;
        private Button buttonMoveUp;
        private Button buttonMoveDown;
        private DataGridView dataGridViewStations;
        private DataGridViewTextBoxColumn colStationNumber;
        private DataGridViewTextBoxColumn colStationName;
    }
}