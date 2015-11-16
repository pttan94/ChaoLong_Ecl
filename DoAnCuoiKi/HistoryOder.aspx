<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoryOder.aspx.cs" Inherits="DoAnCuoiKi.HistoryOder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvHistoryOder" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="ID" Height="130px" Width="842px">
        <Columns>
            <asp:BoundField DataField="ID_DH" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="anhHienThi" HeaderText="EmailNguoiMua" SortExpression="EmailNguoiMua" />
            <asp:BoundField DataField="TenSP" HeaderText="TenNguoiNhan" SortExpression="TenNguoiNhan" />
            <asp:BoundField DataField="SDTNguoiNhan" HeaderText="SDTNguoiNhan" SortExpression="SDTNguoiNhan" />
            <asp:BoundField DataField="DiaChiNhan" HeaderText="DiaChiNhan" SortExpression="DiaChiNhan" />
            <asp:BoundField DataField="TrangThai" HeaderText="TrangThai" SortExpression="TrangThai" />
            <asp:BoundField DataField="NgayLap" HeaderText="NgayLap" SortExpression="NgayLap" />
            <asp:BoundField DataField="TongTien" HeaderText="TongTien" SortExpression="TongTien" />
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



