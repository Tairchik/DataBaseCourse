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
    public partial class SelectEmployeeForm : Form
    {
        private List<Employee> _allEmployees;
        private List<Employee> _filteredEmployees;
        private BindingList<Employee> _displayedEmployees;
        private string _positionFilter;

        public Employee SelectedEmployee { get; private set; }

        public SelectEmployeeForm(List<Employee> employees, string positionFilter = "", string title = "Выберите сотрудника")
        {
            InitializeComponent();
            this.Text = title;
            _allEmployees = employees ?? new List<Employee>();
            _positionFilter = positionFilter?.ToLower() ?? "";

            InitializeData();
            SetupDataGridView();
            ApplyFilters();
        }

        private void InitializeData()
        {
            _filteredEmployees = new List<Employee>();
            _displayedEmployees = new BindingList<Employee>();

            // Инициализация AutoComplete для поиска
            InitializeAutoComplete();
        }

        private void InitializeAutoComplete()
        {
            searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (var employee in _allEmployees)
            {
                autoCompleteCollection.Add(employee.GetFullName());
            }

            searchTextBox.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private void SetupDataGridView()
        {
            employeesDataGridView.AutoGenerateColumns = false;
            employeesDataGridView.Columns.Clear();

            // Колонка ФИО
            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFullName",
                HeaderText = "ФИО",
                DataPropertyName = "FullName",
                Width = 200
            });

            // Колонка Должность
            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPosition",
                HeaderText = "Должность",
                DataPropertyName = "PositionName",
                Width = 150
            });

            // Колонка Табельный номер
            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmployeeId",
                HeaderText = "Табельный номер",
                DataPropertyName = "EmployeeId",
                Width = 120
            });

            employeesDataGridView.DataSource = _displayedEmployees;
        }

        private void ApplyFilters()
        {
            try
            {
                // Начинаем со всех сотрудников
                _filteredEmployees = _allEmployees.ToList();

                // Фильтрация по должности
                if (!string.IsNullOrEmpty(_positionFilter))
                {
                    _filteredEmployees = _filteredEmployees
                        .Where(e => e.Post?.NamePost?.ToLower().Contains(_positionFilter) == true)
                        .ToList();
                }

                // Фильтрация по поисковому тексту (ФИО)
                string searchText = searchTextBox.Text.Trim();
                if (!string.IsNullOrEmpty(searchText))
                {
                    _filteredEmployees = _filteredEmployees
                        .Where(e => e.GetFullName().ToLower().Contains(searchText.ToLower()))
                        .ToList();
                }

                // Обновление отображаемого списка
                _displayedEmployees.Clear();
                foreach (var employee in _filteredEmployees)
                {
                    _displayedEmployees.Add(employee);
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
            lblCount.Text = $"Найдено: {_displayedEmployees.Count}";
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
            if (employeesDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = employeesDataGridView.SelectedRows[0];
                if (selectedRow.DataBoundItem is Employee employee)
                {
                    SelectedEmployee = employee;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника из списка", "Информация",
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

        private void employeesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSelect_Click(sender, e);
            }
        }
    }
}