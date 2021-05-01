using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PNP
{
    
    public partial class Reception : Form
    {
        SqlConnection con = new SqlConnection(@"Server=LAPTOP-0A0FEGEC\SQLEXPRESS; Database=PNP; User Id=nion; Password=nion;");
        public Reception()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (tbusername.Text != "" && tbpassword.Text != "")
            {
                SqlCommand cmd = new SqlCommand("select * from R_tbl where user_name=@user_name and pass=@pass", con);
                cmd.Parameters.AddWithValue("@user_name", tbusername.Text);
                cmd.Parameters.AddWithValue("@pass", tbpassword.Text);
                con.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                con.Close();

                int count = ds.Tables[0].Rows.Count;

                if (count == 1)
                {
                    MessageBox.Show("login Successful");
                    this.Hide();
                    new Reception2().Show();
                }
                else { MessageBox.Show("Error Password"); }
            }
            else { MessageBox.Show("Please Fill The Box"); }
        }

        private void Reception_Load(object sender, EventArgs e)
        {

        }
    }
}
