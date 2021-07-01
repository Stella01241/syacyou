<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="syacyou.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <script src="Bootstrap/js/bootstrap.js"></script>
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <script src="JQuery/jquery-3.6.0.min.js"></script>
    <style>

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="LoginArea">
         <div style="width: 100%">
          
            <div class="LoginArea">
           
            </div>
          <div style="text-align: center;">
           <p>帳號
                <asp:TextBox ID="txtAccount" runat="server" ></asp:TextBox>
           </p>
           <p>密碼
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required ="required" aria-required="true"></asp:TextBox>
           </p> 

         
        <asp:Button ID="Loginn" runat="server" Text="登入" OnClick="Loginn_Click"  /><br/>
        <asp:Label ID="ErrorMsg" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    </div>   
        </div>
       </div>
    </form>
</body>
</html>
