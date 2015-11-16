<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductListByGroup.aspx.cs" Inherits="DoAnCuoiKi.ProductListByGroup" %>

<%@ Register Src="~/UserControls/ProductList.ascx" TagPrefix="uc" TagName="ProductList" %>


<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ProductList runat="server" ID="Products" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExtraContent" runat="server">
</asp:Content>
