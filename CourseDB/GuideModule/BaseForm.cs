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

        protected void InitializeComponent(BaseForm baseForm)
        {
            baseForm.mainTableLayout = new TableLayoutPanel();
            baseForm.searchTableLayout = new TableLayoutPanel();
            baseForm.labelSearch = new Label();
            baseForm.textBoxSearch = new TextBox();
            baseForm.buttonApply = new Button();
            baseForm.dataGridView = new DataGridView();
            baseForm.buttonsFlowLayout = new FlowLayoutPanel();
            baseForm.buttonCreate = new Button();
            baseForm.buttonEdit = new Button();
            baseForm.buttonDelete = new Button();
            baseForm.buttonCancel = new Button();
            baseForm.mainTableLayout.SuspendLayout();
            baseForm.searchTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            baseForm.buttonsFlowLayout.SuspendLayout();
            baseForm.SuspendLayout();
            // 
            // mainTableLayout
            // 
            baseForm.mainTableLayout.ColumnCount = 1;
            baseForm.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            baseForm.mainTableLayout.Controls.Add(searchTableLayout, 0, 1);
            baseForm.mainTableLayout.Controls.Add(dataGridView, 0, 2);
            baseForm.mainTableLayout.Controls.Add(buttonsFlowLayout, 0, 3);
            baseForm.mainTableLayout.Dock = DockStyle.Fill;
            baseForm.mainTableLayout.Location = new Point(0, 0);
            baseForm.mainTableLayout.Name = "mainTableLayout";
            baseForm.mainTableLayout.Padding = new Padding(10);
            baseForm.mainTableLayout.RowCount = 4;
            baseForm.mainTableLayout.RowStyles.Add(new RowStyle());
            baseForm.mainTableLayout.RowStyles.Add(new RowStyle());
            baseForm.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            baseForm.mainTableLayout.RowStyles.Add(new RowStyle());
            baseForm.mainTableLayout.Size = new Size(684, 461);
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
            baseForm.searchTableLayout.Controls.Add(labelSearch, 0, 0);
            baseForm.searchTableLayout.Controls.Add(textBoxSearch, 1, 0);
            baseForm.searchTableLayout.Controls.Add(buttonApply, 2, 0);
            baseForm.searchTableLayout.Dock = DockStyle.Fill;
            baseForm.searchTableLayout.Location = new Point(10, 10);
            baseForm.searchTableLayout.Margin = new Padding(0, 0, 0, 10);
            baseForm.searchTableLayout.Name = "searchTableLayout";
            baseForm.searchTableLayout.RowCount = 1;
            baseForm.searchTableLayout.RowStyles.Add(new RowStyle());
            baseForm.searchTableLayout.Size = new Size(664, 29);
            baseForm.searchTableLayout.TabIndex = 1;
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
            baseForm.textBoxSearch.Size = new Size(499, 25);
            baseForm.textBoxSearch.TabIndex = 1;
            // 
            // buttonApply
            // 
            baseForm.buttonApply.Anchor = AnchorStyles.Right;
            baseForm.buttonApply.AutoSize = true;
            baseForm.buttonApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonApply.Location = new Point(573, 0);
            baseForm.buttonApply.Margin = new Padding(0);
            baseForm.buttonApply.Name = "buttonApply";
            baseForm.buttonApply.Size = new Size(91, 29);
            baseForm.buttonApply.TabIndex = 2;
            baseForm.buttonApply.Text = "Применить";
            baseForm.buttonApply.UseVisualStyleBackColor = true;
            baseForm.buttonApply.Click += ButtonApply_Click;
            // 
            // dataGridView
            // 
            baseForm.dataGridView.AllowUserToAddRows = false;
            baseForm.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            baseForm.dataGridView.Dock = DockStyle.Fill;
            baseForm.dataGridView.Location = new Point(10, 49);
            baseForm.dataGridView.Margin = new Padding(0, 0, 0, 10);
            baseForm.dataGridView.MultiSelect = false;
            baseForm.dataGridView.Name = "dataGridView";
            baseForm.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            baseForm.dataGridView.Size = new Size(664, 357);
            baseForm.dataGridView.TabIndex = 2;
            // 
            // buttonsFlowLayout
            // 
            baseForm.buttonsFlowLayout.AutoSize = true;
            baseForm.buttonsFlowLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonsFlowLayout.Controls.Add(buttonCreate);
            baseForm.buttonsFlowLayout.Controls.Add(buttonEdit);
            baseForm.buttonsFlowLayout.Controls.Add(buttonDelete);
            baseForm.buttonsFlowLayout.Controls.Add(buttonCancel);
            baseForm.buttonsFlowLayout.Dock = DockStyle.Fill;
            baseForm.buttonsFlowLayout.Location = new Point(10, 416);
            baseForm.buttonsFlowLayout.Margin = new Padding(0);
            baseForm.buttonsFlowLayout.Name = "buttonsFlowLayout";
            baseForm.buttonsFlowLayout.Size = new Size(664, 35);
            baseForm.buttonsFlowLayout.TabIndex = 3;
            baseForm.buttonsFlowLayout.WrapContents = false;
            // 
            // buttonCreate
            // 
            baseForm.buttonCreate.Anchor = AnchorStyles.None;
            baseForm.buttonCreate.AutoSize = true;
            baseForm.buttonCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonCreate.Location = new Point(0, 3);
            baseForm.buttonCreate.Margin = new Padding(0, 3, 5, 3);
            baseForm.buttonCreate.Name = "buttonCreate";
            baseForm.buttonCreate.Size = new Size(70, 29);
            baseForm.buttonCreate.TabIndex = 0;
            baseForm.buttonCreate.Text = "Создать";
            baseForm.buttonCreate.UseVisualStyleBackColor = true;
            baseForm.buttonCreate.Click += ButtonCreate_Click;
            // 
            // buttonEdit
            // 
            baseForm.buttonEdit.Anchor = AnchorStyles.None;
            baseForm.buttonEdit.AutoSize = true;
            baseForm.buttonEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonEdit.Location = new Point(75, 3);
            baseForm.buttonEdit.Margin = new Padding(0, 3, 5, 3);
            baseForm.buttonEdit.Name = "buttonEdit";
            baseForm.buttonEdit.Size = new Size(81, 29);
            baseForm.buttonEdit.TabIndex = 1;
            baseForm.buttonEdit.Text = "Изменить";
            baseForm.buttonEdit.UseVisualStyleBackColor = true;
            baseForm.buttonEdit.Click += ButtonEdit_Click;
            // 
            // buttonDelete
            // 
            baseForm.buttonDelete.Anchor = AnchorStyles.None;
            baseForm.buttonDelete.AutoSize = true;
            baseForm.buttonDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonDelete.Location = new Point(161, 3);
            baseForm.buttonDelete.Margin = new Padding(0, 3, 5, 3);
            baseForm.buttonDelete.Name = "buttonDelete";
            baseForm.buttonDelete.Size = new Size(70, 29);
            baseForm.buttonDelete.TabIndex = 2;
            baseForm.buttonDelete.Text = "Удалить";
            baseForm.buttonDelete.UseVisualStyleBackColor = true;
            baseForm.buttonDelete.Click += ButtonDelete_Click;
            // 
            // buttonCancel
            // 
            baseForm.buttonCancel.Anchor = AnchorStyles.None;
            baseForm.buttonCancel.AutoSize = true;
            baseForm.buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.buttonCancel.Location = new Point(236, 3);
            baseForm.buttonCancel.Margin = new Padding(0, 3, 0, 3);
            baseForm.buttonCancel.Name = "buttonCancel";
            baseForm.buttonCancel.Size = new Size(68, 29);
            baseForm.buttonCancel.TabIndex = 3;
            baseForm.buttonCancel.Text = "Выйти";
            baseForm.buttonCancel.UseVisualStyleBackColor = true;
            baseForm.buttonCancel.Click += ButtonCancel_Click;
            // 
            // BrandForm
            // 
            baseForm.AutoScaleDimensions = new SizeF(7F, 15F);
            baseForm.AutoScaleMode = AutoScaleMode.Font;
            baseForm.AutoSize = true;
            baseForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            baseForm.ClientSize = new Size(684, 461);
            baseForm.Controls.Add(mainTableLayout);
            baseForm.MinimumSize = new Size(700, 500);
            baseForm.Name = "BrandForm";
            baseForm.StartPosition = FormStartPosition.CenterScreen;
            baseForm.Text = "Марки";
            baseForm.mainTableLayout.ResumeLayout(false);
            baseForm.mainTableLayout.PerformLayout();
            baseForm.searchTableLayout.ResumeLayout(false);
            baseForm.searchTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            baseForm.buttonsFlowLayout.ResumeLayout(false);
            baseForm.buttonsFlowLayout.PerformLayout();
            baseForm.ResumeLayout(false);
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
