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
    public partial class customerBilling : Form
    {
        public customerBilling()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-79CKPI4B;Initial Catalog=Ayubo_drive_db;Integrated Security=True");

        private void customerBilling_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (txt_reciptno.Text == "" || txt_name.Text == "" || cmb_tourType.Text == "" || cmb_vehicleType.Text == "" || txt_date.Text == "" || txt_reservedDate.Text=="" || txt_payment.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Billing_Insert '" + txt_reciptno.Text + "', '" + txt_name.Text + "', '" + cmb_tourType.Text + "','" + cmb_vehicleType.Text + "','" + txt_date.Text + "','" + txt_reservedDate+ "','" +txt_payment +  "'", con);
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
            SqlCommand com = new SqlCommand("exec dbo.SP_Billing_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_reciptno.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Billing_Delete '" + txt_reciptno.Text + "'", con);
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
            txt_reciptno.Clear();
            txt_name.Clear();
            txt_date.Clear();
            txt_reservedDate.Clear();
            txt_payment.Clear();
            cmb_tourType.ResetText();
            cmb_vehicleType.ResetText();
        }

        private void btn_sumary_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            using (DataTable dt = new DataTable("customer_billing"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from customer_billing where reciptNo=@reciptNo ", con))
                {
                    cmd.Parameters.AddWithValue("reciptNo", txt_reciptno.Text);
                    //cmd.Parameters.AddWithValue("emp_name", string.Format("%{0}%", txt_no.Text));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }
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
                customerBilling page = new customerBilling();
                page.Show();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 page = new Form3();
            page.Show();
        }
    }
}
