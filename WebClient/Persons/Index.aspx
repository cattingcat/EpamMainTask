<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebClient.Persons.Index" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-responsive">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Last name</th>
                    <th>Date of birth</th>
                    <th>Delete</th>
                    <th>Phones</th>
                </tr>
            </thead>
            <tbody>
                <% foreach(var p in Persons){ %>
                <tr>
                    <td> <%= p.Id %> </td>
                    <td> <%= p.Name %> </td>
                    <td> <%= p.LastName %> </td>
                    <td> <%= p.DayOfBirth.ToString("d MMM yyyy") %></td>
                    <td>
                        <button type="submit" value="<%= p.Id %>" name="delete" class="btn btn-xs btn-danger">Delete</button>
                    </td>
                    <td>
                        <a href="/Phones/PhoneList.aspx?ownerId=<%= p.Id %>" class="btn btn-xs btn-outline" role="button">Phones</a>
                    </td>
                </tr>
                <%} %>
            </tbody>
        </table>
        <webcl:Captcha id="captcha" runat="server" />
        <div class="col-sm-4">
            <h3>Insert person</h3>
            <a href="/Persons/Details.aspx" class="btn btn-lg btn-outline" role="button">Create</a>
        </div>
    </div>
</asp:Content>
