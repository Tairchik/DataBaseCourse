using System;
using System.Drawing;
using System.Windows.Forms;
using CourseDB;

namespace DocumentModule
{
    public partial class BusReportForm : Form
    {
        private InitRepos _repos;

        public BusReportForm(InitRepos repos)
        {
            InitializeComponent();
            _repos = repos;
            LoadFilters();
            LoadData();
        }

        private void LoadFilters()
        {
            cmbModel.Items.Add("Все");
            // Загрузка моделей
            // foreach(var m in _repos.Models.GetAll()) cmbModel.Items.Add(m.NameModel);
            cmbModel.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbModel.SelectedIndex = 0;
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            dgvBuses.Rows.Clear();

            // Загрузка и фильтрация
            // ...

            // Пример
            // dgvBuses.Rows.Add("A123BC", "Маршрут 1", "Исправен");

            lblCount.Text = $"Число автобусов: {dgvBuses.Rows.Count}";
        }
    }
}