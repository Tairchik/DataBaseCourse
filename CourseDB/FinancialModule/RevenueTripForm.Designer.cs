namespace FinancialModule
{
    partial class RevenueTripForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevenueTripForm));
            mainTableLayout = new TableLayoutPanel();
            panelFilter = new Panel();
            tableLayoutPanelFilter = new TableLayoutPanel();
            labelDate = new Label();
            labelRouteFilter = new Label();
            comboBoxRouteFilter = new ComboBox();
            buttonResetFilter = new Button();
            buttonApplyFilter = new Button();
            dateTimePickerFilter = new DateTimePicker();
            panelTable = new Panel();
            dataGridViewTrips = new DataGridView();
            colNumber = new DataGridViewTextBoxColumn();
            colRoute = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colActualRevenue = new DataGridViewTextBoxColumn();
            panelRevenueEdit = new Panel();
            tableLayoutPanelRevenue = new TableLayoutPanel();
            labelActualRevenue = new Label();
            textBoxActualRevenue = new TextBox();
            panelButtons = new Panel();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonApply = new Button();
            mainTableLayout.SuspendLayout();
            panelFilter.SuspendLayout();
            tableLayoutPanelFilter.SuspendLayout();
            panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTrips).BeginInit();
            panelRevenueEdit.SuspendLayout();
            tableLayoutPanelRevenue.SuspendLayout();
            panelButtons.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.AutoSize = true;
            mainTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.Controls.Add(panelFilter, 0, 0);
            mainTableLayout.Controls.Add(panelTable, 0, 1);
            mainTableLayout.Controls.Add(panelRevenueEdit, 0, 2);
            mainTableLayout.Controls.Add(panelButtons, 0, 3);
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.Padding = new Padding(10);
            mainTableLayout.RowCount = 4;
            mainTableLayout.RowStyles.Add(new RowStyle());
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle());
            mainTableLayout.RowStyles.Add(new RowStyle());
            mainTableLayout.Size = new Size(903, 603);
            mainTableLayout.TabIndex = 0;
            // 
            // panelFilter
            // 
            panelFilter.AutoSize = true;
            panelFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelFilter.Controls.Add(tableLayoutPanelFilter);
            panelFilter.Location = new Point(13, 13);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(0, 0, 0, 10);
            panelFilter.Size = new Size(877, 44);
            panelFilter.TabIndex = 0;
            // 
            // tableLayoutPanelFilter
            // 
            tableLayoutPanelFilter.AutoSize = true;
            tableLayoutPanelFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelFilter.ColumnCount = 6;
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.Controls.Add(labelDate, 0, 0);
            tableLayoutPanelFilter.Controls.Add(labelRouteFilter, 2, 0);
            tableLayoutPanelFilter.Controls.Add(comboBoxRouteFilter, 3, 0);
            tableLayoutPanelFilter.Controls.Add(buttonResetFilter, 4, 0);
            tableLayoutPanelFilter.Controls.Add(buttonApplyFilter, 5, 0);
            tableLayoutPanelFilter.Controls.Add(dateTimePickerFilter, 1, 0);
            tableLayoutPanelFilter.Location = new Point(0, 0);
            tableLayoutPanelFilter.Name = "tableLayoutPanelFilter";
            tableLayoutPanelFilter.RowCount = 1;
            tableLayoutPanelFilter.RowStyles.Add(new RowStyle());
            tableLayoutPanelFilter.Size = new Size(874, 31);
            tableLayoutPanelFilter.TabIndex = 0;
            // 
            // labelDate
            // 
            labelDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelDate.AutoSize = true;
            labelDate.Location = new Point(3, 8);
            labelDate.Margin = new Padding(3, 0, 10, 0);
            labelDate.MinimumSize = new Size(40, 0);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(40, 15);
            labelDate.TabIndex = 0;
            labelDate.Text = "Дата:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelRouteFilter
            // 
            labelRouteFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelRouteFilter.AutoSize = true;
            labelRouteFilter.Location = new Point(196, 8);
            labelRouteFilter.Margin = new Padding(3, 0, 10, 0);
            labelRouteFilter.MinimumSize = new Size(70, 0);
            labelRouteFilter.Name = "labelRouteFilter";
            labelRouteFilter.Size = new Size(70, 15);
            labelRouteFilter.TabIndex = 2;
            labelRouteFilter.Text = "Маршрут:";
            labelRouteFilter.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxRouteFilter
            // 
            comboBoxRouteFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxRouteFilter.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxRouteFilter.FormattingEnabled = true;
            comboBoxRouteFilter.Location = new Point(279, 3);
            comboBoxRouteFilter.Margin = new Padding(3, 3, 10, 3);
            comboBoxRouteFilter.MinimumSize = new Size(120, 0);
            comboBoxRouteFilter.Name = "comboBoxRouteFilter";
            comboBoxRouteFilter.Size = new Size(352, 23);
            comboBoxRouteFilter.TabIndex = 3;
            // 
            // buttonResetFilter
            // 
            buttonResetFilter.AutoSize = true;
            buttonResetFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonResetFilter.Location = new Point(644, 3);
            buttonResetFilter.Margin = new Padding(3, 3, 10, 3);
            buttonResetFilter.MinimumSize = new Size(100, 25);
            buttonResetFilter.Name = "buttonResetFilter";
            buttonResetFilter.Padding = new Padding(5, 0, 5, 0);
            buttonResetFilter.Size = new Size(124, 25);
            buttonResetFilter.TabIndex = 4;
            buttonResetFilter.Text = "Сбросить фильтр";
            buttonResetFilter.UseVisualStyleBackColor = true;
            buttonResetFilter.Click += buttonResetFilter_Click;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.AutoSize = true;
            buttonApplyFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApplyFilter.Location = new Point(781, 3);
            buttonApplyFilter.MinimumSize = new Size(80, 25);
            buttonApplyFilter.Name = "buttonApplyFilter";
            buttonApplyFilter.Padding = new Padding(5, 0, 5, 0);
            buttonApplyFilter.Size = new Size(90, 25);
            buttonApplyFilter.TabIndex = 5;
            buttonApplyFilter.Text = "Применить";
            buttonApplyFilter.UseVisualStyleBackColor = true;
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // dateTimePickerFilter
            // 
            dateTimePickerFilter.Format = DateTimePickerFormat.Short;
            dateTimePickerFilter.Location = new Point(56, 3);
            dateTimePickerFilter.Margin = new Padding(3, 3, 10, 3);
            dateTimePickerFilter.MinimumSize = new Size(120, 23);
            dateTimePickerFilter.Name = "dateTimePickerFilter";
            dateTimePickerFilter.Size = new Size(127, 23);
            dateTimePickerFilter.TabIndex = 1;
            // 
            // panelTable
            // 
            panelTable.Controls.Add(dataGridViewTrips);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Location = new Point(13, 63);
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(0, 10, 0, 10);
            panelTable.Size = new Size(877, 415);
            panelTable.TabIndex = 1;
            // 
            // dataGridViewTrips
            // 
            dataGridViewTrips.AllowUserToAddRows = false;
            dataGridViewTrips.AllowUserToDeleteRows = false;
            dataGridViewTrips.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTrips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTrips.Columns.AddRange(new DataGridViewColumn[] { colNumber, colRoute, colDate, colTime, colActualRevenue });
            dataGridViewTrips.Dock = DockStyle.Fill;
            dataGridViewTrips.Location = new Point(0, 10);
            dataGridViewTrips.Name = "dataGridViewTrips";
            dataGridViewTrips.ReadOnly = true;
            dataGridViewTrips.RowHeadersVisible = false;
            dataGridViewTrips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTrips.Size = new Size(877, 395);
            dataGridViewTrips.TabIndex = 0;
            dataGridViewTrips.SelectionChanged += dataGridViewTrips_SelectionChanged;
            // 
            // colNumber
            // 
            colNumber.FillWeight = 40F;
            colNumber.HeaderText = "№";
            colNumber.Name = "colNumber";
            colNumber.ReadOnly = true;
            // 
            // colRoute
            // 
            colRoute.FillWeight = 150F;
            colRoute.HeaderText = "Маршрут";
            colRoute.Name = "colRoute";
            colRoute.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.FillWeight = 90F;
            colDate.HeaderText = "Дата";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colTime
            // 
            colTime.FillWeight = 80F;
            colTime.HeaderText = "Время";
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colActualRevenue
            // 
            colActualRevenue.FillWeight = 120F;
            colActualRevenue.HeaderText = "Фактическая выручка";
            colActualRevenue.Name = "colActualRevenue";
            colActualRevenue.ReadOnly = true;
            // 
            // panelRevenueEdit
            // 
            panelRevenueEdit.AutoSize = true;
            panelRevenueEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelRevenueEdit.Controls.Add(tableLayoutPanelRevenue);
            panelRevenueEdit.Dock = DockStyle.Fill;
            panelRevenueEdit.Location = new Point(13, 484);
            panelRevenueEdit.Name = "panelRevenueEdit";
            panelRevenueEdit.Padding = new Padding(0, 10, 0, 10);
            panelRevenueEdit.Size = new Size(877, 49);
            panelRevenueEdit.TabIndex = 2;
            // 
            // tableLayoutPanelRevenue
            // 
            tableLayoutPanelRevenue.AutoSize = true;
            tableLayoutPanelRevenue.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelRevenue.ColumnCount = 2;
            tableLayoutPanelRevenue.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelRevenue.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelRevenue.Controls.Add(labelActualRevenue, 0, 0);
            tableLayoutPanelRevenue.Controls.Add(textBoxActualRevenue, 1, 0);
            tableLayoutPanelRevenue.Dock = DockStyle.Fill;
            tableLayoutPanelRevenue.Location = new Point(0, 10);
            tableLayoutPanelRevenue.Name = "tableLayoutPanelRevenue";
            tableLayoutPanelRevenue.RowCount = 1;
            tableLayoutPanelRevenue.RowStyles.Add(new RowStyle());
            tableLayoutPanelRevenue.Size = new Size(877, 29);
            tableLayoutPanelRevenue.TabIndex = 0;
            // 
            // labelActualRevenue
            // 
            labelActualRevenue.Anchor = AnchorStyles.Left;
            labelActualRevenue.AutoSize = true;
            labelActualRevenue.Location = new Point(3, 7);
            labelActualRevenue.Margin = new Padding(3, 0, 20, 0);
            labelActualRevenue.MinimumSize = new Size(150, 0);
            labelActualRevenue.Name = "labelActualRevenue";
            labelActualRevenue.Size = new Size(150, 15);
            labelActualRevenue.TabIndex = 0;
            labelActualRevenue.Text = "Фактическая выручка:";
            labelActualRevenue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxActualRevenue
            // 
            textBoxActualRevenue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxActualRevenue.Location = new Point(176, 3);
            textBoxActualRevenue.MinimumSize = new Size(120, 23);
            textBoxActualRevenue.Name = "textBoxActualRevenue";
            textBoxActualRevenue.Size = new Size(698, 23);
            textBoxActualRevenue.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.AutoSize = true;
            panelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelButtons.Controls.Add(flowLayoutPanelButtons);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(13, 539);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(0, 10, 0, 0);
            panelButtons.Size = new Size(877, 51);
            panelButtons.TabIndex = 3;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelButtons.Controls.Add(buttonCancel);
            flowLayoutPanelButtons.Controls.Add(buttonApply);
            flowLayoutPanelButtons.Dock = DockStyle.Fill;
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(0, 10);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Padding = new Padding(0, 0, 10, 0);
            flowLayoutPanelButtons.Size = new Size(877, 41);
            flowLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.None;
            buttonCancel.AutoSize = true;
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.Location = new Point(775, 3);
            buttonCancel.MinimumSize = new Size(80, 30);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(15, 5, 15, 5);
            buttonCancel.Size = new Size(89, 35);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.None;
            buttonApply.AutoSize = true;
            buttonApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApply.Location = new Point(659, 3);
            buttonApply.MinimumSize = new Size(90, 30);
            buttonApply.Name = "buttonApply";
            buttonApply.Padding = new Padding(15, 5, 15, 5);
            buttonApply.Size = new Size(110, 35);
            buttonApply.TabIndex = 2;
            buttonApply.Text = "Применить";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // RevenueTripForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(900, 600);
            Controls.Add(mainTableLayout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(600, 400);
            Name = "RevenueTripForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Финансовый учет: Фактическая выручка рейсов";
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            tableLayoutPanelFilter.ResumeLayout(false);
            tableLayoutPanelFilter.PerformLayout();
            panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTrips).EndInit();
            panelRevenueEdit.ResumeLayout(false);
            panelRevenueEdit.PerformLayout();
            tableLayoutPanelRevenue.ResumeLayout(false);
            tableLayoutPanelRevenue.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            flowLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private Panel panelFilter;
        private Panel panelTable;
        private Panel panelRevenueEdit;
        private Panel panelButtons;
        private TableLayoutPanel tableLayoutPanelFilter;
        private Label labelDate;
        private DateTimePicker dateTimePickerFilter;
        private Label labelRouteFilter;
        private ComboBox comboBoxRouteFilter;
        private Button buttonResetFilter;
        private Button buttonApplyFilter;
        private DataGridView dataGridViewTrips;
        private TableLayoutPanel tableLayoutPanelRevenue;
        private Label labelActualRevenue;
        private TextBox textBoxActualRevenue;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button buttonCancel;
        private Button buttonApply;
        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewTextBoxColumn colRoute;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colActualRevenue;
    }
}