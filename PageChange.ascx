﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageChange.ascx.cs" Inherits="syacyou.PageChange" %>
<div class="PageArea" runat="server" id="changePageArea">
    <a runat="server" class="LinkStyle" id="aLinkFristPage" href="#">首頁</a>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">

    </asp:PlaceHolder>
    <a runat="server" class="LinkStyle" id="aLinkLastPage" href="#">末頁</a>
</div>