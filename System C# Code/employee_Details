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
    public partial class EmployeeDetails : Form
    {
        public EmployeeDetails()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-79CKPI4B;Initial Catalog=Ayubo_drive_db;Integrated Security=True");

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" || txt_name.Text == "" || txt_nic.Text == "" || txt_address.Text == "" || txt_phoneNo.Text == "" || cmb_gender.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Employee_Insert '" + txt_id.Text + "', '" + txt_name.Text + "', '" + txt_nic.Text + "','" + txt_address.Text + "','" + txt_phoneNo.Text + "','" + cmb_gender.Text + "'", con);
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
            SqlCommand com = new SqlCommand("exec dbo.SP_Employee_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" || txt_name.Text == "" || txt_nic.Text == "" || txt_address.Text == "" || txt_phoneNo.Text == "" || cmb_gender.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Employee_Update '" + txt_id.Text + "', '" + txt_name.Text + "', '" + txt_nic.Text + "','" + txt_address.Text + "','" + txt_phoneNo.Text + "','" + cmb_gender.Text + "'", con);
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
            if (txt_id.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_Employee_Delete '" + txt_id.Text + "'", con);
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
            txt_id.Clear();
            txt_name.Clear();
            txt_nic.Clear();
            txt_address.Clear();
            txt_phoneNo.Clear();
            cmb_gender.ResetText();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            using (DataTable dt = new DataTable("employee_details"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from employee_details where emp_id=@emp_id ", con))
                {
                    cmd.Parameters.AddWithValue("emp_id", txt_empID.Text);
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
                EmployeeDetails page = new EmployeeDetails();
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
