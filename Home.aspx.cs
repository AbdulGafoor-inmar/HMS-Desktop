using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HMSAPP_web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Response.Redirect("SHome.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to open Doctor Form?", "Doctor Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Response.Redirect("DoctorForm.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to open Patient Form?", "Patient Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Response.Redirect("Patient Form.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Open Diagnosis Form?", "Diagnosis Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Response.Redirect("Diagnosis Form.aspx");
        }
    }
}