using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_ServerClick(object sender, EventArgs e)
        {
            if(username != null && username.Value != "" && username.Value.Length >= 4 && password != null && password.Value != "" && password.Value.Length > 4)
            {

                HospitalRegisterEntities hospitalRegisterEntities = new HospitalRegisterEntities();

                var checkAdmin = hospitalRegisterEntities.Admins.Where(x => x.username == username.Value).FirstOrDefault();
                Admin admin = new Admin();
                if(checkAdmin == null || username.Value!= checkAdmin.username)
                {
                    admin.username = username.Value;
                    admin.password = password.Value;
                    admin.status = true;
                    hospitalRegisterEntities.Admins.Add(admin);
                    hospitalRegisterEntities.SaveChanges();
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Bu username ilə istifadəçi mövcuddur!" + "');", true);

                }

            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Xəta! yenidən cəhd edin!" + "');", true);
                
        }

        protected void cancel_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}