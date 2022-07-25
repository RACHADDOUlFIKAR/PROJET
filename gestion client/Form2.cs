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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=login;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
      public static string message { get; set; }
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'loginDataSet.client'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.clientTableAdapter.Fill(this.loginDataSet.client);
            label5.Text = message;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("REMPLIR LE CHAMP","ALERT");

            }
         
            else
            {  
                con.Open();
                string cm = "select * from client where id ='" + textBox1.Text + "'";
              
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
            DialogResult res = MessageBox.Show("vous etes sure de supprimer cette ligne ?","confirmation?", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (res == DialogResult.OK) { 
            con.Open();
            int position = this.dataGridView1.CurrentRow.Index;
            int ir = int.Parse(this.dataGridView1.Rows[position].Cells[0].Value.ToString());
            cmd.CommandText = "delete from client where ID=" + ir;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
                MessageBox.Show("supression bien faite","NOTIFICATION");
            cmd.CommandText = "select * from client";
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
               
            con.Close();
        }

    }

        private void button2_Click(object sender, EventArgs e)
        {
            

            Form3 myform = new Form3();
            myform.ShowDialog();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select count(*) from client ";
            int a = int.Parse(cmd.ExecuteScalar().ToString());
            textBox2.Text = a.ToString();


            con.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;

        private void button8_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
           
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.ShowDialog();
            f.ShowDialog();
        }
    }
}
