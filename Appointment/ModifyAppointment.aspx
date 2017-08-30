<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyAppointment.aspx.cs" Inherits="OnlineHospitalSystem.Appointment.ModifyAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <div>
                <h1>Modify Existing Appointment</h1>
            </div>
            <div>

                <asp:Label ID="userName" runat="server" Text="userName"></asp:Label>
&nbsp;

            &nbsp;<asp:Label ID="userID" runat="server" Text="userID"></asp:Label>
                <br />
                <asp:Label ID="userIdentity" runat="server" Text="userIdentity"></asp:Label>
                <br />
                Scheduled Appointments:<br />
&nbsp;<asp:GridView ID="appointmentGridView" runat="server">
                </asp:GridView>
                <br />
                <asp:DropDownList ID="appointmentSelectionDropDownList" runat="server">
                </asp:DropDownList>
                <br />
                <asp:Button ID="cancelAppointmentButton" runat="server" Text="Cancel Appointment" OnClick="cancelAppointmentButton_Click" />

                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Messages/messages.aspx">Messages</asp:HyperLink>
                <br />

            </div>
        </div>
    </div>
</asp:Content>
