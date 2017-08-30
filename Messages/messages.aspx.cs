using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace OnlineHospitalSystem.Messages
{
    public partial class messages : System.Web.UI.Page
    {
        AurumStellaEntities dbcon = new AurumStellaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                userIdentity.Text = User.Identity.Name;
                dbcon.PatientTables.Load();
                PatientTable myUserName =
                    (from x in dbcon.PatientTables.Local
                     where x.Email.Trim().Equals(User.Identity.Name.ToString().Trim())
                     select x).First();
                userName.Text = myUserName.FirstName + " " + myUserName.LastName;
                userID.Text = myUserName.PatientID.ToString();


                dbcon.DoctorTables.Load();
                var doctorQuery = from x in dbcon.DoctorTables.Local
                                  orderby x.LastName, x.FirstName
                                  select new
                                  {
                                      Name = x.LastName + ", " + x.FirstName,
                                      x.Email
                                  };

                doctorDropDownList.DataValueField = "Email";
                doctorDropDownList.DataTextField = "Name";

                doctorDropDownList.DataSource = doctorQuery;
                doctorDropDownList.DataBind();
            }

                string uID = userIdentity.Text;
                dbcon.MessagesTables.Load();
                var gridSelect =
                    from x in dbcon.MessagesTables.Local
                    where x.FROM == uID || x.TO == uID
                    select x;
                GridView1.DataSource = gridSelect;
                GridView1.DataBind();

            
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
           
           
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            using (AurumStellaEntities dbcon = new AurumStellaEntities())
            {


                MessagesTable myMsg = new MessagesTable();
                myMsg.FROM = userIdentity.Text;
                myMsg.TO = doctorDropDownList.SelectedValue.Trim();
                myMsg.MessageText = messageTextBox.Text;

                dbcon.MessagesTables.Add(myMsg);
                dbcon.SaveChanges();

                string uID = userIdentity.Text;
                dbcon.MessagesTables.Load();
                var gridSelect =
                    from x in dbcon.MessagesTables.Local
                    where x.FROM == uID || x.TO == uID
                    select x;
                GridView1.DataSource = gridSelect;
                GridView1.DataBind();
            }
            

        }

        protected void doctorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            doctorDropDownList.DataValueField = "Email";
            doctorDropDownList.DataTextField = "Name";
        }
    }
}