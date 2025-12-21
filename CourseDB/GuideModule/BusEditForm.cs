using CourseDB;
using AuthorizationLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GuideModule
{
    public partial class BusEditForm : Form
    {
        private Bus resultBus;
        public Bus ResultModel
        {
            get => resultBus;
            private set => resultBus = value;
        }

        private List<Model> models;
        private int userId;

        public BusEditForm(List<Model> models, int user_id)
        {
            InitializeComponent();
            this.models = models;
            this.userId = user_id;

            if (!InitializeForm())
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            this.Text = "ИС Автобусный парк: Новый автобус";
        }

        public BusEditForm(List<Model> models, Bus existingBus, int user_id)
        {
            InitializeComponent();
            this.models = models;
            this.userId = user_id;
            resultBus = existingBus;

            if (!InitializeForm())
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            LoadBusData(existingBus);
            this.Text = "ИС Автобусный парк: Редактирование автобуса";
        }

        private bool InitializeForm()
        {
            InitializeModelComboBox();
            InitializeStateComboBox();
            ApplyFontSettings();

            // Установить текущую дату в DateTimePicker по умолчанию
            dateTimePickerRelease.Value = DateTime.Now;
            dateTimePickerLastOverhaul.Value = DateTime.Now;
            return true;
        }

        private void ApplyFontSettings()
        {
            SettingsRepository rep = new SettingsRepository();
            Font f = rep.GetSettings(userId);
            this.Font = f;
        }

        private bool InitializeModelComboBox()
        {
            comboBoxModel.DataSource = models;
            comboBoxModel.DisplayMember = "NameModel";
            return true;
        }

        private void InitializeStateComboBox()
        {
            // Заполняем комбобокс состояниями автобуса
            var obj = Enum.GetValues(typeof(BusState));
            List<string> val = new List<string>();  

            foreach (var item in obj) 
            {
                val.Add(BusStateExtensions.GetStringByEnum((BusState)item));
            }

            comboBoxState.DataSource = val;
            comboBoxState.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadBusData(Bus bus)
        {
            try
            {
                // Выбираем модель в комбобоксе
                foreach (Model model in comboBoxModel.Items)
                {
                    if (model.NameModel == bus.Model.NameModel)
                    {
                        comboBoxModel.SelectedItem = model;
                        break;
                    }
                }

                // Заполняем текстовые поля
                textBoxRegNumber.Text = bus.RegistrationNumber;
                textBoxBrand.Text = bus.Model.NameBrand;
                textBoxInventoryNumber.Text = bus.InventoryNumber;
                textBoxColor.Text = bus.Color;
                textBoxNumberEngine.Text = bus.EngineNumber;
                textBoxNumberBody.Text = bus.BodyNumber;
                textBoxNumberChassis.Text = bus.ChassisNumber;
                textBoxMileage.Text = bus.Mileage.ToString();

                // Заполняем комбобокс состояния
                comboBoxState.SelectedItem = bus.State;

                // Заполняем даты
                dateTimePickerRelease.Value = bus.ManufactureDate;

                if (bus.LastOverhaulDate.HasValue)
                {
                    dateTimePickerLastOverhaul.Value = bus.LastOverhaulDate.Value;
                }
                else
                {
                    // Если дата капремонта не установлена, показываем пустое значение
                    dateTimePickerLastOverhaul.Value = DateTimePicker.MinimumDateTime;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? lastOverhaulDate = dateTimePickerLastOverhaul.Value;
                Model selectedModel = (Model)comboBoxModel.SelectedItem;

                // Получаем состояние
                BusState state = BusStateExtensions.GetEnumByString((string) comboBoxState.SelectedItem);

                if (resultBus == null)
                {
                    // Создание нового автобуса
                    resultBus = new Bus(
                        textBoxInventoryNumber.Text.Trim(),
                        textBoxRegNumber.Text.Trim(),
                        selectedModel,
                        textBoxNumberEngine.Text.Trim(),
                        textBoxNumberBody.Text.Trim(),
                        textBoxNumberChassis.Text.Trim(),
                        int.Parse(textBoxMileage.Text),
                        textBoxColor.Text.Trim(),
                        dateTimePickerRelease.Value,
                        state,
                        lastOverhaulDate
                    );
                }
                else
                {
                    resultBus.InventoryNumber = textBoxInventoryNumber.Text.Trim();
                    resultBus.Model = selectedModel;
                    resultBus.RegistrationNumber = textBoxRegNumber.Text.Trim();
                    resultBus.EngineNumber = textBoxNumberEngine.Text.Trim();
                    resultBus.BodyNumber = textBoxNumberBody.Text.Trim();
                    resultBus.ChassisNumber = textBoxNumberChassis.Text.Trim();
                    resultBus.Mileage = int.Parse(textBoxMileage.Text);
                    resultBus.Color = textBoxColor.Text.Trim();
                    resultBus.ManufactureDate = dateTimePickerRelease.Value;
                    resultBus.State = state;
                    resultBus.LastOverhaulDate = lastOverhaulDate;
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

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При изменении выбранной модели обновляем поле марки
            if (comboBoxModel.SelectedItem != null)
            {
                Model selectedModel = (Model)comboBoxModel.SelectedItem;
                textBoxBrand.Text = selectedModel.NameBrand;
            }
        }
    }
}