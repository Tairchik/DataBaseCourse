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
            view.textBoxSearch.KeyDown += TextBoxSearch_KeyDown;
            UpdateColumnTable();
            UpdateRowTable();
            SetupAutoComplete();
        }
        public override void CreateRowTable()
        {
            EditForm editForm = new EditForm(base.user_id, "марки");
            DialogResult dialogResult = editForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (bindingList.Any(b =>string.Equals(b.BrandName, editForm.Model_, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"Марка {editForm.Model_} уже сущесвтует", "Уведомление",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                BrandDataModel model = new BrandDataModel
                {
                    BrandName = editForm.Model_,
                };
                model.Id = dataBase.brandRep.GetOrCreate(model.BrandName);
                
                bindingList.Add(model);
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
            var selected = bindingList[selectedIndex];

            EditForm editForm = new EditForm(base.user_id, selected.BrandName, "марки");
            DialogResult dialogResult = editForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                selected.BrandName = editForm.Model_;
                dataBase.brandRep.Update(selected);
                view.dataGridView.Refresh();
                SetupAutoComplete();
            }
        }

        public override void Search() 
        {
            string searchText = view.textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Введите название марки для поиска", "Предупреждение",
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

            if (foundIndex >= 0)
            {
                view.dataGridView.ClearSelection();
                view.dataGridView.Rows[foundIndex].Selected = true;
                view.dataGridView.FirstDisplayedScrollingRowIndex = foundIndex;
                view.dataGridView.Focus();
            }
            else
            {
                MessageBox.Show($"Марка с названием \"{searchText}\" не найден", "Результат поиска",
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
                "Вы уверены, что хотите удалить выбранную марку?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Получаем индекс выбранной строки
                try
                {
                    int selectedIndex = view.dataGridView.SelectedRows[0].Index;
                    var ToDelete = bindingList[selectedIndex];
                    dataBase.brandRep.Delete(ToDelete.BrandName);
                    bindingList.RemoveAt(selectedIndex);
                    SetupAutoComplete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: данный объект " +
                        $"используется другим объектом, чтобы его удалить," +
                        $" удалите или измените объекты связанные с ним", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            brandColumn.HeaderText = "Название марки";
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
