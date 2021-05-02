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
    public partial class Doctorinsert : Form
    {
        SqlConnection con = new SqlConnection(@"Server=LAPTOP-0A0FEGEC\SQLEXPRESS; Database=PNP; User Id=nion; Password=nion;");
        public Doctorinsert()
        {
            InitializeComponent();
        }

        private void Doctorinsert_Load(object sender, EventArgs e)
        {

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
               
                new Doctor2().Show();
                this.Hide();
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
    }
}
