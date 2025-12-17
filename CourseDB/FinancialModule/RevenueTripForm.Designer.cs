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
            mainTableLayout = new TableLayoutPanel();
            panelFilter = new Panel();
            tableLayoutPanelFilter = new TableLayoutPanel();
            labelDate = new Label();
            dateTimePickerFilter = new DateTimePicker();
            labelRouteFilter = new Label();
            comboBoxRouteFilter = new ComboBox();
            buttonResetFilter = new Button();
            buttonApplyFilter = new Button();
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
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.Controls.Add(panelFilter, 0, 0);
            mainTableLayout.Controls.Add(panelTable, 0, 1);
            mainTableLayout.Controls.Add(panelRevenueEdit, 0, 2);
            mainTableLayout.Controls.Add(panelButtons, 0, 3);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 4;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainTableLayout.Size = new Size(900, 600);
            mainTableLayout.TabIndex = 0;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(tableLayoutPanelFilter);
            panelFilter.Dock = DockStyle.Fill;
            panelFilter.Location = new Point(3, 3);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(10);
            panelFilter.Size = new Size(894, 64);
            panelFilter.TabIndex = 0;
            // 
            // tableLayoutPanelFilter
            // 
            tableLayoutPanelFilter.ColumnCount = 6;
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.Controls.Add(labelDate, 0, 0);
            tableLayoutPanelFilter.Controls.Add(dateTimePickerFilter, 1, 0);
            tableLayoutPanelFilter.Controls.Add(labelRouteFilter, 2, 0);
            tableLayoutPanelFilter.Controls.Add(comboBoxRouteFilter, 3, 0);
            tableLayoutPanelFilter.Controls.Add(buttonResetFilter, 4, 0);
            tableLayoutPanelFilter.Controls.Add(buttonApplyFilter, 5, 0);
            tableLayoutPanelFilter.Dock = DockStyle.Fill;
            tableLayoutPanelFilter.Location = new Point(10, 10);
            tableLayoutPanelFilter.Name = "tableLayoutPanelFilter";
            tableLayoutPanelFilter.RowCount = 1;
            tableLayoutPanelFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelFilter.Size = new Size(874, 44);
            tableLayoutPanelFilter.TabIndex = 0;
            // 
            // labelDate
            // 
            labelDate.Anchor = AnchorStyles.Left;
            labelDate.AutoSize = true;
            labelDate.Location = new Point(3, 14);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(35, 15);
            labelDate.TabIndex = 0;
            labelDate.Text = "Дата:";
            // 
            // dateTimePickerFilter
            // 
            dateTimePickerFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dateTimePickerFilter.Format = DateTimePickerFormat.Short;
            dateTimePickerFilter.Location = new Point(44, 10);
            dateTimePickerFilter.Name = "dateTimePickerFilter";
            dateTimePickerFilter.Size = new Size(114, 23);
            dateTimePickerFilter.TabIndex = 1;
            // 
            // labelRouteFilter
            // 
            labelRouteFilter.Anchor = AnchorStyles.Left;
            labelRouteFilter.AutoSize = true;
            labelRouteFilter.Location = new Point(164, 14);
            labelRouteFilter.Margin = new Padding(3, 0, 10, 0);
            labelRouteFilter.Name = "labelRouteFilter";
            labelRouteFilter.Size = new Size(63, 15);
            labelRouteFilter.TabIndex = 2;
            labelRouteFilter.Text = "Маршрут:";
            // 
            // comboBoxRouteFilter
            // 
            comboBoxRouteFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxRouteFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxRouteFilter.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxRouteFilter.FormattingEnabled = true;
            comboBoxRouteFilter.Location = new Point(240, 10);
            comboBoxRouteFilter.Name = "comboBoxRouteFilter";
            comboBoxRouteFilter.Size = new Size(392, 23);
            comboBoxRouteFilter.TabIndex = 3;
            // 
            // buttonResetFilter
            // 
            buttonResetFilter.Anchor = AnchorStyles.Right;
            buttonResetFilter.AutoSize = true;
            buttonResetFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonResetFilter.Location = new Point(638, 9);
            buttonResetFilter.Margin = new Padding(3, 3, 10, 3);
            buttonResetFilter.MinimumSize = new Size(100, 25);
            buttonResetFilter.Name = "buttonResetFilter";
            buttonResetFilter.Size = new Size(100, 25);
            buttonResetFilter.TabIndex = 4;
            buttonResetFilter.Text = "Сбросить фильтр";
            buttonResetFilter.UseVisualStyleBackColor = true;
            buttonResetFilter.Click += buttonResetFilter_Click;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.Anchor = AnchorStyles.Right;
            buttonApplyFilter.AutoSize = true;
            buttonApplyFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApplyFilter.Location = new Point(751, 9);
            buttonApplyFilter.MinimumSize = new Size(80, 25);
            buttonApplyFilter.Name = "buttonApplyFilter";
            buttonApplyFilter.Size = new Size(80, 25);
            buttonApplyFilter.TabIndex = 5;
            buttonApplyFilter.Text = "Применить";
            buttonApplyFilter.UseVisualStyleBackColor = true;
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // panelTable
            // 
            panelTable.Controls.Add(dataGridViewTrips);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Location = new Point(3, 73);
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(10);
            panelTable.Size = new Size(894, 374);
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
            dataGridViewTrips.Location = new Point(10, 10);
            dataGridViewTrips.Name = "dataGridViewTrips";
            dataGridViewTrips.ReadOnly = true;
            dataGridViewTrips.RowHeadersVisible = false;
            dataGridViewTrips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTrips.Size = new Size(874, 354);
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
            colDate.FillWeight = 100F;
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
            panelRevenueEdit.Controls.Add(tableLayoutPanelRevenue);
            panelRevenueEdit.Dock = DockStyle.Fill;
            panelRevenueEdit.Location = new Point(3, 453);
            panelRevenueEdit.Name = "panelRevenueEdit";
            panelRevenueEdit.Padding = new Padding(10);
            panelRevenueEdit.Size = new Size(894, 74);
            panelRevenueEdit.TabIndex = 2;
            // 
            // tableLayoutPanelRevenue
            // 
            tableLayoutPanelRevenue.ColumnCount = 2;
            tableLayoutPanelRevenue.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanelRevenue.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelRevenue.Controls.Add(labelActualRevenue, 0, 0);
            tableLayoutPanelRevenue.Controls.Add(textBoxActualRevenue, 1, 0);
            tableLayoutPanelRevenue.Dock = DockStyle.Fill;
            tableLayoutPanelRevenue.Location = new Point(10, 10);
            tableLayoutPanelRevenue.Name = "tableLayoutPanelRevenue";
            tableLayoutPanelRevenue.RowCount = 1;
            tableLayoutPanelRevenue.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelRevenue.Size = new Size(874, 54);
            tableLayoutPanelRevenue.TabIndex = 0;
            // 
            // labelActualRevenue
            // 
            labelActualRevenue.Anchor = AnchorStyles.Left;
            labelActualRevenue.AutoSize = true;
            labelActualRevenue.Location = new Point(3, 19);
            labelActualRevenue.Name = "labelActualRevenue";
            labelActualRevenue.Size = new Size(130, 15);
            labelActualRevenue.TabIndex = 0;
            labelActualRevenue.Text = "Фактическая выручка:";
            // 
            // textBoxActualRevenue
            // 
            textBoxActualRevenue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxActualRevenue.Location = new Point(153, 15);
            textBoxActualRevenue.Name = "textBoxActualRevenue";
            textBoxActualRevenue.Size = new Size(718, 23);
            textBoxActualRevenue.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(flowLayoutPanelButtons);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(3, 533);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10);
            panelButtons.Size = new Size(894, 64);
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
            flowLayoutPanelButtons.Location = new Point(10, 10);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Size = new Size(874, 44);
            flowLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.AutoSize = true;
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.Location = new Point(791, 9);
            buttonCancel.MinimumSize = new Size(80, 30);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(10, 5, 10, 5);
            buttonCancel.Size = new Size(80, 30);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonApply.AutoSize = true;
            buttonApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApply.Location = new Point(685, 9);
            buttonApply.MinimumSize = new Size(90, 30);
            buttonApply.Name = "buttonApply";
            buttonApply.Padding = new Padding(10, 5, 10, 5);
            buttonApply.Size = new Size(100, 30);
            buttonApply.TabIndex = 2;
            buttonApply.Text = "Применить";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // RevenueTripForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(mainTableLayout);
            MinimumSize = new Size(916, 639);
            Name = "RevenueTripForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Фактическая выручка рейсов";
            mainTableLayout.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            tableLayoutPanelFilter.ResumeLayout(false);
            tableLayoutPanelFilter.PerformLayout();
            panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTrips).EndInit();
            panelRevenueEdit.ResumeLayout(false);
            tableLayoutPanelRevenue.ResumeLayout(false);
            tableLayoutPanelRevenue.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            flowLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
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