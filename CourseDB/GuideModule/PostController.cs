using AuthorizationLibrary;
using CourseDB.Data;
using CourseDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuideModule
{
    public class PostController : GuideController
    {
        private BindingList<Post> bindingList;
        public PostController(BaseForm form, int user_id, InitRepos initRepos, MenuState menuState) : base(form, user_id, initRepos, menuState)
        {
            view.dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            view.textBoxSearch.KeyDown += TextBoxSearch_KeyDown;
            UpdateColumnTable();
            UpdateRowTable();
            SetupAutoComplete();
        }

        public override void CreateRowTable()
        {
            string postName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите название должности:",
                "Новая должность",
            "");

            Post post = new Post
            {
                NamePost = postName,
            };

            dataBase.postRep.Save(post);
            bindingList.Add(post);

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
            Post selected = bindingList[selectedIndex];

            // Запрашиваем новое название
            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новое название должности:",
                "Редактирование должности",
                selected.NamePost);

            // Проверяем ввод
            if (string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            // Обновляем данные
            selected.NamePost = newName;

            // Обновляем отображение
            view.dataGridView.Refresh();

            dataBase.postRep.Save(selected);
            SetupAutoComplete();
        }

        public override void Search()
        {
            string searchText = view.textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Введите название должности для поиска", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int foundIndex = -1;
            for (int i = 0; i < bindingList.Count; i++)
            {
                if (bindingList[i].NamePost.ToLower().Contains(searchText.ToLower()))
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
                MessageBox.Show($"Должность с названием \"{searchText}\" не найдена", "Результат поиска",
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
                "Вы уверены, что хотите удалить выбранную должнось?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Получаем индекс выбранной строки
                int selectedIndex = view.dataGridView.SelectedRows[0].Index;
                Post ToDelete = bindingList[selectedIndex];
                bindingList.RemoveAt(selectedIndex);
                dataBase.postRep.Delete(ToDelete);
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
            brandColumn.HeaderText = "Название должности";
            brandColumn.Name = "NamePost";
            brandColumn.DataPropertyName = "NamePost";
            brandColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            brandColumn.ReadOnly = true; // Только чтение
            view.dataGridView.Columns.Add(brandColumn);
        }

        public override void UpdateRowTable()
        {
            List<Post> DataModels = dataBase.postRep.GetAll();
            bindingList = new BindingList<Post>(DataModels);
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

            foreach (var post in bindingList)
            {
                autoCompleteCollection.Add(post.NamePost);
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
