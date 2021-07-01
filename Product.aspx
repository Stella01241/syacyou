<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="syacyou.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        h1 {
            color: brown;
            margin-left: auto;
            margin-right: auto;
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
        <div style="text-align: center;">
            <asp:LinkButton ID="Purchase" runat="server" OnClick="Purchase_Click">進貨管理</asp:LinkButton>&nbsp &nbsp &nbsp  &nbsp &nbsp
            &nbsp &nbsp
        <asp:LinkButton ID="Product1" runat="server" OnClick="Product1_Click">商品管理</asp:LinkButton><br />

        </div>

        <h1 style="text-align: center;">商品管理</h1>

        <h3 style="text-align: center;">文具用品</h3>
        <table class="TB_COLLAPSE">
            <thead>
                <tr>
                    <th>商品編號</th>
                    <th>種類</th>
                    <th>商品名稱</th>
                    <th>單價</th>
                </tr>
            </thead>
            <tr>
                <td>SD-2021621</td>
                <td>A1</td>
                <td>水性原子筆</td>
                <td>100 </td>
            </tr>
            <tr>
                <td>SD-2021622</td>
                <td>A2</td>
                <td>油性原子筆</td>
                <td>150 </td>
            </tr>
            <tr>
                <td>SD-2021623</td>
                <td>B1</td>
                <td>剪刀</td>
                <td>130 </td>
            </tr>
            <tr>
                <td>SD-2021624</td>
                <td>C1</td>
                <td>美工刀</td>
                <td>200 </td>
            </tr>
            <tr>
                <td>SD-2021625</td>
                <td>D1</td>
                <td>螢光筆</td>
                <td>250 </td>
            </tr>
            <tr>
                <td>SD-2021626</td>
                <td>E1</td>
                <td>資料夾</td>
                <td>150 </td>
            </tr>
            <tr>
                <td>SD-2021627</td>
                <td>F1</td>
                <td>修正液</td>
                <td>120 </td>
            </tr>

        </table>

    </form>
</body>
</html>
