using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Coursework
{
    public partial class ScheduleForm : Form
    {
        private SqlConnection sqlConnection = null;
        private string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={AppDomain.CurrentDomain.GetData("DataDirectory")}ScheduleDB.mdf;Integrated Security=True";

        public ScheduleForm()
        {
            InitializeComponent();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            try
            {

                // Проверка существования файла базы данных
                string dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                string dbFilePath = Path.Combine(dataDirectory, "ScheduleDB.mdf");

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                if (sqlConnection.State == ConnectionState.Open)
                {
                    LoadFaculties(comboBox1);

                    comboBox1.SelectedIndexChanged += facultyComboBox_SelectedIndexChanged;
                    comboBox2.SelectedIndexChanged += groupComboBox_SelectedIndexChanged;
                    button1.Click += button1_Click;
                }
                else
                {
                    MessageBox.Show("Ошибка подключения!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения!");
            }
        }

        private void LoadFaculties(ComboBox facultyComboBox)
        {
            SqlDataReader dataReader = null;
            facultyComboBox.Items.Clear();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Faculties", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    facultyComboBox.Items.Add(new ComboBoxItem
                    {
                        Text = Convert.ToString(dataReader["faculty_name"]),
                        Value = Convert.ToInt32(dataReader["faculty_id"])
                    });
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

        private void LoadGroups(ComboBox groupComboBox, int facultyId)
        {
            SqlDataReader dataReader = null;
            groupComboBox.Items.Clear();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Groups WHERE faculty_id = @facultyId", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@facultyId", facultyId);
                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    groupComboBox.Items.Add(new ComboBoxItem
                    {
                        Text = Convert.ToString(dataReader["group_name"]),
                        Value = Convert.ToInt32(dataReader["group_id"])
                    });
                }

                // Устанавливаем первую группу как выбранную
                if (groupComboBox.Items.Count > 0)
                {
                    groupComboBox.SelectedIndex = 0;
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

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox facultyComboBox = sender as ComboBox;
            ComboBoxItem selectedFaculty = facultyComboBox.SelectedItem as ComboBoxItem;
            if (selectedFaculty != null)
            {
                LoadGroups(comboBox2, selectedFaculty.Value);
            }
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Можно оставить пустым или удалить, если не нужен автоматический вывод при выборе группы.
        }

        private DataTable LoadScheduleForGroup(int groupId, int weakId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"
                    SELECT 
                        Days.day_name, 
                        TimeSlots.start_time, 
                        TimeSlots.end_time, 
                        TimeSlots.timeslot_name, 
                        Courses.course_name, 
                        Teachers.first_name, 
                        Classrooms.room_number,
                        SpecificsOfOccupations.specific_name 
                    FROM Schedule
                    JOIN Days ON Schedule.day_id = Days.day_id
                    JOIN TimeSlotDetails ON Schedule.timeslotdetail_id = TimeSlotDetails.timeslotdetail_id
                    JOIN TimeSlots ON TimeSlotDetails.timeslot_id = TimeSlots.timeslot_id
                    LEFT JOIN Courses ON TimeSlotDetails.course_id = Courses.course_id
                    LEFT JOIN Teachers ON TimeSlotDetails.teacher_id = Teachers.teacher_id
                    LEFT JOIN Classrooms ON TimeSlotDetails.classroom_id = Classrooms.classroom_id
                    LEFT JOIN SpecificsOfOccupations ON TimeSlotDetails.specific_id = SpecificsOfOccupations.specific_id
                    WHERE TimeSlotDetails.group_id = @GroupId AND Schedule.weak_number = @WeakId
                    ORDER BY Days.day_id, TimeSlots.start_time";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@GroupId", groupId);
                sqlCommand.Parameters.AddWithValue("@WeakId", weakId);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

        private void DisplaySchedule(DataTable scheduleTable, DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // Настройка столбцов
            dataGridView.Columns.Add("Day", "День");
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns.Add("Pair", "Пара");
            dataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns.Add("TimeSlot", "Время");
            dataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns.Add("Course", "Дисциплина");
            dataGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns.Add("Type", "Тип");
            dataGridView.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns.Add("Teacher", "Преподаватели");
            dataGridView.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns.Add("Classroom", "Аудитория");
            dataGridView.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Установка режима авторазмера столбцов
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Список всех дней недели
            var weekDays = new List<string> { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };

            foreach (var day in weekDays)
            {
                // Получение расписания для конкретного дня
                var timeSlotsForDay = scheduleTable.AsEnumerable()
                    .Where(row => row.Field<string>("day_name") == day)
                    .Select(row => new
                    {
                        StartTime = row.Field<TimeSpan>("start_time"),
                        EndTime = row.Field<TimeSpan>("end_time"),
                        TimeSlotName = row.Field<string>("timeslot_name")
                    })
                    .Distinct()
                    .ToList();

                // Добавление заголовка дня
                int dayRowIndex = dataGridView.Rows.Add(day);
                var dayRow = dataGridView.Rows[dayRowIndex];
                dayRow.DefaultCellStyle.BackColor = Color.LightGray;

                if (timeSlotsForDay.Any())
                {
                    foreach (var timeSlot in timeSlotsForDay)
                    {
                        var rows = scheduleTable.AsEnumerable()
                            .Where(row => row.Field<string>("day_name") == day &&
                                          row.Field<TimeSpan>("start_time") == timeSlot.StartTime &&
                                          row.Field<TimeSpan>("end_time") == timeSlot.EndTime);

                        string timeSlotFormatted = $"{timeSlot.StartTime:hh\\:mm}-{timeSlot.EndTime:hh\\:mm}";

                        foreach (var row in rows)
                        {
                            dataGridView.Rows.Add(
                                "",
                                timeSlot.TimeSlotName,
                                timeSlotFormatted,
                                row["course_name"],
                                row["specific_name"],
                                row["first_name"],
                                row["room_number"]
                            );
                        }
                    }
                }
                else
                {
                    // Если на этот день нет занятий, добавляем строку с сообщением
                    int emptyRowIndex = dataGridView.Rows.Add("", "", "", "Занятия по расписанию отсутствуют");
                    var emptyRow = dataGridView.Rows[emptyRowIndex];
                    emptyRow.DefaultCellStyle.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Italic);
                    // emptyRow.Cells[3].ColumnSpan = 4;
                }
            }

            // Установка равной ширины столбцов
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.FillWeight = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComboBoxItem selectedGroup = comboBox2.SelectedItem as ComboBoxItem;
            if (selectedGroup != null)
            {
                // Загрузка и отображение расписания для первой недели
                DataTable scheduleTableWeek1 = LoadScheduleForGroup(selectedGroup.Value, 1);
                DisplaySchedule(scheduleTableWeek1, dataGridView1);

                // Загрузка и отображение расписания для второй недели
                DataTable scheduleTableWeek2 = LoadScheduleForGroup(selectedGroup.Value, 2);
                DisplaySchedule(scheduleTableWeek2, dataGridView2);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите группу.");
            }
        }

        // Вспомогательный класс для хранения текста и значения в ComboBox
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
