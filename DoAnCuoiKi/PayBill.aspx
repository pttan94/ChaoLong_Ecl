<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PayBill.aspx.cs" Inherits="DoAnCuoiKi.PayBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formInfo" class="container b_summary" runat="server">
        <div class="b-summary__head clearfix">
            <h2 class="labeltext">TT KHÁCH HÀNG </h2>
        </div>
        <div>
            <label for="HoTen" class="labelemail">Họ và tên:</label>
        </div>

        <div class="form-group">
            <div class="controls">
                <asp:TextBox class="form-control input-lg" ID="txtTen" runat="server"></asp:TextBox>
            </div>
        </div>
        <div>
            <label for="HoTen" class="labelemail">Số Điện Thoại:</label>
        </div>

        <div class="form-group">
            <div class="controls">
                <asp:TextBox class="form-control input-lg" ID="txtSDT" runat="server"></asp:TextBox>
            </div>
        </div>
        <div>
            <label for="HoTen" class="labelemail">Địa Chỉ Nhận Hàng:</label>
        </div>

        <div class="form-group">
            <div class="controls">
                <asp:TextBox class="form-control input-lg" ID="txtDiaChi" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="b-summary__head clearfix">
            <h2 class="labeltext">Giỏ Hàng </h2>
        </div>
        <%--  <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>--%>
        <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False"
            ShowFooter="false" GridLines="Vertical" CellPadding="4"
            ItemType="DoAnCuoiKi.SanPhamDuocChon"
            SelectMethod="GetShoppingCartItems"
            CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="IDSanPham" HeaderText="ID" />
                <asp:BoundField DataField="SanPham.TenSP" HeaderText="Tên SP" />
                <asp:BoundField DataField="SanPham.GiaMoi" HeaderText="Đơn giá(VNĐ)"
                    DataFormatString="{0:n0}" />
                <asp:TemplateField HeaderText="Số lượng">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" type="number" min="1" max="99" Text="<%#: Item.SoLuong %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thành tiền(VNĐ)">
                    <ItemTemplate>
                        <%#: String.Format("{0:n0}",((Convert.ToDouble(Item.SoLuong)) *Convert.ToDouble(Item.SanPham.GiaMoi)))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
        <div>
            <strong>
                <asp:Label ID="LabelTotalText" runat="server" Text="Tổng tiền:"></asp:Label>
                <asp:Label ID="lblTotal" runat="server"
                    EnableViewState="false"></asp:Label>
            </strong>
        </div>
        <br />

    </div>
    <br />
    <div id="divButton" runat="server" class="container" style="float:left">
        <asp:Button class="bntthanhtoan" ID="bnThanhToan" runat="server" Text="Thanh Toán" OnClick="bnThanhToan_Click" />
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ExtraContent" runat="server">
</asp:Content>
