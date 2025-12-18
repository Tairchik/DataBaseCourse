using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CourseDB;

namespace DocumentModule
{
    public partial class DriverReportForm : Form
    {
        private InitRepos _repos;

        public DriverReportForm(InitRepos repos)
        {
            InitializeComponent();
            _repos = repos;
            // Подписка на события, если они не заданы в дизайнере
            this.Load += (s, e) => { LoadFilters(); ApplyFilters(); };
        }

        private void LoadFilters()
        {
            // Настройка фильтра классов
            cmbClassFilter.Items.Clear();
            cmbClassFilter.Items.Add("Все");
            cmbClassFilter.Items.AddRange(new object[] { "1", "2", "3" });
            cmbClassFilter.SelectedIndex = 0;

            // Настройка фильтра маршрутов
            try {
                var routes = _repos.routRep.GetAll();
                cmbRouteFilter.Items.Clear();
                cmbRouteFilter.Items.Add("Все");
                foreach (var r in routes) cmbRouteFilter.Items.Add(r.NameRoute);
                cmbRouteFilter.SelectedIndex = 0;
            } catch { /* Обработка отсутствия данных */ }
        }

        private void ApplyFilters()
        {
            dgvDrivers.Rows.Clear();
            
            // Получаем данные из репозиториев
            var allEmployees = _repos.employeeRep.GetAll();
            var allTrips = _repos.tripRep.GetAll().Where(t => t.DateStart.ToString("yyyy-MM-dd") == DateTime.Today.ToString("yyyy-MM-dd")).ToList();
            var allRoutes = _repos.routRep.GetAll();

            // Выбираем только водителей
            var drivers = allEmployees.Where(e => e.ClassDriver > 0);

            // Фильтр по классу
            if (cmbClassFilter.SelectedIndex > 0)
            {
                int selectedClass = int.Parse(cmbClassFilter.SelectedItem.ToString());
                drivers = drivers.Where(d => d.ClassDriver == selectedClass);
            }

            string filterRoute = cmbRouteFilter.SelectedItem?.ToString() ?? "Все";
            int maxExp = 0;

            foreach (var driver in drivers)
            {
                var trip = allTrips.FirstOrDefault(t => t.Driver == driver);
                var route = trip != null ? allRoutes.FirstOrDefault(r => r.NameRoute == trip.Rout_.NameRoute) : null;

                if (filterRoute != "Все" && (route == null || route.NameRoute != filterRoute)) continue;

                dgvDrivers.Rows.Add(
                    driver.Surname, 
                    driver.Name, 
                    driver.Patronymic, 
                    route?.NameRoute ?? "-", 
                    trip?.TimeStart.ToString() ?? "-", 
                    driver.TimeWork, 
                    driver.ClassDriver
                );

                if (driver.TimeWork > maxExp) maxExp = driver.TimeWork;
            }

            lblCount.Text = $"Количество: {dgvDrivers.Rows.Count}";
            lblMaxExp.Text = $"Макс. стаж: {maxExp} лет";
        }

        private void btnApply_Click(object sender, EventArgs e) => ApplyFilters();

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbClassFilter.SelectedIndex = 0;
            cmbRouteFilter.SelectedIndex = 0;
            ApplyFilters();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данный отчет выводит список водителей, работающих на маршрутах сегодня.\n" +
                "Используйте фильтры для поиска водителей конкретного класса или маршрута.", 
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e) => this.Close();
    }
}