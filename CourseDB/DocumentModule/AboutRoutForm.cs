using CourseDB;
using AuthorizationLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DocumentModule
{
    public partial class AboutRoutForm : Form
    {
        // Списки данных
        private List<Schedule> scheduleList;
        private List<string> stationsList;
        private List<string> availableStations;
        private bool isEditMode;
        private int userId;
        private Rout ResultModel;
        public AboutRoutForm(List<string> allStations, Rout existingRout, int user_id)
        {
            InitializeComponent();
            this.availableStations = allStations ?? new List<string>();
            this.userId = user_id;
            this.isEditMode = true;
            ResultModel = existingRout;

            InitializeForm();
            LoadRoutData(existingRout);
            this.Text = "Редактирование маршрута";
        }

        private void InitializeForm()
        {
            InitializeScheduleDataGridView();
            InitializeStationsDataGridView();
            ApplyFontSettings();

            // Настройка времени по умолчанию
            timePickerStartDirect.Value = DateTime.Today.AddHours(6); // 06:00
            timePickerEndDirect.Value = DateTime.Today.AddHours(22); // 22:00
            timePickerStartReverse.Value = DateTime.Today.AddHours(6); // 06:00
            timePickerEndReverse.Value = DateTime.Today.AddHours(22); // 22:00

            scheduleList = new List<Schedule>();
            stationsList = new List<string>();
        }

        private void ApplyFontSettings()
        {
            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(userId);
            this.Font = f;
        }
        private void InitializeScheduleDataGridView()
        {
            dataGridViewSchedule.DataSource = null;
            dataGridViewSchedule.Rows.Clear();
            dataGridViewSchedule.AutoGenerateColumns = false;
        }

        private void InitializeStationsDataGridView()
        {
            dataGridViewStations.DataSource = null;
            dataGridViewStations.Rows.Clear();
            dataGridViewStations.AutoGenerateColumns = false;
        }

        private void LoadRoutData(Rout rout)
        {
            try
            {
                // Основные данные
                textBoxName.Text = rout.NameRoute;

                // Время оборота
                numericHoursTimeRoute.Value = rout.TimeRoute.Hours;
                numericMinutesTimeRoute.Value = rout.TimeRoute.Minutes;

                // Расстояние и выручка
                numericDistance.Value = rout.Distance;
                numericRevenue.Value = rout.Revenue;

                // Время движения
                timePickerStartDirect.Value = DateTime.Today.Add(rout.StartTimeDirectRout);
                timePickerEndDirect.Value = DateTime.Today.Add(rout.EndTimeDirectRout);
                timePickerStartReverse.Value = DateTime.Today.Add(rout.StartTimeReversDirectRout);
                timePickerEndReverse.Value = DateTime.Today.Add(rout.EndTimeReversDirectRout);

                // График движения
                scheduleList = rout.Schedule.Schedules;
                UpdateScheduleDataGridView();

                // Остановки
                stationsList = rout.Stations;
                UpdateStationsDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateScheduleDataGridView()
        {
            dataGridViewSchedule.Rows.Clear();

            for (int i = 0; i < scheduleList.Count; i++)
            {
                var schedule = scheduleList[i];
                dataGridViewSchedule.Rows.Add(
                    i + 1,
                    schedule.StartHour,
                    schedule.EndHour,
                    schedule.Interval
                );
            }
        }

        private void UpdateStationsDataGridView()
        {
            dataGridViewStations.Rows.Clear();

            for (int i = 0; i < stationsList.Count; i++)
            {
                dataGridViewStations.Rows.Add(i + 1, stationsList[i]);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}