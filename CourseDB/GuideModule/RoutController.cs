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
    public class RoutController: GuideController
    {

        private BindingList<Rout> bindingList;
        public RoutController(RoutForm form, int user_id, InitRepos initRepos, MenuState menuState) : base(form, user_id, initRepos, menuState)
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

            DataGridViewTextBoxColumn nameRoutColumn = new DataGridViewTextBoxColumn();
            nameRoutColumn.HeaderText = "Номер маршрута";
            nameRoutColumn.Name = "NameRoute";
            nameRoutColumn.DataPropertyName = "NameRoute";
            nameRoutColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nameRoutColumn.ReadOnly = true;
            view.dataGridView.Columns.Add(nameRoutColumn);

            DataGridViewTextBoxColumn startStationColumn = new DataGridViewTextBoxColumn();
            startStationColumn.HeaderText = "Начальная остановка";
            startStationColumn.Name = "StartStation";
            startStationColumn.DataPropertyName = "StartStation";
            startStationColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            startStationColumn.ReadOnly = true;
            view.dataGridView.Columns.Add(startStationColumn);

            DataGridViewTextBoxColumn endStationColumn = new DataGridViewTextBoxColumn();
            endStationColumn.HeaderText = "Конечная остановка";
            endStationColumn.Name = "EndStation";
            endStationColumn.DataPropertyName = "EndStation";
            endStationColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            endStationColumn.ReadOnly = true;
            view.dataGridView.Columns.Add(endStationColumn);
        }

        public override void UpdateRowTable()
        {
            List<Rout> Data = dataBase.routRep.GetAll();
            bindingList = new BindingList<Rout>(Data);
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
            var stations = dataBase.stationRep.GetAll();

            if (stations == null || stations.Count == 0)
            {
                MessageBox.Show("Список остановок пуст. Сначала создайте остановки.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stations_str = new List<string>(); 
            foreach (var i in stations) 
            {
                stations_str.Add(i.StationName);
            }


            using (RoutEditForm form = new RoutEditForm(stations_str, user_id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (bindingList.Any(b => string.Equals(b.NameRoute, form.ResultModel.NameRoute, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show($"Маршрут {form.ResultModel.NameRoute} уже сущесвтует", "Уведомление",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Rout newRout = form.ResultModel;

                    try
                    {
                        dataBase.routRep.Save(newRout);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Добавляем в список
                    bindingList.Add(newRout);
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
            var stations = dataBase.stationRep.GetAll();

            if (stations == null || stations.Count == 0)
            {
                MessageBox.Show("Список остановок пуст. Сначала создайте остановки.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stations_str = new List<string>();
            foreach (var i in stations)
            {
                stations_str.Add(i.StationName);
            }

            int selectedIndex = view.dataGridView.SelectedRows[0].Index;
            Rout selectedRout = bindingList[selectedIndex];


            using (RoutEditForm form = new RoutEditForm(stations_str, selectedRout, user_id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (bindingList.Any(b => string.Equals(b.NameRoute, form.ResultModel.NameRoute, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show($"Маршрут {form.ResultModel.NameRoute} уже сущесвтует", "Уведомление",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Rout updatedRout = form.ResultModel;

                    try
                    {
                        dataBase.routRep.Save(updatedRout);
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"{ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Обновляем в списке
                    bindingList[selectedIndex] = updatedRout;
                    view.dataGridView.Refresh();
                }
            }
            SetupAutoComplete();
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
                if (bindingList[i].NameRoute.ToLower().Contains(searchText.ToLower()))
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
                MessageBox.Show($"Маршрут с названием \"{searchText}\" не найден", "Результат поиска",
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
                "Вы уверены, что хотите удалить выбранный маршрут?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedIndex = view.dataGridView.SelectedRows[0].Index;
                    Rout objectToDelete = bindingList[selectedIndex];
                    dataBase.routRep.Delete(objectToDelete);
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

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateRowNumbers();
        }

        private void SetupAutoComplete()
        {
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

            foreach (var tmp in bindingList)
            {
                autoCompleteCollection.Add(tmp.NameRoute);
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
