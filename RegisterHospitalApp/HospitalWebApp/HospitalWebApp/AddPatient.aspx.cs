using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int Id = 0;
        HospitalRegisterEntities hospitalRegisterEntities= new HospitalRegisterEntities();
        PatientReposiotry patientReposiotry= new PatientReposiotry();
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

                if (PatientReposiotry.shert == true)
                {
                    Patient patient = patientReposiotry.GetData(Id);
                    name.Value = patient.name;
                    surname.Value = patient.surname;
                    email.Value = patient.email;
                    phoneNumber.Value = patient.phone_number;
                    medDepartment.Value = patient.med_department;
                    birthday.Value = patient.birthday.ToString();
                    admitDate.Value = patient.admit_date.ToString();
                    if(patient.status == true) { checkAdmit.Checked = true; }
                    else { checkAdmit.Checked = false; }
                    note.Value = patient.note;
                    if(patient.gender == flexRadioDefault1.Value) { flexRadioDefault1.Checked= true; }
                    else if(patient.gender == flexRadioDefault2.Value) { flexRadioDefault2.Checked= true; }
                    PatientReposiotry.shert = false;
                }
            }
        }

        protected void save_btn_ServerClick(object sender, EventArgs e)
        {
            PatientReposiotry.shert = true;
            Patient patient = new Patient();
            patient.name = name.Value;
            patient.surname = surname.Value;
            patient.email = email.Value;
            patient.phone_number = phoneNumber.Value;
            if (flexRadioDefault1.Checked) { patient.gender = flexRadioDefault1.Value; }
            else if (flexRadioDefault2.Checked){ patient.gender = flexRadioDefault2.Value; }
            patient.med_department = medDepartment.Value;
            //try
            //{
                patient.birthday = DateTime.Parse(birthday.Value);
                patient.admit_date = DateTime.Parse(admitDate.Value);
            //}
            //catch(Exception ex) { myMessage("Məlumatları düzgün formatda daxil edib yenidən cəhd edin!"); }
            patient.register_date = DateTime.Now;
            patient.note =note.Value;
            if (checkAdmit.Checked == true) { patient.status = true; }
            else { patient.status = false; }

            Patient checkPatient = patientReposiotry.GetDataWithPhone(phoneNumber.Value);
            if(checkPatient != null)
            {
                myMessage("Bu mobil nömrə ilə qeydiyyat mövcuddur!");
                phoneNumber.Value = "";
            }
            else
            {
                if (Id == 0 && phoneNumber.Value != "")
                {
                    patientReposiotry.Insert(patient);
                    clearBoxes();
                    Response.Redirect("PatientList.aspx");
                }
                else
                {
                    myMessage("Mobil nömrə qeyd edin!");
                }
            }
            

            

            
            
        }
        public class PatientReposiotry
        {
            public static Boolean shert = true;
            public void Insert(Patient patient)
            {
                HospitalRegisterEntities hospitalRegisterEntities= new HospitalRegisterEntities();
                hospitalRegisterEntities.Patients.Add(patient);
                hospitalRegisterEntities.SaveChanges();
            }

            public List<Patient> GetAllData()
            {
                HospitalRegisterEntities hospitalRegisterEntities = new HospitalRegisterEntities();
                return hospitalRegisterEntities.Patients.ToList();
            }

            public Patient GetData(int Id)
            {
                HospitalRegisterEntities hospitalRegisterEntities = new HospitalRegisterEntities();
                return hospitalRegisterEntities.Patients.Where(x => x.id == Id).FirstOrDefault();
            }
            public Patient GetDataWithPhone(string Phone)
            {
                HospitalRegisterEntities hospitalRegisterEntities = new HospitalRegisterEntities();
                return hospitalRegisterEntities.Patients.Where(x => x.phone_number == Phone).FirstOrDefault();
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

        protected void cancel3_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("PatientList.aspx");
        }
    }
}