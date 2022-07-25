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
    public partial class Form9 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=login;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("remplir les champs", "ALERT");


            }
            else if(textBox2.Text==textBox3.Text)
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update utilisateur set passworde=@passworde  where username=@username";
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@passworde", textBox2.Text);


                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                MessageBox.Show(" modification réussite");
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("verifier votre mot de passe");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }
    }
}
