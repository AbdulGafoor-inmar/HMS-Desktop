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
    public partial class Patient_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populate();
        }
        void populate()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            Con.Open();
            string query = "select * from PatientTable";
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
            patId.Text = "";
            patName.Text = "";
            patAddress.Text = "";
            patPhone.Text = "";
            cmbGender.Text = "";
            cmbBlood.Text = "";
            patAge.Text = "";
            patMajor.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            patId.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
            patName.Text = GridView1.SelectedRow.Cells[2].Text.ToString();
            patAddress.Text = GridView1.SelectedRow.Cells[3].Text.ToString();
            patPhone.Text = GridView1.SelectedRow.Cells[4].Text.ToString();
            patAge.Text = GridView1.SelectedRow.Cells[5].Text.ToString();
            cmbGender.Text = GridView1.SelectedRow.Cells[6].Text.ToString();
            cmbBlood.Text = GridView1.SelectedRow.Cells[7].Text.ToString();
            patMajor.Text = GridView1.SelectedRow.Cells[8].Text.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
                Con.Open();
                string query = "delete from PatientTable where PatientId='" + patId.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Details Successfully Deleted");
                Con.Close();
                populate();
                ClearData();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to go Home?", "Home Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)                
            Response.Redirect("Home.aspx");           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            Con.Open();
            string query = "insert into PatientTable values('" + patId.Text + "','" + patName.Text + "','" + patAddress.Text + "','" + patPhone.Text + "'," + patAge.Text + ",'" + cmbGender.SelectedItem.ToString() + "','" + cmbBlood.SelectedItem.ToString() + "','" + patMajor.Text + "')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Patient Details Successfully Added");
            Con.Close();
            populate();
            ClearData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");

            Con.Open();
            string query = "update PatientTable set PatientName='" + patName.Text + "',PatientAddress='" + patAddress.Text + "',PatientPhone='" + patPhone.Text + "',PatientAge=" + patAge.Text + ",PatientDisease='" + patMajor.Text + "',PatientGender='" + cmbGender.SelectedItem.ToString() + "', PatientBlood='" + cmbBlood.SelectedItem.ToString() + "'where PatientId='" + patId.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Patient Details Updated Successfully");
            Con.Close();
            populate();
            ClearData();
        }
    }
}