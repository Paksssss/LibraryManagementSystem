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
    public partial class StudentAdd : Form
    {
        public StudentAdd()
        {
            InitializeComponent();
            
        }
        string gender;

   
           

        private void label10_Click(object sender, EventArgs e)
        {
            string mysqlconn = "server= 127.0.0.1; user= root; database=db_library; password=";
            MySqlConnection conn = new MySqlConnection(mysqlconn);

            conn.Open();
        
            string query = "INSERT INTO tb_students(StudentNumber, Firstname, Lastname, Age, Gender, Department, YearLevel, ContactNumber, Email) VALUES(@id, @fname, @lname, @age, @gender, @dept, @year, @contact, @email)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(label13.Text) ||
                    string.IsNullOrWhiteSpace(comboBox1.Text) ||
                    string.IsNullOrWhiteSpace(comboBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) ||
                    string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Fill all the fields");
            }
            
            else 
            {
                AddStudent ad = new AddStudent();
                int id = int.Parse(textBox1.Text);
                int age = int.Parse(textBox4.Text);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fname", textBox2.Text);
                cmd.Parameters.AddWithValue("@lname", textBox3.Text);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@gender", label13.Text);
                cmd.Parameters.AddWithValue("@dept", comboBox1.Text);
                cmd.Parameters.AddWithValue("@year", comboBox2.Text);
                cmd.Parameters.AddWithValue("@contact", textBox6.Text);
                cmd.Parameters.AddWithValue("@email", textBox7.Text);

                cmd.ExecuteNonQuery();
               
                MessageBox.Show("Registered");
                ad.table();
                this.Hide();
                ad.ShowDialog();
               
            }




            }




        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                
                label13.Text= "Male";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
               
                label13.Text = "Female";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
