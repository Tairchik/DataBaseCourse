namespace TripModule
{
    partial class SelectEmployeeForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Panel searchPanel;
        private Panel tablePanel;
        private Panel bottomPanel;
        private Label lblSearch;
        private TextBox searchTextBox;
        private Button btnApply;
        private Button btnReset;
        private DataGridView employeesDataGridView;
        private Button btnSelect;
        private Button btnCancel;
        private Label lblCount;

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
            mainLayout = new TableLayoutPanel();
            searchPanel = new Panel();
            tablePanel = new Panel();
            bottomPanel = new Panel();
            lblSearch = new Label();
            searchTextBox = new TextBox();
            btnApply = new Button();
            btnReset = new Button();
            employeesDataGridView = new DataGridView();
            btnSelect = new Button();
            btnCancel = new Button();
            lblCount = new Label();
            mainLayout.SuspendLayout();
            searchPanel.SuspendLayout();
            tablePanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(searchPanel, 0, 0);
            mainLayout.Controls.Add(tablePanel, 0, 1);
            mainLayout.Controls.Add(bottomPanel, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainLayout.Size = new Size(800, 600);
            mainLayout.TabIndex = 0;
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(lblCount);
            searchPanel.Controls.Add(btnReset);
            searchPanel.Controls.Add(btnApply);
            searchPanel.Controls.Add(searchTextBox);
            searchPanel.Controls.Add(lblSearch);
            searchPanel.Dock = DockStyle.Fill;
            searchPanel.Location = new Point(3, 3);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(10);
            searchPanel.Size = new Size(794, 54);
            searchPanel.TabIndex = 0;
            // 
            // tablePanel
            // 
            tablePanel.Controls.Add(employeesDataGridView);
            tablePanel.Dock = DockStyle.Fill;
            tablePanel.Location = new Point(3, 63);
            tablePanel.Name = "tablePanel";
            tablePanel.Padding = new Padding(10);
            tablePanel.Size = new Size(794, 464);
            tablePanel.TabIndex = 1;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(btnCancel);
            bottomPanel.Controls.Add(btnSelect);
            bottomPanel.Dock = DockStyle.Fill;
            bottomPanel.Location = new Point(3, 533);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(10);
            bottomPanel.Size = new Size(794, 64);
            bottomPanel.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Left;
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(99, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Поиск по ФИО:";
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Location = new Point(115, 15);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(400, 23);
            searchTextBox.TabIndex = 1;
            searchTextBox.KeyDown += searchTextBox_KeyDown;
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.Right;
            btnApply.Location = new Point(521, 15);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(80, 23);
            btnApply.TabIndex = 2;
            btnApply.Text = "Применить";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Right;
            btnReset.Location = new Point(607, 15);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 23);
            btnReset.TabIndex = 3;
            btnReset.Text = "Сбросить";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // employeesDataGridView
            // 
            employeesDataGridView.AllowUserToAddRows = false;
            employeesDataGridView.AllowUserToDeleteRows = false;
            employeesDataGridView.AllowUserToResizeRows = false;
            employeesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            employeesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeesDataGridView.Dock = DockStyle.Fill;
            employeesDataGridView.Location = new Point(10, 10);
            employeesDataGridView.MultiSelect = false;
            employeesDataGridView.Name = "employeesDataGridView";
            employeesDataGridView.ReadOnly = true;
            employeesDataGridView.RowHeadersVisible = false;
            employeesDataGridView.RowTemplate.Height = 25;
            employeesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeesDataGridView.Size = new Size(774, 444);
            employeesDataGridView.TabIndex = 0;
            employeesDataGridView.CellDoubleClick += employeesDataGridView_CellDoubleClick;
            // 
            // btnSelect
            // 
            btnSelect.Anchor = AnchorStyles.Right;
            btnSelect.Location = new Point(554, 20);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(100, 30);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "Выбрать";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.Location = new Point(660, 20);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblCount
            // 
            lblCount.Anchor = AnchorStyles.Right;
            lblCount.AutoSize = true;
            lblCount.Location = new Point(693, 18);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(67, 15);
            lblCount.TabIndex = 4;
            lblCount.Text = "Найдено: 0";
            // 
            // SelectEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(mainLayout);
            MinimumSize = new Size(816, 639);
            Name = "SelectEmployeeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Выберите сотрудника";
            mainLayout.ResumeLayout(false);
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            tablePanel.ResumeLayout(false);
            bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)employeesDataGridView).EndInit();
            ResumeLayout(false);
        }
    }
}