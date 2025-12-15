using AuthorizationLibrary;
using CourseDB;

namespace OtherModule
{
    public partial class SettingsForm : Form
    {
        private const int MinFontSize = 8;
        private const int MaxFontSize = 24;
        private User user;
        private Font oldFont;
        // Конструктор принимает репозиторий, как в вашем MainController
        public SettingsForm(User user)
        {
            this.user = user;
            SettingsRepository rp = new SettingsRepository();
            oldFont = rp.GetSettings(user.Id);
            this.Font = oldFont;
            InitializeComponent();
            LoadSettings();
            PopulateFontFamilies();
            PopulateFontSizes();
        }

        private void LoadSettings()
        {
            // Получаем текущий шрифт
            SettingsRepository settings = new SettingsRepository();

            Font currentFont = settings.GetSettings(user.Id);
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

            SettingsRepository settings = new SettingsRepository();
            settings.SaveSettings(user.Id, selectedFontFamily, selectedFontSize);

            // Демонстрация: Создаем новый шрифт и применяем его к форме настроек
            try
            {
                Font newFont = new Font(selectedFontFamily, selectedFontSize, FontStyle.Regular);
                this.Font = newFont;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось применить шрифт: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SettingsRepository settings = new SettingsRepository();
            settings.SaveSettings(user.Id, oldFont.FontFamily.ToString(), (int) oldFont.Size);
            // Просто закрываем форму, игнорируя изменения
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

            SettingsRepository settings = new SettingsRepository();
            settings.SaveSettings(user.Id, selectedFontFamily, selectedFontSize);

            // Демонстрация: Создаем новый шрифт и применяем его к форме настроек
            try
            {
                Font newFont = new Font(selectedFontFamily, selectedFontSize, FontStyle.Regular);
                this.Font = newFont;
                this.DialogResult = DialogResult.Cancel;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось применить шрифт: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
