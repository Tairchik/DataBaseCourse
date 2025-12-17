using AuthorizationLibrary;
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

namespace FinancialModule
{
    public partial class RevenueTripForm : Form
    {
        // Исходные данные
        private List<Trip> allTrips;
        private List<Rout> allRoutes;
        private List<Trip> filteredTrips;
        private BindingList<Trip> bindingList;
        private InitRepos dataBase;
        private int userId;

        // Конструктор формы
        public RevenueTripForm(InitRepos init, int user_id, MenuState menuState)
        {
            InitializeComponent();
            this.dataGridViewTrips.CellFormatting += dataGridViewTrips_CellFormatting;
            dataBase = init;
            this.allTrips = dataBase.tripRep.GetAll();
            this.allRoutes = dataBase.routRep.GetAll();
            this.userId = user_id;
            this.filteredTrips = new List<Trip>();

            InitializeForm();
            LoadData();
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, что это строка с данными, а не заголовок
            if (e.RowIndex >= 0 && e.RowIndex < bindingList.Count)
            {
                Trip current = bindingList[e.RowIndex];

                string columnName = dataGridViewTrips.Columns[e.ColumnIndex].Name;

                if (columnName == "colRoute")
                {
                    // Безопасно достаем бренд через Model
                    e.Value = current.Rout_?.NameRoute ?? "Н/Д";
                    e.FormattingApplied = true;
                }
            }
        }

        private void InitializeForm()
        {
            ApplyFontSettings();
            SetupAutoComplete();
            InitializeDataGridView();

            // Установка текущей даты по умолчанию
            dateTimePickerFilter.Value = DateTime.Today;
        }

        private void ApplyFontSettings()
        {
            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(userId);
            this.Font = f;
        }

        private void LoadData()
        {
            // Заполняем комбобокс названиями маршрутов
            comboBoxRouteFilter.Items.Clear();
            comboBoxRouteFilter.Items.Add("Все маршруты"); // Первый элемент - все маршруты
            foreach (var route in allRoutes)
            {
                comboBoxRouteFilter.Items.Add(route.NameRoute);
            }
            comboBoxRouteFilter.SelectedIndex = 0; // Выбираем "Все маршруты" по умолчанию

            // Инициализируем фильтрованный список
            filteredTrips = allTrips.ToList();

            // Создаем BindingList для DataGridView
            UpdateBindingList();

            // Обновляем номера строк
            UpdateRowNumbers();
        }

        private void InitializeDataGridView()
        {
            dataGridViewTrips.AutoGenerateColumns = false;
            dataGridViewTrips.AllowUserToAddRows = false;
            dataGridViewTrips.AllowUserToDeleteRows = false;
            dataGridViewTrips.ReadOnly = true;
            dataGridViewTrips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTrips.MultiSelect = false;
        }

        private void SetupAutoComplete()
        {
            comboBoxRouteFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxRouteFilter.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void UpdateBindingList()
        {
            bindingList = new BindingList<Trip>(filteredTrips);
            dataGridViewTrips.DataSource = bindingList;
        }

        private void UpdateRowNumbers()
        {
            for (int i = 0; i < dataGridViewTrips.Rows.Count; i++)
            {
                dataGridViewTrips.Rows[i].Cells["colNumber"].Value = i + 1;
            }
        }

        // Обработчики событий

        // Применение фильтра
        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePickerFilter.Value.Date;
            string selectedRoute = comboBoxRouteFilter.Text;

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
                MessageBox.Show($"Рейсы по выбранным критериям не найдены", "Результат поиска",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Обновляем BindingList
            UpdateBindingList();
            UpdateRowNumbers();

            // Очищаем поле выручки, так как выборка изменилась
            textBoxActualRevenue.Text = "";
        }

        // Сброс фильтра
        private void buttonResetFilter_Click(object sender, EventArgs e)
        {
            dateTimePickerFilter.Value = DateTime.Today;
            comboBoxRouteFilter.SelectedIndex = 0;
            filteredTrips = allTrips.ToList();
            UpdateBindingList();
            UpdateRowNumbers();
            textBoxActualRevenue.Text = "";
        }

        // При изменении выделенной строки в таблице
        private void dataGridViewTrips_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTrips.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewTrips.SelectedRows[0];
                if (selectedRow.DataBoundItem is Trip selectedTrip)
                {
                    // Заполняем поле выручки значением из выбранного рейса
                    textBoxActualRevenue.Text = selectedTrip.ActualRevenue.ToString("F2");
                }
            }
            else
            {
                textBoxActualRevenue.Text = "";
            }
        }

        // Применение изменений
        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                // Если выбрана строка и введено значение в поле выручки
                if (dataGridViewTrips.SelectedRows.Count > 0 && !string.IsNullOrWhiteSpace(textBoxActualRevenue.Text))
                {
                    if (decimal.TryParse(textBoxActualRevenue.Text, out decimal newRevenue))
                    {
                        if (newRevenue < 0)
                        {
                            MessageBox.Show("Фактическая выручка не может быть отрицательной", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxActualRevenue.Focus();
                            return;
                        }

                        // Обновляем выручку для выбранного рейса
                        var selectedRow = dataGridViewTrips.SelectedRows[0];
                        if (selectedRow.DataBoundItem is Trip selectedTripData)
                        {
                            selectedTripData.ActualRevenue = newRevenue;
                            dataGridViewTrips.Refresh();

                            // Обновляем выручку в основном списке
                            var originalTrip = allTrips.FirstOrDefault(t =>
                                t.DateStart == selectedTripData.DateStart &&
                                t.TimeStart == selectedTripData.TimeStart &&
                                t.Rout_?.NameRoute == selectedTripData.Rout_.NameRoute);

                            if (originalTrip != null)
                            {
                                originalTrip.ActualRevenue = newRevenue;
                            }

                            dataBase.tripRep.Save(originalTrip);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное числовое значение для фактической выручки", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxActualRevenue.Focus();
                        return;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(textBoxActualRevenue.Text))
                {
                    // Если значение введено, но строка не выбрана
                    MessageBox.Show("Выберите рейс для изменения фактической выручки", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Отмена изменений
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Не сохраняем изменения
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Метод для обновления выручки для всех рейсов в списке
        public void ApplyRevenueToAll(decimal revenue)
        {
            if (bindingList.Count > 0)
            {
                foreach (var tripData in bindingList)
                {
                    tripData.ActualRevenue = revenue;
                }
                dataGridViewTrips.Refresh();
            }
        }

        // Метод для получения текущего значения выручки
        public decimal? GetCurrentRevenue()
        {
            if (decimal.TryParse(textBoxActualRevenue.Text, out decimal revenue))
            {
                return revenue;
            }
            return null;
        }

        // Метод для форматирования отображения времени в DataGridView
        private void dataGridViewTrips_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewTrips.Columns[e.ColumnIndex].Name == "colTime" && e.Value != null)
            {
                if (e.Value is TimeSpan timeSpan)
                {
                    e.Value = timeSpan.ToString(@"hh\:mm");
                    e.FormattingApplied = true;
                }
            }

            if (dataGridViewTrips.Columns[e.ColumnIndex].Name == "colDate" && e.Value != null)
            {
                if (e.Value is DateTime dateTime)
                {
                    e.Value = dateTime.ToString("dd.MM.yyyy");
                    e.FormattingApplied = true;
                }
            }

            if (dataGridViewTrips.Columns[e.ColumnIndex].Name == "colActualRevenue" && e.Value != null)
            {
                if (e.Value is decimal revenue)
                {
                    e.Value = revenue.ToString("F2");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}

