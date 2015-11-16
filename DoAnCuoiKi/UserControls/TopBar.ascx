<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopBar.ascx.cs" Inherits="DoAnCuoiKi.UserControls.TopBar" %>
<nav class="top-bar navbar navbar-inverse">
                <div class="container">
                    <div class="navbar-header hidden-md hidden-lg hidden-sm">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand hidden-md" href="~/">Cháo Lòng Electronic</a>
                    </div>
                    <div class="collapse navbar-collapse" id="myNavbar">
                        <ul class="nav navbar-nav">
                            <li><a runat="server" id="adminLink" visible="false"
                                href="~/Admin/AdminPage">Admin</a></li>
                            <li><a runat="server" href="~/">Trang Chủ</a></li>
                            <li class="dropdown">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Sản Phẩm <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <asp:Repeater ID="Repeater1" runat="server" ItemType="DoAnCuoiKi.TheLoaiSP"
                                        SelectMethod="getProductGroups">
                                        <ItemTemplate>
                                             <li>
                                                 <a href="<%#: GetRouteUrl("ProductByGroupRoute", new { GroupName =Item.TenTL.Trim()}) %>"><%#: Eval("TenTL")%></a>
                                             </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </li>
                            <li><a runat="server" href="~/Blog">Blog</a></li>
                            <li><a runat="server" href="~/About">Giới Thiệu</a></li>
                            <li><a runat="server" href="~/Contact">Liên hệ</a></li>
                        </ul>

                        <asp:LoginView runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Account/Register"><span class="glyphicon glyphicon-user"></span>&nbsp;Đăng Kí</a></li>
                                <li><a runat="server" href="~/Account/Login"><span class="glyphicon glyphicon-log-in"></span>&nbsp;Đăng Nhập</a></li>
                            </ul>
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Account/Manage" title="Manage your account"><span class="glyphicon glyphicon-user"></span>&nbsp;Chào, <%: Context.User.Identity.GetUserName()  %> !</a></li>
                                <li>
                                    <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Đăng xuất" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" />
                                </li>
                            </ul>
                        </LoggedInTemplate>
                    </asp:LoginView>
                    </div>
                </div>
            </nav>