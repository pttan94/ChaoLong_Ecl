<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductList.ascx.cs" Inherits="DoAnCuoiKi.UserControls.ProductList" %>
<div class="filterbox">

    <div class="filteritem">
        <span>Nhà SX</span>
        <asp:DropDownList ID="ProviderList" runat="server" Width="110px" AutoPostBack="true" OnSelectedIndexChanged="ProviderList_SelectedIndexChanged">
        </asp:DropDownList>

    </div>
    <div class="filteritem">
        <span>Mức giá</span>
        <asp:DropDownList ID="Prices" runat="server" Width="110px" AutoPostBack="true" OnSelectedIndexChanged="PriceList_SelectedIndexChanged">
            <asp:ListItem Value="-1">--Tất cả--</asp:ListItem>
            <asp:ListItem Value="0">Dưới 1 triệu</asp:ListItem>
            <asp:ListItem Value="1">Từ 1-3 triệu</asp:ListItem>
            <asp:ListItem Value="2">Từ 3-6 triệu</asp:ListItem>
            <asp:ListItem Value="3">Từ 6-10 triệu</asp:ListItem>
            <asp:ListItem Value="4">Trên 10 triệu</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="filteritem">
        <span>Sắp xếp theo</span>
        <asp:DropDownList ID="PriceOrders" runat="server" Width="110px" AutoPostBack="true" OnSelectedIndexChanged="PriceOrders_SelectedIndexChanged">
            <asp:ListItem Value="0">Giá tăng dần</asp:ListItem>
            <asp:ListItem Value="1">Giá giảm dần</asp:ListItem>

        </asp:DropDownList>
    </div>
</div>
<div id="products">
    <asp:Label ID="lblHeader" runat="server"></asp:Label>
    <div class="row product-list">
        <asp:ListView ID="productList" runat="server" ItemType="DoAnCuoiKi.Models.HienThiSanPham" OnDataBound="productList_DataBound" OnPreRender="productList_PreRender">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
            </EmptyItemTemplate>
            <ItemTemplate>
                <div class="col-xs-6 col-md-3" runat="server">
                    <div class="product-item">
                        <div class="image">
                            <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName= Item.TenSP })%>" title="">
                                <img src="/Catalog/Images/<%#: Item.AnhHienThi %> ">
                            </a>
                            &nbsp;&nbsp;
                        </div>
                        <div class="name">
                            <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName= Item.TenSP })%>"><%#: Item.TenSP %></a>
                        </div>
                        <div class="price">
                            <%#: string.Format("{0:n0}",Convert.ToInt32((Item.GiaMoi))) %> &nbsp; ($/VND/...)
                        </div>
                        <div class="view">
                            <button class="add-to-cart">Thêm vào giỏ</button>
                        </div>
                    </div>

                </div>



            </ItemTemplate>

        </asp:ListView>
    </div>
    <div class="pager">
        <asp:DataPager ID="ProductListPagerCombo" runat="server"
            PagedControlID="productList" PageSize="2">
            <Fields>
                <asp:NextPreviousPagerField FirstPageText="&lt;&lt;" ShowFirstPageButton="false"
                    ShowNextPageButton="false" ShowPreviousPageButton="true" ButtonType="Button" />
                <asp:NumericPagerField ButtonType="Button" />
                <asp:NextPreviousPagerField LastPageText="&gt;&gt;" ShowLastPageButton="false"
                    ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Button" />
            </Fields>
        </asp:DataPager>
    </div>
</div>


