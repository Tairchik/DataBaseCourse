using System.Windows.Forms;
using System.Drawing;

namespace DocumentModule
{
    partial class RoutReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoutReportForm));
            mainLayout = new TableLayoutPanel();
            grpFilters = new GroupBox();
            flowFilters = new FlowLayoutPanel();
            lblStation = new Label();
            cmbEndStation = new ComboBox();
            btnApply = new Button();
            btnReset = new Button();
            dgvRoutes = new DataGridView();
            colRoute = new DataGridViewTextBoxColumn();
            colStart = new DataGridViewTextBoxColumn();
            colEnd = new DataGridViewTextBoxColumn();
            colTimeStart = new DataGridViewTextBoxColumn();
            colTimeEnd = new DataGridViewTextBoxColumn();
            btnHelp = new Button();
            bottomPanel = new TableLayoutPanel();
            statusStrip = new StatusStrip();
            lblTotalDistance = new ToolStripStatusLabel();
            btnExit = new Button();
            mainLayout.SuspendLayout();
            grpFilters.SuspendLayout();
            flowFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoutes).BeginInit();
            bottomPanel.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            mainLayout.Controls.Add(grpFilters, 0, 0);
            mainLayout.Controls.Add(dgvRoutes, 0, 1);
            mainLayout.Controls.Add(btnHelp, 0, 2);
            mainLayout.Controls.Add(bottomPanel, 0, 3);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 4;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.Size = new Size(800, 548);
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
            flowFilters.Controls.Add(lblStation);
            flowFilters.Controls.Add(cmbEndStation);
            flowFilters.Controls.Add(btnApply);
            flowFilters.Controls.Add(btnReset);
            flowFilters.Dock = DockStyle.Fill;
            flowFilters.Location = new Point(3, 19);
            flowFilters.Name = "flowFilters";
            flowFilters.Size = new Size(788, 31);
            flowFilters.TabIndex = 0;
            // 
            // lblStation
            // 
            lblStation.AutoSize = true;
            lblStation.Location = new Point(3, 8);
            lblStation.Margin = new Padding(3, 8, 3, 0);
            lblStation.Name = "lblStation";
            lblStation.Size = new Size(122, 15);
            lblStation.TabIndex = 0;
            lblStation.Text = "Конечная остановка:";
            lblStation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbEndStation
            // 
            cmbEndStation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEndStation.Location = new Point(131, 3);
            cmbEndStation.Name = "cmbEndStation";
            cmbEndStation.Size = new Size(200, 23);
            cmbEndStation.TabIndex = 1;
            // 
            // btnApply
            // 
            btnApply.AutoSize = true;
            btnApply.Location = new Point(337, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(80, 25);
            btnApply.TabIndex = 2;
            btnApply.Text = "Применить";
            btnApply.Click += btnApply_Click;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Location = new Point(423, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 25);
            btnReset.TabIndex = 3;
            btnReset.Text = "Сбросить";
            btnReset.Click += btnReset_Click;
            // 
            // dgvRoutes
            // 
            dgvRoutes.AllowUserToAddRows = false;
            dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoutes.Columns.AddRange(new DataGridViewColumn[] { colRoute, colStart, colEnd, colTimeStart, colTimeEnd });
            dgvRoutes.Dock = DockStyle.Fill;
            dgvRoutes.Location = new Point(3, 62);
            dgvRoutes.Name = "dgvRoutes";
            dgvRoutes.ReadOnly = true;
            dgvRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoutes.Size = new Size(794, 412);
            dgvRoutes.TabIndex = 1;
            // 
            // colRoute
            // 
            colRoute.HeaderText = "Маршрут";
            colRoute.Name = "colRoute";
            colRoute.ReadOnly = true;
            // 
            // colStart
            // 
            colStart.HeaderText = "Начальная остановка";
            colStart.Name = "colStart";
            colStart.ReadOnly = true;
            // 
            // colEnd
            // 
            colEnd.HeaderText = "Конечная остановка";
            colEnd.Name = "colEnd";
            colEnd.ReadOnly = true;
            // 
            // colTimeStart
            // 
            colTimeStart.HeaderText = "Начало движения";
            colTimeStart.Name = "colTimeStart";
            colTimeStart.ReadOnly = true;
            // 
            // colTimeEnd
            // 
            colTimeEnd.HeaderText = "Конец движения";
            colTimeEnd.Name = "colTimeEnd";
            colTimeEnd.ReadOnly = true;
            // 
            // btnHelp
            // 
            btnHelp.Anchor = AnchorStyles.Left;
            btnHelp.AutoSize = true;
            btnHelp.Location = new Point(3, 482);
            btnHelp.Margin = new Padding(3, 5, 3, 5);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(133, 25);
            btnHelp.TabIndex = 2;
            btnHelp.Text = "Справка о маршруте";
            btnHelp.Click += btnHelp_Click;
            // 
            // bottomPanel
            // 
            bottomPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bottomPanel.AutoSize = true;
            bottomPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bottomPanel.ColumnCount = 2;
            bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bottomPanel.ColumnStyles.Add(new ColumnStyle());
            bottomPanel.Controls.Add(statusStrip, 0, 0);
            bottomPanel.Controls.Add(btnExit, 1, 0);
            bottomPanel.Location = new Point(3, 515);
            bottomPanel.MinimumSize = new Size(0, 30);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            bottomPanel.Size = new Size(794, 30);
            bottomPanel.TabIndex = 3;
            // 
            // statusStrip
            // 
            statusStrip.Dock = DockStyle.Fill;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblTotalDistance });
            statusStrip.Location = new Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(685, 30);
            statusStrip.TabIndex = 0;
            // 
            // lblTotalDistance
            // 
            lblTotalDistance.Name = "lblTotalDistance";
            lblTotalDistance.Size = new Size(0, 25);
            // 
            // btnExit
            // 
            btnExit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExit.Location = new Point(688, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(103, 24);
            btnExit.TabIndex = 1;
            btnExit.Text = "Выйти";
            btnExit.Click += btnExit_Click;
            // 
            // RoutReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 548);
            Controls.Add(mainLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(816, 539);
            Name = "RoutReportForm";
            Text = "Документы: Отчет по маршрутам";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            grpFilters.ResumeLayout(false);
            grpFilters.PerformLayout();
            flowFilters.ResumeLayout(false);
            flowFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoutes).EndInit();
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
        private Label lblStation;
        private ComboBox cmbEndStation;
        private Button btnApply;
        private Button btnReset;
        private DataGridView dgvRoutes;
        private DataGridViewTextBoxColumn colRoute;
        private DataGridViewTextBoxColumn colStart;
        private DataGridViewTextBoxColumn colEnd;
        private DataGridViewTextBoxColumn colTimeStart;
        private DataGridViewTextBoxColumn colTimeEnd;
        private Button btnHelp;
        private TableLayoutPanel bottomPanel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblTotalDistance;
        private Button btnExit;
    }
}