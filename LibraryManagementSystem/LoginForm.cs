using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Username fo = new Username();
            this.Hide();
            fo.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm fo = new RegisterForm();
            this.Hide();
            fo.Show();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm fo = new RegisterForm();
            this.Hide();
            fo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string mysqlconn = "server= 127.0.0.1; user= root; database=db_library; password=";
                MySqlConnection conn1 = new MySqlConnection(mysqlconn);
                conn1.Open();
                string query = "SELECT * FROM tb_admins Where Username = @user AND Password =@pass";
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successfully");
                    Dashboard ds = new Dashboard();
                    this.Hide();
                    ds.ShowDialog();

                }
                else
                {
                    MessageBox.Show("INVALID");
                }
                conn1.Close();
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }
    }
}
