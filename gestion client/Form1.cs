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
namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=login;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd = new SqlCommand("select * from utilisateur where username = '" + textBox1.Text + "'  and passworde = '" + textBox2.Text + "'", con);


            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                MessageBox.Show("BONJOUR   CHER  " + textBox1.Text,"FELICITAION");
                Form2 myform = new Form2();
                Form2.message = "BONJOUR :  " + textBox1.Text;
                myform.ShowDialog();
                textBox1.Clear();
                textBox2.Clear();
            }

            else
            {
                MessageBox.Show("UTILISATEUR OU MOT DE PASSE INCORRECTE");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;


            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
