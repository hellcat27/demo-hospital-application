<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="OnlineHospitalSystem.Messages.messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <span style="font-size: x-large">Message Doctor</span>
    </p>
    <p>
        &nbsp;<asp:Label ID="userName" runat="server" Text="userName"></asp:Label>
        &nbsp;<asp:Label ID="userID" runat="server" Text="userID"></asp:Label>
    </p>
    <p>
        <asp:Label ID="userIdentity" runat="server" Text="userIdentity"></asp:Label>
        <br />
    </p>
    <p>
        To&nbsp;&nbsp;&nbsp;
    
    
        <asp:DropDownList ID="doctorDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="doctorDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
    
    
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        Message
    <asp:TextBox ID="messageTextBox" runat="server" Height="117px" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="sendButton" runat="server" OnClick="sendButton_Click" Text="Send" />
    </p>
    <p>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>
    </p>
</asp:Content>
