using AuthorizationLibrary;
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

namespace GuideModule
{
    public partial class StationForm : BaseForm
    {
        public GuideController controller;
        public InitRepos initRepos;
        public StationForm(InitRepos initRepos, int user_id, MenuState menuState) : base()
        {
            InitializeComponent(this);
            this.Text = "Справочник: Остановки";
            controller = new StationController(this, user_id, initRepos, menuState);
        }
        public override void ButtonApply_Click(object sender, EventArgs e)
        {
            controller.Search();
        }

        public override void ButtonCreate_Click(object sender, EventArgs e)
        {
            controller.CreateRowTable();
        }

        public override void ButtonEdit_Click(object sender, EventArgs e)
        {
            controller.EditRowTable();
        }

        public override void ButtonDelete_Click(object sender, EventArgs e)
        {
            controller.DeleteRowTable();
        }
    }
}
