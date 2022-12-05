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

namespace systemCsharp
{
    public partial class vehiclePackages : Form
    {
        public vehiclePackages()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-79CKPI4B;Initial Catalog=Ayubo_drive_db;Integrated Security=True");

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (txt_name.Text=="" || dt_rented.Text==""||dt_returned.Text==""|| txt_noweekstaken1.Text==""|| txt_nodaystaken1.Text==""|| txt_drivercost1.Text==""||txt_totalrent.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Rent_Insert '" + txt_name.Text + "', '" + dt_rented.Text + "', '" + dt_returned.Text + "','"  + int.Parse(txt_totaldays.Text) + "','" + txt_noweekstaken1.Text + "','"+ txt_nodaystaken1.Text+ "','"+ txt_drivercost1.Text+"','"+txt_totalrent.Text +  "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    LoadAllRecords();
                    MessageBox.Show("Successfully saved");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.SP_Rent_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true && radioButton2.Checked==false)
            {
                txt_noweekstaken1.Enabled = false;
                txt_nodaystaken1.Enabled = false;
                txt_drivercost1.Enabled = false;

                int total_days = int.Parse(txt_totaldays.Text);
                int weeks = (total_days / 7);
                int days = ((total_days) - (weeks * 7));
                txt_noweekstaken1.Text = Convert.ToString(weeks);
                txt_nodaystaken1.Text = Convert.ToString(days);
                txt_totalrent.Text = Convert.ToString(total_days);
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == true)
            {
                txt_noweekstaken1.Enabled = false;
                txt_nodaystaken1.Enabled = false;
                txt_drivercost1.Enabled = false;
                txt_drivercost2.Enabled = false;
                int total_days = int.Parse(txt_totaldays.Text);
                int weeks = (total_days / 7);
                int days = ((total_days) - (weeks * 7));
                txt_nodaystaken1.Text = Convert.ToString(weeks);
                txt_nodaystaken1.Text = Convert.ToString(days);
            }
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            int total_days = int.Parse(txt_totaldays.Text);
            int weeks = (total_days / 7);
            int days = ((total_days) - (weeks * 7));
            txt_noweekstaken1.Text = Convert.ToString(weeks);
            txt_nodaystaken1.Text = Convert.ToString(days);
            txt_drivercost1.Text = Convert.ToString(total_days);
            int count_weeks = int.Parse(txt_noweekstaken1.Text);
            int count_days = int.Parse(txt_nodaystaken1.Text);
            if (radioButton1.Checked==true && radioButton2.Checked==false)
            {
                int driver_count = int.Parse(txt_drivercost2.Text);
                int total = ((weeks * count_weeks) + (days * count_days) + (total_days * driver_count));
                txt_totalrent.Text = Convert.ToString(total);
                txt_ttalhireee.Text = Convert.ToString("Rs" + total);
            }
            else if (radioButton1.Checked==false && radioButton2.Checked==true)
            {
                int total = ((weeks* count_weeks) + (days*count_days));
                txt_totalrent.Text = Convert.ToString(total);
                txt_ttalhireee.Text = Convert.ToString("Rs" + total);
            }
            string customer_name = txt_name.Text;
            txt_cusname.Text = customer_name;
        }

        private void withOrWithOutDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            vehiclePackages page = new vehiclePackages();
            page.Show();
        }

        private void vehiclePackages_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Rent_Delete '" + txt_name.Text + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    LoadAllRecords();
                    MessageBox.Show("Successfully Deleted");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            dt_rented.ResetText();
            dt_returned.ResetText();
            txt_totaldays.Clear();
            txt_noweekstaken1.Clear();
            txt_nodaystaken1.Clear();
            txt_drivercost1.Clear();
            txt_totalrent.Clear();
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
                vehiclePackages page = new vehiclePackages();
                page.Show();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 page = new Form3();
            page.Show();
        }

        private void dayTourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            hire_dayTour page = new hire_dayTour();
            page.Show();
        }

        private void longTourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            hire_longTour page = new hire_longTour();
            page.Show();
        }
    }
}
