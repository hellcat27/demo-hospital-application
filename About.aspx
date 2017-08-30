<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OnlineHospitalSystem.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8">
            <div>
                <h1>About Us</h1>
                <br />
                <p>
                    Aurum Stella is an integrated health system serving patients in Fargo, North Dakota.

Aurum Stella combines the talents of 10,000 employees, including more than 1,000 physicians and practitioners, who serve our communities by providing essential and crital services and outreach to the surrounding area.


Aurum Stella is accredited as an Accountable Care Organization by the National Committee for Quality Assurance.
                </p>
            </div>
        </div>
        <div class="col-md-4">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/hospital_exterior.jpg" Width="400px" />
        </div>
    </div>
</asp:Content>
