using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CourseDB;

namespace TripModule
{
    public partial class SelectBusForm : Form
    {
        private List<Bus> _allBuses;
        private List<Bus> _filteredBuses;
        private BindingList<Bus> _displayedBuses;

        public Bus SelectedBus { get; private set; }

        public SelectBusForm(List<Bus> buses, string title = "Выберите автобус")
        {
            InitializeComponent();
            this.Text = title;
            _allBuses = buses ?? new List<Bus>();
            busesDataGridView.CellFormatting += DataGridView_CellFormatting;
            InitializeData();
            SetupDataGridView();
            ApplyFilters();
        }

        private void InitializeData()
        {
            _filteredBuses = new List<Bus>();
            _displayedBuses = new BindingList<Bus>();

            // Инициализация AutoComplete для поиска
            InitializeAutoComplete();
        }

        private void InitializeAutoComplete()
        {
            searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (var bus in _allBuses)
            {
                autoCompleteCollection.Add(bus.ToString());
            }

            searchTextBox.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private void SetupDataGridView()
        {
            busesDataGridView.AutoGenerateColumns = false;
            busesDataGridView.Columns.Clear();

            // Колонка Госномер
            busesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNumber",
                HeaderText = "Госномер",
                DataPropertyName = "RegistrationNumber",
                Width = 120
            });

            // Колонка Марка
            busesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colModel",
                HeaderText = "Модель",
                Width = 150
            });

            // Колонка Вместимость
            busesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCapacity",
                HeaderText = "Вместимость",
                Width = 100
            });

            busesDataGridView.DataSource = _displayedBuses;
        }
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, что это строка с данными, а не заголовок
            if (e.RowIndex >= 0 && e.RowIndex < _displayedBuses.Count)
            {
                Bus currentBus = _displayedBuses[e.RowIndex];

                // Получаем имя столбца, который сейчас отрисовывается
                string columnName = busesDataGridView.Columns[e.ColumnIndex].Name;

                if (columnName == "colModel")
                {
                    // Безопасно достаем бренд через Model
                    e.Value = currentBus.Model?.NameModel ?? "Н/Д";
                    e.FormattingApplied = true;
                }
                else if (columnName == "colCapacity")
                {
                    // Безопасно достаем название модели
                    e.Value = currentBus.Model?.FullCapacity.ToString() ?? "Н/Д";
                    e.FormattingApplied = true;
                }
            }
        }
        private void ApplyFilters()
        {
            try
            {
                // Начинаем со всех автобусов
                _filteredBuses = _allBuses.ToList();

                // Фильтрация по поисковому тексту
                string searchText = searchTextBox.Text.Trim();
                if (!string.IsNullOrEmpty(searchText))
                {
                    _filteredBuses = _filteredBuses
                        .Where(b => b.RegistrationNumber.ToLower().Contains(searchText.ToLower()))
                        .ToList();
                }

                // Обновление отображаемого списка
                _displayedBuses.Clear();
                foreach (var bus in _filteredBuses)
                {
                    _displayedBuses.Add(bus);
                }

                // Обновление информации о количестве
                UpdateCountInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при применении фильтров: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCountInfo()
        {
            lblCount.Text = $"Найдено: {_displayedBuses.Count}";
        }

        // Обработчики событий
        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            searchTextBox.Clear();
            ApplyFilters();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (busesDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = busesDataGridView.SelectedRows[0];
                if (selectedRow.DataBoundItem is Bus bus)
                {
                    SelectedBus = bus;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите автобус из списка", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void busesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSelect_Click(sender, e);
            }
        }
    }
}