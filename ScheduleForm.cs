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
                SqlDataReader dataReader = null;
                listView1.Items.Clear();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT Name, Surname, Age FROM Students", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();
                    ListViewItem item = null;

                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["Name"]),
                            Convert.ToString(dataReader["Surname"]),
                            Convert.ToString(dataReader["Age"]) });
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
                // MessageBox.Show("Подключение установлено");
            }
            else
            {
                this.Close();
            }
        }
    }
}
