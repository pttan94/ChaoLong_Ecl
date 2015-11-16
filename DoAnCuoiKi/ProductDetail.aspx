<%@ Page Language="C#" Title="sp" EnableEventValidation="false" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProductDetail.aspx.cs" Inherits="DoAnCuoiKi.ProductDetail" %>


<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <style>
        .carousel-inner > .item > img,
        .carousel-inner > .item > a > img {
            height: 300px;
        }
    </style>
</asp:Content>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:FormView ID="productDetail" runat="server"
        ItemType="DoAnCuoiKi.Models.HienThiSanPham"
        SelectMethod="GetProduct"
        RenderOuterTable="false">

        <ItemTemplate>
            <div class=" row breadcrumb">
                <li>
                    <a href="<%#: GetRouteUrl("ProductsByCategoryRoute", new { categoryName =Item.TenDM.Trim()}) %>">
                        <%#:Item.TenDM %>
                    </a>
                </li>
                <li>
                    <span><%#:Item.TenSP %></span>
                </li>
            </div>

            <div class="row" style="display: flex; padding-left: 0">
                <div class="col-xs-12 col-md-5" style="padding-left: 0">
                    <div class="product-item">
                        <div id="myCarousel" class="carousel slide" data-ride="carousel">
                            <!-- Wrapper for slides -->
                            <div class="carousel-inner" role="listbox">

                                <asp:Repeater runat="server" ID="rptImg" ItemType="System.string"
                                    DataSource='<%# Item.Anhs %>'>
                                    <ItemTemplate>
                                        <div class="item <%# Container.ItemIndex== 0 ? "active" : "" %>">
                                            <img src="/Catalog/Images/<%# Item %>" width="460" height="345">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <!-- Left and right controls -->
                            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>

                </div>
                <div class="col-xs-12 col-md-7" style="background-color: #ededed">
                    <section id="gaming">
                        <div class="grid-list-products">
                            <h2 class="section-title" style="color: #6EC8C7;"><%#: Item.TenSP %></h2>
                        </div>
                    </section>


                    <asp:Label runat="server" ForeColor="Green" Visible='<%# !String.IsNullOrEmpty(Item.TinhTrang) && Item.SLTon>0%>'>
                     <span > (&nbsp;<%#: Item.TinhTrang %>&nbsp;)</span><br />
                    </asp:Label>

                    <asp:Label runat="server" ForeColor="Red" Visible='<%# Item.SLTon<=0%>'>
                     <span > (&nbsp;Hết hàng &nbsp;)</span><br />
                    </asp:Label>



                    <asp:Label runat="server" Visible="<%# Item.HienGiaCu ==true%>">
                     <span style="color:black; font-size:20px;"><del><%#: string.Format("{0:n0}",Convert.ToInt32((Item.GiaCu))) %></del>&nbsp; VNĐ</span><br />
                    </asp:Label>

                    <span style="color: red; font-size: 30px;"><%#: string.Format("{0:n0}",Convert.ToInt32((Item.GiaMoi))) %> &nbsp; VNĐ</span>
                    <br>
                    Số lượng:                  
                         <asp:TextBox ID="txtQuantity" runat="server" type="number" min="1" max="99" Text="1" />
                    <br>
                    <br />
                    <div class="fb-like" data-href="http://localhost:25951/SanPham/&lt;%#:Item.TenSP%&gt;" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
                    <br>
                    <br />
                    <div class="product-item">
                        <div class="view" style="text-align: left;">
                            <asp:Label ID="lblProductID" Visible="false" runat="server" Text="<%# Item.ID %>"></asp:Label>
                            <asp:Button ID="btnAdd" runat="server" CssClass="add-to-cart" OnClick="btnAdd_Click" Text="Mua hàng" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <h2>Thông tin khuyến mãi</h2>
                <%#: Item.KhuyenMai %>
            </div>
            <div class="row">
                <h2>Chính sách Bảo hành</h2>
                <%#: Item.ChinhSachBH %>
            </div>


            <ul class="row tabs" style="padding-top: 20px">
                <li class="tab-link current" data-tab="tab-1">Thông tin Sản Phẩm</li>
                <li class="tab-link" data-tab="tab-2">Thông số kĩ thuật</li>
                <li class="tab-link" data-tab="tab-3">Đánh giá</li>
            </ul>


            <div id="tab-1" class="tab-content current">
                <section>
                    <%#: Item.MoTaSP %>
                </section>
                <br>
            </div>
            <div id="tab-2" class="tab-content">
                <%#: Item.ThongTinSP %>
            </div>
            <div id="tab-3" class="tab-content">
            </div>
            <!--Comments Facebook-->
            <div class="row">
                <h2>Bình luận về sản phẩm</h2>
                <!--<div class="fb-comments" data-href="http://localhost:25951/SanPham/" data-width="100%" data-numposts="5"></div> -->
                <div class="fb-comments" data-href="http://localhost:25951/SanPham/<%#:Item.TenSP%>" data-width="100%" data-numposts="5"></div>
            </div>


            <script>
                $('ul.tabs li').click(function () {
                    var tab_id = $(this).attr('data-tab');

                    $('ul.tabs li').removeClass('current');
                    $('.tab-content').removeClass('current');

                    $(this).addClass('current');
                    $("#" + tab_id).addClass('current');
                })
            </script>

            <!-- Scripts FB comments-->
            <div id="fb-root"></div>
            <script>
                (function (d, s, id) {
                    var js, fjs = d.getElementsByTagName(s)[0];
                    if (d.getElementById(id)) return;
                    js = d.createElement(s); js.id = id;
                    js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.3&appId=1682397368655041";
                    fjs.parentNode.insertBefore(js, fjs);
                }(document, 'script', 'facebook-jssdk'));
            </script>

            <!-- Script FB Like -->
            <script>
                (function (d, s, id) {
                    var js, fjs = d.getElementsByTagName(s)[0];
                    if (d.getElementById(id)) return;
                    js = d.createElement(s); js.id = id;
                    js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.3&appId=1682397368655041";
                    fjs.parentNode.insertBefore(js, fjs);
                }(document, 'script', 'facebook-jssdk'));

            </script>

        </ItemTemplate>
    </asp:FormView>

    <asp:Repeater ID="abc" runat="server"></asp:Repeater>
</asp:Content>
