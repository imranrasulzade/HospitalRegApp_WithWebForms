using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static HospitalWebApp.WebForm1;

namespace HospitalWebApp
{
    public partial class SearchPatient : System.Web.UI.Page
    {
        PatientReposiotry patientReposiotry = new PatientReposiotry();
        string checkNumber = null;
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
        }

        protected void edit_btn_ServerClick(object sender, EventArgs e)
        {
            if(patientPhone.Value != "") {
                HospitalRegisterEntities hospitalRegisterEntities = new HospitalRegisterEntities();
                var updatePatient = hospitalRegisterEntities.Patients.Where(x => x.phone_number == patientPhone.Value).FirstOrDefault();
                if (updatePatient != null)
                {
                    checkNumber = updatePatient.phone_number.ToString();
                }


                updatePatient.name = name.Value;
                updatePatient.surname = surname.Value;
                updatePatient.email = email.Value;
                updatePatient.phone_number = phoneNumber.Value;
                updatePatient.med_department = medDepartment.Value;
                if (flexRadioDefault1.Checked) { updatePatient.gender = flexRadioDefault1.Value; }
                else if (flexRadioDefault2.Checked) { updatePatient.gender = flexRadioDefault2.Value; }
                //try
                //{
                updatePatient.birthday = DateTime.Parse(birthday.Value);
                updatePatient.admit_date = DateTime.Parse(admitDate.Value);
                //}
                //catch (Exception ex) { myMessage("Məlumatları düzgün formatda daxil edib yenidən cəhd edin!"); }
                updatePatient.note = note.Value;
                if (checkAdmit.Checked == true) { updatePatient.status = true; }
                else { updatePatient.status = false; }
                Patient checkPatient = patientReposiotry.GetDataWithPhone(phoneNumber.Value);
                if (checkPatient == null || checkPatient.phone_number == checkNumber)
                {
                    hospitalRegisterEntities.SaveChanges();
                    Response.Redirect("PatientList.aspx");
                }
                else
                {
                    myMessage("Bu mobil nömrə ilə qeydiyyat mövcuddur!");
                    phoneNumber.Value = patientPhone.Value;
                }


            }
            else
            {
                
                myMessage("Əvvəlcə pasiyenti axtarın!");
            }

        }

        protected void search_btn2_ServerClick(object sender, EventArgs e)
        {
            Patient patient = patientReposiotry.GetDataWithPhone(patientPhone.Value);
            if(patient != null)
            {
                name.Value = patient.name;
                surname.Value = patient.surname;
                email.Value = patient.email;
                phoneNumber.Value = patient.phone_number;
                medDepartment.Value = patient.med_department;
                birthday.Value = patient.birthday.ToString();
                admitDate.Value = patient.admit_date.ToString();
                if (patient.status == true) { checkAdmit.Checked = true; }
                else { checkAdmit.Checked = false; }
                note.Value = patient.note;
                if (patient.gender == flexRadioDefault1.Value) { flexRadioDefault1.Checked = true; }
                else if (patient.gender == flexRadioDefault2.Value) { flexRadioDefault2.Checked = true; }
            }
            else
            {
                patientPhone.Value = null;
                clearBoxes();
                myMessage("Bu mobil nömrəni istifadə edən pasiyent yoxdur!");
            }
        }
        public void myMessage(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
        }
        public void clearBoxes()
        {
            name.Value = null;
            surname.Value = null;
            birthday.Value = null;
            admitDate.Value = null;
            phoneNumber.Value = null;
            email.Value = null;
            medDepartment.SelectedIndex = 0;
            flexRadioDefault1.Checked = false;
            flexRadioDefault2.Checked = false;
            note.Value = null;
            checkAdmit.Checked = false;
        }

        protected void logout_btn2_ServerClick(object sender, EventArgs e)
        {
            if (Request.Cookies["UsernameCookie"] != null)
            {
                Response.Cookies["UsernameCookie"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Remove("Username");
            Response.Redirect("~/Login.aspx");
        }

        protected void cancel2_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("PatientList.aspx");
        }

        protected void remove_btn_ServerClick(object sender, EventArgs e)
        {
            HospitalRegisterEntities hospitalRegisterEntities = new HospitalRegisterEntities();
            var deletePatient = hospitalRegisterEntities.Patients.Where(x => x.phone_number == phoneNumber.Value).FirstOrDefault();
           if(deletePatient != null)
            {
                hospitalRegisterEntities.Patients.Remove(deletePatient);
                hospitalRegisterEntities.SaveChanges();
                Response.Redirect("PatientList.aspx");
            }
            else
            {
                clearBoxes();
                myMessage("Əvvəlcə pasiyenti axtarın!");
            }
        }

        protected void cancel_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("PatientList.aspx");
        }

    }
}