using AuthorizationLibrary;
using CourseDB;
using CourseDB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuideModule
{
    public class BrandController : GuideController
    {
        private BindingList<BrandDataModel> bindingList;
        public BrandController(BaseForm form, int user_id, InitRepos initRepos, MenuState menuState) : base (form, user_id, initRepos, menuState)
        {
            view.dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            UpdateColumnTable();
            UpdateRowTable();
            SetupAutoComplete();
        }
        public override void CreateRowTable()
        {
            string brandName = Microsoft.VisualBasic.Interaction.InputBox(
            "Введите название бренда:",
            "Новый бренд",
            "");

            BrandDataModel newBrand = new BrandDataModel
            {
                BrandName = brandName
            };
            
            newBrand.Id = dataBase.brandRep.GetOrCreate(newBrand.BrandName);
            bindingList.Add(newBrand);

            SetupAutoComplete();
        }

        // Метод поиска
        public override void Search() 
        {
            string searchText = view.textBoxSearch.Text.Trim();

            // Проверяем, что поле не пустое
            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Введите название бренда для поиска", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ищем строку с совпадающим названием (регистронезависимый поиск)
            int foundIndex = -1;
            for (int i = 0; i < bindingList.Count; i++)
            {
                if (bindingList[i].BrandName.ToLower().Contains(searchText.ToLower()))
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
                MessageBox.Show($"Бренд с названием \"{searchText}\" не найден", "Результат поиска",
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
                "Вы уверены, что хотите удалить выбранный бренд?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Получаем индекс выбранной строки
                int selectedIndex = view.dataGridView.SelectedRows[0].Index;
                BrandDataModel brandToDelete = bindingList[selectedIndex];
                bindingList.RemoveAt(selectedIndex);
                dataBase.brandRep.Delete(brandToDelete.Id);
                SetupAutoComplete();
            }
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
            BrandDataModel selectedBrand = bindingList[selectedIndex];

            // Запрашиваем новое название
            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новое название бренда:",
                "Редактирование бренда",
                selectedBrand.BrandName);

            // Проверяем ввод
            if (string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            // Обновляем данные
            selectedBrand.BrandName = newName;

            // Обновляем отображение
            view.dataGridView.Refresh();

            dataBase.brandRep.Update(selectedBrand);
            SetupAutoComplete();
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
            brandColumn.HeaderText = "Название бренда";
            brandColumn.Name = "BrandName";
            brandColumn.DataPropertyName = "BrandName";
            brandColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            brandColumn.ReadOnly = true; // Только чтение
            view.dataGridView.Columns.Add(brandColumn);
        }

        public override void UpdateRowTable()
        {
            List<BrandDataModel> brandDataModels = dataBase.brandRep.GetAll();
            bindingList = new BindingList<BrandDataModel>(brandDataModels);
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

            foreach (var brand in bindingList)
            {
                autoCompleteCollection.Add(brand.BrandName);
            }

            // Настраиваем автодополнение для TextBox
            view.textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            view.textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            view.textBoxSearch.AutoCompleteCustomSource = autoCompleteCollection;
        }
    }
}
