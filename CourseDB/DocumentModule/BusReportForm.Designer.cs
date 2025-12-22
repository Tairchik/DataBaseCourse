using System.Windows.Forms;
using System.Drawing;

namespace DocumentModule
{
    partial class BusReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusReportForm));
            mainLayout = new TableLayoutPanel();
            grpFilters = new GroupBox();
            flowFilters = new FlowLayoutPanel();
            lblModel = new Label();
            cmbModel = new ComboBox();
            btnApply = new Button();
            btnReset = new Button();
            dgvBuses = new DataGridView();
            colRegNum = new DataGridViewTextBoxColumn();
            colRoute = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            bottomPanel = new TableLayoutPanel();
            statusStrip = new StatusStrip();
            lblCount = new ToolStripStatusLabel();
            btnExit = new Button();
            mainLayout.SuspendLayout();
            grpFilters.SuspendLayout();
            flowFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBuses).BeginInit();
            bottomPanel.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            mainLayout.Controls.Add(grpFilters, 0, 0);
            mainLayout.Controls.Add(dgvBuses, 0, 1);
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
            flowFilters.Controls.Add(lblModel);
            flowFilters.Controls.Add(cmbModel);
            flowFilters.Controls.Add(btnApply);
            flowFilters.Controls.Add(btnReset);
            flowFilters.Dock = DockStyle.Fill;
            flowFilters.Location = new Point(3, 19);
            flowFilters.Name = "flowFilters";
            flowFilters.Size = new Size(788, 31);
            flowFilters.TabIndex = 0;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new Point(3, 8);
            lblModel.Margin = new Padding(3, 8, 3, 0);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(53, 15);
            lblModel.TabIndex = 0;
            lblModel.Text = "Модель:";
            lblModel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbModel
            // 
            cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModel.Location = new Point(62, 3);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(150, 23);
            cmbModel.TabIndex = 1;
            // 
            // btnApply
            // 
            btnApply.AutoSize = true;
            btnApply.Location = new Point(218, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(80, 25);
            btnApply.TabIndex = 2;
            btnApply.Text = "Применить";
            btnApply.Click += btnApply_Click;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Location = new Point(304, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 25);
            btnReset.TabIndex = 3;
            btnReset.Text = "Сбросить";
            btnReset.Click += btnReset_Click;
            // 
            // dgvBuses
            // 
            dgvBuses.AllowUserToAddRows = false;
            dgvBuses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBuses.Columns.AddRange(new DataGridViewColumn[] { colRegNum, colRoute, colStatus });
            dgvBuses.Dock = DockStyle.Fill;
            dgvBuses.Location = new Point(3, 62);
            dgvBuses.Name = "dgvBuses";
            dgvBuses.ReadOnly = true;
            dgvBuses.Size = new Size(794, 399);
            dgvBuses.TabIndex = 1;
            // 
            // colRegNum
            // 
            colRegNum.HeaderText = "Регистрационный номер";
            colRegNum.Name = "colRegNum";
            colRegNum.ReadOnly = true;
            // 
            // colRoute
            // 
            colRoute.HeaderText = "Маршрут";
            colRoute.Name = "colRoute";
            colRoute.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Статус";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // bottomPanel
            // 
            bottomPanel.AutoSize = true;
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
            statusStrip.Dock = DockStyle.Fill;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblCount });
            statusStrip.Location = new Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(713, 30);
            statusStrip.TabIndex = 0;
            // 
            // lblCount
            // 
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 25);
            // 
            // btnExit
            // 
            btnExit.AutoSize = true;
            btnExit.Location = new Point(716, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 24);
            btnExit.TabIndex = 1;
            btnExit.Text = "Выйти";
            btnExit.Click += btnExit_Click;
            // 
            // BusReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(mainLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BusReportForm";
            Text = "Документы: Отчет по автобусам";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            grpFilters.ResumeLayout(false);
            grpFilters.PerformLayout();
            flowFilters.ResumeLayout(false);
            flowFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBuses).EndInit();
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
        private Label lblModel;
        private ComboBox cmbModel;
        private Button btnApply;
        private Button btnReset;
        private DataGridView dgvBuses;
        private DataGridViewTextBoxColumn colRegNum;
        private DataGridViewTextBoxColumn colRoute;
        private DataGridViewTextBoxColumn colStatus;
        private TableLayoutPanel bottomPanel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblCount;
        private Button btnExit;
    }
}