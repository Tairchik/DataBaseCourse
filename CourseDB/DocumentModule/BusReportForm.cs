using System;
using System.Linq;
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
            this.Load += (s, e) => { LoadFilters(); LoadData(); };
        }

        private void LoadFilters()
        {
            var buses = _repos.busRep.GetAll();
            var models = buses.Select(b => b.Model.NameModel).Distinct().OrderBy(m => m);

            cmbModel.Items.Clear();
            cmbModel.Items.Add("Все");
            foreach (var m in models) cmbModel.Items.Add(m);
            cmbModel.SelectedIndex = 0;
        }

        private void LoadData()
        {
            dgvBuses.Rows.Clear();
            var buses = _repos.busRep.GetAll();
            var allTrips = _repos.tripRep.GetAll().Where(t => t.DateStart.ToString("yyyy-MM-dd") == DateTime.Today.ToString("yyyy-MM-dd")).ToList();
            var allRoutes = _repos.routRep.GetAll();

            string filterModel = cmbModel.SelectedItem?.ToString() ?? "Все";

            foreach (var bus in buses)
            {
                if (filterModel != "Все" && bus.Model.NameModel != filterModel) continue;

                var trip = allTrips.FirstOrDefault(t => t.Bus_.RegistrationNumber == bus.RegistrationNumber);
                var route = trip != null ? allRoutes.FirstOrDefault(r => r.NameRoute == trip.Rout_.NameRoute) : null;

                dgvBuses.Rows.Add(
                    bus.RegistrationNumber,
                    route?.NameRoute ?? "В депо",
                    BusStateExtensions.GetStringByEnum(bus.State)
                );
            }
            lblCount.Text = $"Всего единиц: {dgvBuses.Rows.Count}";
        }

        private void btnApply_Click(object sender, EventArgs e) => LoadData();

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbModel.SelectedIndex = 0;
            LoadData();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Отчет по автобусам показывает текущее распределение техники по маршрутам.\n" +
                "Статус 'В депо' означает отсутствие запланированных рейсов на сегодня.",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e) => this.Close();
    }
}