using AuthorizationLibrary;
using CourseDB;
using GuideModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialModule
{
    public class PostSalaryController: GuideController
    {
        private BindingList<Post> bindingList;
        public PostSalaryController(BaseForm form, int user_id, InitRepos initRepos, MenuState menuState) : base(form, user_id, initRepos, menuState)
        {
            view.dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            view.textBoxSearch.KeyDown += TextBoxSearch_KeyDown;
            UpdateColumnTable();
            UpdateRowTable();
            SetupAutoComplete();
        }

        public override void CreateRowTable()
        {
            using (PostEditForm form = new PostEditForm(user_id))
            {
                try
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (bindingList.Any(b => string.Equals(b.NamePost, form.ResultModel.NamePost, StringComparison.OrdinalIgnoreCase)))
                        {
                            MessageBox.Show($"Должность {form.ResultModel.NamePost} уже сущесвтует", "Уведомление",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        Post newPost = form.ResultModel;
                        dataBase.postRep.Save(newPost);
                        bindingList.Add(newPost);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
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

            using (PostEditForm form = new PostEditForm(selected, user_id))
            {
                try
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Post updated = form.ResultModel;

                        // Обновляем в БД
                        dataBase.postRep.Save(updated);

                        // Обновляем в списке
                        bindingList[selectedIndex] = updated;
                        view.dataGridView.Refresh();
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
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
                "Вы уверены, что хотите удалить выбранную должность?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedIndex = view.dataGridView.SelectedRows[0].Index;
                    Post ToDelete = bindingList[selectedIndex];
                    dataBase.postRep.Delete(ToDelete);
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

            DataGridViewTextBoxColumn brandColumn = new DataGridViewTextBoxColumn();
            brandColumn.HeaderText = "Название должности";
            brandColumn.Name = "NamePost";
            brandColumn.DataPropertyName = "NamePost";
            brandColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            brandColumn.ReadOnly = true; 
            view.dataGridView.Columns.Add(brandColumn);

            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Оклад";
            column.Name = "Salary";
            column.DataPropertyName = "Salary";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true; 
            view.dataGridView.Columns.Add(column);
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
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

            foreach (var post in bindingList)
            {
                autoCompleteCollection.Add(post.NamePost);
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
