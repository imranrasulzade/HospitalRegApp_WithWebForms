using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebApp
{
    public partial class PatientList : System.Web.UI.Page
    {
        int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Request.Cookies["UsernameCookie"] != null)
            {
                string username = Request.Cookies["UsernameCookie"].Value;
                Username.InnerText = "\tProfile: " + username.ToUpper() + "\t";
            }

            if (Request.QueryString["id"] != null)
            {
                Id = int.Parse(Request.QueryString["id"].ToString());
                HospitalRegisterEntities hospitalRegisterEntities = new HospitalRegisterEntities();
                var deletePatient = hospitalRegisterEntities.Patients.Where(x => x.id == Id).FirstOrDefault();
                hospitalRegisterEntities.Patients.Remove(deletePatient);
                hospitalRegisterEntities.SaveChanges();
                Response.Redirect("PatientList.aspx");
            }


        }

        protected void add_btn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("AddPatient.aspx");
        }

        protected void refresh_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl, true);
        }

        

        protected void logout_btn_ServerClick(object sender, EventArgs e)
        {
            if (Request.Cookies["UsernameCookie"] != null)
            {
                Response.Cookies["UsernameCookie"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Remove("Username");
            Response.Redirect("~/Login.aspx");
        }

        protected void search_btn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("SearchPatient.aspx");
        }
    }
}