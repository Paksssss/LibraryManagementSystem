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
    public partial class RecoveryForm : Form
    {
        public RecoveryForm(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string mysqlconn = "server= 127.0.0.1; user= root; database=db_library; password=";
                MySqlConnection conn1 = new MySqlConnection(mysqlconn);
                conn1.Open();

                string query = "UPDATE tb_admins SET Password = @pass WHERE Username =@user";
               
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                cmd.Parameters.AddWithValue("@pass", textBox3.Text);
                cmd.Parameters.AddWithValue("@user", label1.Text);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("Invalid Pass");
                }
                else
                {
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully.");
                        LoginForm form1 = new LoginForm();
                        this.Hide();
                        form1.ShowDialog();
                        conn1.Close();
                    }
                    else
                    {
                        MessageBox.Show("No matching user found.");
                    }
                }

            }
            catch (MySqlException ex)
            {
                
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
