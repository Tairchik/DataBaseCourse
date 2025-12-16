namespace GuideModule
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainTableLayout_ = new TableLayoutPanel();
            searchTableLayout_ = new TableLayoutPanel();
            labelSearch_ = new Label();
            textBoxSearch_ = new TextBox();
            buttonApply_ = new Button();
            dataGridView_ = new DataGridView();
            buttonsFlowLayout_ = new FlowLayoutPanel();
            buttonCreate_ = new Button();
            buttonEdit_ = new Button();
            buttonDelete_ = new Button();
            buttonCancel_ = new Button();
            mainTableLayout_.SuspendLayout();
            searchTableLayout_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_).BeginInit();
            buttonsFlowLayout_.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout_
            // 
            mainTableLayout_.ColumnCount = 1;
            mainTableLayout_.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout_.Controls.Add(searchTableLayout_, 0, 1);
            mainTableLayout_.Controls.Add(dataGridView_, 0, 2);
            mainTableLayout_.Controls.Add(buttonsFlowLayout_, 0, 3);
            mainTableLayout_.Dock = DockStyle.Fill;
            mainTableLayout_.Location = new Point(0, 0);
            mainTableLayout_.Name = "mainTableLayout_";
            mainTableLayout_.Padding = new Padding(10);
            mainTableLayout_.RowCount = 4;
            mainTableLayout_.RowStyles.Add(new RowStyle());
            mainTableLayout_.RowStyles.Add(new RowStyle());
            mainTableLayout_.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout_.RowStyles.Add(new RowStyle());
            mainTableLayout_.Size = new Size(684, 461);
            mainTableLayout_.TabIndex = 0;
            // 
            // searchTableLayout_
            // 
            searchTableLayout_.AutoSize = true;
            searchTableLayout_.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchTableLayout_.ColumnCount = 3;
            searchTableLayout_.ColumnStyles.Add(new ColumnStyle());
            searchTableLayout_.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchTableLayout_.ColumnStyles.Add(new ColumnStyle());
            searchTableLayout_.Controls.Add(labelSearch_, 0, 0);
            searchTableLayout_.Controls.Add(textBoxSearch_, 1, 0);
            searchTableLayout_.Controls.Add(buttonApply_, 2, 0);
            searchTableLayout_.Dock = DockStyle.Fill;
            searchTableLayout_.Location = new Point(10, 10);
            searchTableLayout_.Margin = new Padding(0, 0, 0, 10);
            searchTableLayout_.Name = "searchTableLayout_";
            searchTableLayout_.RowCount = 1;
            searchTableLayout_.RowStyles.Add(new RowStyle());
            searchTableLayout_.Size = new Size(664, 29);
            searchTableLayout_.TabIndex = 1;
            // 
            // labelSearch_
            // 
            labelSearch_.Anchor = AnchorStyles.Left;
            labelSearch_.AutoSize = true;
            labelSearch_.Location = new Point(0, 4);
            labelSearch_.Margin = new Padding(0, 0, 10, 0);
            labelSearch_.Name = "labelSearch_";
            labelSearch_.Size = new Size(54, 21);
            labelSearch_.TabIndex = 0;
            labelSearch_.Text = "Поиск";
            // 
            // textBoxSearch_
            // 
            textBoxSearch_.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxSearch_.Location = new Point(64, 2);
            textBoxSearch_.Margin = new Padding(0, 0, 10, 0);
            textBoxSearch_.Name = "textBoxSearch_";
            textBoxSearch_.Size = new Size(499, 25);
            textBoxSearch_.TabIndex = 1;
            // 
            // buttonApply_
            // 
            buttonApply_.Anchor = AnchorStyles.Right;
            buttonApply_.AutoSize = true;
            buttonApply_.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApply_.Location = new Point(573, 0);
            buttonApply_.Margin = new Padding(0);
            buttonApply_.Name = "buttonApply_";
            buttonApply_.Size = new Size(91, 29);
            buttonApply_.TabIndex = 2;
            buttonApply_.Text = "Применить";
            buttonApply_.UseVisualStyleBackColor = true;
            //buttonApply_.Click += buttonApply_Click;
            // 
            // dataGridView_
            // 
            dataGridView_.AllowUserToAddRows = false;
            dataGridView_.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_.Dock = DockStyle.Fill;
            dataGridView_.Location = new Point(10, 49);
            dataGridView_.Margin = new Padding(0, 0, 0, 10);
            dataGridView_.MultiSelect = false;
            dataGridView_.Name = "dataGridView_";
            dataGridView_.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_.Size = new Size(664, 357);
            dataGridView_.TabIndex = 2;
            // 
            // buttonsFlowLayout_
            // 
            buttonsFlowLayout_.AutoSize = true;
            buttonsFlowLayout_.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonsFlowLayout_.Controls.Add(buttonCreate_);
            buttonsFlowLayout_.Controls.Add(buttonEdit_);
            buttonsFlowLayout_.Controls.Add(buttonDelete_);
            buttonsFlowLayout_.Controls.Add(buttonCancel_);
            buttonsFlowLayout_.Dock = DockStyle.Fill;
            buttonsFlowLayout_.Location = new Point(10, 416);
            buttonsFlowLayout_.Margin = new Padding(0);
            buttonsFlowLayout_.Name = "buttonsFlowLayout_";
            buttonsFlowLayout_.Size = new Size(664, 35);
            buttonsFlowLayout_.TabIndex = 3;
            buttonsFlowLayout_.WrapContents = false;
            // 
            // buttonCreate_
            // 
            buttonCreate_.Anchor = AnchorStyles.None;
            buttonCreate_.AutoSize = true;
            buttonCreate_.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCreate_.Location = new Point(0, 3);
            buttonCreate_.Margin = new Padding(0, 3, 5, 3);
            buttonCreate_.Name = "buttonCreate_";
            buttonCreate_.Size = new Size(70, 29);
            buttonCreate_.TabIndex = 0;
            buttonCreate_.Text = "Создать";
            buttonCreate_.UseVisualStyleBackColor = true;
            //buttonCreate_.Click += buttonCreate_Click;
            // 
            // buttonEdit_
            // 
            buttonEdit_.Anchor = AnchorStyles.None;
            buttonEdit_.AutoSize = true;
            buttonEdit_.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEdit_.Font = new Font("Segoe UI", 10F);
            buttonEdit_.Location = new Point(75, 3);
            buttonEdit_.Margin = new Padding(0, 3, 5, 3);
            buttonEdit_.Name = "buttonEdit_";
            buttonEdit_.Size = new Size(81, 29);
            buttonEdit_.TabIndex = 1;
            buttonEdit_.Text = "Изменить";
            buttonEdit_.UseVisualStyleBackColor = true;
            //buttonEdit_.Click += buttonEdit__Click;
            // 
            // buttonDelete_
            // 
            buttonDelete_.Anchor = AnchorStyles.None;
            buttonDelete_.AutoSize = true;
            buttonDelete_.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDelete_.Location = new Point(161, 3);
            buttonDelete_.Margin = new Padding(0, 3, 5, 3);
            buttonDelete_.Name = "buttonDelete_";
            buttonDelete_.Size = new Size(70, 29);
            buttonDelete_.TabIndex = 2;
            buttonDelete_.Text = "Удалить";
            buttonDelete_.UseVisualStyleBackColor = true;
            //buttonDelete_.Click += buttonDelete__Click;
            // 
            // buttonCancel_
            // 
            buttonCancel_.Anchor = AnchorStyles.None;
            buttonCancel_.AutoSize = true;
            buttonCancel_.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel_.Location = new Point(236, 3);
            buttonCancel_.Margin = new Padding(0, 3, 0, 3);
            buttonCancel_.Name = "buttonCancel_";
            buttonCancel_.Size = new Size(68, 29);
            buttonCancel_.TabIndex = 3;
            buttonCancel_.Text = "Отмена";
            buttonCancel_.UseVisualStyleBackColor = true;
            //buttonCancel_.Click += buttonCancel__Click;
            // 
            // BrandForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(684, 461);
            Controls.Add(mainTableLayout_);
            MinimumSize = new Size(700, 500);
            Name = "BrandForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Марки";
            mainTableLayout_.ResumeLayout(false);
            mainTableLayout_.PerformLayout();
            searchTableLayout_.ResumeLayout(false);
            searchTableLayout_.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_).EndInit();
            buttonsFlowLayout_.ResumeLayout(false);
            buttonsFlowLayout_.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label labelSearch_;
        private System.Windows.Forms.TextBox textBoxSearch_;
        private System.Windows.Forms.Button buttonApply_;
        private System.Windows.Forms.DataGridView dataGridView_;
        private System.Windows.Forms.Button buttonCreate_;
        private System.Windows.Forms.Button buttonEdit_;
        private System.Windows.Forms.Button buttonDelete_;
        private System.Windows.Forms.Button buttonCancel_;
        private System.Windows.Forms.TableLayoutPanel mainTableLayout_;
        private System.Windows.Forms.TableLayoutPanel searchTableLayout_;
        private System.Windows.Forms.FlowLayoutPanel buttonsFlowLayout_;
    }
}