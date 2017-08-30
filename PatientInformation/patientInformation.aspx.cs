using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace OnlineHospitalSystem.PatientInformation
{
    public partial class patientInformation : System.Web.UI.Page
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
            dbcon.PatientTables.Load();
            var gridSelect =
                from x in dbcon.PatientTables.Local
                where x.PatientID == uID
                select x;
            GridView1.DataSource = gridSelect;
            GridView1.DataBind();

            int aID = Convert.ToInt32(userID.Text);
            dbcon.AppointmentsTables.Load();
            var gridSelectApp =
                from x in dbcon.AppointmentsTables.Local
                where x.PatientID == uID
                select x;
            GridView2.DataSource = gridSelectApp;
            GridView2.DataBind();
        }
    }
}