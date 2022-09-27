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
    public partial class Diagnosis_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populate();
            if (IsPostBack) return;
            populateCombo();
        }
        public void populateCombo()
        {
            SqlDataAdapter da;          
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            Con.Open();
            string sql = "select PatientId,PatientName,PatientAddress from PatientTable";
            SqlCommand cmd = new SqlCommand(sql, Con);
            var ds1 = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds1);
            diapatId.DataSource = ds1;
            diapatId.DataValueField = "PatientName";
            diapatId.DataTextField = "PatientId";
            diapatId.DataBind();
            diapatId.Items.Insert(0, "---Select---");
            Con.Close();         
        }
       
        public void populate()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            Con.Open();
            string query = "select * from DiagnosisTable";
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
            diaSym.Text = "";
            diaPatname.Text = "";            
            diaMedicines.Text = "";
            diaDia.Text = "";
            diaId.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            diaId.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
            diapatId.SelectedItem.Text = GridView1.SelectedRow.Cells[2].Text.ToString();
            diaPatname.Text = GridView1.SelectedRow.Cells[3].Text.ToString();
            diaSym.Text = GridView1.SelectedRow.Cells[4].Text.ToString();
            diaDia.Text = GridView1.SelectedRow.Cells[5].Text.ToString();
            diaMedicines.Text = GridView1.SelectedRow.Cells[6].Text.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            if (diaPatname.Text == "" || diaMedicines.Text == "" || diaDia.Text == "" || diaSym.Text == "")
                MessageBox.Show("No Empty Field Accepted");
            else
            {
                SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
                Con.Open();
                string query = "insert into DiagnosisTable values('" + diaId.Text + "'," + diapatId.SelectedItem + ",'" + diaPatname.Text + "','" + diaDia.Text + "','" + diaSym.Text + "','" + diaMedicines.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis Details Successfully Added");
                Con.Close();
                populate();
                ClearData();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            Con.Open();
            string query = "update DiagnosisTable set Symptoms='" + diaSym.Text + "',Diagnosis='" + diaDia.Text + "',Medicines='" + diaMedicines.Text + "'where DiagnosisId='" + diaId.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Diagnosis Details Updated Successfully");
            populate();
            ClearData();
            Con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (diaId.Text == "")
            {
                MessageBox.Show("Enter the Diagnosis Id");
            }
            else
            {
                if (MessageBox.Show("Do you want to Delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
                    Con.Open();
                    string query = "delete from DiagnosisTable where DiagnosisId='" + diaId.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Diagnosis Details Successfully Deleted");
                    populate();
                    ClearData();
                    Con.Close();
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to go Home?", "Home Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Response.Redirect("Home.aspx");
        }

        protected void diapatId_SelectedIndexChanged(object sender, EventArgs e)
         {
            string value = diapatId.SelectedValue;
            string text = diapatId.SelectedItem.Text;
            diaPatname.Text = String.Format("{0}",value);
        }

        protected void diaDia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}