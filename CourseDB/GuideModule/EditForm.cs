using AuthorizationLibrary;
using CourseDB;
using CourseDB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuideModule
{
    public partial class EditForm : Form
    {
        private string model;

        public string Model_
        {
            get => model;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Поле для ввода значения не может быть пустым");
                }
                else model = value;
            }
        }

        public EditForm(int user_id, string nameForm)
        {
            InitializeComponent();
            SettingsRepository rep = new SettingsRepository();
            this.Font = rep.GetSettings(user_id);
            this.labelName.Text = $"Название {nameForm.ToLower()}:";
            this.Text = $"Создание {nameForm.ToLower()}";
        }

        public EditForm(int user_id, string oldVal, string nameForm)
        {
            InitializeComponent();
            SettingsRepository rep = new SettingsRepository();
            this.Font = rep.GetSettings(user_id);
            this.labelName.Text = $"Название {nameForm.ToLower()}:";
            this.Text = $"Редактирование {nameForm.ToLower()}";
            this.textBox.Text = oldVal;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                Model_ = textBox.Text.Trim();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
