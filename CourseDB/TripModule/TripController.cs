using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CourseDB;

namespace TripModule
{
    public class TripController
    {
        private TripForm view;
        private InitRepos dataBase;
        private int userId;
        private List<Trip> allTrips;
        private List<Rout> allRoutes;
        private List<Trip> filteredTrips;
        private List<Bus> allBuses;
        private List<Employee> allEmployees;
        private List<Employee> allDrivers;
        private List<Employee> allConductors;

        public TripController(TripForm form, InitRepos initRepos, int user_id)
        {
            view = form;
            dataBase = initRepos;
            userId = user_id;
            allTrips = new List<Trip>();
            allRoutes = new List<Rout>();
            filteredTrips = new List<Trip>();
            allBuses = new List<Bus>();
            allEmployees = new List<Employee>();
            allDrivers = new List<Employee>();
            allConductors = new List<Employee>();

            InitializeController();
            LoadData();
        }

        private void InitializeController()
        {
            // Устанавливаем начальные значения
            view.DateFilterPicker.Value = DateTime.Today;

            // Настраиваем DataGridView
            view.TripsDataGridView.AutoGenerateColumns = false;
            view.TripsDataGridView.SelectionChanged += TripsDataGridView_SelectionChanged;
            view.TripsDataGridView.CellFormatting += TripsDataGridView_CellFormatting;

            // Подписываемся на события кнопок
            view.ApplyFilterButton.Click += ApplyFilterButton_Click;
            view.ResetFilterButton.Click += ResetFilterButton_Click;
            view.CreateButton.Click += CreateButton_Click;
            view.EditButton.Click += EditButton_Click;
            view.DeleteButton.Click += DeleteButton_Click;
            view.CancelButton.Click += CancelButton_Click;

            // Обновляем состояние кнопок
            UpdateButtonsState();
        }

