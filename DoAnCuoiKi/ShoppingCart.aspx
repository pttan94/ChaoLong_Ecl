<%@ Page Title="Gio hang" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="DoAnCuoiKi.ShoppingCart" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label id="ShoppingCartTitle" runat="server" CssClass="ContentHead">
        <h1>Giỏ Hàng</h1>
    </asp:Label>
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
                    <asp:TextBox ID="txtQuantity" runat="server" type="number" min="1" max="99" Text="<%#: Item.SoLuong %>"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Thành tiền(VNĐ)">
                <ItemTemplate>
                    <%#: String.Format("{0:n0}",((Convert.ToDouble(Item.SoLuong)) *Convert.ToDouble(Item.SanPham.GiaMoi)))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <table>
        <tr>
            <td>
                <asp:Button ID="UpdateBtn" runat="server" Text="Update"
                    OnClick="UpdateBtn_Click" />
            </td>
        </tr>
    </table>


    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Tổng tiền:"></asp:Label>
            <asp:Label ID="lblTotal" runat="server"
                EnableViewState="false"></asp:Label>
        </strong>
    </div>
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="bnThanhToan"  class="bntthanhtoan"   runat="server" Text="Thanh Toán"
                    OnClick="bnThanhToan_Click" />
            </td>
        </tr>
    </table>    


</asp:Content>

