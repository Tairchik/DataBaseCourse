using System;
using System.Drawing;
using System.Windows.Forms;
using CourseDB;
using AuthorizationLibrary;

namespace TripModule
{
    public partial class TripForm : Form
    {
        private TripController controller;

        public TripForm(InitRepos initRepos, int user_id)
        {
            InitializeComponent();
            controller = new TripController(this, initRepos, user_id);
            SettingsRepository set = new SettingsRepository();
            Font = set.GetSettings(user_id);

        }

        public DataGridView TripsDataGridView => tripsDataGridView;
        public DateTimePicker DateFilterPicker => dateFilterPicker;
        public ComboBox RouteFilterComboBox => routeFilterComboBox;
        public Button ApplyFilterButton => applyFilterButton;
        public Button ResetFilterButton => resetFilterButton;
        public Button CreateButton => createButton;
        public Button EditButton => editButton;
        public Button DeleteButton => deleteButton;
        public Button CancelButton => cancelButton;
    }
}