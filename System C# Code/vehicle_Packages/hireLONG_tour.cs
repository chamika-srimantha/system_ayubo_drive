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
    public partial class hire_longTour : Form
    {
        public hire_longTour()
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
            if (txt_name.Text == "" || txt_startTime.Text == "" || txt_startingKM.Text == "" || txt_endTime.Text == "" || txt_endingKM.Text == "" || cmb_hirecharge.Text == "" || txt_totalKM.Text == "" || txt_overnight1.Text == "" || txt_nightpark1.Text == "" || txt_extraKMCharge1.Text=="" || txt_totalHire.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Hire2_Insert '" + txt_name.Text + "', '" + txt_startTime.Text + "', '" + int.Parse(txt_startingKM.Text) + "','" + txt_endTime.Text + "','" + int.Parse(txt_endingKM.Text) + "','" + int.Parse(cmb_hirecharge.Text) + "','" + txt_totalKM.Text + "','" + txt_overnight1.Text + "','" + txt_nightpark1.Text + "','" + txt_extraKMCharge1.Text + "','"+txt_totalHire+ "'", con);
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
            SqlCommand com = new SqlCommand("exec dbo.SP_Hire2_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_startingKM.Clear();
            txt_startTime.Clear();
            txt_endTime.Clear();
            txt_endingKM.Clear();
            cmb_hirecharge.ResetText();
            txt_totalKM.Clear();
            txt_overnight1.Clear();
            txt_nightpark1.Clear();
            txt_extraKMCharge1.Clear();
            txt_totalHire.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int end_km = int.Parse(txt_endingKM.Text);
            int start_km = int.Parse(txt_startingKM.Text);
            int t_km_travelled = (end_km - start_km);
            int extra_km = (t_km_travelled - 250);
            txt_extraKMCharge1.Text = Convert.ToString(extra_km);
            int km = (t_km_travelled - extra_km);
            txt_totalKM.Text = Convert.ToString(km);
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            int end_km = int.Parse(txt_endingKM.Text);
            int start_km = int.Parse(txt_startingKM.Text);
            int t_km_travelled = (end_km - start_km);
            int extra_km = (t_km_travelled - 250);
            txt_extraKMCharge1.Text = Convert.ToString(extra_km);
            int km = (t_km_travelled - extra_km);
            txt_totalKM.Text = Convert.ToString(km);

            int count_km = int.Parse(txt_totalKM2.Text);
            int extra_count = int.Parse(ttx_extraKMChrage2.Text);
            int OTD = int.Parse(txt_overnight2.Text);
            int OTD1 = int.Parse(txt_overnight1.Text);
            int NPV = int.Parse(txt_nightpark2.Text);
            int NPV1 = int.Parse(txt_nightpark1.Text);
            int base_p = int.Parse(cmb_hirecharge.Text);
            int total = (base_p + (km * count_km) + (OTD * OTD1) + (NPV * NPV1) + (extra_km * extra_count));
            txt_totalHire.Text = Convert.ToString(total);
            txt_ttalhireee.Text = Convert.ToString("Rs" + total);

            string customer_name = txt_name.Text;
            txt_cusname.Text = customer_name;
        }

        public static string sendtext = "";
        public static string sendtext1 = "";
        public static string sendtext3 = "";

        private void btn_submit_Click(object sender, EventArgs e)
        {
            //sendtext3 = DateTimePicker1.Text;

            sendtext1 = txt_cusname.Text;
            sendtext = txt_ttalhireee.Text;

            this.Hide();
            customerBilling page = new customerBilling();
            page.Show();
        }
    }
}
