<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="DoAnCuoiKi.Search" %>

<%@ Register Src="~/UserControls/ProductList.ascx" TagPrefix="uc" TagName="ProductList" %>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="MainContent">
    <uc:ProductList runat="server" ID="Products" />

</asp:Content>

