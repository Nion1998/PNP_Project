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
    public partial class Reception2 : Form
    {
        SqlConnection con = new SqlConnection(@"Server=LAPTOP-0A0FEGEC\SQLEXPRESS; Database=PNP; User Id=nion; Password=nion;");
        string user;
        public Reception2()
        {
            InitializeComponent();
        }

        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Appointment_tb";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public void id()
        {
            string sid;
            string query = "select id from Appointment_tb order by id Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                sid = id.ToString("00000");
            }
            else if(Convert.IsDBNull(dr))
            {
                sid = ("00001");

            }
            else { sid = ("00001"); }
            con.Close();
            textBox1.Text = sid.ToString();
        }

        private void Reception2_Load(object sender, EventArgs e)
        {
            id();
            disp_data();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox3.Text != "" && textBox8.Text != "")
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Appointment_tb values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Insert");
               // this.Hide();
                new Reception2().Show();
            }
            else { MessageBox.Show("please insert all data"); }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox3.Text == "Dr.Nurul_Islam")
            {
                int n = 1000;
                textBox6.Text = n.ToString();
            }
           else if (comboBox3.Text == "Dr.Shohidul_khan")
            {
                int n = 700;
                textBox6.Text = n.ToString();
            }
           else if (comboBox3.Text == "Dr.Sarmin_Akter")
            {
                int n = 800;
                textBox6.Text = n.ToString();
            }
           else if (comboBox3.Text == "Dr.Mun_Shaha")
            {
                int n = 500;
                textBox6.Text = n.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int tbox6 = Convert.ToInt32(textBox6.Text);
            int tbox7 = Convert.ToInt32(textBox7.Text);
            int Due = tbox6 - tbox7;
            textBox8.Text = Due.ToString();

            if (Due == 0) { textBox9.Text = "Payed"; }
            else { textBox9.Text = "Due"; }
        }

        

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            user = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Appointment_tb where name='" + textBox10.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("DELETED!!!");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select*from Appointment_tb where name='" + textBox10.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            disp_data();
        }
    }
}
