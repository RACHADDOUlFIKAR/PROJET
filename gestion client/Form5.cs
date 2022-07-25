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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=login;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public bool exist()
        {
            bool e = false;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from client where id ='" + textBox1.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {

                e = true;


            }
            con.Close();
            return e;
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("remplir les champs", "ALERT");


            }

            else
            {

                con.Open();
                cmd.CommandText = ("insert into tache values(@id,@nom,@datereservation)");
                cmd.Connection = con;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@nom", textBox2.Text);

                cmd.Parameters.AddWithValue("@datereservation", dateTimePicker1.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                MessageBox.Show("inserssion bien faite", "NOTIFICATION");

                con.Close();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("remplir les champs", "ALERT");


            }
            else
            {
                if (exist() == false)

                {
                    MessageBox.Show("ce client n existe pas", "alert");
                    textBox1.Clear();
                    textBox2.Clear();

                }



                else
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "update tache set nom=@nom  , datereservation=@datereservation where id = @id";
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nom", textBox2.Text);

                    cmd.Parameters.AddWithValue("@datereservation", dateTimePicker1.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    MessageBox.Show(" modification réussite");
                    con.Close();
                    this.Hide();
                }
            }
        }
    }
}
