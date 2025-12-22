using AuthorizationLibrary;
using CourseDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuideModule
{
    public abstract partial class BaseForm : Form
    {
        public Label labelSearch;
        public TextBox textBoxSearch;
        public Button buttonApply;
        public DataGridView dataGridView;
        public Button buttonCreate;
        public Button buttonEdit;
        public Button buttonDelete;
        public Button buttonCancel;
        public TableLayoutPanel mainTableLayout;
        public TableLayoutPanel searchTableLayout;
        public FlowLayoutPanel buttonsFlowLayout;
        public StatusStrip statusStrip;
        public TableLayoutPanel bottomPanel;
        public ToolStripStatusLabel lblCount;

        protected void InitializeComponent(BaseForm baseForm)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));

            baseForm.mainTableLayout = new TableLayoutPanel();
            baseForm.searchTableLayout = new TableLayoutPanel();
            baseForm.bottomPanel = new TableLayoutPanel(); // Оставляем TableLayoutPanel
            baseForm.labelSearch = new Label();
            baseForm.textBoxSearch = new TextBox();
            baseForm.buttonApply = new Button();
            baseForm.dataGridView = new DataGridView();
            baseForm.buttonsFlowLayout = new FlowLayoutPanel();
            baseForm.buttonCreate = new Button();
            baseForm.buttonEdit = new Button();
            baseForm.buttonDelete = new Button();
            baseForm.buttonCancel = new Button();
            baseForm.statusStrip = new StatusStrip();
            baseForm.lblCount = new ToolStripStatusLabel();
            baseForm.mainTableLayout.SuspendLayout();
            baseForm.searchTableLayout.SuspendLayout();
            baseForm.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(baseForm.dataGridView)).BeginInit();
            baseForm.buttonsFlowLayout.SuspendLayout();
            baseForm.statusStrip.SuspendLayout();
            baseForm.SuspendLayout();

            // 
            // mainTableLayout
            // 
            baseForm.mainTableLayout.ColumnCount = 1;
            baseForm.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            baseForm.mainTableLayout.Controls.Add(baseForm.searchTableLayout, 0, 0);
            baseForm.mainTableLayout.Controls.Add(baseForm.dataGridView, 0, 1);
            baseForm.mainTableLayout.Controls.Add(baseForm.buttonsFlowLayout, 0, 2);
            baseForm.mainTableLayout.Controls.Add(baseForm.bottomPanel, 0, 3);
            baseForm.mainTableLayout.Dock = DockStyle.Fill;
            baseForm.mainTableLayout.Location = new Point(0, 0);
            baseForm.mainTableLayout.Name = "mainTableLayout";
            baseForm.mainTableLayout.Padding = new Padding(10);
            baseForm.mainTableLayout.RowCount = 4;
            baseForm.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            baseForm.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            baseForm.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            baseForm.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            baseForm.mainTableLayout.Size = new Size(800, 600);
            baseForm.mainTableLayout.TabIndex = 0;

            // 
            // searchTableLayout
            // 
            baseForm.searchTableLayout.AutoSize = true;
            baseForm.searchTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.searchTableLayout.ColumnCount = 3;
            baseForm.searchTableLayout.ColumnStyles.Add(new ColumnStyle());
            baseForm.searchTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            baseForm.searchTableLayout.ColumnStyles.Add(new ColumnStyle());
            baseForm.searchTableLayout.Controls.Add(baseForm.labelSearch, 0, 0);
            baseForm.searchTableLayout.Controls.Add(baseForm.textBoxSearch, 1, 0);
            baseForm.searchTableLayout.Controls.Add(baseForm.buttonApply, 2, 0);
            baseForm.searchTableLayout.Dock = DockStyle.Fill;
            baseForm.searchTableLayout.Location = new Point(13, 13);
            baseForm.searchTableLayout.Name = "searchTableLayout";
            baseForm.searchTableLayout.RowCount = 1;
            baseForm.searchTableLayout.RowStyles.Add(new RowStyle());
            baseForm.searchTableLayout.Size = new Size(774, 29);
            baseForm.searchTableLayout.TabIndex = 1;

            //
            // bottomPanel
            //
            baseForm.bottomPanel.ColumnCount = 1;
            baseForm.bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            baseForm.bottomPanel.Controls.Add(baseForm.statusStrip, 0, 0);
            baseForm.bottomPanel.Dock = DockStyle.Fill;
            baseForm.bottomPanel.Location = new Point(13, 563);
            baseForm.bottomPanel.Name = "bottomPanel";
            baseForm.bottomPanel.RowCount = 1;
            baseForm.bottomPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            baseForm.bottomPanel.Size = new Size(774, 24);
            baseForm.bottomPanel.TabIndex = 4;

            // 
            // statusStrip
            // 
            baseForm.statusStrip.Dock = DockStyle.Fill;
            baseForm.statusStrip.Items.AddRange(new ToolStripItem[] {
        baseForm.lblCount});
            baseForm.statusStrip.Location = new Point(0, 0);
            baseForm.statusStrip.Name = "statusStrip";
            baseForm.statusStrip.Size = new Size(774, 24);
            baseForm.statusStrip.SizingGrip = false;
            baseForm.statusStrip.TabIndex = 0;

            // 
            // lblCount
            // 
            baseForm.lblCount.Name = "lblCount";
            baseForm.lblCount.Size = new Size(759, 19);
            baseForm.lblCount.Spring = true;
            baseForm.lblCount.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // labelSearch
            // 
            baseForm.labelSearch.Anchor = AnchorStyles.Left;
            baseForm.labelSearch.AutoSize = true;
            baseForm.labelSearch.Location = new Point(0, 4);
            baseForm.labelSearch.Margin = new Padding(0, 0, 10, 0);
            baseForm.labelSearch.Name = "labelSearch";
            baseForm.labelSearch.Size = new Size(54, 21);
            baseForm.labelSearch.TabIndex = 0;
            baseForm.labelSearch.Text = "Поиск";

            // 
            // textBoxSearch
            // 
            baseForm.textBoxSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            baseForm.textBoxSearch.Location = new Point(64, 2);
            baseForm.textBoxSearch.Margin = new Padding(0, 0, 10, 0);
            baseForm.textBoxSearch.Name = "textBoxSearch";
            baseForm.textBoxSearch.Size = new Size(608, 25);
            baseForm.textBoxSearch.TabIndex = 1;

            // 
            // buttonApply
            // 
            baseForm.buttonApply.Anchor = AnchorStyles.Right;
            baseForm.buttonApply.AutoSize = true;
            baseForm.buttonApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonApply.Location = new Point(682, 0);
            baseForm.buttonApply.Margin = new Padding(0);
            baseForm.buttonApply.Name = "buttonApply";
            baseForm.buttonApply.Size = new Size(92, 29);
            baseForm.buttonApply.TabIndex = 2;
            baseForm.buttonApply.Text = "Применить";
            baseForm.buttonApply.UseVisualStyleBackColor = true;
            baseForm.buttonApply.Click += baseForm.ButtonApply_Click;

            // 
            // dataGridView
            // 
            baseForm.dataGridView.AllowUserToAddRows = false;
            baseForm.dataGridView.AllowUserToDeleteRows = false;
            baseForm.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            baseForm.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            baseForm.dataGridView.Dock = DockStyle.Fill;
            baseForm.dataGridView.Location = new Point(13, 55);
            baseForm.dataGridView.Margin = new Padding(3, 10, 3, 10);
            baseForm.dataGridView.Name = "dataGridView";
            baseForm.dataGridView.ReadOnly = true;
            baseForm.dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            baseForm.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            baseForm.dataGridView.Size = new Size(774, 472);
            baseForm.dataGridView.TabIndex = 2;

            // 
            // buttonsFlowLayout
            // 
            baseForm.buttonsFlowLayout.AutoSize = true;
            baseForm.buttonsFlowLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonsFlowLayout.Controls.Add(baseForm.buttonCreate);
            baseForm.buttonsFlowLayout.Controls.Add(baseForm.buttonEdit);
            baseForm.buttonsFlowLayout.Controls.Add(baseForm.buttonDelete);
            baseForm.buttonsFlowLayout.Controls.Add(baseForm.buttonCancel);
            baseForm.buttonsFlowLayout.Dock = DockStyle.Fill;
            baseForm.buttonsFlowLayout.Location = new Point(13, 540);
            baseForm.buttonsFlowLayout.Name = "buttonsFlowLayout";
            baseForm.buttonsFlowLayout.Size = new Size(774, 35);
            baseForm.buttonsFlowLayout.TabIndex = 3;

            // 
            // buttonCreate
            // 
            baseForm.buttonCreate.Anchor = AnchorStyles.None;
            baseForm.buttonCreate.AutoSize = true;
            baseForm.buttonCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonCreate.Location = new Point(0, 3);
            baseForm.buttonCreate.Margin = new Padding(0, 3, 10, 3);
            baseForm.buttonCreate.Name = "buttonCreate";
            baseForm.buttonCreate.Size = new Size(70, 29);
            baseForm.buttonCreate.TabIndex = 0;
            baseForm.buttonCreate.Text = "Создать";
            baseForm.buttonCreate.UseVisualStyleBackColor = true;
            baseForm.buttonCreate.Click += baseForm.ButtonCreate_Click;

            // 
            // buttonEdit
            // 
            baseForm.buttonEdit.Anchor = AnchorStyles.None;
            baseForm.buttonEdit.AutoSize = true;
            baseForm.buttonEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonEdit.Location = new Point(80, 3);
            baseForm.buttonEdit.Margin = new Padding(0, 3, 10, 3);
            baseForm.buttonEdit.Name = "buttonEdit";
            baseForm.buttonEdit.Size = new Size(81, 29);
            baseForm.buttonEdit.TabIndex = 1;
            baseForm.buttonEdit.Text = "Изменить";
            baseForm.buttonEdit.UseVisualStyleBackColor = true;
            baseForm.buttonEdit.Click += baseForm.ButtonEdit_Click;

            // 
            // buttonDelete
            // 
            baseForm.buttonDelete.Anchor = AnchorStyles.None;
            baseForm.buttonDelete.AutoSize = true;
            baseForm.buttonDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonDelete.Location = new Point(171, 3);
            baseForm.buttonDelete.Margin = new Padding(0, 3, 10, 3);
            baseForm.buttonDelete.Name = "buttonDelete";
            baseForm.buttonDelete.Size = new Size(70, 29);
            baseForm.buttonDelete.TabIndex = 2;
            baseForm.buttonDelete.Text = "Удалить";
            baseForm.buttonDelete.UseVisualStyleBackColor = true;
            baseForm.buttonDelete.Click += baseForm.ButtonDelete_Click;

            // 
            // buttonCancel
            // 
            baseForm.buttonCancel.Anchor = AnchorStyles.None;
            baseForm.buttonCancel.AutoSize = true;
            baseForm.buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonCancel.Location = new Point(251, 3);
            baseForm.buttonCancel.Margin = new Padding(0, 3, 0, 3);
            baseForm.buttonCancel.Name = "buttonCancel";
            baseForm.buttonCancel.Size = new Size(68, 29);
            baseForm.buttonCancel.TabIndex = 3;
            baseForm.buttonCancel.Text = "Выйти";
            baseForm.buttonCancel.UseVisualStyleBackColor = true;
            baseForm.buttonCancel.Click += baseForm.ButtonCancel_Click;

            // 
            // BaseForm
            // 
            baseForm.AutoScaleDimensions = new SizeF(7F, 15F);
            baseForm.AutoScaleMode = AutoScaleMode.Font;
            baseForm.ClientSize = new Size(800, 600);
            baseForm.Controls.Add(baseForm.mainTableLayout);
            baseForm.MinimumSize = new Size(816, 639);
            baseForm.Name = "BaseForm";
            baseForm.Padding = new Padding(0);
            baseForm.StartPosition = FormStartPosition.CenterScreen;
            baseForm.Text = "Базовая форма";
            baseForm.mainTableLayout.ResumeLayout(false);
            baseForm.mainTableLayout.PerformLayout();
            baseForm.searchTableLayout.ResumeLayout(false);
            baseForm.searchTableLayout.PerformLayout();
            baseForm.bottomPanel.ResumeLayout(false);
            baseForm.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(baseForm.dataGridView)).EndInit();
            baseForm.buttonsFlowLayout.ResumeLayout(false);
            baseForm.buttonsFlowLayout.PerformLayout();
            baseForm.statusStrip.ResumeLayout(false);
            baseForm.statusStrip.PerformLayout();
            baseForm.ResumeLayout(false);
            baseForm.Icon = (Icon)resources.GetObject("$this.Icon");
        }

        public virtual void ButtonApply_Click(object sender, EventArgs e)
        {
            // Логика применения поиска
            MessageBox.Show("Поиск применен: " + textBoxSearch.Text);
        }

        public virtual void ButtonCreate_Click(object sender, EventArgs e)
        {
            // Логика создания записи
            MessageBox.Show("Создать новую запись");
        }

        public virtual void ButtonEdit_Click(object sender, EventArgs e)
        {
            // Логика редактирования записи
            if (dataGridView.SelectedRows.Count > 0)
            {
                MessageBox.Show("Изменить выбранную запись");
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения");
            }
        }

        public virtual void ButtonDelete_Click(object sender, EventArgs e)
        {
            // Логика удаления записи
            if (dataGridView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Удалить выбранную запись?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }

        public void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Логика отмены
            this.Close();
        }
    }
}
