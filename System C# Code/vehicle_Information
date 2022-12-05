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
    public partial class vehicleInformation : Form
    {
        public vehicleInformation()
        {
            InitializeComponent();
        }
        public static string send;
        private void btn_select_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
            {
                MessageBox.Show("You have selected  " + checkBox1.Text);
                send = checkBox1.Text;
                this.Hide();
                vehicleReservation page = new vehicleReservation();
                page.Show();
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
            {
                MessageBox.Show("You have selected  " + checkBox2.Text);
                send = checkBox2.Text;
                this.Hide();
                vehicleReservation page = new vehicleReservation();
                page.Show();
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
            {
                MessageBox.Show("You have selected  " + checkBox3.Text);
                send = checkBox3.Text;
                this.Hide();
                vehicleReservation page = new vehicleReservation();
                page.Show();
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true && checkBox5.Checked == false && checkBox6.Checked == false)
            {
                MessageBox.Show("You have selected  " + checkBox4.Text);
                send = checkBox4.Text;
                this.Hide();
                vehicleReservation page = new vehicleReservation();
                page.Show();
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true && checkBox6.Checked == false)
            {
                MessageBox.Show("You have selected  " + checkBox5.Text);
                send = checkBox5.Text;
                this.Hide();
                vehicleReservation page = new vehicleReservation();
                page.Show();
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == true)
            {
                MessageBox.Show("You have selected  " + checkBox6.Text);
                send = checkBox6.Text;
                this.Hide();
                vehicleReservation page = new vehicleReservation();
                page.Show();
            }
            else
            {
                MessageBox.Show("Please Select a Vehicle");
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form page = new Form3();
            page.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to exit? ", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Hide();
                vehicleInformation page = new vehicleInformation();
                page.Show();
            }
        }
    }
}
