using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CourseDB;
using AuthorizationLibrary;

namespace EmployeeModule
{
    public partial class EmployeeEditForm : Form
    {
        // Результат работы формы
        public Employee ResultEmployee { get; private set; }

        // Списки данных
        private List<Post> allPosts;
        private Employee existingEmployee;
        private bool isEditMode;
        private int userId;

        // Конструктор для создания нового сотрудника
        public EmployeeEditForm(List<Post> allPosts, int user_id)
        {
            InitializeComponent();
            this.allPosts = allPosts ?? new List<Post>();
            this.userId = user_id;
            this.isEditMode = false;

            InitializeForm();
            this.Text = "Новый сотрудник";
        }

        // Конструктор для редактирования существующего сотрудника
        public EmployeeEditForm(List<Post> allPosts, Employee existingEmployee, int user_id)
        {
            InitializeComponent();
            this.allPosts = allPosts ?? new List<Post>();
            this.userId = user_id;
            this.isEditMode = true;
            this.existingEmployee = existingEmployee;
            ResultEmployee = existingEmployee;

            InitializeForm();
            LoadEmployeeData(existingEmployee);
            this.Text = "Редактирование сотрудника";
        }

        private void InitializeForm()
        {
            // Настройка шрифта
            ApplyFontSettings();

            // Заполнение выпадающих списков
            FillComboBoxes();

            // Установка начальных значений
            birthdayPicker.Value = DateTime.Today.AddYears(-25); // По умолчанию 25 лет
            timeWorkNumeric.Value = 0;
            classDriverNumeric.Value = 0;
            bonusNumeric.Value = 0;
        }

        private void ApplyFontSettings()
        {
            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(userId);
            this.Font = f;
        }

        private void FillComboBoxes()
        {
            // Заполнение списка должностей
            positionComboBox.Items.Clear();
            foreach (var post in allPosts)
            {
                positionComboBox.Items.Add(post.NamePost);
            }

            if (positionComboBox.Items.Count > 0)
                positionComboBox.SelectedIndex = 0;

            // Заполнение списка пола
            genderComboBox.Items.Clear();
            genderComboBox.Items.Add("Мужской");
            genderComboBox.Items.Add("Женский");

            if (genderComboBox.Items.Count > 0)
                genderComboBox.SelectedIndex = 0;
        }

        private void LoadEmployeeData(Employee employee)
        {
            try
            {
                // Личные данные
                surnameTextBox.Text = employee.Surname;
                nameTextBox.Text = employee.Name;
                patronymicTextBox.Text = employee.Patronymic;

                // Пол
                if (employee.Gender == Gender.M)
                    genderComboBox.SelectedIndex = 0;
                else if (employee.Gender == Gender.W)
                    genderComboBox.SelectedIndex = 1;

                // Дата рождения
                birthdayPicker.Value = employee.Birthday;

                // Адрес
                if (employee.Address != null)
                {
                    streetTextBox.Text = employee.Address.Street;
                    houseTextBox.Text = employee.Address.House;
                    apartmentTextBox.Text = employee.Address.Apartment;
                }

                // Рабочие данные
                timeWorkNumeric.Value = employee.TimeWork;
                bonusNumeric.Value = employee.Bonus;
                classDriverNumeric.Value = employee.ClassDriver;

                // Должность
                if (employee.Post != null)
                {
                    for (int i = 0; i < positionComboBox.Items.Count; i++)
                    {
                        if (positionComboBox.Items[i].ToString() == employee.Post.NamePost)
                        {
                            positionComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация обязательных полей
                if (string.IsNullOrWhiteSpace(surnameTextBox.Text))
                {
                    MessageBox.Show("Введите фамилию", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    surnameTextBox.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    MessageBox.Show("Введите имя", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nameTextBox.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(streetTextBox.Text))
                {
                    MessageBox.Show("Введите улицу", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    streetTextBox.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(houseTextBox.Text))
                {
                    MessageBox.Show("Введите номер дома", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    houseTextBox.Focus();
                    return;
                }

                if (positionComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите должность", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    positionComboBox.Focus();
                    return;
                }

                // Получение выбранной должности
                string selectedPositionName = positionComboBox.SelectedItem.ToString();
                Post selectedPost = allPosts.FirstOrDefault(p => p.NamePost == selectedPositionName);

                if (selectedPost == null)
                {
                    MessageBox.Show("Выбранная должность не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Пол
                Gender gender = Gender.M;
                if (genderComboBox.SelectedIndex == 1)
                    gender = Gender.W;

                // Создание адреса
                Address address = new Address(
                    streetTextBox.Text.Trim(),
                    houseTextBox.Text.Trim(),
                    apartmentTextBox.Text?.Trim()
                );

                if (isEditMode && existingEmployee != null)
                {
                    // Редактирование существующего сотрудника
                    existingEmployee.Surname = surnameTextBox.Text.Trim();
                    existingEmployee.Name = nameTextBox.Text.Trim();
                    existingEmployee.Patronymic = patronymicTextBox.Text?.Trim();
                    existingEmployee.Gender = gender;
                    existingEmployee.Birthday = birthdayPicker.Value;
                    existingEmployee.Address = address;
                    existingEmployee.TimeWork = (int)timeWorkNumeric.Value;
                    existingEmployee.Post = selectedPost;
                    existingEmployee.ClassDriver = (int)classDriverNumeric.Value;
                    existingEmployee.Bonus = bonusNumeric.Value;

                    ResultEmployee = existingEmployee;
                }
                else
                {
                    // Создание нового сотрудника
                    ResultEmployee = new Employee(
                        name: nameTextBox.Text.Trim(),
                        surname: surnameTextBox.Text.Trim(),
                        gender: gender,
                        birthday: birthdayPicker.Value,
                        address: address,
                        post: selectedPost,
                        timeWork: (int)timeWorkNumeric.Value,
                        patronymic: patronymicTextBox.Text?.Trim(),
                        bonus: bonusNumeric.Value,
                        classDriver: (int)classDriverNumeric.Value
                    );
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}