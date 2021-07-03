﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase_Create.aspx.cs" Inherits="syacyou.Purchase_Create" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>jQuery UI Dialog - Default functionality</title>
    <script src="Bootstrap/js/bootstrap.js"></script>
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <script src="JQuery/jquery-3.6.0.min.js"></script>
   <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
     <link href="http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" />
      <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
      <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
      <link rel="stylesheet" href="//apps.bdimg.com/libs/jqueryui/1.10.4/css/jquery-ui.min.css">
  <script src="//apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
  <script src="//apps.bdimg.com/libs/jqueryui/1.10.4/jquery-ui.min.js"></script>
  <link rel="stylesheet" href="jqueryui/style.css">

     <style>
             .ui-widget-header,.ui-state-default, ui-button{
 
            background:#b9cd6d;
            border: 1px solid #b9cd6d;
            color: #FFFFFF; 
            font-weight: bold;
 
         }
     </style>
 

  <script>
      $(function () {
          $("#dialog").dialog({
              autoOpen: true,
              show: {
                  effect: "blind",
                  duration: 1000
              },
              hide: {
                  effect: "explode",
                  duration: 1000
              }
          });

          $("#opener").click(function () {
              $("#dialog").dialog("open");
          });
      });
  </script>
</head>
<body>
    <form id="form1" runat="server">
   <div id="dialog" title="Basic dialog">
  <p>哈囉你好</p>
</div>
 
<button id="opener">open</button>
 
 
        <div style="text-align: center">
            <asp:LinkButton ID="Purchase" runat="server" OnClick="Purchase_Click">進貨管理</asp:LinkButton>
            &nbsp &nbsp &nbsp  &nbsp &nbsp
            &nbsp &nbsp
        <asp:LinkButton ID="Product" runat="server" OnClick="Product_Click">商品管理</asp:LinkButton>
        </div>
        單據編號:<asp:TextBox ID="txtPurchase" runat="server"></asp:TextBox></br>
        進貨時間:<asp:TextBox ID="txtPurchase_Time" runat="server" input Type="date"></asp:TextBox></br>
           <div style="text-align: center">      
           </div>
        <asp:Button ID="opener" runat="server" Text="新增商品" OnClick="opener_Click" />
        <table style="width: 80%" class="table table-striped" style="font-size: 18px; border-spacing: 10px" align="center">
            <thead>
                <tr class="tdHeight">
                    <th scope="col">商品編號</th>
                    <th scope="col">商品名稱</th>
                    <th scope="col">單價</th>
                    <th scope="col">數量</th>
                    <th scope="col">小計</th>
                </tr>
            </thead>
            <asp:Repeater ID="repInvoice1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Product_Number") %></td>
                        <td><%# Eval("Product_Name") %></td>
                        <td><%# Eval("Purchase_Price") %></td>
                        <td><%# Eval("Unit_Price") %></td>
                        <td><%# Eval("Product_Quantity") %></td>
                        <td>
                            <asp:Button runat="server" Text="刪除" CommandName="DeleteItem" CommandArgument='<%# Eval("Purchase_Number") %>' OnClientClick="javascript:return confirm('是否刪除此訂單')" /></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
            <asp:Label ID="Label1" runat="server" Text="Err_Msg" Visible="false" ></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Time_show" Visible="false"></asp:Label>
    <asp:Button ID="Btn_Create" runat="server" Text="儲存" OnClick="Btn_Create_Click" />
    <asp:Button ID="Btn_Canel" runat="server" Text="取消" OnClick="Btn_Canel_Click" />        
</div>
    </form>
</body>
</html>
