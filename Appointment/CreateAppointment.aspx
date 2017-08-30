<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAppointment.aspx.cs" Inherits="OnlineHospitalSystem.Appointment.CreateAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h1>Create New Appointment</h1>
            <p>
                <asp:Label ID="userName" runat="server" Text="userName"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="userID" runat="server" Text="userID"></asp:Label>
            </p>
            <p>
                <asp:Label ID="userIdentity" runat="server" Text="userIdentity"></asp:Label>
            </p>
            <asp:Label ID="Label2" runat="server" Text="City"></asp:Label>
&nbsp;
            <asp:DropDownList ID="cityDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cityDropDownList_SelectedIndexChanged" >
                <asp:ListItem Value="">Please Select City</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cityDropDownList" ErrorMessage="Please Select a City" style="color: #CC0000"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" style="font-size: medium" Text="Location:"></asp:Label>
&nbsp;
            <asp:DropDownList ID="locationDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="locationDropDownList_SelectedIndexChanged">
                <asp:ListItem Value="">Please Select Location</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="locationDropDownList" ErrorMessage="Please Select a Location" style="color: #CC0000"></asp:RequiredFieldValidator>
            <br />
            <br />
            Department:
            <asp:DropDownList ID="departmentDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="departmentDropDownList_SelectedIndexChanged" >
                <asp:ListItem Value="">Please Select Department</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="departmentDropDownList" ErrorMessage="Please Select a Department" style="color: #CC0000"></asp:RequiredFieldValidator>
            <br />
            <br />
            Doctor:
            <asp:DropDownList ID="doctorDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="doctorDropDownList_SelectedIndexChanged" >
                <asp:ListItem Value="">Please Select Doctor</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="doctorDropDownList" ErrorMessage="Please Select a Doctor" style="color: #CC0000"></asp:RequiredFieldValidator>
            <br />
            <br />
            Date and Time of Visit:<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="calendarString" ErrorMessage="Please Choose a Date" style="color: #CC0000"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="calendarString" runat="server"></asp:TextBox>
&nbsp;<asp:Calendar ID="Calendar" runat="server" OnSelectionChanged="Calendar_SelectionChanged"></asp:Calendar>
            <br />
            <asp:TextBox ID="hoursTextBox" runat="server" Width="38px"></asp:TextBox>
            &nbsp;: <asp:TextBox ID="minutesTextBox" runat="server" Width="41px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please fill in the Minute" ControlToValidate="minutesTextBox" style="color: #CC0000"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please fill in the Hour" ControlToValidate="hoursTextBox" style="color: #CC0000"></asp:RequiredFieldValidator>
            <br />
            Reason for Visit:
            <br />
&nbsp;<asp:TextBox ID="reasonTextBox" runat="server" Height="111px" TextMode="MultiLine" Width="268px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="submitAppointmentButton" runat="server" Text="Submit" Width="96px" OnClick="submitAppointmentButton_Click" />
            <br />
        </div>
    </div>
</asp:Content>
