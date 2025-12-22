using AuthorizationLibrary;
using CourseDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuideModule
{
    public abstract class GuideController
    {
        public BaseForm view;
        public int user_id;
        public InitRepos dataBase;
        public MenuState menuState;

        public GuideController(BaseForm form, int user_id, InitRepos initRepos, MenuState menuState) 
        {
            view = form;
            this.user_id = user_id;
            dataBase = initRepos;
            this.menuState = menuState;
            view.dataGridView.DataBindingComplete += DataGridView_DataCount;
            ChangeSettings();
            ChangeRootSettings(); 
        }

        private void DataGridView_DataCount(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int count = view.dataGridView.Rows.Count;
            view.lblCount.Text = $"Всего записей: {count}";
        }

        // Метод который подгружает из user настройки
        private void ChangeSettings() 
        {
            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(user_id);
            view.Font = f;
        }
        // Метод который подгружает из user права доступа
        private void ChangeRootSettings()
        {
            if (menuState.R == 0) 
            {
                MessageBox.Show("Отказано в доступе");
                view.DialogResult = DialogResult.Abort;
                view.Close();
            }
            if (menuState.W == 0)
            {
                view.buttonCreate.Visible = false;
            }
            if (menuState.E == 0)
            {
                view.buttonEdit.Visible = false;
            }
            if (menuState.D == 0)
            {
                view.buttonDelete.Visible = false;
            }
        }
        // Метод который создает столбцы в таблице
        abstract public void UpdateColumnTable();

        // Метод который заполняет таблицу
        abstract public void UpdateRowTable();

        // Метод обработчик создать
        abstract public void CreateRowTable();
        // Метод обработчик изменить
        abstract public void EditRowTable();
        // Метод обработчик удалить
        abstract public void DeleteRowTable();
        // Метод поиска
        abstract public void Search();
    }
}
