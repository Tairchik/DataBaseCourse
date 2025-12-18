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
            this.mainLayout = new TableLayoutPanel();
            this.grpFilters = new GroupBox();
            this.flowFilters = new FlowLayoutPanel();
            this.lblStation = new Label();
            this.cmbEndStation = new ComboBox();
            this.btnApply = new Button();
            this.btnReset = new Button();
            this.dgvRoutes = new DataGridView();
            this.colRoute = new DataGridViewTextBoxColumn();
            this.colStart = new DataGridViewTextBoxColumn();
            this.colEnd = new DataGridViewTextBoxColumn();
            this.colTimeStart = new DataGridViewTextBoxColumn();
            this.colTimeEnd = new DataGridViewTextBoxColumn();
            this.btnHelp = new Button();
            this.bottomPanel = new TableLayoutPanel();
            this.statusStrip = new StatusStrip();
            this.lblTotalDistance = new ToolStripStatusLabel();
            this.btnExit = new Button();

            this.mainLayout.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.flowFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Фильтр
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Таблица
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Кнопка Справка
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Подвал
            this.mainLayout.Controls.Add(this.grpFilters, 0, 0);
            this.mainLayout.Controls.Add(this.dgvRoutes, 0, 1);
            this.mainLayout.Controls.Add(this.btnHelp, 0, 2);
            this.mainLayout.Controls.Add(this.bottomPanel, 0, 3);

            // Фильтры
            this.grpFilters.Text = "Фильтр";
            this.grpFilters.Dock = DockStyle.Fill;
            this.grpFilters.AutoSize = true;
            this.grpFilters.Controls.Add(this.flowFilters);

            this.flowFilters.Dock = DockStyle.Fill;
            this.flowFilters.AutoSize = true;
            this.flowFilters.Controls.Add(this.lblStation);
            this.flowFilters.Controls.Add(this.cmbEndStation);
            this.flowFilters.Controls.Add(this.btnApply);
            this.flowFilters.Controls.Add(this.btnReset);

            this.lblStation.Text = "Конечная остановка:";
            this.lblStation.AutoSize = true;
            this.lblStation.TextAlign = ContentAlignment.MiddleLeft;
            this.lblStation.Margin = new Padding(3, 8, 3, 0);

            this.cmbEndStation.Width = 200;
            this.cmbEndStation.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnApply.Text = "Применить";
            this.btnApply.AutoSize = true;
            this.btnApply.Click += btnApply_Click;

            this.btnReset.Text = "Сбросить";
            this.btnReset.AutoSize = true;
            this.btnReset.Click += btnReset_Click;

            // Таблица
            this.dgvRoutes.Dock = DockStyle.Fill;
            this.dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoutes.AllowUserToAddRows = false;
            this.dgvRoutes.ReadOnly = true;
            this.dgvRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoutes.Columns.AddRange(new DataGridViewColumn[] {
                this.colRoute, this.colStart, this.colEnd, this.colTimeStart, this.colTimeEnd
            });

            this.colRoute.HeaderText = "Маршрут";
            this.colStart.HeaderText = "Начальная остановка";
            this.colEnd.HeaderText = "Конечная остановка";
            this.colTimeStart.HeaderText = "Начало движения";
            this.colTimeEnd.HeaderText = "Конец движения";

            // Кнопка Справка
            this.btnHelp.Text = "Справка о маршруте";
            this.btnHelp.AutoSize = true;
            this.btnHelp.Anchor = AnchorStyles.Left;
            this.btnHelp.Margin = new Padding(3, 5, 3, 5);
            this.btnHelp.Click += btnHelp_Click;

            // Подвал
            this.bottomPanel.Dock = DockStyle.Fill;
            this.bottomPanel.AutoSize = true;
            this.bottomPanel.ColumnCount = 2;
            this.bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.bottomPanel.Controls.Add(this.statusStrip, 0, 0);
            this.bottomPanel.Controls.Add(this.btnExit, 1, 0);

            this.statusStrip.Dock = DockStyle.Fill;
            this.statusStrip.Items.Add(this.lblTotalDistance);

            this.btnExit.Text = "Выйти";
            this.btnExit.AutoSize = true;
            this.btnExit.Click += btnExit_Click;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.mainLayout);
            this.Text = "Отчет по маршрутам";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.flowFilters.ResumeLayout(false);
            this.flowFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).EndInit();
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