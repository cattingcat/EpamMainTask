<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebClient.Phones.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="form-signin">
        <div>    
            <label>Id:</label>        
            <asp:TextBox ID="idField" runat="server" />
        </div>
        <div>
            <label>Number:</label>
            <asp:TextBox ID="numberField" runat="server" />
        </div>        
        <div>
            <label>Owner:</label>
            <asp:TextBox ID="ownerField" runat="server" />
        </div>
        <webcl:Captcha ID="captcha" runat="server" />
        <button type="submit" runat="server" onserverclick="Unnamed_ServerClick">Submit</button>
    </div>
</asp:Content>
