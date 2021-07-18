<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TasksManager.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task Managment</title>
    <link href="~/Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/Site.js"></script>
</head>
<body>
    <form id="form1" runat="server">
      <h1>Task Managment</h1>
        <div class="btn-group homepage">
          <div id="btn_tecnhician" onclick="btn_tecnhician_click();">Technician</div>
          <div id="btn_manager" onclick="btn_manager_click();">Manager</div>
        </div>
    </form>
</body>
</html>
