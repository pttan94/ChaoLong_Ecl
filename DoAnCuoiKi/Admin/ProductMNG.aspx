<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ProductMNG.aspx.cs" Inherits="DoAnCuoiKi.AdminSection.ProductMNG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridProducts" AutoGenerateColumns="False" runat="server"
        CellPadding="40" ForeColor="#333333" GridLines="None" AllowSorting="true"
        ItemType="DoAnCuoiKi.SanPham" Height="201px" Width="893px">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="TenSP" HeaderText="Tên sản phẩm" />
            <asp:BoundField DataField="GiaMoi" HeaderText="Gía mới(VNĐ)" DataFormatString="{0:n0}" />
            <asp:BoundField DataField="GiaCu" HeaderText="Gía cũ(VNĐ)" DataFormatString="{0:n0}" />
            <asp:BoundField DataField="TinhTrangSP" HeaderText="Tình trạng" />
            <asp:BoundField DataField="SLton" HeaderText="Số lượng tồn" />

            <asp:BoundField DataField="NhaCungCap.TenNCC" HeaderText="Nhà cung cấp" />
            <asp:BoundField DataField="HienThi" HeaderText="Hiển thị" />

        </Columns>

        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</asp:Content>
