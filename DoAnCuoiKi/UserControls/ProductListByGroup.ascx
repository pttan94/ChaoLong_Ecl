<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductListByGroup.ascx.cs" Inherits="DoAnCuoiKi.UserControls.ProductListByGroup" %>

<div id="hot-product" class="container">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
    <div class="row product-list">

        <asp:ListView ID="productList" runat="server" ItemType="DoAnCuoiKi.Models.HienThiSanPham">
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
                <div class="col-xs-6 col-md-5ths" runat="server">
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
    <div class="row see-more">
                <div class="col-xs-6 col-xs-offset-3 col-md-3 col-md-offset-8 more">
                    <asp:HyperLink ID="btnSeemore" runat="server">
                        <div class="more-button">...Xem thêm</div>
                    </asp:HyperLink>
                </div>
     </div>
</div>
