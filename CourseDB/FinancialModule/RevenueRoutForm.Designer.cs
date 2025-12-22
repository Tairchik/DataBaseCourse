namespace FinancialModule
{
    partial class RevenueRoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevenueRoutForm));
            mainTableLayout = new TableLayoutPanel();
            panelFilter = new Panel();
            tableLayoutPanelFilter = new TableLayoutPanel();
            labelSearch = new Label();
            comboBoxSearch = new ComboBox();
            buttonApplyFilter = new Button();
            buttonResetFilter = new Button();
            panelTable = new Panel();
            dataGridViewRoutes = new DataGridView();
            colNumber = new DataGridViewTextBoxColumn();
            colRouteName = new DataGridViewTextBoxColumn();
            colPlannedRevenue = new DataGridViewTextBoxColumn();
            panelRevenueEdit = new Panel();
            tableLayoutPanelRevenue = new TableLayoutPanel();
            labelPlannedRevenue = new Label();
            textBoxPlannedRevenue = new TextBox();
            panelButtons = new Panel();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonApply = new Button();
            mainTableLayout.SuspendLayout();
            panelFilter.SuspendLayout();
            tableLayoutPanelFilter.SuspendLayout();
            panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoutes).BeginInit();
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
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 4;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainTableLayout.Size = new Size(800, 455);
            mainTableLayout.TabIndex = 0;
            // 
            // panelFilter
            // 
            panelFilter.AutoSize = true;
            panelFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelFilter.Controls.Add(tableLayoutPanelFilter);
            panelFilter.Dock = DockStyle.Fill;
            panelFilter.Location = new Point(3, 3);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(10);
            panelFilter.Size = new Size(794, 64);
            panelFilter.TabIndex = 0;
            // 
            // tableLayoutPanelFilter
            // 
            tableLayoutPanelFilter.AutoSize = true;
            tableLayoutPanelFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelFilter.ColumnCount = 4;
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFilter.Controls.Add(labelSearch, 0, 0);
            tableLayoutPanelFilter.Controls.Add(comboBoxSearch, 1, 0);
            tableLayoutPanelFilter.Controls.Add(buttonApplyFilter, 2, 0);
            tableLayoutPanelFilter.Controls.Add(buttonResetFilter, 3, 0);
            tableLayoutPanelFilter.Dock = DockStyle.Fill;
            tableLayoutPanelFilter.Location = new Point(10, 10);
            tableLayoutPanelFilter.Name = "tableLayoutPanelFilter";
            tableLayoutPanelFilter.RowCount = 1;
            tableLayoutPanelFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelFilter.Size = new Size(774, 44);
            tableLayoutPanelFilter.TabIndex = 0;
            // 
            // labelSearch
            // 
            labelSearch.Anchor = AnchorStyles.Left;
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(3, 14);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(63, 15);
            labelSearch.TabIndex = 0;
            labelSearch.Text = "Маршрут:";
            labelSearch.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxSearch
            // 
            comboBoxSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxSearch.FormattingEnabled = true;
            comboBoxSearch.Location = new Point(72, 10);
            comboBoxSearch.Name = "comboBoxSearch";
            comboBoxSearch.Size = new Size(486, 23);
            comboBoxSearch.TabIndex = 1;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.Anchor = AnchorStyles.Left;
            buttonApplyFilter.AutoSize = true;
            buttonApplyFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApplyFilter.Location = new Point(564, 9);
            buttonApplyFilter.Margin = new Padding(3, 3, 10, 3);
            buttonApplyFilter.Name = "buttonApplyFilter";
            buttonApplyFilter.Size = new Size(80, 25);
            buttonApplyFilter.TabIndex = 2;
            buttonApplyFilter.Text = "Применить";
            buttonApplyFilter.UseVisualStyleBackColor = true;
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // buttonResetFilter
            // 
            buttonResetFilter.Anchor = AnchorStyles.Left;
            buttonResetFilter.AutoSize = true;
            buttonResetFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonResetFilter.Location = new Point(657, 9);
            buttonResetFilter.Name = "buttonResetFilter";
            buttonResetFilter.Size = new Size(114, 25);
            buttonResetFilter.TabIndex = 3;
            buttonResetFilter.Text = "Сбросить фильтр";
            buttonResetFilter.UseVisualStyleBackColor = true;
            buttonResetFilter.Click += buttonResetFilter_Click;
            // 
            // panelTable
            // 
            panelTable.AutoSize = true;
            panelTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTable.Controls.Add(dataGridViewRoutes);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Location = new Point(3, 73);
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(10);
            panelTable.Size = new Size(794, 229);
            panelTable.TabIndex = 1;
            // 
            // dataGridViewRoutes
            // 
            dataGridViewRoutes.AllowUserToAddRows = false;
            dataGridViewRoutes.AllowUserToDeleteRows = false;
            dataGridViewRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRoutes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRoutes.Columns.AddRange(new DataGridViewColumn[] { colNumber, colRouteName, colPlannedRevenue });
            dataGridViewRoutes.Dock = DockStyle.Fill;
            dataGridViewRoutes.Location = new Point(10, 10);
            dataGridViewRoutes.Name = "dataGridViewRoutes";
            dataGridViewRoutes.ReadOnly = true;
            dataGridViewRoutes.RowHeadersVisible = false;
            dataGridViewRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRoutes.Size = new Size(774, 209);
            dataGridViewRoutes.TabIndex = 0;
            dataGridViewRoutes.SelectionChanged += dataGridViewRoutes_SelectionChanged;
            // 
            // colNumber
            // 
            colNumber.HeaderText = "№";
            colNumber.Name = "colNumber";
            colNumber.ReadOnly = true;
            // 
            // colRouteName
            // 
            colRouteName.DataPropertyName = "NameRoute";
            colRouteName.HeaderText = "Название маршрута";
            colRouteName.Name = "colRouteName";
            colRouteName.ReadOnly = true;
            // 
            // colPlannedRevenue
            // 
            colPlannedRevenue.DataPropertyName = "Revenue";
            colPlannedRevenue.HeaderText = "Плановая выручка";
            colPlannedRevenue.Name = "colPlannedRevenue";
            colPlannedRevenue.ReadOnly = true;
            // 
            // panelRevenueEdit
            // 
            panelRevenueEdit.Controls.Add(tableLayoutPanelRevenue);
            panelRevenueEdit.Dock = DockStyle.Fill;
            panelRevenueEdit.Location = new Point(3, 308);
            panelRevenueEdit.Name = "panelRevenueEdit";
            panelRevenueEdit.Padding = new Padding(10);
            panelRevenueEdit.Size = new Size(794, 74);
            panelRevenueEdit.TabIndex = 2;
            // 
            // tableLayoutPanelRevenue
            // 
            tableLayoutPanelRevenue.AutoSize = true;
            tableLayoutPanelRevenue.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelRevenue.ColumnCount = 2;
            tableLayoutPanelRevenue.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelRevenue.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelRevenue.Controls.Add(labelPlannedRevenue, 0, 0);
            tableLayoutPanelRevenue.Controls.Add(textBoxPlannedRevenue, 1, 0);
            tableLayoutPanelRevenue.Dock = DockStyle.Fill;
            tableLayoutPanelRevenue.Location = new Point(10, 10);
            tableLayoutPanelRevenue.Name = "tableLayoutPanelRevenue";
            tableLayoutPanelRevenue.RowCount = 1;
            tableLayoutPanelRevenue.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelRevenue.Size = new Size(774, 54);
            tableLayoutPanelRevenue.TabIndex = 0;
            // 
            // labelPlannedRevenue
            // 
            labelPlannedRevenue.Anchor = AnchorStyles.Left;
            labelPlannedRevenue.AutoSize = true;
            labelPlannedRevenue.Location = new Point(3, 19);
            labelPlannedRevenue.Name = "labelPlannedRevenue";
            labelPlannedRevenue.Size = new Size(114, 15);
            labelPlannedRevenue.TabIndex = 0;
            labelPlannedRevenue.Text = "Плановая выручка:";
            // 
            // textBoxPlannedRevenue
            // 
            textBoxPlannedRevenue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPlannedRevenue.Location = new Point(123, 15);
            textBoxPlannedRevenue.Name = "textBoxPlannedRevenue";
            textBoxPlannedRevenue.Size = new Size(648, 23);
            textBoxPlannedRevenue.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.AutoSize = true;
            panelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelButtons.Controls.Add(flowLayoutPanelButtons);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(3, 388);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(0, 10, 0, 0);
            panelButtons.Size = new Size(794, 64);
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
            flowLayoutPanelButtons.Size = new Size(794, 54);
            flowLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.None;
            buttonCancel.AutoSize = true;
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.Location = new Point(701, 3);
            buttonCancel.MinimumSize = new Size(80, 30);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(10, 5, 10, 5);
            buttonCancel.Size = new Size(80, 35);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Выйти";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.None;
            buttonApply.AutoSize = true;
            buttonApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApply.Location = new Point(595, 3);
            buttonApply.MinimumSize = new Size(90, 30);
            buttonApply.Name = "buttonApply";
            buttonApply.Padding = new Padding(10, 5, 10, 5);
            buttonApply.Size = new Size(100, 35);
            buttonApply.TabIndex = 2;
            buttonApply.Text = "Применить";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // RevenueRoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 455);
            Controls.Add(mainTableLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(816, 464);
            Name = "RevenueRoutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Финансовый учет: Плановая выручка маршрутов";
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            tableLayoutPanelFilter.ResumeLayout(false);
            tableLayoutPanelFilter.PerformLayout();
            panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoutes).EndInit();
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
        private Label labelSearch;
        private ComboBox comboBoxSearch;
        private Button buttonApplyFilter;
        private Button buttonResetFilter;
        private DataGridView dataGridViewRoutes;
        private TableLayoutPanel tableLayoutPanelRevenue;
        private Label labelPlannedRevenue;
        private TextBox textBoxPlannedRevenue;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button buttonCancel;
        private Button buttonApply;
        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewTextBoxColumn colRouteName;
        private DataGridViewTextBoxColumn colPlannedRevenue;
    }
}