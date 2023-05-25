using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        HospitalRegisterEntities HospitalRegisterEntities = new HospitalRegisterEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void log_in_ServerClick(object sender, EventArgs e)
        {
            string usrnm = username.Value;
            string pswrd = password.Value;

            using (var db = new HospitalRegisterEntities())
            {
                var user = db.Admins.FirstOrDefault(u => u.username == usrnm && u.password == pswrd);
                
                 if (user != null && user.status == true)
                 {
                    Session["Username"] = user.username;

                    HttpCookie userCookie = new HttpCookie("UsernameCookie");
                    userCookie.Value = user.username;
                    Response.Cookies.Add(userCookie);

                    Response.Redirect("~/PatientList.aspx");
                 }
                 else
                 {
                    Response.Redirect("Login.aspx");
                 }
            }
        }

        protected void register_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");

        }
    }
}