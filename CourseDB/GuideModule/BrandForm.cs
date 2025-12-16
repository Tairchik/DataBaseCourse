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
    public partial class BrandForm : BaseForm
    {
        public GuideController guideController;
        public InitRepos initRepos;

        public BrandForm(InitRepos initRepos, int user_id, MenuState menuState) : base() 
        {
            InitializeComponent(this);
            this.Text = "Марки213";
            guideController = new BrandController(this, user_id, initRepos, menuState);
        }


        public override void ButtonApply_Click(object sender, EventArgs e)
        {
            guideController.Search();
        }

        public override void ButtonCreate_Click(object sender, EventArgs e)
        {
            guideController.CreateRowTable();
        }

        public override void ButtonEdit_Click(object sender, EventArgs e)
        {
            guideController.EditRowTable();
        }

        public override void ButtonDelete_Click(object sender, EventArgs e)
        {
            guideController.DeleteRowTable();
        }
    }
}
