using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coursework
{
    public partial class ScheduleForm : Form
    {
        private SqlConnection sqlConnection = null;

        public ScheduleForm()
        {
            InitializeComponent();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScheduleDB"].ConnectionString);
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
                this.Close();
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
                    JOIN TimeSlots ON Schedule.timeslot_id = TimeSlots.timeslot_id
                    JOIN Courses ON Schedule.course_id = Courses.course_id
                    JOIN Teachers ON Schedule.teacher_id = Teachers.teacher_id
                    JOIN Classrooms ON Schedule.classroom_id = Classrooms.classroom_id
                    JOIN SpecificsOfOccupations ON Schedule.specific_id = SpecificsOfOccupations.specific_id
                    WHERE Schedule.group_id = @GroupId AND Schedule.weak_id = @WeakId
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
            dataGridView.Columns.Add("Pair", "Пара");
            dataGridView.Columns.Add("TimeSlot", "Время");
            dataGridView.Columns.Add("Course", "Дисциплина");
            dataGridView.Columns.Add("Type", "Тип");
            dataGridView.Columns.Add("Teacher", "Преподаватели");
            dataGridView.Columns.Add("Classroom", "Аудитория");

            // Установка режима авторазмера столбцов
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Получение уникальных дней
            var days = scheduleTable.AsEnumerable().Select(row => row.Field<string>("day_name")).Distinct().ToList();

            foreach (var day in days)
            {
                // Получение уникальных временных слотов для конкретного дня
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

                foreach (var timeSlot in timeSlotsForDay)
                {
                    var rows = scheduleTable.AsEnumerable()
                        .Where(row => row.Field<string>("day_name") == day &&
                                      row.Field<TimeSpan>("start_time") == timeSlot.StartTime &&
                                      row.Field<TimeSpan>("end_time") == timeSlot.EndTime);

                    string timeSlotFormatted = $"{timeSlot.StartTime:hh\\:mm}-{timeSlot.EndTime:hh\\:mm}";

                    if (rows.Any())
                    {
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
                    else
                    {
                        // Если на это время нет занятий, добавляем пустую строку
                        dataGridView.Rows.Add("", timeSlot.TimeSlotName, timeSlotFormatted, "", "", "", "");
                    }
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
