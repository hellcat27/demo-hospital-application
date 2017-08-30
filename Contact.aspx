<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="OnlineHospitalSystem.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>15th Ave Hospital</h3>
    <address>
        320 15th Ave S<br />
        Fargo, ND 58102<br />
        <abbr title="Phone">P:</abbr>
        701.557.0130
    </address>
    <h3>32 Street Hospital</h3>
    <address>
        716 32 St N<br />
        Fargo, ND 58103<br />
        <abbr title="Phone">P:</abbr>
        701.557.0140
    </address>
    <h3>1271 Thomas St Hospital</h3>
    <address>
        1271 Thomas St<br />
        Moorhead, MN 56560<br />
        <abbr title="Phone">P:</abbr>
        218.684.0150
    </address>
    <h3>14th St SE Hospital</h3>
    <address>
        3615 14th St SE<br />
        Moorhead, MN 56561<br />
        <abbr title="Phone">P:</abbr>
        218.684.1172
    </address>
    
    <address>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Messages/messages.aspx">Message Doctor</asp:HyperLink>
    </address>
    <br />
    <p><strong style="color: #FF0000">FOR EMERGENCIES CALL 911</strong></p>

    <address>
        &nbsp;</address>
</asp:Content>
