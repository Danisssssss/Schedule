using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

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
                MessageBox.Show("Подключение установлено");
                SqlDataReader dataReader = null;
                listView1.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "SELECT " +
                        "Courses.course_name, " +
                        "Teachers.first_name, " +
                        "Groups.group_name, " +
                        "Classrooms.room_number, " +
                        "Days.day_name, " +
                        "CONCAT(CONVERT(VARCHAR(5), TimeSlots.start_time, 108), ' - '," +
                        "CONVERT(VARCHAR(5), TimeSlots.end_time, 108)) AS timeslot_name " +
                        "FROM Schedule " +
                        "JOIN Courses ON Schedule.course_id = Courses.course_id " +
                        "JOIN Teachers ON Schedule.teacher_id = Teachers.teacher_id " +
                        "JOIN Groups ON Schedule.group_id = Groups.group_id " +
                        "JOIN Classrooms ON Schedule.classroom_id = Classrooms.classroom_id " +
                        "JOIN Days ON Schedule.day_id = Days.day_id " +
                        "JOIN TimeSlots ON Schedule.timeslot_id = TimeSlots.timeslot_id", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();
                    ListViewItem item = null;

                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["course_name"]),
                            Convert.ToString(dataReader["first_name"]),
                            Convert.ToString(dataReader["group_name"]),
                            Convert.ToString(dataReader["room_number"]),
                            Convert.ToString(dataReader["day_name"]),
                            Convert.ToString(dataReader["timeslot_name"]),
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
