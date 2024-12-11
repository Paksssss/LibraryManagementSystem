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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class ForgotForm : Form
    {
        public ForgotForm(string txt)
        {
            InitializeComponent();
            label9.Text = txt;
            Read();

        }
        public void Read()
        {
            string mysqlconn = "server= 127.0.0.1; user= root; database=db_library; password=";
            try
            {
                MySqlConnection conn1 = new MySqlConnection(mysqlconn);
                conn1.Open();

                string query2 = "SELECT tb_forgotpass.Q1, tb_forgotpass.Q2, tb_forgotpass.Q3 FROM tb_admins JOIN tb_forgotpass ON tb_forgotpass.adminId = tb_admins.adminId WHERE tb_admins.Username = @user";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn1);
                cmd2.Parameters.AddWithValue("@user", label9.Text);

                MySqlDataReader reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    label2.Text = reader["Q1"].ToString();
                    label7.Text = reader["Q2"].ToString();
                    label8.Text = reader["Q3"].ToString();
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string mysqlconn = "server= 127.0.0.1; user= root; database=db_library; password=";

            try
            {
                MySqlConnection conn1 = new MySqlConnection(mysqlconn);
                conn1.Open();
                 
               
             
                if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                      string.IsNullOrWhiteSpace(textBox4.Text) ||
                      string.IsNullOrWhiteSpace(textBox5.Text) ||
                      string.IsNullOrEmpty(label9.Text))
                {
                    MessageBox.Show("Please answer all the fields.");
                }
                else
                {
                    

                    string query = "SELECT tb_admins.Username, tb_forgotpass.Ans1, tb_forgotpass.Ans2, tb_forgotpass.Ans3 FROM tb_admins JOIN tb_forgotpass ON tb_forgotpass.adminId = tb_admins.adminId WHERE tb_admins.Username = @user AND tb_forgotpass.Ans1 = @a1 AND tb_forgotpass.Ans2 = @a2 AND tb_forgotpass.Ans3 = @a3";
                    


                    MySqlCommand cmd = new MySqlCommand(query, conn1);
                    cmd.Parameters.AddWithValue("@user", label9.Text);
                    cmd.Parameters.AddWithValue("@a1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@a2", textBox4.Text);
                    cmd.Parameters.AddWithValue("@a3", textBox5.Text);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        RecoveryForm f5 = new RecoveryForm(label9.Text);

                        this.Hide();
                        f5.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid");
                    }
                    conn1.Close();
                }

            }
            catch (MySqlException ex)
            {
            }
        }

        private void text_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
