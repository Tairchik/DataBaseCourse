using AuthorizationLibrary;
using System.Windows.Forms;

namespace MainModule
{
    public partial class MainForm : Form
    {
        private MainController _controller;

        public MainForm(User user)
        {
            InitializeComponent();
            _controller = new MainController(user, this);
            _controller.FontIsChange += FontR;
            _controller.AddMenuItems(menuStrip);
            Font f = _controller.GetFont();
            menuStrip.Font = f;
        }

        private void FontR(object sender, Font e)
        {
            menuStrip.Font = e;
        }
    }
}
