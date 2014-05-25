<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebClient.Persons.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-signin">
        <div>    
            <label>Id:</label>        
            <asp:TextBox ID="idField" runat="server" />
        </div>
        <div>
            <label>Name:</label>
            <asp:TextBox ID="nameField" runat="server" />
        </div>
        <div>
            <label>Last name:</label>
            <asp:TextBox ID="lastNameField" runat="server" />
        </div>
        <div>
            <label>Birthday:</label>
            <asp:TextBox ID="birthdayField" runat="server" />
        </div>
        <webcl:Captcha ID="captcha" runat="server" />
        <button type="submit" runat="server" onserverclick="Submit_ServerClick">Submit</button>
    </div>
</asp:Content>
