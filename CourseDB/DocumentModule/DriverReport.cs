using CourseDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentModule
{
    public partial class DriverReport : Form
    {
        private InitRepos _repos;

        public DriverReport(InitRepos repos)
        {
            InitializeComponent();
            _repos = repos;
            LoadFilters();
            LoadData();
        }

        private void LoadFilters()
        {
            // Загрузка классов (0-3)
            cmbClassFilter.Items.Add("Все");
            cmbClassFilter.Items.AddRange(new object[] { "1", "2", "3" });
            cmbClassFilter.SelectedIndex = 0;

            // Загрузка маршрутов (нужна логика получения из репозитория)
            cmbRouteFilter.Items.Add("Все");
            // foreach (var r in _repos.Routes.GetAll()) cmbRouteFilter.Items.Add(r.NameRoute);
            cmbRouteFilter.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbRouteFilter.SelectedIndex = 0;
            cmbClassFilter.SelectedIndex = 0;
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            dgvDrivers.Rows.Clear();

            // Здесь должна быть выборка из репозитория
            // var drivers = _repos.Employees.GetDrivers(); 

            // Имитация данных для примера
            int count = 0;
            int maxExp = 0;

            // foreach (var driver in drivers) ... фильтрация ...

            // Пример добавления строки:
            // dgvDrivers.Rows.Add(driver.Surname, driver.Name, driver.Patronymic, "Маршрут 5", "08:00", driver.TimeWork, driver.ClassDriver);

            // Обновляем статус
            lblCount.Text = $"Количество: {dgvDrivers.Rows.Count}";

            // Расчет максимального стажа по отображаемым строкам
            if (dgvDrivers.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDrivers.Rows)
                {
                    if (row.Cells["colExp"].Value != null && int.TryParse(row.Cells["colExp"].Value.ToString(), out int exp))
                    {
                        if (exp > maxExp) maxExp = exp;
                    }
                }
            }
            lblMaxExp.Text = $"Макс. стаж: {maxExp} лет";
        }
    }
}