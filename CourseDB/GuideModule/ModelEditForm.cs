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
using System.Security.Cryptography.X509Certificates;
using AuthorizationLibrary;

namespace GuideModule
{
    public partial class ModelEditForm : Form
    {
        public Model ResultModel { get; private set; }
        private List<BrandDataModel> brands;
        private bool isEditMode;

        // Конструктор для создания новой модели
        public ModelEditForm(List<BrandDataModel> brands, int user_id)
        {
            InitializeComponent();
            this.brands = brands;
            this.isEditMode = false;
            InitializeBrandComboBox();
            this.Text = "Новая модель";
            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(user_id);
            this.Font = f;
        }

        // Конструктор для редактирования существующей модели
        public ModelEditForm(List<BrandDataModel> brands, Model existingModel, int user_id)
        {
            InitializeComponent();
            this.brands = brands;
            this.isEditMode = true;
            ResultModel = existingModel;
            InitializeBrandComboBox();

            comboBoxBrand.Text = existingModel.NameBrand;
            textBoxModelName.Text = existingModel.NameModel;
            numericUpDownSeatCapacity.Value = existingModel.SeatingCapacity;
            numericUpDownFullCapacity.Value = existingModel.FullCapacity;

            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(user_id);
            this.Font = f;
            this.Text = "Редактирование модели";
        }

        private void InitializeBrandComboBox()
        {
            if (brands == null || brands.Count == 0)
            {
                MessageBox.Show("Список брендов пуст", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            comboBoxBrand.DataSource = brands;
            comboBoxBrand.DisplayMember = "BrandName";
            comboBoxBrand.ValueMember = "Id";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация
                if (comboBoxBrand.SelectedItem == null)
                {
                    MessageBox.Show("Выберите бренд", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxBrand.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxModelName.Text))
                {
                    MessageBox.Show("Введите название модели", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxModelName.Focus();
                    return;
                }

                int seatCapacity = (int)numericUpDownSeatCapacity.Value;
                int fullCapacity = (int)numericUpDownFullCapacity.Value;

                if (seatCapacity > fullCapacity)
                {
                    MessageBox.Show("Число посадочных мест не может превышать полную вместимость",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numericUpDownSeatCapacity.Focus();
                    return;
                }

                if (ResultModel == null) 
                {
                    ResultModel = new Model(
                        comboBoxBrand.Text,
                        textBoxModelName.Text.Trim(),
                        fullCapacity,
                        seatCapacity
                    );
                }
                else
                {
                    ResultModel.NameBrand = comboBoxBrand.Text;
                    ResultModel.NameModel = textBoxModelName.Text.Trim();
                    ResultModel.FullCapacity = fullCapacity;
                    ResultModel.SeatingCapacity = seatCapacity;
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
