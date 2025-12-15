using CourseDB;

namespace HelpModule
{
    public partial class ContentForm : Form
    {
        public ContentForm(InitRepos repos)
        {
            InitializeComponent();
            PopulateTopics();
        }

        // Метод заполнения дерева тем
        private void PopulateTopics()
        {
            TreeNode root = new TreeNode("АИС Автобусный парк");

            root.Nodes.Add(new TreeNode("Общие сведения"));
            root.Nodes.Add(new TreeNode("Подвижной состав"));
            root.Nodes.Add(new TreeNode("Маршрутная сеть"));
            root.Nodes.Add(new TreeNode("Кадры"));
            root.Nodes.Add(new TreeNode("Роли пользователей"));

            treeViewTopics.Nodes.Add(root);
            treeViewTopics.ExpandAll();

            // Выбор первого узла, если он есть
            if (root.Nodes.Count > 0)
                treeViewTopics.SelectedNode = root.Nodes[0];
        }

        // Обработчик события выбора узла в дереве
        private void TreeViewTopics_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string header = e.Node.Text;
            string text = "";

            switch (header)
            {
                case "АИС Автобусный парк":
                    text = "Выберите раздел слева для просмотра информации.";
                    break;

                case "Общие сведения":
                    text = "Автобусный парк – муниципальное предприятие, обслуживающее внутригородские транспортные маршруты. " +
                           "Основными компонентами деятельности являются подвижной состав, маршрутная сеть, персонал и система оперативного управления.";
                    break;

                case "Подвижной состав":
                    text = "Подвижной состав автопарка включает автобусы разных моделей и вместимости.\n\n" +
                           "Каждая единица описывается следующими признаками:\n" +
                           "- Марка и модель\n" +
                           "- Государственный регистрационный номер\n" +
                           "- VIN (Номер кузова, шасси, двигателя)\n" +
                           "- Вместимость (полная и посадочная)\n" +
                           "- Состояние (исправен, в ремонте, списан)";
                    break;

                case "Маршрутная сеть":
                    text = "Каждый маршрут характеризуется номером, списком остановок, временем оборота и графиком.\n\n" +
                          "График движения включает:\n" +
                          "- Время выхода первого и последнего автобуса.\n" +
                          "- Интервалы движения по часам суток.\n\n" +
                          "На маршрутах осуществляется оперативный контроль (время прибытия, число ездок).";
                    break;

                case "Кадры":
                    text = "В системе ведется учет сотрудников (водители, кондукторы, ИТР).\n\n" +
                           "Особенности учета:\n" +
                           "- Водители работают посменно (утро/день/вечер).\n" +
                           "- Максимальное время за рулем - 8 часов.\n" +
                           "- Хранятся данные о стаже, квалификации (класс водителя) и кадровых перемещениях (Т-2).";
                    break;

                case "Роли пользователей":
                    text = "Права доступа в системе разделены по ролям:\n\n" +
                           "1. Директор — полный доступ к отчетности.\n" +
                           "2. Кадровик — прием/увольнение, ведение трудовых книжек.\n" +
                           "3. Диспетчер — планирование выхода автобусов на линию.\n" +
                           "4. Инженер — контроль тех. состояния автобусов.\n" +
                           "5. Бухгалтер — начисление зарплаты и учет выручки.";
                    break;

                default:
                    text = "Информация по данному разделу отсутствует.";
                    break;
            }

            // Вывод текста с форматированием
            richTextBoxContent.Clear();

            // Заголовок жирным
            richTextBoxContent.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
            richTextBoxContent.AppendText(header + "\n\n");

            // Основной текст
            richTextBoxContent.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxContent.AppendText(text);
        }
    }
}
