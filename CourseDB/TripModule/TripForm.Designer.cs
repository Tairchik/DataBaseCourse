namespace TripModule
{
    partial class TripForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainTableLayout;
        private Panel filterPanel;
        private TableLayoutPanel filterTableLayout;
        private Label dateLabel;
        private DateTimePicker dateFilterPicker;
        private Label routeLabel;
        private ComboBox routeFilterComboBox;
        private Button applyFilterButton;
        private Button resetFilterButton;
        private Panel tablePanel;
        private DataGridView tripsDataGridView;
        private Panel buttonsPanel;
        private FlowLayoutPanel buttonsFlowLayout;
        private Button createButton;
        private Button editButton;
        private Button deleteButton;
        private Button cancelButton;

        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colDirection;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TripForm));
            mainTableLayout = new TableLayoutPanel();
            filterPanel = new Panel();
            filterTableLayout = new TableLayoutPanel();
            dateLabel = new Label();
            dateFilterPicker = new DateTimePicker();
            routeLabel = new Label();
            routeFilterComboBox = new ComboBox();
            applyFilterButton = new Button();
            resetFilterButton = new Button();
            tablePanel = new Panel();
            tripsDataGridView = new DataGridView();
            colNumber = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colDirection = new DataGridViewTextBoxColumn();
            buttonsPanel = new Panel();
            buttonsFlowLayout = new FlowLayoutPanel();
            createButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            cancelButton = new Button();
            mainTableLayout.SuspendLayout();
            filterPanel.SuspendLayout();
            filterTableLayout.SuspendLayout();
            tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tripsDataGridView).BeginInit();
            buttonsPanel.SuspendLayout();
            buttonsFlowLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.Controls.Add(filterPanel, 0, 0);
            mainTableLayout.Controls.Add(tablePanel, 0, 1);
            mainTableLayout.Controls.Add(buttonsPanel, 0, 2);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 3;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainTableLayout.Size = new Size(1000, 600);
            mainTableLayout.TabIndex = 0;
            // 
            // filterPanel
            // 
            filterPanel.Controls.Add(filterTableLayout);
            filterPanel.Dock = DockStyle.Fill;
            filterPanel.Location = new Point(3, 3);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(10);
            filterPanel.Size = new Size(994, 74);
            filterPanel.TabIndex = 0;
            // 
            // filterTableLayout
            // 
            filterTableLayout.ColumnCount = 6;
            filterTableLayout.ColumnStyles.Add(new ColumnStyle());
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            filterTableLayout.ColumnStyles.Add(new ColumnStyle());
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            filterTableLayout.ColumnStyles.Add(new ColumnStyle());
            filterTableLayout.ColumnStyles.Add(new ColumnStyle());
            filterTableLayout.Controls.Add(dateLabel, 0, 0);
            filterTableLayout.Controls.Add(dateFilterPicker, 1, 0);
            filterTableLayout.Controls.Add(routeLabel, 2, 0);
            filterTableLayout.Controls.Add(routeFilterComboBox, 3, 0);
            filterTableLayout.Controls.Add(applyFilterButton, 4, 0);
            filterTableLayout.Controls.Add(resetFilterButton, 5, 0);
            filterTableLayout.Dock = DockStyle.Fill;
            filterTableLayout.Location = new Point(10, 10);
            filterTableLayout.Name = "filterTableLayout";
            filterTableLayout.RowCount = 1;
            filterTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filterTableLayout.Size = new Size(974, 54);
            filterTableLayout.TabIndex = 0;
            // 
            // dateLabel
            // 
            dateLabel.Anchor = AnchorStyles.Left;
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(3, 19);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(35, 15);
            dateLabel.TabIndex = 0;
            dateLabel.Text = "Дата:";
            // 
            // dateFilterPicker
            // 
            dateFilterPicker.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dateFilterPicker.Format = DateTimePickerFormat.Short;
            dateFilterPicker.Location = new Point(44, 15);
            dateFilterPicker.Name = "dateFilterPicker";
            dateFilterPicker.Size = new Size(325, 23);
            dateFilterPicker.TabIndex = 1;
            // 
            // routeLabel
            // 
            routeLabel.Anchor = AnchorStyles.Left;
            routeLabel.AutoSize = true;
            routeLabel.Location = new Point(375, 19);
            routeLabel.Name = "routeLabel";
            routeLabel.Size = new Size(63, 15);
            routeLabel.TabIndex = 2;
            routeLabel.Text = "Маршрут:";
            // 
            // routeFilterComboBox
            // 
            routeFilterComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            routeFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            routeFilterComboBox.FormattingEnabled = true;
            routeFilterComboBox.Location = new Point(444, 15);
            routeFilterComboBox.Name = "routeFilterComboBox";
            routeFilterComboBox.Size = new Size(325, 23);
            routeFilterComboBox.TabIndex = 3;
            // 
            // applyFilterButton
            // 
            applyFilterButton.Anchor = AnchorStyles.Left;
            applyFilterButton.AutoSize = true;
            applyFilterButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            applyFilterButton.Location = new Point(775, 9);
            applyFilterButton.Name = "applyFilterButton";
            applyFilterButton.Padding = new Padding(10, 5, 10, 5);
            applyFilterButton.Size = new Size(100, 35);
            applyFilterButton.TabIndex = 4;
            applyFilterButton.Text = "Применить";
            applyFilterButton.UseVisualStyleBackColor = true;
            // 
            // resetFilterButton
            // 
            resetFilterButton.Anchor = AnchorStyles.Left;
            resetFilterButton.AutoSize = true;
            resetFilterButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            resetFilterButton.Location = new Point(881, 9);
            resetFilterButton.Name = "resetFilterButton";
            resetFilterButton.Padding = new Padding(10, 5, 10, 5);
            resetFilterButton.Size = new Size(90, 35);
            resetFilterButton.TabIndex = 5;
            resetFilterButton.Text = "Сбросить";
            resetFilterButton.UseVisualStyleBackColor = true;
            // 
            // tablePanel
            // 
            tablePanel.Controls.Add(tripsDataGridView);
            tablePanel.Dock = DockStyle.Fill;
            tablePanel.Location = new Point(3, 83);
            tablePanel.Name = "tablePanel";
            tablePanel.Padding = new Padding(10);
            tablePanel.Size = new Size(994, 444);
            tablePanel.TabIndex = 1;
            // 
            // tripsDataGridView
            // 
            tripsDataGridView.AllowUserToAddRows = false;
            tripsDataGridView.AllowUserToDeleteRows = false;
            tripsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tripsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tripsDataGridView.Columns.AddRange(new DataGridViewColumn[] { colNumber, colDate, colTime, colDirection });
            tripsDataGridView.Dock = DockStyle.Fill;
            tripsDataGridView.Location = new Point(10, 10);
            tripsDataGridView.Name = "tripsDataGridView";
            tripsDataGridView.ReadOnly = true;
            tripsDataGridView.RowHeadersVisible = false;
            tripsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tripsDataGridView.Size = new Size(974, 424);
            tripsDataGridView.TabIndex = 0;
            // 
            // colNumber
            // 
            colNumber.HeaderText = "№";
            colNumber.Name = "colNumber";
            colNumber.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.HeaderText = "Дата выезда";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colTime
            // 
            colTime.HeaderText = "Время выезда";
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colDirection
            // 
            colDirection.HeaderText = "Направление";
            colDirection.Name = "colDirection";
            colDirection.ReadOnly = true;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(buttonsFlowLayout);
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.Location = new Point(3, 533);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(10);
            buttonsPanel.Size = new Size(994, 64);
            buttonsPanel.TabIndex = 2;
            // 
            // buttonsFlowLayout
            // 
            buttonsFlowLayout.AutoSize = true;
            buttonsFlowLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonsFlowLayout.Controls.Add(createButton);
            buttonsFlowLayout.Controls.Add(editButton);
            buttonsFlowLayout.Controls.Add(deleteButton);
            buttonsFlowLayout.Controls.Add(cancelButton);
            buttonsFlowLayout.Dock = DockStyle.Fill;
            buttonsFlowLayout.Location = new Point(10, 10);
            buttonsFlowLayout.Name = "buttonsFlowLayout";
            buttonsFlowLayout.Size = new Size(974, 44);
            buttonsFlowLayout.TabIndex = 0;
            // 
            // createButton
            // 
            createButton.AutoSize = true;
            createButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            createButton.Location = new Point(3, 3);
            createButton.MinimumSize = new Size(80, 35);
            createButton.Name = "createButton";
            createButton.Padding = new Padding(10, 5, 10, 5);
            createButton.Size = new Size(80, 35);
            createButton.TabIndex = 0;
            createButton.Text = "Создать";
            createButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            editButton.AutoSize = true;
            editButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            editButton.Location = new Point(89, 3);
            editButton.MinimumSize = new Size(80, 35);
            editButton.Name = "editButton";
            editButton.Padding = new Padding(10, 5, 10, 5);
            editButton.Size = new Size(91, 35);
            editButton.TabIndex = 1;
            editButton.Text = "Изменить";
            editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.AutoSize = true;
            deleteButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            deleteButton.Location = new Point(186, 3);
            deleteButton.MinimumSize = new Size(80, 35);
            deleteButton.Name = "deleteButton";
            deleteButton.Padding = new Padding(10, 5, 10, 5);
            deleteButton.Size = new Size(81, 35);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Удалить";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.AutoSize = true;
            cancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cancelButton.Location = new Point(273, 3);
            cancelButton.MinimumSize = new Size(80, 35);
            cancelButton.Name = "cancelButton";
            cancelButton.Padding = new Padding(10, 5, 10, 5);
            cancelButton.Size = new Size(80, 35);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // TripForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(mainTableLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1016, 639);
            Name = "TripForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление рейсами";
            mainTableLayout.ResumeLayout(false);
            filterPanel.ResumeLayout(false);
            filterTableLayout.ResumeLayout(false);
            filterTableLayout.PerformLayout();
            tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tripsDataGridView).EndInit();
            buttonsPanel.ResumeLayout(false);
            buttonsPanel.PerformLayout();
            buttonsFlowLayout.ResumeLayout(false);
            buttonsFlowLayout.PerformLayout();
            ResumeLayout(false);
        }
    }
}