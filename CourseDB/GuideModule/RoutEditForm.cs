using CourseDB;
using AuthorizationLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuideModule
{
    public partial class RoutEditForm : Form
    {
        // Результат работы формы
        public Rout ResultModel { get; private set; }

        // Списки данных
        private List<Schedule> scheduleList;
        private List<string> stationsList;
        private List<string> availableStations;
        private bool isEditMode;
        private int userId;

        // Конструктор для создания нового маршрута
        public RoutEditForm(List<string> allStations, int user_id)
        {
            InitializeComponent();
            this.availableStations = allStations ?? new List<string>();
            this.userId = user_id;
            this.isEditMode = false;

            InitializeForm();
            this.Text = "Новый маршрут";
        }

        // Конструктор для редактирования существующего маршрута
        public RoutEditForm(List<string> allStations, Rout existingRout, int user_id)
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
            InitializeStationsComboBox();
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

        private void InitializeStationsComboBox()
        {
            comboBoxStations.DataSource = availableStations;
            comboBoxStations.DropDownStyle = ComboBoxStyle.DropDownList;
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

        // Обработчики событий для графика движения
        private void buttonAddSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                int startHour = (int)numericFromHour.Value;
                int endHour = (int)numericToHour.Value;
                int interval = (int)numericInterval.Value;

                var newSchedule = new Schedule
                {
                    StartHour = startHour,
                    EndHour = endHour,
                    Interval = interval
                };


                scheduleList.Add(newSchedule);
                scheduleList = scheduleList.OrderBy(s => s.StartHour).ToList();
                UpdateScheduleDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении графика: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemoveSchedule_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchedule.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int selectedIndex = dataGridViewSchedule.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < scheduleList.Count)
                {
                    scheduleList.RemoveAt(selectedIndex);
                    UpdateScheduleDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении графика: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчики событий для остановок
        private void buttonAddStation_Click(object sender, EventArgs e)
        {
            if (comboBoxStations.SelectedItem == null)
            {
                MessageBox.Show("Выберите остановку из списка", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string station = comboBoxStations.SelectedItem.ToString();

            // Проверка на дубликат (без учета регистра)
            if (stationsList.Any(s => s.Equals(station, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Остановка '{station}' уже добавлена в маршрут", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            stationsList.Add(station);
            UpdateStationsDataGridView();
        }

        private void buttonRemoveStation_Click(object sender, EventArgs e)
        {
            if (dataGridViewStations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int selectedIndex = dataGridViewStations.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < stationsList.Count)
                {
                    stationsList.RemoveAt(selectedIndex);
                    UpdateStationsDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении остановки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (dataGridViewStations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для перемещения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dataGridViewStations.SelectedRows[0].Index;
            if (selectedIndex > 0)
            {
                var temp = stationsList[selectedIndex];
                stationsList[selectedIndex] = stationsList[selectedIndex - 1];
                stationsList[selectedIndex - 1] = temp;
                UpdateStationsDataGridView();
                dataGridViewStations.Rows[selectedIndex - 1].Selected = true;
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewStations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для перемещения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dataGridViewStations.SelectedRows[0].Index;
            if (selectedIndex < stationsList.Count - 1)
            {
                var temp = stationsList[selectedIndex];
                stationsList[selectedIndex] = stationsList[selectedIndex + 1];
                stationsList[selectedIndex + 1] = temp;
                UpdateStationsDataGridView();
                dataGridViewStations.Rows[selectedIndex + 1].Selected = true;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                // Время движения
                TimeSpan startDirect = timePickerStartDirect.Value.TimeOfDay;
                TimeSpan endDirect = timePickerEndDirect.Value.TimeOfDay;
                TimeSpan startReverse = timePickerStartReverse.Value.TimeOfDay;
                TimeSpan endReverse = timePickerEndReverse.Value.TimeOfDay;
                // Время оборота
                TimeSpan timeRoute = new TimeSpan(
                    (int)numericHoursTimeRoute.Value,
                    (int)numericMinutesTimeRoute.Value,
                    0
                );

                // Создание объекта ScheduleList
                ScheduleList schedule = new ScheduleList();
                foreach (var scheduleItem in scheduleList)
                {
                    schedule.Add(scheduleItem);
                }

                // Создание или обновление маршрута
                if (ResultModel == null)
                {
                    ResultModel = new Rout(
                        textBoxName.Text.Trim(),
                        timeRoute,
                        (int)numericDistance.Value,
                        startDirect,
                        endDirect,
                        startReverse,
                        endReverse,
                        schedule,
                        stationsList
                    )
                    {
                        Revenue = numericRevenue.Value
                    };
                }
                else
                {
                    ResultModel.NameRoute = textBoxName.Text.Trim();
                    ResultModel.TimeRoute = timeRoute;
                    ResultModel.Distance = (int)numericDistance.Value;
                    ResultModel.Revenue = numericRevenue.Value;
                    ResultModel.StartTimeDirectRout = startDirect;
                    ResultModel.EndTimeDirectRout = endDirect;
                    ResultModel.StartTimeReversDirectRout = startReverse;
                    ResultModel.EndTimeReversDirectRout = endReverse;
                    ResultModel.Schedule = schedule;

                    // Обновление остановок
                    ResultModel.Stations = stationsList;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}