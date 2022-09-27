using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Web.Security;

namespace HMSAPP_web
{
    public partial class SHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Login?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DocName.Text == "" || DocPass.Text == "")
                    MessageBox.Show("Enter a Username and Password");
                else
                {
                    SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
                    Con.Open();
                    SqlDataAdapter sad = new SqlDataAdapter("select Count(*) from DoctorTable where DoctorName='" + DocName.Text + "' and DoctorPass='" + DocPass.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sad.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        //Home h = new Home();
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password");
                    }
                    Con.Close();
                }
            }
        }
    }
}