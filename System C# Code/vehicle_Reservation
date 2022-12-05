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
    public partial class vehicleReservation : Form
    {
        public vehicleReservation()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-79CKPI4B;Initial Catalog=Ayubo_drive_db;Integrated Security=True");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_number.Text == "" || cmb_tour.Text == "" || cmb_vehicle.Text == "" || txt_date.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Reservation_Insert '" + txt_name.Text + "', '" + txt_number.Text + "', '" + cmb_tour.Text + "','" + cmb_vehicle.Text + "','" + txt_date.Text + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    LoadAllRecords();
                    MessageBox.Show("Successfully saved");
                }
                catch
                {
                    MessageBox.Show("");
                }
            }
        }
                
        
        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.SP_Reservation_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_number.Text == "" || cmb_tour.Text == "" || cmb_vehicle.Text == "" || txt_date.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Reservation_Update '" + txt_name.Text + "', '" + txt_number.Text + "', '" + cmb_tour.Text + "','" + cmb_vehicle.Text + "','" + txt_date.Text + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    LoadAllRecords();
                    MessageBox.Show("Successfully Updated");
                }
                catch
                {
                    MessageBox.Show("");
                }
            }
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
                    SqlCommand com = new SqlCommand("exec dbo.SP_Reservation_Delete '" + txt_name.Text + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    LoadAllRecords();
                    MessageBox.Show("Successfully Deleted");
                }
                catch
                {
                    MessageBox.Show("");
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_number.Clear();
            txt_date.Clear();
            cmb_tour.ResetText();
            cmb_vehicle.ResetText();

        }

        private void vehicleReservation_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }

        private void txt_search_Click(object sender, EventArgs e)
        {
            using (DataTable dt = new DataTable("vehicle_reservation"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from vehicle_reservation where cus_number=@cus_number ", con))
                {
                    cmd.Parameters.AddWithValue("cus_number", txt_no.Text);
                    //cmd.Parameters.AddWithValue("emp_name", string.Format("%{0}%", txt_no.Text));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }   
        }

        private void txt_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 page = new Form3();
            page.Show();
        }

        private void txt_exit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to exit? ", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Hide();
                vehicleReservation page = new vehicleReservation();
                page.Show();
            }
        }

        private void txt_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            vehicleInformation page = new vehicleInformation();
            page.Show();
        }
    }
}
