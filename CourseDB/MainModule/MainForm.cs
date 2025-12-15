using System.Windows.Forms;

namespace MainModule
{
    public partial class MainForm : Form
    {
        private MainController _controller;

        public MainForm(MainController controller)
        {
            InitializeComponent();
            _controller = controller;
            _controller.AddMenuItems(menuStrip);
        }

        
    }
}
