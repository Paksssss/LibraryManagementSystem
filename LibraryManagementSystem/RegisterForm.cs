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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
     
       

        private void button1_Click(object sender, EventArgs e)
        {
            string mysqlconn = "server= 127.0.0.1; user= root; database=db_library; password=";



            try
            {
                MySqlConnection conn1 = new MySqlConnection(mysqlconn);
                conn1.Open();

                string query1 = "Insert into tb_admins(Username, Password) values(@use, @pass)";
                string query2 = "Insert into tb_forgotpass(Ans1, Ans2, Ans3, Q1, Q2, Q3) values(@a1, @a2, @a3, @q1, @q2, @q3)";
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(comboBox1.Text) ||
                    string.IsNullOrWhiteSpace(comboBox2.Text) ||
                    string.IsNullOrWhiteSpace(comboBox3.Text))
                {
                    MessageBox.Show("Please answer all the fields.");
                }
                else
                {
                    try
                    {
                        

                        
                        MySqlCommand cmd1 = new MySqlCommand(query1, conn1);
                        cmd1.Parameters.AddWithValue("@use", textBox1.Text);
                        cmd1.Parameters.AddWithValue("@pass", textBox2.Text);
                        cmd1.ExecuteNonQuery();

                       
                        MySqlCommand cmd2 = new MySqlCommand(query2, conn1);
                        cmd2.Parameters.AddWithValue("@a1", textBox3.Text);
                        cmd2.Parameters.AddWithValue("@a2", textBox4.Text);
                        cmd2.Parameters.AddWithValue("@a3", textBox5.Text);
                        cmd2.Parameters.AddWithValue("@q1", comboBox1.Text);
                        cmd2.Parameters.AddWithValue("@q2", comboBox2.Text);
                        cmd2.Parameters.AddWithValue("@q3", comboBox3.Text);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Data successfully saved.");
                        LoginForm form = new LoginForm();
                        this.Hide();
                        
                        form.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( ex.Message);
                    }
                    finally
                    {
                        conn1.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
