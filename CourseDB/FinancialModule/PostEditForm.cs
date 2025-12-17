using AuthorizationLibrary;
using CourseDB.Data;
using CourseDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialModule
{
    public partial class PostEditForm : Form
    {
        public Post ResultModel { get; private set; }

        public PostEditForm(int user_id)
        {
            InitializeComponent();
            this.Text = "Новая должность";
            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(user_id);
            this.Font = f;
        }

        public PostEditForm(Post existingPost, int user_id)
        {
            InitializeComponent();
            ResultModel = existingPost;

            textBoxPost.Text = existingPost.NamePost;
            numericSalary.Value = existingPost.Salary;

            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(user_id);
            this.Font = f;
            this.Text = "Редактирование должности";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация
                if (string.IsNullOrWhiteSpace(textBoxPost.Text))
                {
                    MessageBox.Show("Введите название должности", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPost.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(numericSalary.Text))
                {
                    MessageBox.Show("Введите месячный оклад", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numericSalary.Focus();
                    return;
                }

                int salary = (int)numericSalary.Value;

                if (ResultModel == null)
                {
                    ResultModel = new Post(
                        textBoxPost.Text, salary
                    );
                }
                else
                { 
                    ResultModel.NamePost = textBoxPost.Text;
                    ResultModel.Salary = salary;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
