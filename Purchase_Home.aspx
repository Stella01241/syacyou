<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase_Home.aspx.cs" Inherits="syacyou.Purchase_Home" %>

<%@ Register Src="~/PageChange.ascx" TagPrefix="uc1" TagName="PageChange" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Bootstrap/js/bootstrap.js"></script>
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <script src="JQuery/jquery-3.6.0.min.js"></script>
    <style>
        .lout {
            float: right;
            display: inline-block;
            margin-top: 10px;
        }

        .Btn_Create {
            margin-right: 120px;
            /*margin-left: 40px;*/
        }

        .auto-style1 {
            height: 29px;
        }

        table.TB_COLLAPSE {
            width: 50%;
            border-collapse: separate;
            margin-left: auto;
            margin-right: auto;
        }

            table.TB_COLLAPSE caption {
                padding: 10px;
                font-size: 24px;
                background-color: #d6d6a5;
            }

            table.TB_COLLAPSE thead th {
                padding: 5px 0px;
                color: #fff;
                background-color: #7D6C46;
            }

            table.TB_COLLAPSE tbody td {
                padding: 5px 0px;
                color: #555;
                text-align: center;
                background-color: #fff;
                border-bottom: 1px solid #915957;
            }
    </style>

</head>
<body>
    <form id="form1" runat="server">
     
  
        <asp:Button ID="LogoutBtn" runat="server" Text="登出"  />

        <div style="text-align: center">
            <asp:LinkButton ID="Purchase" runat="server" OnClick="Purchase_Click">進貨管理</asp:LinkButton>
            &nbsp &nbsp &nbsp  &nbsp &nbsp
            &nbsp &nbsp
        <asp:LinkButton ID="Product" runat="server" OnClick="Product_Click">商品管理</asp:LinkButton>
        </div>
        <div class="col-10 tableArea"></div>
        <h2 style="text-align: center;">進貨單管理</h2>

        <asp:Button ID="Create_Purchase" runat="server" Text="新增" OnClick="Create_Purchase_Click" Style="margin-left: 100px" />

        <table style="width: 80%" class="table table-striped" style="font-size: 18px; border-spacing: 10px" align="center">
            <thead>
                <tr class="tdHeight">
                    <th scope="col">單據編號</th>
                    <th scope="col">貨物種類</th>
                    <th scope="col">進貨數量</th>
                    <th scope="col">預計進貨時間</th>
                    <th scope="col">進貨金額</th>

                </tr>
            </thead>
            <asp:Repeater ID="repInvoice" runat="server" OnItemCommand="repInvoice_ItemCommand">

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Purchase_Number") %></td>
                        <td><%# Eval("Goods_Type") %></td>
                        <td><%# Eval("Purchase_Quantity") %></td>
                        <td><%# Eval("Shipping_Time","{0:yyyy/MM/dd}") %></td>
                        <td><%# Eval("Purchase_Amount") %></td>

                        <td>
                            <asp:Button runat="server" Text="刪除" CommandName="DeleteItem" CommandArgument='<%# Eval("Purchase_Number") %>' OnClientClick="javascript:return confirm('是否刪除此訂單')" /></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div>
            <uc1:PageChange runat="server" ID="PageChange" />
        </div>
         <asp:Button ID="Button3" runat="server" Text="報表匯出" OnClick="Button3_Click" />
    </form>
</body>
</html>
