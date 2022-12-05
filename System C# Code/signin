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
    public partial class signin : Form
    {
        public signin()
        {
            InitializeComponent();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Please fill the both fields");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-79CKPI4B;Initial Catalog=systemCsharp;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM signup WHERE username ='" + txt_username.Text + "' AND password='" + txt_password.Text + "'", con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show(" Sign In Success ", "Sign In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Form3 page = new Form3();
                    page.Show();
                }
                else
                {
                    MessageBox.Show(" Sign In Unsuccessfull ", "Sign In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();
                }
            }
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
                signin page = new signin();
                page.Show();
            }
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            signup page = new signup();
            page.Show();
        }
    }
}
