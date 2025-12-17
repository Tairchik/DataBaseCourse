using System;
using System.Drawing;
using System.Windows.Forms;
using CourseDB;

namespace DocumentModule
{
    public partial class RoutReportForm : Form
    {
        private InitRepos _repos;

        public RoutReportForm(InitRepos repos)
        {
            InitializeComponent();
            _repos = repos;
            LoadFilters();
            LoadData();
        }

        private void LoadFilters()
        {
            cmbEndStation.Items.Add("Все");
            // Загрузка уникальных конечных остановок из репозитория
            // ...
            cmbEndStation.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbEndStation.SelectedIndex = 0;
            LoadData();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count > 0)
            {
                string routeName = dgvRoutes.SelectedRows[0].Cells[0].Value.ToString();
                // Логика открытия формы справки
                MessageBox.Show($"Открываю справку для маршрута: {routeName}");
                // new RouteHelpForm(routeName).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите маршрут в таблице.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            dgvRoutes.Rows.Clear();
            double totalDist = 0;

            // Логика получения и фильтрации данных
            // foreach(var r in routes) ...

            // Пример
            // dgvRoutes.Rows.Add("105", "Вокзал", "Центр", "06:00", "23:00");
            // totalDist += 15.5;

            lblTotalDistance.Text = $"Общая протяженность: {totalDist} км";
        }
    }
}