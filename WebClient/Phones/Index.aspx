<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebClient.Phones.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-responsive">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Number</th>
                    <th>Person id</th>
                    <th>Delete</th>
                    <th>Person</th>
                </tr>
            </thead>
            <tbody>
                <% foreach(var p in Phones){ %>
                <tr>
                    <td> <%= p.Id %> </td>
                    <td> <%= p.Number %> </td>
                    <td> <%= p.PersonId%> </td>
                    <td>
                        <button type="submit" value="<%= p.Id %>" name="delete" class="btn btn-xs btn-danger">Delete</button>
                    </td>
                    <td>
                        <a href="/Persons/Details.aspx?id=<%= p.PersonId %>" class="btn btn-xs btn-outline" role="button">Phones</a>
                    </td>
                </tr>
                <%} %>
            </tbody>
        </table>
        <webcl:Captcha id="captcha" runat="server" />
        <div class="col-sm-4">
            <h3>Insert phone</h3>
            <a href="/Phones/Details.aspx" class="btn btn-lg btn-outline" role="button">Create</a>
        </div>
    </div>
</asp:Content>
