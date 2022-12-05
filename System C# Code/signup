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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-79CKPI4B;Initial Catalog=systemCsharp;Integrated Security=True");

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (txt_fullname.Text == "" || txt_username.Text == "" || txt_password.Text == "" || txt_passwordAgain.Text == "" || txt_age.Text == "")
            {
                MessageBox.Show("Please fill the all fields");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("exec dbo.SP_SignUp '" + txt_fullname.Text + "', '" + txt_username.Text + "', '" + txt_password.Text + "', '" + txt_passwordAgain.Text + "', '" + txt_age.Text + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("You have registered ! Please SignIn now ", "Sign Up");
                    this.Hide();
                    signin page = new signin();
                    page.Show();
                }
                catch
                {
                    MessageBox.Show("");
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
                signup page = new signup();
                page.Show();
            }
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            this.Hide();
            signin page = new signin();
            page.Show();
        }
    }
}
