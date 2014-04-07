<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="WebClient.PersonList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="styles/style.css"/>
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script type="text/javascript" src="scripts/script.js"></script>
    <title>Web client</title>
</head>
<body onload="init();">
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="accessorSelector" runat="server" AutoPostBack="true">
            <asp:ListItem Text="ORM accessor" Value="orm" />
            <asp:ListItem Text="ADO accessor" Value="ado" />
            <asp:ListItem Text="Directory accessor" Value="dir" />
            <asp:ListItem Text="File accessor" Value="file" />
            <asp:ListItem Text="Memory accessor" Value="mem" />
        </asp:DropDownList>

        <div class="table-responsive">
            <table class="table table-striped">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Name</th>
                  <th>Last name</th>
                  <th>Date of birth</th>
                  <th>Delete</th>
                </tr>
              </thead>
              <tbody runat="server" id="tableBody">                
              </tbody>
            </table>
            <label runat="server" id="elapsedTime"> </label>
         </div>

         <div id='panel'>
            <div class="form-signin">
                <h2 class="form-signin-heading">Person fields</h2>
                <input type="number" class="form-control" placeholder="Id" required="" autofocus="" runat="server" id="idInput"/>
                <input type="text" class="form-control" placeholder="Name" required="" runat="server" id="nameInput"/>
                <input type="text" class="form-control" placeholder="Last Name" required="" runat="server" id="lastNameInput"/>
                <input type="date" class="form-control" placeholder="Day of birth" required="" runat="server" id="dateInput"/>
                <button class="btn btn-lg btn-primary btn-block" type="button" runat="server" onserverclick="InsertClick">Insert person</button>
            </div>
        </div>
        <button type="button" class="btn btn-lg btn-primary" id='click'> Insert </button>
        
    </div>
    </form>
</body>
</html>
