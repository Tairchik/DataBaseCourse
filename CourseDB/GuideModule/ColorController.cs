using AuthorizationLibrary;
using CourseDB;
using CourseDB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideModule
{
    public class ColorController : GuideController
    {
        private BindingList<ColorDataModel> bindingList;
        public ColorController(BaseForm form, int user_id, InitRepos initRepos, MenuState menuState) : base(form, user_id, initRepos, menuState)
        {
            view.dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            view.textBoxSearch.KeyDown += TextBoxSearch_KeyDown;
            UpdateColumnTable();
            UpdateRowTable();
            SetupAutoComplete();
        }

        public override void CreateRowTable()
        {
            string colorName = Microsoft.VisualBasic.Interaction.InputBox(
            "Введите название цвета:",
            "Новый цвет",
            "");

            ColorDataModel newColor = new ColorDataModel
            {
                ColorName = colorName,
            };

            newColor.Id = dataBase.colorRep.GetOrCreate(newColor.ColorName);
            bindingList.Add(newColor);

            SetupAutoComplete();
        }

        public override void EditRowTable()
        {
            if (view.dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для редактирования", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = view.dataGridView.SelectedRows[0].Index;
            ColorDataModel selected = bindingList[selectedIndex];

            // Запрашиваем новое название
            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новое название цвета:",
                "Редактирование цвета",
                selected.ColorName);

            // Проверяем ввод
            if (string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            // Обновляем данные
            selected.ColorName = newName;

            // Обновляем отображение
            view.dataGridView.Refresh();

            dataBase.colorRep.Update(selected);
            SetupAutoComplete();
        }

        public override void Search()
        {
            string searchText = view.textBoxSearch.Text.Trim();

            // Проверяем, что поле не пустое
            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Введите название цвета для поиска", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ищем строку с совпадающим названием (регистронезависимый поиск)
            int foundIndex = -1;
            for (int i = 0; i < bindingList.Count; i++)
            {
                if (bindingList[i].ColorName.ToLower().Contains(searchText.ToLower()))
                {
                    foundIndex = i;
                    break;
                }
            }

            // Если найдено
            if (foundIndex >= 0)
            {
                // Снимаем выделение со всех строк
                view.dataGridView.ClearSelection();

                // Выделяем найденную строку
                view.dataGridView.Rows[foundIndex].Selected = true;

                // Прокручиваем к найденной строке
                view.dataGridView.FirstDisplayedScrollingRowIndex = foundIndex;

                // Устанавливаем фокус на DataGridView
                view.dataGridView.Focus();
            }
            else
            {
                MessageBox.Show($"Цвет с названием \"{searchText}\" не найден", "Результат поиска",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void DeleteRowTable()
        {
            if (view.dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для удаления", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Подтверждение удаления
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранный цвет?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Получаем индекс выбранной строки
                int selectedIndex = view.dataGridView.SelectedRows[0].Index;
                ColorDataModel ToDelete = bindingList[selectedIndex];
                bindingList.RemoveAt(selectedIndex);
                dataBase.colorRep.Delete(ToDelete.Id);
                SetupAutoComplete();
            }
        }

        public override void UpdateColumnTable()
        {
            view.dataGridView.AutoGenerateColumns = false;
            view.dataGridView.AllowUserToAddRows = false;
            view.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.dataGridView.MultiSelect = false;
            view.dataGridView.ReadOnly = true; // Запрещаем редактирование напрямую
            view.dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically; // Редактирование только программно
            view.dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // Очищаем колонки (на случай повторного вызова)
            view.dataGridView.Columns.Clear();

            // Колонка для порядкового номера
            DataGridViewTextBoxColumn numberColumn = new DataGridViewTextBoxColumn();
            numberColumn.HeaderText = "№";
            numberColumn.Name = "NumberColumn";
            numberColumn.Width = 50;
            numberColumn.ReadOnly = true;
            view.dataGridView.Columns.Add(numberColumn);

            // Колонка для названия бренда
            DataGridViewTextBoxColumn brandColumn = new DataGridViewTextBoxColumn();
            brandColumn.HeaderText = "Название цвета";
            brandColumn.Name = "ColorName";
            brandColumn.DataPropertyName = "ColorName";
            brandColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            brandColumn.ReadOnly = true; // Только чтение
            view.dataGridView.Columns.Add(brandColumn);
        }

        public override void UpdateRowTable()
        {
            List<ColorDataModel> DataModels = dataBase.colorRep.GetAll();
            bindingList = new BindingList<ColorDataModel>(DataModels);
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

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateRowNumbers();
        }

        private void SetupAutoComplete()
        {
            // Получаем все названия брендов
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

            foreach (var color in bindingList)
            {
                autoCompleteCollection.Add(color.ColorName);
            }

            // Настраиваем автодополнение для TextBox
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
