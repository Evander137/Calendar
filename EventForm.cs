using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace Calendar
{
    public partial class EventForm : Form
    {
        String connString = "server=localhogy;user id=root;database=db_calendar;sslmode-none";

        public EventForm()
        {
            InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            txdate.Text = Form1.YEAR + "/" + Form1.MONTH + "/" + UserControlDays.DAY;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            String sql = "INSERT INTO tbl_calendar(date,event)values(?,?)";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommantText = sql;
            cmd.Parameters.AddWithValue("data", txdate.Text);
            cmd.Parameters.AddWIthValue("event", txevent);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");
            cmd.Dispose();
            conn.Close();
        }
    }
}
