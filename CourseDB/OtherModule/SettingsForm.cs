using CourseDB;

namespace OtherModule
{
    public partial class SettingsForm : Form
    {
        private const int MinFontSize = 8;
        private const int MaxFontSize = 24;

        // Конструктор принимает репозиторий, как в вашем MainController
        public SettingsForm(InitRepos repos)
        {
            InitializeComponent();
            LoadSettings();
            PopulateFontFamilies();
            PopulateFontSizes();
        }

        private void LoadSettings()
        {
            // Здесь должна быть логика загрузки текущих настроек из файла/БД
            // Для примера, используем текущий шрифт формы:

            // Получаем текущий шрифт
            Font currentFont = this.Font;

            // Сохраняем значения в Tag для дальнейшего использования
            cmbFontFamily.Tag = currentFont.FontFamily.Name;
            cmbFontSize.Tag = (int)currentFont.Size;
        }

        private void PopulateFontFamilies()
        {
            // Заполняем ComboBox доступными семействами шрифтов
            foreach (FontFamily family in FontFamily.Families)
            {
                cmbFontFamily.Items.Add(family.Name);
            }

            // Устанавливаем текущий шрифт (загруженный в LoadSettings)
            string currentFontName = cmbFontFamily.Tag as string;
            if (cmbFontFamily.Items.Contains(currentFontName))
            {
                cmbFontFamily.SelectedItem = currentFontName;
            }
        }

        private void PopulateFontSizes()
        {
            // Заполняем ComboBox размерами шрифтов от 8 до 24
            for (int size = MinFontSize; size <= MaxFontSize; size += 2)
            {
                cmbFontSize.Items.Add(size);
            }

            // Устанавливаем текущий размер (загруженный в LoadSettings)
            int currentSize = (int)cmbFontSize.Tag;
            if (cmbFontSize.Items.Contains(currentSize))
            {
                cmbFontSize.SelectedItem = currentSize;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cmbFontFamily.SelectedItem == null || cmbFontSize.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите и шрифт, и размер.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранные значения
            string selectedFontFamily = cmbFontFamily.SelectedItem.ToString();
            int selectedFontSize = (int)cmbFontSize.SelectedItem;

            // !!! ВАЖНО: Здесь должна быть логика сохранения настроек
            // Например, запись в файл конфигурации или в реестр.

            // Демонстрация: Создаем новый шрифт и применяем его к форме настроек
            try
            {
                Font newFont = new Font(selectedFontFamily, selectedFontSize, FontStyle.Regular);
                this.Font = newFont;

                // Здесь же нужно вызвать метод, который применит этот шрифт ко ВСЕМУ приложению
                // Например, через статический класс FontManager.ApplyFont(newFont);

                MessageBox.Show("Настройки шрифта успешно применены.", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Закрываем форму настроек после успешного применения
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось применить шрифт: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Просто закрываем форму, игнорируя изменения
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
