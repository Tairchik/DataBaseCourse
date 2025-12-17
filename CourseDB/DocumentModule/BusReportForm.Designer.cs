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
            this.mainLayout = new TableLayoutPanel();
            this.grpFilters = new GroupBox();
            this.flowFilters = new FlowLayoutPanel();
            this.lblModel = new Label();
            this.cmbModel = new ComboBox();
            this.btnApply = new Button();
            this.btnReset = new Button();
            this.dgvBuses = new DataGridView();
            this.colRegNum = new DataGridViewTextBoxColumn();
            this.colRoute = new DataGridViewTextBoxColumn();
            this.colStatus = new DataGridViewTextBoxColumn();
            this.bottomPanel = new TableLayoutPanel();
            this.statusStrip = new StatusStrip();
            this.lblCount = new ToolStripStatusLabel();
            this.btnExit = new Button();

            this.mainLayout.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.flowFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.mainLayout.Controls.Add(this.grpFilters, 0, 0);
            this.mainLayout.Controls.Add(this.dgvBuses, 0, 1);
            this.mainLayout.Controls.Add(this.bottomPanel, 0, 2);

            // Фильтры
            this.grpFilters.Text = "Фильтр";
            this.grpFilters.Dock = DockStyle.Fill;
            this.grpFilters.AutoSize = true;
            this.grpFilters.Controls.Add(this.flowFilters);

            this.flowFilters.Dock = DockStyle.Fill;
            this.flowFilters.AutoSize = true;
            this.flowFilters.Controls.Add(this.lblModel);
            this.flowFilters.Controls.Add(this.cmbModel);
            this.flowFilters.Controls.Add(this.btnApply);
            this.flowFilters.Controls.Add(this.btnReset);

            this.lblModel.Text = "Модель:";
            this.lblModel.AutoSize = true;
            this.lblModel.TextAlign = ContentAlignment.MiddleLeft;
            this.lblModel.Margin = new Padding(3, 8, 3, 0);

            this.cmbModel.Width = 150;
            this.cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnApply.Text = "Применить";
            this.btnApply.AutoSize = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);

            this.btnReset.Text = "Сбросить";
            this.btnReset.AutoSize = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // Таблица
            this.dgvBuses.Dock = DockStyle.Fill;
            this.dgvBuses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuses.AllowUserToAddRows = false;
            this.dgvBuses.ReadOnly = true;
            this.dgvBuses.Columns.AddRange(new DataGridViewColumn[] {
                this.colRegNum, this.colRoute, this.colStatus
            });

            this.colRegNum.HeaderText = "Регистрационный номер";
            this.colRoute.HeaderText = "Маршрут";
            this.colStatus.HeaderText = "Статус";

            // Подвал
            this.bottomPanel.Dock = DockStyle.Fill;
            this.bottomPanel.AutoSize = true;
            this.bottomPanel.ColumnCount = 2;
            this.bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.bottomPanel.Controls.Add(this.statusStrip, 0, 0);
            this.bottomPanel.Controls.Add(this.btnExit, 1, 0);

            this.statusStrip.Dock = DockStyle.Fill;
            this.statusStrip.Items.Add(this.lblCount);

            this.btnExit.Text = "Выйти";
            this.btnExit.AutoSize = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.mainLayout);
            this.Text = "Отчет по автобусам";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.flowFilters.ResumeLayout(false);
            this.flowFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
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