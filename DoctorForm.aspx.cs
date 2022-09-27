using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HMSAPP_web
{
    public partial class DoctorForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populate();
        }
        void populate()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            Con.Open();
            string query = "select * from DoctorTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder build = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            Con.Close();
        }
        void ClearData()
        {
            DocId.Text = "";
            DocName.Text = "";
            DocExp.Text = "";
            DocPass.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to go Home?", "Home Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Response.Redirect("Home.aspx");

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocId.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
            DocName.Text = GridView1.SelectedRow.Cells[2].Text.ToString();
            DocExp.Text = GridView1.SelectedRow.Cells[3].Text.ToString();
            DocPass.Text = GridView1.SelectedRow.Cells[4].Text.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            if (DocId.Text == "" || DocName.Text == "" || DocExp.Text == "" || DocPass.Text == "")
                MessageBox.Show("No Empty Field Accepted");
            else
            {
                Con.Open();
                string query = "insert into DoctorTable values('" + DocId.Text + "','" + DocName.Text + "','" + DocExp.Text + "','" + DocPass.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Details Successfully Added");
                Con.Close();
                populate();
                ClearData();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
                Con.Open();
                string query = "delete from DoctorTable where DoctorId='" + DocId.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Details Successfully Deleted");
                Con.Close();
                populate();
                ClearData();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            Con.Open();
            string query = "update DoctorTable set DoctorName='" + DocName.Text + "',DoctorExp='" + DocExp.Text + "',DoctorPass='" + DocPass.Text + "' where DoctorId='" + DocId.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor Details Updated Successfully");
            Con.Close();
            populate();
            ClearData();
        }
    }
}