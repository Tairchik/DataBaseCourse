using System;
using System.Linq;
using System.Windows.Forms;
using CourseDB;

namespace DocumentModule
{
    public partial class RoutReportForm : Form
    {
        private InitRepos _repos;
        private int user_id;

        public RoutReportForm(InitRepos repos, int user_id)
        {
            InitializeComponent();
            _repos = repos;
            this.user_id = user_id;
            this.Load += (s, e) => { LoadFilters(); LoadData(); };
        }

        private void LoadFilters()
        {
            var routes = _repos.routRep.GetAll();
            // Станции берутся из связанных данных маршрута
            HashSet<string> stations = new HashSet<string>();
            foreach (var route in routes) 
            {
                stations.Add(route.StartStation);
                stations.Add(route.EndStation);
            }

            cmbEndStation.Items.Clear();
            cmbEndStation.Items.Add("Все");
            foreach (var s in stations) cmbEndStation.Items.Add(s);
            cmbEndStation.SelectedIndex = 0;
        }

        private void LoadData()
        {
            dgvRoutes.Rows.Clear();
            var routes = _repos.routRep.GetAll();
            string filterStation = cmbEndStation.SelectedItem?.ToString() ?? "Все";
            double totalDist = 0;

            foreach (var r in routes)
            {
                string endStation = r.EndStation ?? "-";
                string startStation = r.StartStation ?? "-";

                if (filterStation != "Все" && (endStation != filterStation && startStation != filterStation)) continue;

                dgvRoutes.Rows.Add(r.NameRoute, startStation, endStation, r.StartTimeDirectRout.ToString(@"hh\:mm"), r.EndTimeDirectRout.ToString(@"hh\:mm"));
                totalDist += r.Distance;
            }

            lblTotalDistance.Text = $"Общая протяженность: {totalDist} км";
        }

        private void btnApply_Click(object sender, EventArgs e) => LoadData();

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbEndStation.SelectedIndex = 0;
            LoadData();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выбирете маршрут для подробной информации о нем",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var routName = (string)dgvRoutes.SelectedRows[0].Cells[0].Value;
            var stations = _repos.stationRep.GetAll();
            var stations_str = new List<string>();
            foreach (var i in stations)
            {
                stations_str.Add(i.StationName);
            }
            Rout rout = _repos.routRep.GetByNumber(routName);
            AboutRoutForm form = new AboutRoutForm(stations_str, rout, user_id);
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e) 
        {
            this.Close(); 
        }
    }
}