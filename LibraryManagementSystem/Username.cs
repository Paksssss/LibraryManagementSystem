using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace LibraryManagementSystem
{
    public partial class Username : Form
    {
        public Username()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string mysqlconn = "server= 127.0.0.1; user= root; database=db_library; password=";
                MySqlConnection conn1 = new MySqlConnection(mysqlconn);
                conn1.Open();

                string query = "Select * from tb_admins Where Username = @user";
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Correct");
                    ForgotForm fo = new ForgotForm(textBox1.Text);
                    this.Hide();
                    fo.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username");
                   
                }
            }
            catch (MySqlException ex)
            {
            }
        }
    }
}
