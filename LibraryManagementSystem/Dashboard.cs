using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            label10.ForeColor = Color.Red;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ULrayt");
        }

        private void label10_CursorChanged(object sender, EventArgs e)
        {
            label10.BackColor = Color.Red;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AddStudent st = new AddStudent();
            this.Hide();
            st.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddBooks ad = new AddBooks();
            this.Hide();
            ad.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {
            StorageBook sg = new StorageBook();
            this.Hide();
            sg.ShowDialog();
        }
    }
}
