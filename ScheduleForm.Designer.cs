namespace Coursework
{
    partial class ScheduleForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.Size = new Size(936, 544);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 1);
            tableLayoutPanel2.Controls.Add(label4, 1, 1);
            tableLayoutPanel2.Controls.Add(comboBox1, 0, 2);
            tableLayoutPanel2.Controls.Add(comboBox2, 1, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(13, 13);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(910, 144);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(label1, 4);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(904, 48);
            label1.TabIndex = 0;
            label1.Text = "Расписание занятий студентов";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(label2, 2);
            label2.Dock = DockStyle.Fill;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Location = new Point(3, 48);
            label2.Name = "label2";
            label2.Size = new Size(448, 48);
            label2.TabIndex = 1;
            label2.Text = "Факультет";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(label4, 2);
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(457, 48);
            label4.Name = "label4";
            label4.Size = new Size(450, 48);
            label4.TabIndex = 3;
            label4.Text = "Группа";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            tableLayoutPanel2.SetColumnSpan(comboBox1, 2);
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 99);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(448, 28);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "Выберите факультет";
            // 
            // comboBox2
            // 
            tableLayoutPanel2.SetColumnSpan(comboBox2, 2);
            comboBox2.Dock = DockStyle.Fill;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(457, 99);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(450, 28);
            comboBox2.TabIndex = 6;
            comboBox2.Text = "Выберите группу";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel3.Controls.Add(button1, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(13, 485);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(910, 46);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(713, 3);
            button1.Name = "button1";
            button1.Size = new Size(194, 40);
            button1.TabIndex = 0;
            button1.Text = "Показать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(13, 163);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(910, 316);
            dataGridView1.TabIndex = 3;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 544);
            Controls.Add(tableLayoutPanel1);
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Schedule";
            WindowState = FormWindowState.Maximized;
            Load += Schedule_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label label2;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button1;
        private DataGridView dataGridView1;
    }
}