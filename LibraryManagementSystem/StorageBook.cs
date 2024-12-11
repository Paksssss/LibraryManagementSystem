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
    public partial class StorageBook : Form
    {
        public StorageBook()
        {
            InitializeComponent();
            label21.ForeColor = Color.Red;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Dashboard ds =  new Dashboard();
            this.Hide();
            ds.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddBooks ad = new AddBooks();
            this.Hide();
            ad.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AddStudent at = new AddStudent();
            this.Hide();
            at.ShowDialog();
        }
    }
}
