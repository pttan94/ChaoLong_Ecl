<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="DoAnCuoiKi.UserControls.MainMenu" %>
<div class="col-xs-12 col-sm-4 col-md-3 sidemenu-holder">
    <div class="side-menu">
        <div class="head">
            <span class="glyphicon glyphicon-list"></span>
            Danh mục sản phẩm
        </div>
        <nav role="navigation">
            <ul class="nav">
                <asp:ListView ID="categoryList"
                    ItemType="DoAnCuoiKi.DanhMucSanPham"
                    runat="server"
                    SelectMethod="GetCategories">
                    <ItemTemplate>
                        <li runat="server">
                            <a href="<%#: GetRouteUrl("ProductsByCategoryRoute", new {categoryName = Item.TenDM.Trim()})%>" class="dropdown-toggle  ">
                                <%#: Item.TenDM%>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </ul>
        </nav>
    </div>

    <div class="boxhohokythuat">
        <ul>
            <li>
                <div class="avatar-hotrokt">
                    <a href="ymsgr:sendim?chaolong&amp;m=Chào bạn, tôi muốn tư vấn kinh doanh" title="Chát cùng Thanh Thảo">
                        <img alt="Thanh Thảo" src="https://lh3.googleusercontent.com/-nHXBrWAsbSU/VBvC_qf9qdI/AAAAAAAAKMc/Zk9xWzFEuhA/s0/0001455718_w76.png">
                    </a>
                </div>
                <div class="info-hotrokt">
                    <p>Tư vấn - <span>Thanh Thảo</span></p>
                    <p>Call: 0972.123.456</p>
                    <p>ChaoLong1@gmail.com</p>
                    <p>
                        <a class="mar-right" href="skype:thaontt306?chat" title="Chát cùng Thanh Thảo">
                            <img alt="skype" src="https://lh5.googleusercontent.com/-TjigBkH9RYo/U8pYXI3KOwI/AAAAAAAAImc/2pnj_qp2Xrw/s0/skype-icon.png" style="float: left; margin-right: 10px;">
                        </a>
                        <a href="ymsgr:sendim?chaolong&amp;m=Chào bạn, tôi muốn tư vấn về Thiết kế Web">
                            <img alt="yh" border="0" src="http://opi.yahoo.com/online?u=chaolong&amp;m=g&amp;t=1&amp;l=us">
                        </a>
                    </p>
                </div>
            </li>
            <li>
                <div class="avatar-hotrokt">
                    <a href="ymsgr:sendim?chaolong&amp;m=Chào bạn, tôi muốn tư vấn kỹ thuật" title="Chát cùng Trọng Tâm">
                        <img alt="Trọng Tâm" src="https://lh3.googleusercontent.com/-nHXBrWAsbSU/VBvC_qf9qdI/AAAAAAAAKMc/Zk9xWzFEuhA/s0/0001455718_w76.png">
                    </a>
                </div>
                <div class="info-hotrokt">
                    <p>Kỹ thuật - <span>Trọng Tâm</span></p>
                    <p>Call: 0972.123.457</p>
                    <p>ChaoLong2@gmail.com</p>
                    <p>
                        <a class="mar-right" href="skype:vutam664?chat">
                            <img alt="skype" src="https://lh5.googleusercontent.com/-TjigBkH9RYo/U8pYXI3KOwI/AAAAAAAAImc/2pnj_qp2Xrw/s0/skype-icon.png" style="float: left; margin-right: 10px;">
                        </a><a href="ymsgr:sendim?chaolong&amp;m=Chào bạn, tôi muốn nhờ bạn giúp về lỗi kỹ thuật...">
                            <img alt="yh" border="0" src="http://opi.yahoo.com/online?u=chaolong&amp;m=g&amp;t=1&amp;l=us"></a>
                    </p>
                </div>
            </li>
            <li>
                <div class="avatar-hotrokt">
                    <a href="ymsgr:sendim?chaolong&amp;m=Chào bạn, tôi muốn tư vấn kinh doanh...">
                        <img alt="Thảo Trang" src="https://lh3.googleusercontent.com/-nHXBrWAsbSU/VBvC_qf9qdI/AAAAAAAAKMc/Zk9xWzFEuhA/s0/0001455718_w76.png">
                    </a>
                </div>
                <div class="info-hotrokt">
                    <p>Kinh doanh - <span>Thảo Trang</span></p>
                    <p>Call: 0972.123.457</p>
                    <p>ChaoLong3@gmail.com</p>
                    <p>
                        <a class="mar-right" href="skype:trang.pio?chat">
                            <img alt="skype" src="https://lh5.googleusercontent.com/-TjigBkH9RYo/U8pYXI3KOwI/AAAAAAAAImc/2pnj_qp2Xrw/s0/skype-icon.png" style="float: left; margin-right: 10px;">
                        </a>
                        <a href="ymsgr:sendim?chaolong&amp;m=Chào bạn, tôi muốn tư vấn kinh doanh">
                            <img alt="Thảo Trang" border="0" src="http://opi.yahoo.com/online?u=chaolong&amp;m=g&amp;t=1&amp;l=us">
                        </a>
                    </p>
                </div>
            </li>
        </ul>
    </div>
</div>
