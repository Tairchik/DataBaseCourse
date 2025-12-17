using CourseDB;
using AuthorizationLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinancialModule
{
    public partial class RevenueRoutForm : Form
    {
        // Результат работы формы - список маршрутов с обновленной выручкой
        public List<Rout> ResultRoutes { get; private set; }

        // Исходные данные
        private List<Rout> allRoutes;
        private List<Rout> filteredRoutes;
        private BindingList<Rout> bindingList;
        private InitRepos dataBase;
        private int userId;

        // Конструктор формы
        public RevenueRoutForm(InitRepos init, int user_id, MenuState menuState)
        {
            InitializeComponent();
            dataBase = init;
            this.allRoutes = dataBase.routRep.GetAll();
            this.userId = user_id;
            this.filteredRoutes = new List<Rout>();
            this.ResultRoutes = new List<Rout>();

            InitializeForm();
            LoadData();
        }

        private void InitializeForm()
        {
            ApplyFontSettings();
            SetupAutoComplete();
            InitializeDataGridView();
        }

        private void ApplyFontSettings()
        {
            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(userId);
            this.Font = f;
        }
        private void SetupAutoComplete()
        {
            comboBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void InitializeDataGridView()
        {
            dataGridViewRoutes.AutoGenerateColumns = false;
            dataGridViewRoutes.AllowUserToAddRows = false;
            dataGridViewRoutes.AllowUserToDeleteRows = false;
            dataGridViewRoutes.ReadOnly = true;
            dataGridViewRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRoutes.MultiSelect = false;
        }

        private void LoadData()
        {
            // Заполняем комбобокс названиями маршрутов
            comboBoxSearch.Items.Clear();
            foreach (var route in allRoutes)
            {
                comboBoxSearch.Items.Add(route.NameRoute);
            }

            // Инициализируем фильтрованный список
            filteredRoutes = allRoutes.ToList();

            // Создаем BindingList для DataGridView
            bindingList = new BindingList<Rout>(filteredRoutes);
            dataGridViewRoutes.DataSource = bindingList;

            // Обновляем номера строк
            UpdateRowNumbers();
        }

       
        
        private void UpdateRowNumbers()
        {
            for (int i = 0; i < dataGridViewRoutes.Rows.Count; i++)
            {
                dataGridViewRoutes.Rows[i].Cells["colNumber"].Value = i + 1;
            }
        }

        // Применение фильтра
        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            string searchText = comboBoxSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                // Если поле пустое, показываем все маршруты
                filteredRoutes = allRoutes.ToList();
            }
            else
            {
                // Фильтруем маршруты по названию (без учета регистра)
                filteredRoutes = allRoutes
                    .Where(r => r.NameRoute.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            // Обновляем BindingList
            bindingList = new BindingList<Rout>(filteredRoutes);
            dataGridViewRoutes.DataSource = bindingList;
            UpdateRowNumbers();

            // Очищаем поле выручки, так как выборка изменилась
            textBoxPlannedRevenue.Text = "";
        }

        // Сброс фильтра
        private void buttonResetFilter_Click(object sender, EventArgs e)
        {
            comboBoxSearch.Text = "";
            filteredRoutes = allRoutes.ToList();
            bindingList = new BindingList<Rout>(filteredRoutes);
            dataGridViewRoutes.DataSource = bindingList;
            UpdateRowNumbers();
            textBoxPlannedRevenue.Text = "";
        }

        // При изменении выделенной строки в таблице
        private void dataGridViewRoutes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRoutes.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewRoutes.SelectedRows[0];
                if (selectedRow.DataBoundItem is Rout selectedRoute)
                {
                    // Заполняем поле выручки значением из выбранного маршрута
                    textBoxPlannedRevenue.Text = selectedRoute.Revenue.ToString("F2");
                }
            }
            else
            {
                textBoxPlannedRevenue.Text = "";
            }
        }

        // Применение изменений
        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                // Если выбрана строка и введено значение в поле выручки
                if (dataGridViewRoutes.SelectedRows.Count > 0 && !string.IsNullOrWhiteSpace(textBoxPlannedRevenue.Text))
                {
                    if (decimal.TryParse(textBoxPlannedRevenue.Text, out decimal newRevenue))
                    {
                        if (newRevenue < 0)
                        {
                            MessageBox.Show("Плановая выручка не может быть отрицательной", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxPlannedRevenue.Focus();
                            return;
                        }

                        // Обновляем выручку для выбранного маршрута
                        var selectedRow = dataGridViewRoutes.SelectedRows[0];
                        if (selectedRow.DataBoundItem is Rout selectedRoute)
                        {
                            selectedRoute.Revenue = newRevenue;
                            dataBase.routRep.Save(selectedRoute);
                            dataGridViewRoutes.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное числовое значение для плановой выручки", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPlannedRevenue.Focus();
                        return;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(textBoxPlannedRevenue.Text))
                {
                    // Если значение введено, но строка не выбрана
                    MessageBox.Show("Выберите маршрут для изменения плановой выручки", "Предупреждение",
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Метод для обновления выручки для всех маршрутов в списке
        public void ApplyRevenueToAll(decimal revenue)
        {
            if (bindingList.Count > 0)
            {
                foreach (var route in bindingList)
                {
                    route.Revenue = revenue;
                }
                dataGridViewRoutes.Refresh();
            }
        }

        // Метод для получения текущего выбранного маршрута
        public Rout GetSelectedRoute()
        {
            if (dataGridViewRoutes.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewRoutes.SelectedRows[0];
                return selectedRow.DataBoundItem as Rout;
            }
            return null;
        }

        // Метод для получения текущего значения выручки
        public decimal? GetCurrentRevenue()
        {
            if (decimal.TryParse(textBoxPlannedRevenue.Text, out decimal revenue))
            {
                return revenue;
            }
            return null;
        }
    }
}