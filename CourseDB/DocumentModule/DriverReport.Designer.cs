namespace DocumentModule
{
    partial class DriverReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverReportForm));
            mainLayout = new TableLayoutPanel();
            grpFilters = new GroupBox();
            flowFilters = new FlowLayoutPanel();
            lblRoute = new Label();
            cmbRouteFilter = new ComboBox();
            lblClass = new Label();
            cmbClassFilter = new ComboBox();
            btnApply = new Button();
            btnReset = new Button();
            dgvDrivers = new DataGridView();
            colSurname = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPatronymic = new DataGridViewTextBoxColumn();
            colRoute = new DataGridViewTextBoxColumn();
            colStartTime = new DataGridViewTextBoxColumn();
            colExp = new DataGridViewTextBoxColumn();
            colClass = new DataGridViewTextBoxColumn();
            bottomPanel = new TableLayoutPanel();
            statusStrip = new StatusStrip();
            lblCount = new ToolStripStatusLabel();
            lblMaxExp = new ToolStripStatusLabel();
            btnExit = new Button();
            mainLayout.SuspendLayout();
            grpFilters.SuspendLayout();
            flowFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).BeginInit();
            bottomPanel.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            mainLayout.Controls.Add(grpFilters, 0, 0);
            mainLayout.Controls.Add(dgvDrivers, 0, 1);
            mainLayout.Controls.Add(bottomPanel, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.Size = new Size(800, 500);
            mainLayout.TabIndex = 0;
            // 
            // grpFilters
            // 
            grpFilters.AutoSize = true;
            grpFilters.Controls.Add(flowFilters);
            grpFilters.Dock = DockStyle.Fill;
            grpFilters.Location = new Point(3, 3);
            grpFilters.Name = "grpFilters";
            grpFilters.Size = new Size(794, 53);
            grpFilters.TabIndex = 0;
            grpFilters.TabStop = false;
            grpFilters.Text = "Фильтр";
            // 
            // flowFilters
            // 
            flowFilters.AutoSize = true;
            flowFilters.Controls.Add(lblRoute);
            flowFilters.Controls.Add(cmbRouteFilter);
            flowFilters.Controls.Add(lblClass);
            flowFilters.Controls.Add(cmbClassFilter);
            flowFilters.Controls.Add(btnApply);
            flowFilters.Controls.Add(btnReset);
            flowFilters.Dock = DockStyle.Fill;
            flowFilters.Location = new Point(3, 19);
            flowFilters.Name = "flowFilters";
            flowFilters.Size = new Size(788, 31);
            flowFilters.TabIndex = 0;
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Location = new Point(3, 8);
            lblRoute.Margin = new Padding(3, 8, 3, 0);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(63, 15);
            lblRoute.TabIndex = 0;
            lblRoute.Text = "Маршрут:";
            lblRoute.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbRouteFilter
            // 
            cmbRouteFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRouteFilter.Location = new Point(72, 3);
            cmbRouteFilter.Name = "cmbRouteFilter";
            cmbRouteFilter.Size = new Size(150, 23);
            cmbRouteFilter.TabIndex = 1;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(235, 8);
            lblClass.Margin = new Padding(10, 8, 3, 0);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(42, 15);
            lblClass.TabIndex = 2;
            lblClass.Text = "Класс:";
            lblClass.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbClassFilter
            // 
            cmbClassFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassFilter.Location = new Point(283, 3);
            cmbClassFilter.Name = "cmbClassFilter";
            cmbClassFilter.Size = new Size(80, 23);
            cmbClassFilter.TabIndex = 3;
            // 
            // btnApply
            // 
            btnApply.AutoSize = true;
            btnApply.Location = new Point(369, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(80, 25);
            btnApply.TabIndex = 4;
            btnApply.Text = "Применить";
            btnApply.Click += btnApply_Click;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Location = new Point(455, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 25);
            btnReset.TabIndex = 5;
            btnReset.Text = "Сбросить";
            btnReset.Click += btnReset_Click;
            // 
            // dgvDrivers
            // 
            dgvDrivers.AllowUserToAddRows = false;
            dgvDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDrivers.Columns.AddRange(new DataGridViewColumn[] { colSurname, colName, colPatronymic, colRoute, colStartTime, colExp, colClass });
            dgvDrivers.Dock = DockStyle.Fill;
            dgvDrivers.Location = new Point(3, 62);
            dgvDrivers.Name = "dgvDrivers";
            dgvDrivers.ReadOnly = true;
            dgvDrivers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrivers.Size = new Size(794, 399);
            dgvDrivers.TabIndex = 1;
            // 
            // colSurname
            // 
            colSurname.HeaderText = "Фамилия";
            colSurname.Name = "colSurname";
            colSurname.ReadOnly = true;
            // 
            // colName
            // 
            colName.HeaderText = "Имя";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPatronymic
            // 
            colPatronymic.HeaderText = "Отчество";
            colPatronymic.Name = "colPatronymic";
            colPatronymic.ReadOnly = true;
            // 
            // colRoute
            // 
            colRoute.HeaderText = "№ Маршрута";
            colRoute.Name = "colRoute";
            colRoute.ReadOnly = true;
            // 
            // colStartTime
            // 
            colStartTime.HeaderText = "Начало движ.";
            colStartTime.Name = "colStartTime";
            colStartTime.ReadOnly = true;
            // 
            // colExp
            // 
            colExp.HeaderText = "Стаж";
            colExp.Name = "colExp";
            colExp.ReadOnly = true;
            // 
            // colClass
            // 
            colClass.HeaderText = "Класс";
            colClass.Name = "colClass";
            colClass.ReadOnly = true;
            // 
            // bottomPanel
            // 
            bottomPanel.AutoSize = true;
            bottomPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bottomPanel.ColumnCount = 2;
            bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bottomPanel.ColumnStyles.Add(new ColumnStyle());
            bottomPanel.Controls.Add(statusStrip, 0, 0);
            bottomPanel.Controls.Add(btnExit, 1, 0);
            bottomPanel.Dock = DockStyle.Fill;
            bottomPanel.Location = new Point(3, 467);
            bottomPanel.MinimumSize = new Size(0, 30);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            bottomPanel.Size = new Size(794, 30);
            bottomPanel.TabIndex = 2;
            // 
            // statusStrip
            // 
            statusStrip.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            statusStrip.Dock = DockStyle.None;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblCount, lblMaxExp });
            statusStrip.Location = new Point(0, 4);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(736, 22);
            statusStrip.TabIndex = 0;
            // 
            // lblCount
            // 
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 17);
            // 
            // lblMaxExp
            // 
            lblMaxExp.Name = "lblMaxExp";
            lblMaxExp.Size = new Size(0, 17);
            // 
            // btnExit
            // 
            btnExit.AutoSize = true;
            btnExit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExit.Location = new Point(739, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(52, 24);
            btnExit.TabIndex = 1;
            btnExit.Text = "Выйти";
            btnExit.Click += btnExit_Click;
            // 
            // DriverReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(mainLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DriverReportForm";
            Text = "Документы: Отчет по водителям";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            grpFilters.ResumeLayout(false);
            grpFilters.PerformLayout();
            flowFilters.ResumeLayout(false);
            flowFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).EndInit();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private GroupBox grpFilters;
        private FlowLayoutPanel flowFilters;
        private Label lblRoute;
        private ComboBox cmbRouteFilter;
        private Label lblClass;
        private ComboBox cmbClassFilter;
        private Button btnApply;
        private Button btnReset;
        private DataGridView dgvDrivers;
        private TableLayoutPanel bottomPanel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblCount;
        private ToolStripStatusLabel lblMaxExp;
        private Button btnExit;
        // Колонки
        private DataGridViewTextBoxColumn colSurname;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPatronymic;
        private DataGridViewTextBoxColumn colRoute;
        private DataGridViewTextBoxColumn colStartTime;
        private DataGridViewTextBoxColumn colExp;
        private DataGridViewTextBoxColumn colClass;

    }
}
#endregion