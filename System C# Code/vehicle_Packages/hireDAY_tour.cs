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
    public partial class hire_dayTour : Form
    {
        public hire_dayTour()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-79CKPI4B;Initial Catalog=Ayubo_drive_db;Integrated Security=True");

        private void withOrWithOutDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            vehiclePackages page = new vehiclePackages();
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

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_startTime.Text == "" || txt_startingKM.Text == "" || txt_endTime.Text == "" || txt_endingKM.Text == "" || cmb_hirecharge.Text == "" || txt_totalKM.Text == ""|| noKM1.Text==""|| txt_extraKM1.Text==""|| txt_totalHire.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Hire1_Insert '" + txt_name.Text + "', '" + txt_startTime.Text + "', '" + int.Parse(txt_startingKM.Text) + "','" + txt_endTime.Text + "','" + int.Parse(txt_endingKM.Text) + "','" + int.Parse(cmb_hirecharge.Text) + "','" + txt_totalKM.Text + "','" + noKM1.Text + "','" +txt_extraKM1.Text+ "','"+txt_totalHire.Text+  "'", con);
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
            SqlCommand com = new SqlCommand("exec dbo.SP_Hire1_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int base_p = int.Parse(cmb_hirecharge.Text);
            int end_km = int.Parse(txt_endingKM.Text);
            int start_km = int.Parse(txt_startingKM.Text);
            int km_travel = (end_km - start_km);
            txt_totalKM.Text = Convert.ToString(km_travel);
            int extra_km = (km_travel - 100);
            txt_extraKM1.Text = Convert.ToString(extra_km);
            int no_km = (km_travel - extra_km);
            noKM1.Text = Convert.ToString(no_km);
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            int base_p = int.Parse(cmb_hirecharge.Text);
            int end_km = int.Parse(txt_endingKM.Text);
            int start_km = int.Parse(txt_startingKM.Text);
            int km_travel = (end_km - start_km);
            txt_totalKM.Text = Convert.ToString(km_travel);
            int extra_km = (km_travel - 100);
            txt_extraKM1.Text = Convert.ToString(extra_km);
            int no_km = (km_travel - extra_km);
            noKM1.Text = Convert.ToString(no_km);
            int count_km = int.Parse(txt_extraKM2.Text);
            int extra_count = int.Parse(txt_noKM2.Text);
            int total_cost = ((base_p) + (no_km*count_km) + (extra_km*extra_count));
            txt_totalHire.Text = Convert.ToString(total_cost);
            txt_ttalhireee.Text = Convert.ToString("Rs" + total_cost);

            string customer_name = txt_name.Text;
            txt_cusname.Text = customer_name;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_startTime.Clear();
            txt_startingKM.Clear();
            txt_endingKM.Clear();
            txt_endTime.Clear();
            cmb_hirecharge.ResetText();
            txt_totalKM.Clear();
            noKM1.Clear();
            txt_extraKM1.Clear();
            txt_totalHire.Clear();

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 page = new Form3();
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
                hire_dayTour page = new hire_dayTour();
                page.Show();
            }
        }
    }
}
