using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginWindow
{
    public partial class MainForm : Form
    {
        private MainController _controller;

        public MainForm(MainController controller)
        {
            InitializeComponent();
            _controller = controller;
            _controller.AddMenuItems(menuStrip);
            _controller.MenuItemClick += MenuItemClick;
        }

        private void MenuItemClick(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString(), "Обработчик меню");
        }
    }
}
