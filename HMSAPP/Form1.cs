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

namespace HMSAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (DocName.Text == "" || DocPass.Text == "")
            {
                
                label5.ForeColor = System.Drawing.Color.Red;
                label5.Text = "Empty fields not allowed";
                label6.ForeColor = System.Drawing.Color.Red;
                label6.Text = "Empty fields not allowed";
                checkBox1.Visible = false;
            }
               
            else
            {
                SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
                Con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("select Count(*) from DoctorTable where DoctorName='" + DocName.Text + "' and DoctorPass='" + DocPass.Text+"'",Con);
                DataTable dt = new DataTable();
                sad.Fill(dt);
                if(dt.Rows[0][0].ToString()=="1")
                {
                                       
                        Home H = new Home();
                        H.Show();
                        this.Hide();
                    
                }
                else
                {
                    //MessageBox.Show("Incorrect Username or Password");
                    label7.Visible = true;
                    label7.ForeColor = System.Drawing.Color.Red;
                    label7.Text = "Incorrect Username or Password..!";
                    checkBox1.Visible = true;
                }
                Con.Close();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Close this Project?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DocName.Text = "";
            DocPass.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DocName_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            checkBox1.Visible = true;
        }

        private void DocPass_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            checkBox1.Visible = true;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                DocPass.UseSystemPasswordChar = false;

            }
            else
                DocPass.UseSystemPasswordChar = true;
        }
    }
}
