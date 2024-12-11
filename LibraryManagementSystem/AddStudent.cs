using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
            label2.ForeColor = Color.Red;
            table();
            
        }
        string mysqlconn = "server= 127.0.0.1; user= root; database=db_library; password=";
        public void Cell()
        {
            
        }
        public void clear()
        {
            txt_id.Text = "";
            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_age.Text = "";
            txt_gender.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            txt_contact.Text = "";
            txt_email.Text = "";
        }
        public void table()
        {
           
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            conn.Open();
            string query = "SELECT StudentNumber, Firstname, Lastname, Age, Gender, Department, YearLevel, ContactNumber, Email FROM tb_students";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }


         void search(string text = null)
        {
            
            MySqlConnection conn = new MySqlConnection(mysqlconn);

            try
            {
                conn.Open();
                string query = "Select * from tb_students WHERE Firstname like '%@name'";
                MySqlCommand cmd = new MySqlCommand(query,conn);

                if (string.IsNullOrEmpty(text))
                {
                    query = "SELECT * FROM tb_students";
                    cmd = new MySqlCommand(query, conn);
                }
                else
                {
                    query = "SELECT * FROM tb_students WHERE Firstname LIKE @name";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", "%" + text + "%"); // Use parameterized query
                }



            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddBooks ad = new AddBooks();
            this.Hide();
            ad.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            this.Hide();
            ds.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {
           StorageBook sg = new StorageBook();
            this.Hide();
            sg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentAdd st = new StudentAdd();
            
            this.Hide();
            st.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];

            txt_id.Text = row.Cells[0].Value.ToString();
            txt_fname.Text = row.Cells[1].Value.ToString();
            txt_lname.Text = row.Cells[2].Value.ToString();
            txt_age.Text = row.Cells[3].Value.ToString();
            txt_gender.Text = row.Cells[4].Value.ToString();
            comboBox1.Text = row.Cells[5].Value.ToString();
            comboBox2.Text = row.Cells[6].Value.ToString();
            txt_contact.Text = row.Cells[7].Value.ToString();
            txt_email.Text = row.Cells[8].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            try
            {
                conn.Open();
                int id = int.Parse(txt_id.Text);
                int age = int.Parse(txt_age.Text);
                string query = "UPDATE tb_students SET Firstname = @fname, Lastname = @lname, Age =@age, Gender = @gender, Department = @dept, YearLevel = @year, ContactNumber = @contact, Email = @email WHERe StudentNumber = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fname", txt_fname.Text);
                cmd.Parameters.AddWithValue("lname", txt_lname.Text);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@gender", txt_gender);
                cmd.Parameters.AddWithValue("@dept", comboBox1.Text);
                cmd.Parameters.AddWithValue("@year", comboBox2.Text);
                cmd.Parameters.AddWithValue("@contact", txt_contact.Text);
                cmd.Parameters.AddWithValue("@email", txt_email.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated");
                table();
                clear();
                conn.Close();
            }
            catch (MySqlException ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            try
            {
                conn.Open();
                int id = int.Parse(txt_id.Text);
                string query = "DELETE FROM tb_students WHERE StudentNumber = @id";
                MySqlCommand cmd = new MySqlCommand(@query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                DialogResult result = MessageBox.Show("Are your sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    table();
                    clear();
                }
                else
                {
                    MessageBox.Show("Cancel");
                }

            }
            catch (MySqlException ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            try
            {
                conn.Open();
                string query = "SELECT * FROM tb_students WHERE Lastname LIKE'" + this.textBox1.Text + "%' OR Firstname LIKE '" + this.textBox1.Text + "%'";

                MySqlCommand cmd = new MySqlCommand(query,conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }
    }
}
