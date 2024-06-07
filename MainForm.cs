using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Coursework
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm newAboutProgram = new AboutProgramForm();
            newAboutProgram.ShowDialog();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleForm newSchedule = new ScheduleForm();
            newSchedule.Show();
        }

        private SqlConnection sqlConnection = null;
        private List<Control> createdControls = new List<Control>();
        private void аудиторныйФондToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCreatedControls(sender, e);
            Text = "Главная программа - [Аудиторный фонд]";
            // Создаем и настраиваем элементы
            ColumnHeader columnHeader1 = new ColumnHeader();
            ColumnHeader columnHeader2 = new ColumnHeader();
            ColumnHeader columnHeader3 = new ColumnHeader();
            ColumnHeader columnHeader4 = new ColumnHeader();
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
            Button выходButton = new Button();
            ListView listView1 = new ListView();

            // Настройка tableLayoutPanel1
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(listView1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 28);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 40, 10, 10);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Size = new Size(900, 472);
            tableLayoutPanel1.TabIndex = 1;

            // Настройка tableLayoutPanel2
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(выходButton, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(13, 409);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(874, 50);
            tableLayoutPanel2.TabIndex = 0;

            // Настройка выходButton
            выходButton.Dock = DockStyle.Fill;
            выходButton.Location = new Point(657, 3);
            выходButton.Name = "выходButton";
            выходButton.Size = new Size(214, 44);
            выходButton.TabIndex = 0;
            выходButton.Text = "Выход";
            выходButton.UseVisualStyleBackColor = true;
            выходButton.Click += new EventHandler(DeleteCreatedControls);
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Dock = DockStyle.Fill;
            listView1.GridLines = true;
            listView1.Location = new Point(13, 13);
            listView1.Name = "listView1";
            listView1.Size = new Size(910, 418);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Код";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Аудитория";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Вмещаемость";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Специфика";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = -2;
            // Добавляем панели и элементы на форму
            this.Controls.Add(tableLayoutPanel1);

            // Сохраняем созданные элементы в список
            createdControls.Add(tableLayoutPanel1);
            createdControls.Add(tableLayoutPanel2);
            createdControls.Add(выходButton);
            createdControls.Add(listView1);

            // Обновляем оформление панели
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.PerformLayout();

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScheduleDB"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                SqlDataReader dataReader = null;
                listView1.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM Classrooms", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();
                    ListViewItem item = null;

                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["classroom_id"]),
                            Convert.ToString(dataReader["room_number"]),
                            Convert.ToString(dataReader["room_capacity"]),
                            Convert.ToString(dataReader["room_specific"]),
                        });
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                    {
                        sqlConnection.Close();
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void DeleteCreatedControls(object sender, EventArgs e)
        {
            Text = "Главная программа";
            // Удаление всех созданных элементов
            foreach (Control ctrl in createdControls)
            {
                this.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
            createdControls.Clear(); // Очистка списка после удаления элементов
        }

        private void преподавателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCreatedControls(sender, e);
            Text = "Главная программа - [Преподаватели]";

            // Создаем и настраиваем элементы
            ColumnHeader columnHeader1 = new ColumnHeader();
            ColumnHeader columnHeader2 = new ColumnHeader();
            ColumnHeader columnHeader3 = new ColumnHeader();
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
            TableLayoutPanel searchPanel = new TableLayoutPanel();
            Button выходButton = new Button();
            Button поискButton = new Button();
            ListView listView1 = new ListView();
            Label searchLabel = new Label();
            TextBox searchTextBox = new TextBox();

            // Настройка searchPanel
            searchPanel.ColumnCount = 3;
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            searchPanel.Controls.Add(searchLabel, 0, 0);
            searchPanel.Controls.Add(searchTextBox, 1, 0);
            searchPanel.Controls.Add(поискButton, 2, 0);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(0, 0);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(10);
            searchPanel.RowCount = 1;
            searchPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            searchPanel.Size = new Size(900, 50);

            // Настройка searchLabel
            searchLabel.Text = "ФИО:";
            searchLabel.TextAlign = ContentAlignment.MiddleRight;
            searchLabel.Dock = DockStyle.Fill;

            // Настройка searchTextBox
            searchTextBox.Dock = DockStyle.Fill;
            searchTextBox.Name = "searchTextBox";

            // Настройка поискButton
            поискButton.Text = "Поиск";
            поискButton.Dock = DockStyle.Fill;
            поискButton.Click += new EventHandler(ПоискButton_Click);

            // Настройка tableLayoutPanel1
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(searchPanel, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(listView1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 28);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 40, 10, 10);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Size = new Size(900, 472);
            tableLayoutPanel1.TabIndex = 1;

            // Настройка tableLayoutPanel2
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(выходButton, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(13, 409);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(874, 50);
            tableLayoutPanel2.TabIndex = 0;

            // Настройка выходButton
            выходButton.Dock = DockStyle.Fill;
            выходButton.Location = new Point(657, 3);
            выходButton.Name = "выходButton";
            выходButton.Size = new Size(214, 44);
            выходButton.TabIndex = 0;
            выходButton.Text = "Выход";
            выходButton.UseVisualStyleBackColor = true;
            выходButton.Click += new EventHandler(DeleteCreatedControls);

            // Настройка listView1
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.Dock = DockStyle.Fill;
            listView1.GridLines = true;
            listView1.Location = new Point(13, 53);
            listView1.Name = "listView1";
            listView1.Size = new Size(874, 346);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;

            // Настройка columnHeader1
            columnHeader1.Text = "Код";
            columnHeader1.Width = 100;

            // Настройка columnHeader2
            columnHeader2.Text = "ФИО";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 250;

            // Настройка columnHeader3
            columnHeader3.Text = "Должность";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = -2;

            // Добавляем панели и элементы на форму
            this.Controls.Add(tableLayoutPanel1);

            // Сохраняем созданные элементы в список
            createdControls.Add(tableLayoutPanel1);
            createdControls.Add(tableLayoutPanel2);
            createdControls.Add(выходButton);
            createdControls.Add(listView1);
            createdControls.Add(searchPanel);
            createdControls.Add(searchLabel);
            createdControls.Add(searchTextBox);
            createdControls.Add(поискButton);

            // Обновляем оформление панели
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.PerformLayout();

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScheduleDB"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                LoadTeachers(listView1);
            }
            else
            {
                this.Close();
            }
        }

        private void LoadTeachers(ListView listView1)
        {
            SqlDataReader dataReader = null;
            listView1.Items.Clear();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Teachers", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                ListViewItem item = null;

                while (dataReader.Read())
                {
                    item = new ListViewItem(new string[] {
                    Convert.ToString(dataReader["teacher_id"]),
                    Convert.ToString(dataReader["first_name"]),
                    Convert.ToString(dataReader["teacher_post"]),
                });
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }

        private void ПоискButton_Click(object sender, EventArgs e)
        {
            string searchText = ((TableLayoutPanel)((Button)sender).Parent).Controls["searchTextBox"].Text.Trim();

            SqlDataReader dataReader = null;
            ListView listView1 = createdControls.OfType<ListView>().FirstOrDefault();
            if (listView1 != null)
            {
                listView1.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM Teachers WHERE first_name LIKE @searchText", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    dataReader = sqlCommand.ExecuteReader();
                    ListViewItem item = null;

                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                        Convert.ToString(dataReader["teacher_id"]),
                        Convert.ToString(dataReader["first_name"]),
                        Convert.ToString(dataReader["teacher_post"]),
                    });
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }
                }
            }
        }

        private void факультетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCreatedControls(sender, e);
            Text = "Главная программа - [Факультеты]";
            // Создаем и настраиваем элементы
            ColumnHeader columnHeader1 = new ColumnHeader();
            ColumnHeader columnHeader2 = new ColumnHeader();
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
            Button выходButton = new Button();
            ListView listView1 = new ListView();

            // Настройка tableLayoutPanel1
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(listView1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 28);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 40, 10, 10);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Size = new Size(900, 472);
            tableLayoutPanel1.TabIndex = 1;

            // Настройка tableLayoutPanel2
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(выходButton, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(13, 409);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(874, 50);
            tableLayoutPanel2.TabIndex = 0;

            // Настройка выходButton
            выходButton.Dock = DockStyle.Fill;
            выходButton.Location = new Point(657, 3);
            выходButton.Name = "выходButton";
            выходButton.Size = new Size(214, 44);
            выходButton.TabIndex = 0;
            выходButton.Text = "Выход";
            выходButton.UseVisualStyleBackColor = true;
            выходButton.Click += new EventHandler(DeleteCreatedControls);
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listView1.Dock = DockStyle.Fill;
            listView1.GridLines = true;
            listView1.Location = new Point(13, 13);
            listView1.Name = "listView1";
            listView1.Size = new Size(910, 418);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Код";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Наименование";
            columnHeader2.TextAlign = HorizontalAlignment.Left;
            columnHeader2.Width = -2;

            // Добавляем панели и элементы на форму
            this.Controls.Add(tableLayoutPanel1);

            // Сохраняем созданные элементы в список
            createdControls.Add(tableLayoutPanel1);
            createdControls.Add(tableLayoutPanel2);
            createdControls.Add(выходButton);
            createdControls.Add(listView1);

            // Обновляем оформление панели
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.PerformLayout();

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScheduleDB"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                SqlDataReader dataReader = null;
                listView1.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM Faculties", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();
                    ListViewItem item = null;

                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["faculty_id"]),
                            Convert.ToString(dataReader["faculty_name"]),
                        });
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                    {
                        sqlConnection.Close();
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void предметыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCreatedControls(sender, e);
            Text = "Главная программа - [Предметы]";
            // Создаем и настраиваем элементы
            ColumnHeader columnHeader1 = new ColumnHeader();
            ColumnHeader columnHeader2 = new ColumnHeader();
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
            Button выходButton = new Button();
            ListView listView1 = new ListView();

            // Настройка tableLayoutPanel1
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(listView1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 28);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 40, 10, 10);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Size = new Size(900, 472);
            tableLayoutPanel1.TabIndex = 1;

            // Настройка tableLayoutPanel2
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(выходButton, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(13, 409);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(874, 50);
            tableLayoutPanel2.TabIndex = 0;

            // Настройка выходButton
            выходButton.Dock = DockStyle.Fill;
            выходButton.Location = new Point(657, 3);
            выходButton.Name = "выходButton";
            выходButton.Size = new Size(214, 44);
            выходButton.TabIndex = 0;
            выходButton.Text = "Выход";
            выходButton.UseVisualStyleBackColor = true;
            выходButton.Click += new EventHandler(DeleteCreatedControls);
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listView1.Dock = DockStyle.Fill;
            listView1.GridLines = true;
            listView1.Location = new Point(13, 13);
            listView1.Name = "listView1";
            listView1.Size = new Size(910, 418);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Код";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Название предмета";
            columnHeader2.TextAlign = HorizontalAlignment.Left;
            columnHeader2.Width = -2;
            // Добавляем панели и элементы на форму
            this.Controls.Add(tableLayoutPanel1);

            // Сохраняем созданные элементы в список
            createdControls.Add(tableLayoutPanel1);
            createdControls.Add(tableLayoutPanel2);
            createdControls.Add(выходButton);
            createdControls.Add(listView1);

            // Обновляем оформление панели
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.PerformLayout();

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScheduleDB"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                SqlDataReader dataReader = null;
                listView1.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM Courses", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();
                    ListViewItem item = null;

                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["course_id"]),
                            Convert.ToString(dataReader["course_name"]),
                        });
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                    {
                        sqlConnection.Close();
                    }
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
