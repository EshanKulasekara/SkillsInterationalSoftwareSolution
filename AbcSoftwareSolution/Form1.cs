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

namespace AbcSoftwareSolution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VKBFCKA\SQLSERVER;Initial Catalog=Student;Integrated Security=True");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string uname = textBox1.Text;
            string pass = textBox2.Text;

            string query_select = "SELECT * FROM login WHERE username = '" + uname + "' AND password = '" + pass + "'";
            SqlCommand cmnd = new SqlCommand(query_select, con);
            SqlDataReader row = cmnd.ExecuteReader();

            if (row.HasRows)
            {
                this.Hide();
                Form2 obj = new Form2();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials, Please check Username and Password and Try Again!", "Invalid Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure,Do you really want to Exit....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
