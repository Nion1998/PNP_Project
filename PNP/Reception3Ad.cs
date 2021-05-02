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
    public partial class Reception3Ad : Form
    {
        SqlConnection con = new SqlConnection(@"Server=LAPTOP-0A0FEGEC\SQLEXPRESS; Database=PNP; User Id=nion; Password=nion;");
        public Reception3Ad()
        {
            InitializeComponent();
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Admission_tb";
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
            string query = "select id from Admission_tb order by id Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                sid = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                sid = ("00001");

            }
            else { sid = ("00001"); }
            con.Close();
            textBox1.Text = sid.ToString();
        }

        private void Reception3Ad_Load(object sender, EventArgs e)
        {
            disp_data();
            id();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox3.Text == "Dr.Nurul_Islam")
            {
                int n = 1000;
                textBox11.Text = n.ToString();
            }
            else if (comboBox3.Text == "Dr.Shohidul_khan")
            {
                int n = 700;
                textBox11.Text = n.ToString();
            }
            else if (comboBox3.Text == "Dr.Sarmin_Akter")
            {
                int n = 800;
                textBox11.Text = n.ToString();
            }
            else if (comboBox3.Text == "Dr.Mun_Shaha")
            {
                int n = 500;
                textBox11.Text = n.ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "VIP")
            {
                int n = 1000;
                textBox13.Text = n.ToString();
            }
            else if (comboBox4.Text == "Normal")
            {
                int n = 700;
                textBox13.Text = n.ToString();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "Arthroscopy")
            {
                int n = 15000;
                textBox12.Text = n.ToString();
            }
            else if (comboBox3.Text == "Dental Restoration")
            {
                int n = 70000;
                textBox12.Text = n.ToString();
            }
            else if (comboBox5.Text == "Gastric Bypass")
            {
                int n = 81500;
                textBox12.Text = n.ToString();
            }

            int tbox11 = Convert.ToInt32(textBox11.Text);
            int tbox12 = Convert.ToInt32(textBox12.Text);
            int tbox13 = Convert.ToInt32(textBox13.Text);
            int Due = tbox11 + tbox12 + tbox13;
            textBox6.Text = Due.ToString();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                int tbox6 = Convert.ToInt32(textBox6.Text);
                int tbox7 = Convert.ToInt32(textBox7.Text);
                int Due = tbox6 - tbox7;
                textBox8.Text = Due.ToString();

                if (Due == 0) { textBox9.Text = "Payed"; }
                else { textBox9.Text = "Due"; }
            }
            else { MessageBox.Show("please paye"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox3.Text != "" && textBox8.Text != "")
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Admission_tb values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Insert");
             
                new Reception3Ad().Show();
                this.Hide();
            }
            else { MessageBox.Show("please insert all data"); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Reception2().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select*from Admission_tb where name='" + textBox10.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Admission_tb where name='" + textBox10.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("DELETED!!!");
        }
    }
}
