<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineHospitalSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <div style="text-align: left">
                &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/Img/main.jpg" Width="423px" />
            </div>
            <h2>Welcome to Aurum Stella Online Services!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h2>
            <div>
                <p>Here at Aurum Stella, we commit to providing the finest health services to the communities we serve.</p>
            </div>
            <div>
                <p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Appointment/CreateAppointment">Create New Appointment</asp:HyperLink>
                </p>
                <p>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Appointment/ModifyAppointment">Modify Existing Appointment</asp:HyperLink>
                </p>
                <p>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/About.aspx">About Us</asp:HyperLink>
                </p>
                <p class="text-primary">
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Contact.aspx">Contact</asp:HyperLink>
                </p>
            </div>
        </div>
        <div class="col-md-4">
            
        </div>
    </div>

</asp:Content>
