using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CourseDB;

namespace TripModule
{
    public partial class RedactorTripForm : Form
    {
        private Trip _editingTrip; // Объект для редактирования (копия)
        private Trip _originalTrip; // Исходный объект (если редактирование)
        private List<Rout> _allRoutes;
        private List<Bus> _allBuses;
        private List<Employee> _allDrivers;
        private List<Employee> _allConductors;
        private BindingList<ControlTrip> _scheduleRecords;

        public Trip ResultTrip { get; private set; }
        public bool IsEditMode { get; private set; }

        public RedactorTripForm(Trip trip = null,
                              List<Rout> routes = null,
                              List<Bus> buses = null,
                              List<Employee> drivers = null,
                              List<Employee> conductors = null)
        {
            InitializeComponent();

            _allRoutes = routes ?? new List<Rout>();
            _allBuses = buses ?? new List<Bus>();
            _allDrivers = drivers ?? new List<Employee>();
            _allConductors = conductors ?? new List<Employee>();

            // Если передан рейс - режим редактирования
            if (trip != null)
            {
                _originalTrip = trip;
                _editingTrip = _originalTrip; // Создаем копию для редактирования
                IsEditMode = true;
                this.Text = "Редактирование рейса";
            }
            else
            {
                _editingTrip = new Trip();
                IsEditMode = false;
                this.Text = "Создание рейса";
            }

            InitializeFormData();
            InitializeScheduleGrid();
        }

       
        private void InitializeFormData()
        {
            try
            {
                // Заполнение ComboBox маршрутов
                routeComboBox.Items.Clear();
                foreach (var route in _allRoutes)
                {
                    routeComboBox.Items.Add(route.NameRoute);
                }

                // Если есть выбранный маршрут
                if (_editingTrip.Rout_ != null)
                {
                    int routeIndex = _allRoutes.FindIndex(r => r.NameRoute == _editingTrip.Rout_.NameRoute);
                    if (routeIndex >= 0) routeComboBox.SelectedIndex = routeIndex;
                }

                // Заполнение остальных полей
                if (_editingTrip.DateStart != DateTime.MinValue)
                    dateDepartureDate.Value = _editingTrip.DateStart;
                else
                    dateDepartureDate.Value = DateTime.Today;

                if (_editingTrip.TimeStart != TimeSpan.Zero)
                    timeDepartureTime.Value = DateTime.Today.Add(_editingTrip.TimeStart);
                txtDriver.Text = _editingTrip.Driver?.GetFullName() ?? "";
                txtConductor.Text = _editingTrip.Conductor?.GetFullName() ?? "";

                // Направление
                if (_editingTrip.DirectRout)
                    rbDirectDirection.Checked = true;
                else
                    rbReturnDirection.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeScheduleGrid()
        {
            _scheduleRecords = new BindingList<ControlTrip>();

            // Загрузка существующих записей контроля рейса
            if (_editingTrip.ControlTrips != null && _editingTrip.ControlTrips.Count > 0)
            {
                foreach (ControlTrip controlTrip in _editingTrip.ControlTrips)
                {
                    _scheduleRecords.Add(controlTrip);
                }
            }

            scheduleDataGridView.AutoGenerateColumns = false;
            scheduleDataGridView.DataSource = _scheduleRecords;

            // Настройка колонок
            scheduleDataGridView.Columns.Clear();

            scheduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colOrderNumber",
                HeaderText = "№",
                Width = 50
            });

            scheduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTimeComingStation",
                HeaderText = "Время прибытия",
                Width = 120,
                DataPropertyName = "TimeComingStation"
            });

            scheduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTimeLeave",
                HeaderText = "Время снятия",
                Width = 120,
                DataPropertyName = "TimeLeave"
            });

            scheduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colReasonLeave",
                HeaderText = "Причина снятия",
                Width = 150,
                DataPropertyName = "ReasonLeave"
            });

            scheduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNumRides",
                HeaderText = "Число ездок",
                Width = 100,
                DataPropertyName = "NumRides"
            });

            UpdateOrderNumbers();
        }

        private void UpdateOrderNumbers()
        {
            for (int i = 0; i < _scheduleRecords.Count; i++)
            {
                scheduleDataGridView.Rows[i].Cells["colOrderNumber"].Value = i + 1;
            }
        }

        // Обработчики событий выбора
        private void btnSelectBus_Click(object sender, EventArgs e)
        {
            if (_allBuses != null && _allBuses.Count > 0)
            {
                using (var form = new SelectBusForm(_allBuses, "Выберите автобус"))
                {
                    if (form.ShowDialog() == DialogResult.OK && form.SelectedBus != null)
                    {
                        _editingTrip.Bus_ = form.SelectedBus;
                        txtBus.Text = form.SelectedBus.RegistrationNumber;
                    }
                }
            }
            else
            {
                MessageBox.Show("Список автобусов пуст", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelectDriver_Click(object sender, EventArgs e)
        {
            if (_allDrivers != null && _allDrivers.Count > 0)
            {
                using (var form = new SelectEmployeeForm(_allDrivers, "водитель", "Выберите водителя"))
                {
                    if (form.ShowDialog() == DialogResult.OK && form.SelectedEmployee != null)
                    {
                        _editingTrip.Driver = form.SelectedEmployee;
                        txtDriver.Text = form.SelectedEmployee.GetFullName();
                    }
                }
            }
            else
            {
                MessageBox.Show("Список сотрудников пуст", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelectConductor_Click(object sender, EventArgs e)
        {
            if (_allConductors != null && _allConductors.Count > 0)
            {
                using (var form = new SelectEmployeeForm(_allConductors, "кондуктор", "Выберите кондуктора"))
                {
                    if (form.ShowDialog() == DialogResult.OK && form.SelectedEmployee != null)
                    {
                        _editingTrip.Conductor = form.SelectedEmployee;
                        txtConductor.Text = form.SelectedEmployee.GetFullName();
                    }
                }
            }
            else
            {
                MessageBox.Show("Список сотрудников пуст", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtTripCount.Text, out int numRides) || numRides < 0)
                    throw new ArgumentException("Некорректное число ездок");

                // Получаем время прибытия из DateTimePicker
                var arrivalTimeValue = timeArrivalTime.Value;
                TimeSpan arrivalTime = new TimeSpan(arrivalTimeValue.Hour, arrivalTimeValue.Minute, 0);

                // Получаем время снятия из DateTimePicker
                var removalTimeValue = timeRemovalTime.Value;
                TimeSpan? removalTime = new TimeSpan(removalTimeValue.Hour, removalTimeValue.Minute, 0);

                ControlTrip controlTrip;

                if (chkHasRemovalTime.Checked == true) 
                {

                    controlTrip = new ControlTrip(
                        timeLeave: removalTime,
                        timeComingStation: arrivalTime,
                        reasonLeave: txtRemovalReason.Text,
                        numRides: numRides
                    );

                }
                else 
                {
                    controlTrip = new ControlTrip(
                        timeComingStation: arrivalTime,
                        numRides: numRides
                    );

                }
                _scheduleRecords.Add(controlTrip);
                UpdateOrderNumbers();

                // Очистка полей для следующей записи
                txtRemovalReason.Clear();
                txtTripCount.Clear();
                // Установка времени по умолчанию для следующих записей
                timeArrivalTime.Value = DateTime.Today.Add(TimeSpan.FromHours(arrivalTime.Hours + 1)); // +1 час
                timeRemovalTime.Value = DateTime.Today.Add(TimeSpan.FromHours(removalTimeValue.Hour + 1)); // +1 час

                // Фокус на поле причины снятия
                txtRemovalReason.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveSchedule_Click(object sender, EventArgs e)
        {
            if (scheduleDataGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in scheduleDataGridView.SelectedRows)
                {
                    if (row.DataBoundItem is ControlTrip record)
                    {
                        _scheduleRecords.Remove(record);
                    }
                }

                UpdateOrderNumbers();
                scheduleDataGridView.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateForm()
        {
            if (routeComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите маршрут", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_editingTrip.Driver == null)
            {
                MessageBox.Show("Выберите водителя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_editingTrip.Conductor == null)
            {
                MessageBox.Show("Выберите кондуктора", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_editingTrip.Bus_ == null)
            {
                MessageBox.Show("Выберите автобус", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                // Обновление данных рейса
                _editingTrip.DateStart = dateDepartureDate.Value;
                _editingTrip.TimeStart = timeDepartureTime.Value.TimeOfDay;
                _editingTrip.DirectRout = rbDirectDirection.Checked;

                // Выбранный маршрут
                string selectedRouteName = routeComboBox.SelectedItem.ToString();
                var selectedRoute = _allRoutes.FirstOrDefault(r => r.NameRoute == selectedRouteName);
                if (selectedRoute != null)
                    _editingTrip.Rout_ = selectedRoute;

                // Обновление списка контрольных записей
                _editingTrip.ControlTrips = new List<IControlTrip>(_scheduleRecords);

                // Возвращаем результат
                ResultTrip = _editingTrip;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkHasRemovalTime_CheckedChanged(object sender, EventArgs e)
        {
            timeRemovalTime.Enabled = chkHasRemovalTime.Checked;

            // Если снимаем галочку, очищаем поле причины снятия
            if (!chkHasRemovalTime.Checked)
            {
                txtRemovalReason.Clear();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}