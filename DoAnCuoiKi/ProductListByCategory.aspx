<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductListByCategory.aspx.cs" Inherits="DoAnCuoiKi.ProductList" %>

<%@ Register Src="~/UserControls/ProductList.ascx" TagPrefix="uc" TagName="ProductList" %>


<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ProductList runat="server" id="Products" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExtraContent" runat="server">
</asp:Content>
