using AuthorizationLibrary;
using CourseDB;
using GuideModule;

namespace FinancialModule
{
    public partial class SalaryForm : BaseForm
    {
        public GuideController controller;
        public SalaryForm(InitRepos initRepos, int user_id, MenuState menuState)
        {
            InitializeComponent(this);
            this.Text = "Назначить оклад";
            controller = new PostSalaryController(this, user_id, initRepos, menuState);
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
