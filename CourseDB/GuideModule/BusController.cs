using AuthorizationLibrary;
using CourseDB.Data;
using CourseDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideModule
{
    public class BusController: GuideController
    {
        private BindingList<Bus> bindingList;
        public BusController(BaseForm form, int user_id, InitRepos initRepos, MenuState menuState) : base(form, user_id, initRepos, menuState)
        {
            view.dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            view.textBoxSearch.KeyDown += TextBoxSearch_KeyDown;
            view.dataGridView.CellFormatting += DataGridView_CellFormatting;
            UpdateColumnTable();
            UpdateRowTable();
            SetupAutoComplete();
        }

        public override void UpdateColumnTable()
        {
            view.dataGridView.AutoGenerateColumns = false;
            view.dataGridView.AllowUserToAddRows = false;
            view.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.dataGridView.MultiSelect = false;
            view.dataGridView.ReadOnly = true;
            view.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Добавьте эту строку
            view.dataGridView.Columns.Clear();

            // 1. Номер строки (№)
            DataGridViewTextBoxColumn numberColumn = new DataGridViewTextBoxColumn();
            numberColumn.HeaderText = "№";
            numberColumn.Name = "NumberColumn";
            numberColumn.FillWeight = 40; // Вместо Width используйте FillWeight для пропорционального размера
            view.dataGridView.Columns.Add(numberColumn);

            // 2. Инвентарный номер
            DataGridViewTextBoxColumn colInv = new DataGridViewTextBoxColumn();
            colInv.HeaderText = "Инв. номер";
            colInv.Name = "InventoryNumber";
            colInv.DataPropertyName = "InventoryNumber";
            colInv.FillWeight = 100;
            view.dataGridView.Columns.Add(colInv);

            // 3. Бренд
            DataGridViewTextBoxColumn colBrand = new DataGridViewTextBoxColumn();
            colBrand.HeaderText = "Бренд";
            colBrand.Name = "BrandColumn";
            colBrand.FillWeight = 100;
            view.dataGridView.Columns.Add(colBrand);

            // 4. Модель
            DataGridViewTextBoxColumn colModel = new DataGridViewTextBoxColumn();
            colModel.HeaderText = "Модель";
            colModel.Name = "ModelColumn";
            colModel.FillWeight = 100;
            view.dataGridView.Columns.Add(colModel);

            // 5. Гос. номер
            DataGridViewTextBoxColumn colReg = new DataGridViewTextBoxColumn();
            colReg.HeaderText = "Гос. номер";
            colReg.Name = "RegistrationNumber";
            colReg.DataPropertyName = "RegistrationNumber";
            colReg.FillWeight = 100;
            view.dataGridView.Columns.Add(colReg);

            // 6. Состояние
            DataGridViewTextBoxColumn colState = new DataGridViewTextBoxColumn();
            colState.HeaderText = "Состояние";
            colState.Name = "StateColumn";
            colState.DataPropertyName = "State_str";
            colState.FillWeight = 100;
            view.dataGridView.Columns.Add(colState);

            // 7. Цвет
            DataGridViewTextBoxColumn colColor = new DataGridViewTextBoxColumn();
            colColor.HeaderText = "Цвет";
            colColor.Name = "Color";
            colColor.DataPropertyName = "Color";
            colColor.FillWeight = 80;
            view.dataGridView.Columns.Add(colColor);

            // 8. Год выпуска
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.HeaderText = "Год вып.";
            colDate.Name = "ManufactureDate";
            colDate.DataPropertyName = "ManufactureDate";
            colDate.DefaultCellStyle.Format = "yyyy";
            colDate.FillWeight = 80;
            view.dataGridView.Columns.Add(colDate);

            // 9. Пробег
            DataGridViewTextBoxColumn colMileage = new DataGridViewTextBoxColumn();
            colMileage.HeaderText = "Пробег";
            colMileage.Name = "Mileage";
            colMileage.DataPropertyName = "Mileage";
            colMileage.FillWeight = 80;
            view.dataGridView.Columns.Add(colMileage);
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, что это строка с данными, а не заголовок
            if (e.RowIndex >= 0 && e.RowIndex < bindingList.Count)
            {
                Bus currentBus = bindingList[e.RowIndex];

                // Получаем имя столбца, который сейчас отрисовывается
                string columnName = view.dataGridView.Columns[e.ColumnIndex].Name;

                if (columnName == "BrandColumn")
                {
                    // Безопасно достаем бренд через Model
                    e.Value = currentBus.Model?.NameBrand ?? "Н/Д";
                    e.FormattingApplied = true;
                }
                else if (columnName == "ModelColumn")
                {
                    // Безопасно достаем название модели
                    e.Value = currentBus.Model?.NameModel ?? "Н/Д";
                    e.FormattingApplied = true;
                }
            }
        }

        public override void UpdateRowTable()
        {
            List<Bus> Data = dataBase.busRep.GetAll();
            bindingList = new BindingList<Bus>(Data);
            view.dataGridView.DataSource = bindingList;

            SetupAutoComplete();
        }

        private void UpdateRowNumbers()
        {
            for (int i = 0; i < view.dataGridView.Rows.Count; i++)
            {
                view.dataGridView.Rows[i].Cells["NumberColumn"].Value = i + 1;
            }
        }

        public override void CreateRowTable()
        {
            var models = dataBase.modelRep.GetAll();

            if (models == null || models.Count == 0)
            {
                MessageBox.Show("Список моделей пуст. Сначала создайте модели.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BusEditForm form = new BusEditForm(models, user_id);

            // Проверяем DialogResult сразу после создания формы
            if (form.DialogResult == DialogResult.Cancel)
            {
                form.Dispose(); // Освобождаем ресурсы
                return;
            }

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (bindingList.Any(b => string.Equals(b.InventoryNumber, form.ResultModel.InventoryNumber, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"Авобус с инвентарным номером {form.ResultModel.InventoryNumber} уже сущесвтует", "Уведомление",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Bus newBus = form.ResultModel;

                // Сохраняем в БД
                dataBase.busRep.Save(newBus);

                // Добавляем в список
                bindingList.Add(newBus);
            }

            form.Dispose();
            SetupAutoComplete();
        }

        public override void EditRowTable()
        {
            if(view.dataGridView.SelectedRows.Count == 0)
    {
                MessageBox.Show("Выберите строку для редактирования", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = view.dataGridView.SelectedRows[0].Index;
            Bus selectedBus = bindingList[selectedIndex];

            // Используем только models, так как brands не нужны в форме
            List<Model> models = dataBase.modelRep.GetAll();

            if (models == null || models.Count == 0)
            {
                MessageBox.Show("Список моделей пуст.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BusEditForm form = new BusEditForm(models, selectedBus, user_id);
            DialogResult dialogResult = form.ShowDialog();


            // Проверяем DialogResult сразу после создания формы
            if (dialogResult == DialogResult.Cancel)
            {
                form.Dispose(); // Освобождаем ресурсы
                return;
            }

            if (dialogResult == DialogResult.OK)
            {
                if (bindingList.Any(b => string.Equals(b.InventoryNumber, form.ResultModel.InventoryNumber, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"Авобус с инвентарным номером {form.ResultModel.InventoryNumber} уже сущесвтует", "Уведомление",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Bus updatedBus = form.ResultModel;

                // Обновляем в БД
                dataBase.busRep.Save(updatedBus);

                // Обновляем в списке
                bindingList[selectedIndex] = updatedBus;
                view.dataGridView.Refresh();
            }

            form.Dispose();
            SetupAutoComplete();
        }

        // Метод поиска
        public override void Search()
        {
            string searchText = view.textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Введите инвентарный номер автобуса для поиска", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int foundIndex = -1;
            for (int i = 0; i < bindingList.Count; i++)
            {
                if (bindingList[i].InventoryNumber.ToLower().Contains(searchText.ToLower()))
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex >= 0)
            {

                view.dataGridView.ClearSelection();
                view.dataGridView.Rows[foundIndex].Selected = true;
                view.dataGridView.FirstDisplayedScrollingRowIndex = foundIndex;
                view.dataGridView.Focus();
            }
            else
            {
                MessageBox.Show($"Автобус с инвентарным номером \"{searchText}\" не найден", "Результат поиска",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void DeleteRowTable()
        {
            if (view.dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите автобус для удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bus selectedBus = (Bus)view.dataGridView.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить автобус {selectedBus.InventoryNumber} ({selectedBus.Model?.NameBrand} {selectedBus.Model?.NameModel})?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dataBase.busRep.Delete(selectedBus.InventoryNumber);
                    bindingList.Remove(selectedBus);
                    SetupAutoComplete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateRowNumbers();
        }

        private void SetupAutoComplete()
        {
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

            foreach (var tmp in bindingList)
            {
                autoCompleteCollection.Add(tmp.RegistrationNumber);
            }

            view.textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            view.textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            view.textBoxSearch.AutoCompleteCustomSource = autoCompleteCollection;
        }
        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
