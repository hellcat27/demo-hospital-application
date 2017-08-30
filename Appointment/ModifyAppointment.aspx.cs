using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace OnlineHospitalSystem.Appointment
{
    public partial class ModifyAppointment : System.Web.UI.Page
    {
        AurumStellaEntities dbcon = new AurumStellaEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            userIdentity.Text = User.Identity.Name;
            dbcon.PatientTables.Load();
            PatientTable myUserName =
                (from x in dbcon.PatientTables.Local
                 where x.Email.Trim().Equals(User.Identity.Name.ToString().Trim())
                 select x).First();
            userName.Text = myUserName.FirstName + " " + myUserName.LastName;
            userID.Text = myUserName.PatientID.ToString();


            int uID = Convert.ToInt32(userID.Text);
            dbcon.AppointmentsTables.Load();
            var gridSelect =
                from x in dbcon.AppointmentsTables.Local
                where x.PatientID == uID
                select x;
            appointmentGridView.DataSource = gridSelect;
            appointmentGridView.DataBind();

            var listSelect =
                from x in dbcon.AppointmentsTables.Local
                where x.PatientID == uID
                select new
                {
                    x.AppointmentDate,
                    x.AppointmentID
                };
            appointmentSelectionDropDownList.DataTextField = "AppointmentDate";
            appointmentSelectionDropDownList.DataValueField = "AppointmentID";

            appointmentSelectionDropDownList.DataSource = listSelect;
            appointmentSelectionDropDownList.DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void cancelAppointmentButton_Click(object sender, EventArgs e)
        {
            if(dbcon != null)
            {
                dbcon.Dispose();
            }

            dbcon = new AurumStellaEntities();
            dbcon.AppointmentsTables.Load();

            
                AppointmentsTable del = (from x in dbcon.AppointmentsTables.Local
                                         where x.AppointmentID == Convert.ToInt32(appointmentSelectionDropDownList.SelectedValue)
                                         select x).SingleOrDefault();
            if (del != null)
            {
                dbcon.AppointmentsTables.Remove(del);
                dbcon.SaveChanges();
                Response.Write("<script language=javascript>alert('Appointment Cancelled!')</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('There are no appointments to cancel!')</script>");
            }

            int uID = Convert.ToInt32(userID.Text);
            dbcon.AppointmentsTables.Load();
            var gridSelect =
                from x in dbcon.AppointmentsTables.Local
                where x.PatientID == uID
                select x;
            appointmentGridView.DataSource = gridSelect;
            appointmentGridView.DataBind();

            var listSelect =
                from x in dbcon.AppointmentsTables.Local
                where x.PatientID == uID
                select new
                {
                    x.AppointmentDate,
                    x.AppointmentID
                };
            appointmentSelectionDropDownList.DataTextField = "AppointmentDate";
            appointmentSelectionDropDownList.DataValueField = "AppointmentID";

            appointmentSelectionDropDownList.DataSource = listSelect;
            appointmentSelectionDropDownList.DataBind();
        }
    }
}