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
    public class ModelController : GuideController
    {
        private BindingList<Model> bindingList;
        public ModelController(ModelForm form, int user_id, InitRepos initRepos, MenuState menuState) : base(form, user_id, initRepos, menuState)
        {
            view.dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            view.textBoxSearch.KeyDown += TextBoxSearch_KeyDown;
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
            view.dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically; 
            view.dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            view.dataGridView.Columns.Clear();

            // Колонка для порядкового номера
            DataGridViewTextBoxColumn numberColumn = new DataGridViewTextBoxColumn();
            numberColumn.HeaderText = "№";
            numberColumn.Name = "NumberColumn";
            numberColumn.Width = 50;
            numberColumn.ReadOnly = true;
            view.dataGridView.Columns.Add(numberColumn);

            // Колонка для названия брeнда
            DataGridViewTextBoxColumn brandColumn = new DataGridViewTextBoxColumn();
            brandColumn.HeaderText = "Название бренда";
            brandColumn.Name = "NameBrand";
            brandColumn.DataPropertyName = "NameBrand";
            brandColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            brandColumn.ReadOnly = true; 
            view.dataGridView.Columns.Add(brandColumn);

            // Колонка для названия модели
            DataGridViewTextBoxColumn modelColumn = new DataGridViewTextBoxColumn();
            modelColumn.HeaderText = "Название модели";
            modelColumn.Name = "NameModel";
            modelColumn.DataPropertyName = "NameModel";
            modelColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            modelColumn.ReadOnly = true;
            view.dataGridView.Columns.Add(modelColumn);

            // Колонка для числа сидячих мест
            DataGridViewTextBoxColumn seatCapacityColumn = new DataGridViewTextBoxColumn();
            seatCapacityColumn.HeaderText = "Число посадочных мест";
            seatCapacityColumn.Name = "SeatingCapacity";
            seatCapacityColumn.DataPropertyName = "SeatingCapacity";
            seatCapacityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            seatCapacityColumn.ReadOnly = true;
            view.dataGridView.Columns.Add(seatCapacityColumn);

            // Колонка для полный посадки
            DataGridViewTextBoxColumn fullCapacityColumn = new DataGridViewTextBoxColumn();
            fullCapacityColumn.HeaderText = "Название модели";
            fullCapacityColumn.Name = "FullCapacity";
            fullCapacityColumn.DataPropertyName = "FullCapacity";
            fullCapacityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fullCapacityColumn.ReadOnly = true;
            view.dataGridView.Columns.Add(fullCapacityColumn);
        }

        public override void UpdateRowTable()
        {
            List<Model> DataModels = dataBase.modelRep.GetAll();
            bindingList = new BindingList<Model>(DataModels);
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
            List<BrandDataModel> brands = dataBase.brandRep.GetAll();
            using (ModelEditForm form = new ModelEditForm(brands, user_id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (bindingList.Any(b => string.Equals(b.NameModel, form.ResultModel.NameModel, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show($"Модель {form.ResultModel.NameModel} бренда {form.ResultModel.NameBrand} уже сущесвтует", "Уведомление",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Model newModel = form.ResultModel;

                    // Сохраняем в БД
                    dataBase.modelRep.Save(newModel);

                    // Добавляем в список
                    bindingList.Add(newModel);
                    SetupAutoComplete();
                }
            }
        }

        // Метод поиска
        public override void Search()
        {
            string searchText = view.textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Введите название модели для поиска", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int foundIndex = -1;
            for (int i = 0; i < bindingList.Count; i++)
            {
                if (bindingList[i].NameModel.ToLower().Contains(searchText.ToLower()))
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

            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранную модель?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedIndex = view.dataGridView.SelectedRows[0].Index;
                    var ToDelete = bindingList[selectedIndex];
                    dataBase.modelRep.Delete(ToDelete);
                    bindingList.RemoveAt(selectedIndex);
                    SetupAutoComplete();
                }
                catch
                {
                    MessageBox.Show($"Ошибка при удалении: данный объект " +
                       $"используется другим объектом, чтобы его удалить," +
                       $" удалите или измените объекты связанные с ним", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            Model selectedModel = bindingList[selectedIndex];

            List<BrandDataModel> brands = dataBase.brandRep.GetAll();

            using (ModelEditForm form = new ModelEditForm(brands, selectedModel, user_id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (bindingList.Any(b => string.Equals(b.NameModel, form.ResultModel.NameModel, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show($"Модель {form.ResultModel.NameModel} бренда {form.ResultModel.NameBrand} уже сущесвтует", "Уведомление",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Model updatedModel = form.ResultModel;

                    // Обновляем в БД
                    dataBase.modelRep.Save(updatedModel);

                    // Обновляем в списке
                    bindingList[selectedIndex] = updatedModel;
                    view.dataGridView.Refresh();
                    SetupAutoComplete();
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
                autoCompleteCollection.Add(tmp.NameModel);
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
