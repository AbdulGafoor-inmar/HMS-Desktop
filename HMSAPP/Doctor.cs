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
    public partial class Doctor : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
        public Doctor()
        {
            InitializeComponent();
            invoiceNo();
        }
        void populate()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            Con.Open();
            string query = "select * from DoctorTable";
            SqlDataAdapter da = new SqlDataAdapter(query,Con);
            SqlCommandBuilder build = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DoctorGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        void ClearData()
        {
            DocId.Text = "";
            DocName.Text = "";
            DocExp.Text = "";
            DocPass.Text = "";
        }
        public void invoiceNo()
        {
            SqlConnection Conn = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True;Pooling=False");
            SqlCommand cmd;
            string query;
            try
            {
                query = "Select MAX(DoctorId) from DoctorTable";
                cmd = new SqlCommand(query, Conn);
                Conn.Open();
                var maxid = cmd.ExecuteScalar() as string;
                if (maxid == null)
                {
                    DocId.Text = "DOC0001";
                }
                else
                {
                    int intval = int.Parse(maxid.Substring(3, 4));
                    intval++;
                    DocId.Text = String.Format("DOC{0:0000}", intval);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
                Home h = new Home();
                h.Show();
                this.Hide();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (DocId.Text == "" || DocName.Text == "" || DocExp.Text == "" || DocPass.Text == "")
                MessageBox.Show("No Empty Field Accepted");
            else
            {
                SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
                Con.Open();
                string query = "insert into DoctorTable values('" + DocId.Text + "','" + DocName.Text + "','" + DocExp.Text + "','" + DocPass.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Details Successfully Added");
                Con.Close();
                populate();
                ClearData();
                invoiceNo();
            }
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            populate();
            invoiceNo();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
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
                invoiceNo();
            }
        }

        private void DoctorGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DocId.Text = DoctorGV.SelectedRows[0].Cells[0].Value.ToString();
            DocName.Text = DoctorGV.SelectedRows[0].Cells[1].Value.ToString();
            DocExp.Text = DoctorGV.SelectedRows[0].Cells[2].Value.ToString();
            DocPass.Text = DoctorGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=IN-WIN-AGAFOOR\SQLEXPRESS;Initial Catalog=HospitalDatabase;Integrated Security=True");
            Con.Open();
            string query = "update DoctorTable set DoctorName='" + DocName.Text + "',DoctorExp='" + DocExp.Text + "',DoctorPass='" + DocPass.Text + "' where DoctorId='"+DocId.Text +"'";
            SqlCommand cmd = new SqlCommand(query,Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor Details Updated Successfully");

            populate();
            
            Con.Close();

            ClearData();
            invoiceNo();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Close this Application?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
