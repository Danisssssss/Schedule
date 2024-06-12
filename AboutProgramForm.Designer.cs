namespace Coursework
{
    partial class AboutProgramForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutProgramForm));
            labelProductName = new Label();
            labelCopyright = new Label();
            labelCompanyName = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBoxDescription = new TextBox();
            okButton = new Button();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelProductName
            // 
            labelProductName.Dock = DockStyle.Fill;
            labelProductName.Font = new Font("Segoe UI", 9F);
            labelProductName.Location = new Point(214, 10);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(573, 47);
            labelProductName.TabIndex = 0;
            labelProductName.Text = "Название продукта: Курсовой проект";
            labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            labelCopyright.Dock = DockStyle.Fill;
            labelCopyright.Font = new Font("Segoe UI", 9F);
            labelCopyright.Location = new Point(214, 57);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(573, 47);
            labelCopyright.TabIndex = 1;
            labelCopyright.Text = "Авторские права: Яхьяев Данис Дамирович";
            labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            labelCompanyName.Dock = DockStyle.Fill;
            labelCompanyName.Font = new Font("Segoe UI", 9F);
            labelCompanyName.Location = new Point(214, 104);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(573, 47);
            labelCompanyName.TabIndex = 2;
            labelCompanyName.Text = "Название организации: АГТУ, ИИтиК, кафедра АСОИУ";
            labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.76923F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.23077F));
            tableLayoutPanel1.Controls.Add(textBoxDescription, 1, 3);
            tableLayoutPanel1.Controls.Add(labelProductName, 1, 0);
            tableLayoutPanel1.Controls.Add(labelCopyright, 1, 1);
            tableLayoutPanel1.Controls.Add(labelCompanyName, 1, 2);
            tableLayoutPanel1.Controls.Add(okButton, 1, 4);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = SystemColors.Control;
            textBoxDescription.BorderStyle = BorderStyle.None;
            textBoxDescription.Cursor = Cursors.IBeam;
            textBoxDescription.Dock = DockStyle.Fill;
            textBoxDescription.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxDescription.Location = new Point(214, 154);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.ScrollBars = ScrollBars.Vertical;
            textBoxDescription.Size = new Size(573, 232);
            textBoxDescription.TabIndex = 4;
            textBoxDescription.TabStop = false;
            textBoxDescription.Text = resources.GetString("textBoxDescription.Text");
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.Location = new Point(693, 408);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 5;
            okButton.Text = "&ОК";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(13, 13);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel1.SetRowSpan(pictureBox1, 5);
            pictureBox1.Size = new Size(195, 424);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // AboutProgramForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutProgramForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Справка о программе";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelProductName;
        private Label labelCopyright;
        private Label labelCompanyName;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBoxDescription;
        private Button okButton;
        private PictureBox pictureBox1;
    }
}