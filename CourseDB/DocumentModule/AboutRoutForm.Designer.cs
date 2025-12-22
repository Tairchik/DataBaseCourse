using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DocumentModule
{
    partial class AboutRoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutRoutForm));
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
            dataGridViewSchedule = new DataGridView();
            colScheduleNumber = new DataGridViewTextBoxColumn();
            colScheduleStartHour = new DataGridViewTextBoxColumn();
            colScheduleEndHour = new DataGridViewTextBoxColumn();
            colScheduleInterval = new DataGridViewTextBoxColumn();
            groupBoxStations = new GroupBox();
            tableLayoutPanelStations = new TableLayoutPanel();
            panelStationsControls = new Panel();
            dataGridViewStations = new DataGridView();
            colStationNumber = new DataGridViewTextBoxColumn();
            colStationName = new DataGridViewTextBoxColumn();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonCancel = new Button();
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
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedule).BeginInit();
            groupBoxStations.SuspendLayout();
            tableLayoutPanelStations.SuspendLayout();
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
            splitContainer1.SplitterDistance = 496;
            splitContainer1.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(tableLayoutPanelLeft);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(10, 10, 10, 10);
            leftPanel.Size = new Size(496, 634);
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
            tableLayoutPanelLeft.Size = new Size(476, 614);
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
            textBoxName.Enabled = false;
            textBoxName.Location = new Point(241, 8);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(232, 23);
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
            panelTimeRoute.Size = new Size(232, 23);
            panelTimeRoute.TabIndex = 3;
            // 
            // numericHoursTimeRoute
            // 
            numericHoursTimeRoute.Enabled = false;
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
            numericMinutesTimeRoute.Enabled = false;
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
            numericDistance.Enabled = false;
            numericDistance.Location = new Point(241, 88);
            numericDistance.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericDistance.Name = "numericDistance";
            numericDistance.Size = new Size(232, 23);
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
            numericRevenue.Enabled = false;
            numericRevenue.Location = new Point(241, 128);
            numericRevenue.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericRevenue.Name = "numericRevenue";
            numericRevenue.Size = new Size(232, 23);
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
            timePickerStartDirect.Enabled = false;
            timePickerStartDirect.Format = DateTimePickerFormat.Time;
            timePickerStartDirect.Location = new Point(241, 168);
            timePickerStartDirect.Name = "timePickerStartDirect";
            timePickerStartDirect.ShowUpDown = true;
            timePickerStartDirect.Size = new Size(232, 23);
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
            timePickerEndDirect.Enabled = false;
            timePickerEndDirect.Format = DateTimePickerFormat.Time;
            timePickerEndDirect.Location = new Point(241, 208);
            timePickerEndDirect.Name = "timePickerEndDirect";
            timePickerEndDirect.ShowUpDown = true;
            timePickerEndDirect.Size = new Size(232, 23);
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
            timePickerStartReverse.Enabled = false;
            timePickerStartReverse.Format = DateTimePickerFormat.Time;
            timePickerStartReverse.Location = new Point(241, 248);
            timePickerStartReverse.Name = "timePickerStartReverse";
            timePickerStartReverse.ShowUpDown = true;
            timePickerStartReverse.Size = new Size(232, 23);
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
            timePickerEndReverse.Enabled = false;
            timePickerEndReverse.Format = DateTimePickerFormat.Time;
            timePickerEndReverse.Location = new Point(241, 288);
            timePickerEndReverse.Name = "timePickerEndReverse";
            timePickerEndReverse.ShowUpDown = true;
            timePickerEndReverse.Size = new Size(232, 23);
            timePickerEndReverse.TabIndex = 15;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(tableLayoutPanelRight);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(0, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(10, 10, 10, 10);
            rightPanel.Size = new Size(494, 634);
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
            tableLayoutPanelRight.Size = new Size(474, 614);
            tableLayoutPanelRight.TabIndex = 0;
            // 
            // groupBoxSchedule
            // 
            groupBoxSchedule.Controls.Add(tableLayoutPanelSchedule);
            groupBoxSchedule.Dock = DockStyle.Fill;
            groupBoxSchedule.Location = new Point(3, 3);
            groupBoxSchedule.Name = "groupBoxSchedule";
            groupBoxSchedule.Size = new Size(468, 301);
            groupBoxSchedule.TabIndex = 0;
            groupBoxSchedule.TabStop = false;
            groupBoxSchedule.Text = "График движения";
            // 
            // tableLayoutPanelSchedule
            // 
            tableLayoutPanelSchedule.ColumnCount = 1;
            tableLayoutPanelSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelSchedule.Controls.Add(dataGridViewSchedule, 0, 1);
            tableLayoutPanelSchedule.Dock = DockStyle.Fill;
            tableLayoutPanelSchedule.Location = new Point(3, 19);
            tableLayoutPanelSchedule.Name = "tableLayoutPanelSchedule";
            tableLayoutPanelSchedule.RowCount = 2;
            tableLayoutPanelSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 6F));
            tableLayoutPanelSchedule.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelSchedule.Size = new Size(462, 279);
            tableLayoutPanelSchedule.TabIndex = 0;
            // 
            // dataGridViewSchedule
            // 
            dataGridViewSchedule.AllowUserToAddRows = false;
            dataGridViewSchedule.AllowUserToDeleteRows = false;
            dataGridViewSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSchedule.Columns.AddRange(new DataGridViewColumn[] { colScheduleNumber, colScheduleStartHour, colScheduleEndHour, colScheduleInterval });
            dataGridViewSchedule.Dock = DockStyle.Fill;
            dataGridViewSchedule.Location = new Point(3, 9);
            dataGridViewSchedule.Name = "dataGridViewSchedule";
            dataGridViewSchedule.ReadOnly = true;
            dataGridViewSchedule.RowHeadersVisible = false;
            dataGridViewSchedule.RowHeadersWidth = 51;
            dataGridViewSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSchedule.Size = new Size(456, 267);
            dataGridViewSchedule.TabIndex = 1;
            // 
            // colScheduleNumber
            // 
            colScheduleNumber.HeaderText = "№";
            colScheduleNumber.MinimumWidth = 6;
            colScheduleNumber.Name = "colScheduleNumber";
            colScheduleNumber.ReadOnly = true;
            // 
            // colScheduleStartHour
            // 
            colScheduleStartHour.HeaderText = "Начальный час";
            colScheduleStartHour.MinimumWidth = 6;
            colScheduleStartHour.Name = "colScheduleStartHour";
            colScheduleStartHour.ReadOnly = true;
            // 
            // colScheduleEndHour
            // 
            colScheduleEndHour.HeaderText = "Конечный час";
            colScheduleEndHour.MinimumWidth = 6;
            colScheduleEndHour.Name = "colScheduleEndHour";
            colScheduleEndHour.ReadOnly = true;
            // 
            // colScheduleInterval
            // 
            colScheduleInterval.HeaderText = "Интервал (мин.)";
            colScheduleInterval.MinimumWidth = 6;
            colScheduleInterval.Name = "colScheduleInterval";
            colScheduleInterval.ReadOnly = true;
            // 
            // groupBoxStations
            // 
            groupBoxStations.Controls.Add(tableLayoutPanelStations);
            groupBoxStations.Dock = DockStyle.Fill;
            groupBoxStations.Location = new Point(3, 310);
            groupBoxStations.Name = "groupBoxStations";
            groupBoxStations.Size = new Size(468, 301);
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
            tableLayoutPanelStations.RowStyles.Add(new RowStyle(SizeType.Absolute, 6F));
            tableLayoutPanelStations.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelStations.Size = new Size(462, 279);
            tableLayoutPanelStations.TabIndex = 0;
            // 
            // panelStationsControls
            // 
            panelStationsControls.Dock = DockStyle.Fill;
            panelStationsControls.Location = new Point(3, 3);
            panelStationsControls.Name = "panelStationsControls";
            panelStationsControls.Size = new Size(456, 1);
            panelStationsControls.TabIndex = 0;
            // 
            // dataGridViewStations
            // 
            dataGridViewStations.AllowUserToAddRows = false;
            dataGridViewStations.AllowUserToDeleteRows = false;
            dataGridViewStations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStations.Columns.AddRange(new DataGridViewColumn[] { colStationNumber, colStationName });
            dataGridViewStations.Dock = DockStyle.Fill;
            dataGridViewStations.Location = new Point(3, 9);
            dataGridViewStations.Name = "dataGridViewStations";
            dataGridViewStations.ReadOnly = true;
            dataGridViewStations.RowHeadersVisible = false;
            dataGridViewStations.RowHeadersWidth = 51;
            dataGridViewStations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStations.Size = new Size(456, 267);
            dataGridViewStations.TabIndex = 1;
            // 
            // colStationNumber
            // 
            colStationNumber.HeaderText = "№";
            colStationNumber.MinimumWidth = 6;
            colStationNumber.Name = "colStationNumber";
            colStationNumber.ReadOnly = true;
            // 
            // colStationName
            // 
            colStationName.HeaderText = "Название остановки";
            colStationName.MinimumWidth = 6;
            colStationName.Name = "colStationName";
            colStationName.ReadOnly = true;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelButtons.Controls.Add(buttonCancel);
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
            // AboutRoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(mainTableLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1016, 737);
            Name = "AboutRoutForm";
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
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedule).EndInit();
            groupBoxStations.ResumeLayout(false);
            tableLayoutPanelStations.ResumeLayout(false);
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
        private DataGridView dataGridViewSchedule;
        private DataGridViewTextBoxColumn colScheduleNumber;
        private DataGridViewTextBoxColumn colScheduleStartHour;
        private DataGridViewTextBoxColumn colScheduleEndHour;
        private DataGridViewTextBoxColumn colScheduleInterval;
        private GroupBox groupBoxStations;
        private TableLayoutPanel tableLayoutPanelStations;
        private Panel panelStationsControls;
        private DataGridView dataGridViewStations;
        private DataGridViewTextBoxColumn colStationNumber;
        private DataGridViewTextBoxColumn colStationName;
    }
}