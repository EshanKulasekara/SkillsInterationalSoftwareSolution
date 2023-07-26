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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VKBFCKA\SQLSERVER;Initial Catalog=Student;Integrated Security=True");

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            DateTime thisDay = DateTime.Today;
            dateTimePicker1.Text = thisDay.ToString();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox6.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox9.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = textBox1.Text;
                string lname = textBox2.Text;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy/MM/dd";
                string gender;
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = textBox6.Text;
                string email = textBox5.Text;
                int mPhone = int.Parse(textBox7.Text);
                int hPhone = int.Parse(textBox8.Text);
                string pName = textBox3.Text;
                string nic = textBox4.Text;
                int contact = int.Parse(textBox9.Text);
                string query_insert = "INSERT INTO Registration VALUES ('" + fname + "', '" + lname + "', '" + dateTimePicker1.Text + "', '" + gender + "', '" + address + "', '" + email + "', " + mPhone + ", " + hPhone + ", '" + pName + "', '" + nic + "', " + contact + ")";

                Console.WriteLine(query_insert);


                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmnd = new SqlCommand(query_insert, con);
                cmnd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Added Successfully!", "Registerd Student!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string no = comboBox1.Text;

            if (no != "New Register")
            {
                string fname = textBox1.Text;
                string lname = textBox2.Text;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy/MM/dd";
                string gender;
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = textBox6.Text;
                string email = textBox5.Text;
                int mPhone = int.Parse(textBox7.Text);
                int hPhone = int.Parse(textBox8.Text);
                string pName = textBox3.Text;
                string nic = textBox4.Text;
                int contactNo = int.Parse(textBox9.Text);
                string query_insert = "UPDATE Registration Set firstName = '" + fname + "', lastName = '" + lname + "', dateOfBirth = '" + dateTimePicker1.Text + "', gender = '" + gender + "', address = '" + address + "', email = '" + email + "', mobilePhone = " + mPhone + ", homePhone = " + hPhone + ", parentName = '" + pName + "', nic = '" + nic + "', contactNo = '" + contactNo + "' WHERE regNo = " + no;

                con.Open();
                SqlCommand cmnd = new SqlCommand(query_insert, con);

                cmnd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully!", "Updated Student!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                var result = MessageBox.Show("Are you sure, Do you really want to Delete this Record....?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    string no = comboBox1.Text;
                    string query_insert = "DELETE FROM Registration WHERE regNo = " + no + "";
                    con.Open();
                    SqlCommand cmnd = new SqlCommand(query_insert, con);
                    cmnd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Succesfully!", "Deleted Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else if(result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to exit.....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }else if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
            string query_select = "SELECT * FROM Registration";
            SqlCommand cmnd = new SqlCommand(query_select, con);
            SqlDataReader row = cmnd.ExecuteReader();
            comboBox1.Items.Add("New Register");
            while (row.Read())
            {
                comboBox1.Items.Add(row[0].ToString());
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string no = comboBox1.Text;
            if(no != "New Register")
            {
                con.Open();
                string query_select = "SELECT * FROM Registration WHERE regNo = " + no;
                SqlCommand cmnd = new SqlCommand(query_select, con);
                SqlDataReader row = cmnd.ExecuteReader();
                while (row.Read())
                {
                    textBox1.Text = row[1].ToString();
                    textBox2.Text = row[2].ToString();
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "yyyy/MM/dd";
                    dateTimePicker1.Text = row[3].ToString();
                    if(row[4].ToString() == "Male")
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = true;
                    }
                    textBox6.Text = row[5].ToString();
                    textBox5.Text = row[6].ToString();
                    textBox7.Text = row[7].ToString();
                    textBox8.Text = row[8].ToString();
                    textBox3.Text = row[9].ToString();
                    textBox4.Text = row[10].ToString();
                    textBox9.Text = row[11].ToString();
                }
                con.Close();
                button3.Enabled = false;
                button4.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy/MM/dd";
                DateTime thisDay = DateTime.Today;
                dateTimePicker1.Text = thisDay.ToString();
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                textBox6.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox9.Text = "";
                button3.Enabled = true;
                button4.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Close();
        }
    }
}
