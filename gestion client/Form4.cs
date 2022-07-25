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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=login;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Form4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'loginDataSet1.tache'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.tacheTableAdapter.Fill(this.loginDataSet1.tache);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("REMPLIR LE CHAMP", "ALERT");

            }

            else
            {
                con.Open();
                string cm = "select * from tache where id ='" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(cm, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;


                dt = null;
                dr = null;
                cmd = null;
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("vous etes sure de supprimer cette ligne ?", "confirmation?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                con.Open();
                int position = this.dataGridView1.CurrentRow.Index;
                int ir = int.Parse(this.dataGridView1.Rows[position].Cells[0].Value.ToString());
                cmd.CommandText = "delete from tache where id=" + ir;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("supression bien faite", "NOTIFICATION");

                cmd.CommandText = "select * from tache";
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 F = new Form5();
            F.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select count(*) from tache ";
            int a = int.Parse(cmd.ExecuteScalar().ToString());
            textBox2.Text = a.ToString();


            con.Close();
        }
    }
}
