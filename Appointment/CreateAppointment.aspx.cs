using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace OnlineHospitalSystem.Appointment
{
    public partial class CreateAppointment : System.Web.UI.Page
    {
        AurumStellaEntities dbcon = new AurumStellaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Display user data at top for confirmation and submission validation
            userIdentity.Text = User.Identity.Name;
            dbcon.PatientTables.Load();
            PatientTable myUserName =
                (from x in dbcon.PatientTables.Local
                 where x.Email.Trim().Equals(User.Identity.Name.ToString().Trim())
                 select x).First();
            userName.Text = myUserName.FirstName + " " + myUserName.LastName;
            userID.Text = myUserName.PatientID.ToString();
            

            if (!IsPostBack)
            {
                dbcon.HospitalTables.Load();
                var cityResult =
                    from location in dbcon.HospitalTables.Local
                    select new
                    {
                        location.City
                    };

                var filteredCityResult = cityResult
                    .GroupBy(x => x.City)
                    .Select(x => x.First());

                cityDropDownList.DataTextField = "City";
                cityDropDownList.DataValueField = "City";

                cityDropDownList.DataSource = filteredCityResult;
                cityDropDownList.DataBind();
                cityDropDownList.Items.Insert(0, "Please Select City");
            }


        }

        protected void cityDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
                dbcon.HospitalTables.Load();
                var hospitalResult =
                    from hospital in dbcon.HospitalTables.Local
                    where hospital.City == cityDropDownList.SelectedValue
                    select new
                    {
                        hospital.Name,
                        hospital.HospitalID
                    };

                locationDropDownList.DataTextField = "Name";
                locationDropDownList.DataValueField = "HospitalID";

                locationDropDownList.DataSource = hospitalResult;
                locationDropDownList.DataBind();
                locationDropDownList.Items.Insert(0, "Please Select Location");
            if (cityDropDownList.Items.Count > 2)
            {
                cityDropDownList.Items.RemoveAt(0);
            }


        }

        protected void locationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbcon.DepartmentTables.Load();
            var departmentResult =
                from department in dbcon.DepartmentTables.Local
                where department.HospitalID == Convert.ToInt32(locationDropDownList.SelectedValue)
                select new
                {
                    department.Name,
                    department.DepartmentID
                };

            departmentDropDownList.DataTextField = "Name";
            departmentDropDownList.DataValueField = "DepartmentID";

            departmentDropDownList.DataSource = departmentResult;
            departmentDropDownList.DataBind();
            departmentDropDownList.Items.Insert(0, "Please Select Department");
            if (locationDropDownList.Items.Count > 2)
            {
                locationDropDownList.Items.RemoveAt(0);
            }

        }

        protected void departmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbcon.DoctorTables.Load();
            var doctorResult =
                from doctor in dbcon.DoctorTables.Local
                where doctor.DepartmentID == Convert.ToInt32(departmentDropDownList.SelectedValue)
                select new
                {
                    doctor.FirstName,
                    doctor.LastName,
                    doctor.DoctorID
                };
         

            doctorDropDownList.DataTextField = "LastName";
            doctorDropDownList.DataValueField = "DoctorID";

            doctorDropDownList.DataSource = doctorResult;
            doctorDropDownList.DataBind();
            if (departmentDropDownList.Items.Count > 2)
            {
                departmentDropDownList.Items.RemoveAt(0);
            }

            doctorDropDownList.Items.Insert(0, "Please Select Doctor");
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            calendarString.Text = Calendar.SelectedDate.ToShortDateString();
        }

        protected void doctorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doctorDropDownList.Items.Count > 2)
            {
                doctorDropDownList.Items.RemoveAt(0);
            }
        }

        protected void submitAppointmentButton_Click(object sender, EventArgs e)
        {
            if(dbcon != null)
            {
                dbcon.Dispose();
            }


            dbcon = new AurumStellaEntities();

            //create object for record
            AppointmentsTable myAppointment = new AppointmentsTable();



            //get doctorid for appointment
            int docID = Convert.ToInt32(doctorDropDownList.SelectedValue);
            var doctorID = dbcon.DoctorTables.Single(x => x.DoctorID == docID).DoctorID;

            //get patientid for appointment
            var patientID = userID;

            //get time for appointment
            int hours = Convert.ToInt32(hoursTextBox.Text);
            int min = Convert.ToInt32(minutesTextBox.Text);
            
            //get date for appointment
            var date = calendarString.Text;
            DateTime parsedDate = DateTime.Parse(date);
            DateTime appTime = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, hours, min, 0);

            
            //get departmentid for appointment
            int deptID = Convert.ToInt32(departmentDropDownList.SelectedValue);
            var departmentID = dbcon.DepartmentTables.Single(x => x.DepartmentID == deptID).DepartmentID;

            //get hospital for appointment
            int hospID = Convert.ToInt32(locationDropDownList.SelectedValue);
            var hospitalID = dbcon.HospitalTables.Single(x => x.HospitalID == hospID).HospitalID;

            //get reason for appointment
            string reason = reasonTextBox.Text;

            //add data
            myAppointment.DoctorID = doctorID;
            myAppointment.PatientID = Convert.ToInt32(userID.Text);
            myAppointment.AppointmentDate = Convert.ToDateTime(appTime);
            myAppointment.AppointmentTime = new TimeSpan(hours, min, 0);
            myAppointment.DepartmentID = departmentID;
            myAppointment.HospitalID = hospitalID;

            //check date/time data to avoid schedule conflicts
            var timeCheck =
                from appointment in dbcon.AppointmentsTables
                where appointment.DoctorID == myAppointment.DoctorID && appointment.HospitalID == appointment.HospitalID && appointment.DepartmentID == appointment.DepartmentID
                select appointment;
            

            int i = 0; //i is increased by one each time an appointment 30 minutes on the same day is detected
            
            foreach(var item in timeCheck)
            {
                DateTime scheduledTime = item.AppointmentDate;
                DateTime requestedTime = myAppointment.AppointmentDate;
                TimeSpan span = requestedTime.Subtract(scheduledTime).Duration();
                if(span.TotalMinutes < 30)
                {
                    i++;
                }
            }

            //save data to table
            if (i == 0)
            {
                dbcon.AppointmentsTables.Add(myAppointment);
                dbcon.SaveChanges();
                Response.Write("<script language=javascript>alert('Appointment created!')</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Another appointment is already scheduled within this timeframe. Please choose a different time.')</script>");
            }

        }


    }
}