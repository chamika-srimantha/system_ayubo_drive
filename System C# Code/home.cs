using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systemCsharp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            customerBilling page = new customerBilling();
            page.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            vehicleInformation page = new vehicleInformation();
            page.Show();
        }

        private void btn_empDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeDetails page = new EmployeeDetails();
            page.Show();
        }

        private void btn_tourPackages_Click(object sender, EventArgs e)
        {
            this.Hide();
            vehiclePackages page = new vehiclePackages();
            page.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to exit? ", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Hide();
                Form3 page = new Form3();
                page.Show();
            }
        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do You Really Want To SignOut ? ", "SignOut", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                signup page = new signup();
                page.Show();
            }
            else
            {
                this.Hide();
                Form3 page = new Form3();
                page.Show();
            }
        }
    }
}