        private void LoadData()
        {
            try
            {
                // Загружаем данные из базы
                allTrips = dataBase.tripRep.GetAll();
                allRoutes = dataBase.routRep.GetAll();
                allBuses = dataBase.busRep.GetAll();
                allEmployees = dataBase.employeeRep.GetAll();

                // Фильтруем сотрудников по должностям
                allDrivers = allEmployees.Where(e =>
                    e.Post?.NamePost.ToLower().Contains("водитель") == true).ToList();
                allConductors = allEmployees.Where(e =>
                    e.Post?.NamePost.ToLower().Contains("кондуктор") == true).ToList();

                // Заполняем ComboBox маршрутов
                view.RouteFilterComboBox.Items.Clear();
                view.RouteFilterComboBox.Items.Add("Все маршруты");

                foreach (var route in allRoutes)
                {
                    view.RouteFilterComboBox.Items.Add(route.NameRoute);
                }

                view.RouteFilterComboBox.SelectedIndex = 0;

                // Инициализируем отфильтрованный список
                filteredTrips = allTrips.ToList();

                // Обновляем отображение
                UpdateTripsDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTripsDataGridView()
        {
            view.TripsDataGridView.Rows.Clear();

            int rowNumber = 1;
            foreach (var trip in filteredTrips)
            {
                int rowIndex = view.TripsDataGridView.Rows.Add();
                DataGridViewRow row = view.TripsDataGridView.Rows[rowIndex];

                row.Cells["colNumber"].Value = rowNumber;
                row.Cells["colDate"].Value = trip.DateStart.ToString("dd.MM.yyyy");
                row.Cells["colTime"].Value = trip.TimeStart.ToString(@"hh\:mm");

                // Получаем направление
                string direction = GetDirectionString(trip);
                row.Cells["colDirection"].Value = direction;

                // Сохраняем объект Trip в Tag строки
                row.Tag = trip;

                rowNumber++;
            }

            UpdateButtonsState();
        }

        private string GetDirectionString(Trip trip)
        {
            if (trip.Rout_ != null && trip.Rout_ is Rout route)
            {
                var stations = route.GetStartEndStationByDirect(trip.DirectRout);
                if (stations.Length >= 2)
                {
                    return $"{stations[0]} → {stations[1]}";
                }
            }
            return trip.DirectRout ? "Прямое направление" : "Обратное направление";
        }

        private void UpdateButtonsState()
        {
            bool hasSelectedRow = view.TripsDataGridView.SelectedRows.Count > 0;

            view.EditButton.Enabled = hasSelectedRow;
            view.DeleteButton.Enabled = hasSelectedRow;
        }

        // Обработчики событий
        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = view.DateFilterPicker.Value.Date;
                string selectedRoute = view.RouteFilterComboBox.SelectedItem?.ToString();

                // Начинаем со всех рейсов
                filteredTrips = allTrips.ToList();

                // Фильтрация по дате
                filteredTrips = filteredTrips
                    .Where(t => t.DateStart.Date == selectedDate)
                    .ToList();

                // Фильтрация по маршруту (если выбрано не "Все маршруты")
                if (selectedRoute != "Все маршруты" && !string.IsNullOrEmpty(selectedRoute))
                {
                    filteredTrips = filteredTrips
                        .Where(t => t.Rout_?.NameRoute == selectedRoute)
                        .ToList();
                }

                if (filteredTrips.Count == 0)
                {
                    MessageBox.Show("Рейсы по выбранным критериям не найдены", "Результат поиска",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                UpdateTripsDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при применении фильтра: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilterButton_Click(object sender, EventArgs e)
        {
            view.DateFilterPicker.Value = DateTime.Today;
            view.RouteFilterComboBox.SelectedIndex = 0;
            filteredTrips = allTrips.ToList();
            UpdateTripsDataGridView();
        }

        private void TripsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void TripsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Дополнительное форматирование ячеек
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new RedactorTripForm(
                    null, // Новый рейс
                    allRoutes,
                    allBuses,
                    allDrivers,
                    allConductors))
                {
                    if (form.ShowDialog() == DialogResult.OK && form.ResultTrip != null)
                    {
                        // Сохраняем в базу данных
                        dataBase.tripRep.Save(form.ResultTrip);

                        // Обновляем данные
                        LoadData();
                        UpdateTripsDataGridView();

                        MessageBox.Show("Рейс успешно создан", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании рейса: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (view.TripsDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = view.TripsDataGridView.SelectedRows[0];
                if (selectedRow.Tag is Trip trip)
                {
                    try
                    {
                        using (var form = new RedactorTripForm(
                            trip, // Редактируемый рейс
                            allRoutes,
                            allBuses,
                            allDrivers,
                            allConductors))
                        {
                            if (form.ShowDialog() == DialogResult.OK && form.ResultTrip != null)
                            {
                                // Сохраняем изменения в базу данных
                                dataBase.tripRep.Save(form.ResultTrip);

                                // Обновляем данные
                                LoadData();
                                UpdateTripsDataGridView();

                                MessageBox.Show("Рейс успешно обновлен", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при редактировании рейса: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите рейс для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (view.TripsDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = view.TripsDataGridView.SelectedRows[0];
                if (selectedRow.Tag is Trip trip)
                {
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить рейс?\n" +
                        $"Дата: {trip.DateStart:dd.MM.yyyy}\n" +
                        $"Время: {trip.TimeStart:hh\\:mm}\n" +
                        $"Маршрут: {trip.Rout_?.NameRoute}",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            dataBase.tripRep.Delete(trip);
                            LoadData();
                            UpdateTripsDataGridView();

                            MessageBox.Show("Рейс успешно удален", "Удаление",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении рейса: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        // Метод для обновления шрифта формы
        public void UpdateFont(Font font)
        {
            view.Font = font;
            UpdateControlFont(view.Controls, font);
        }

        private void UpdateControlFont(Control.ControlCollection controls, Font font)
        {
            foreach (Control control in controls)
            {
                control.Font = font;
                if (control.HasChildren)
                {
                    UpdateControlFont(control.Controls, font);
                }
            }
        }
    }
}