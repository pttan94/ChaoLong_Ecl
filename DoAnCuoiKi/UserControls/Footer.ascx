<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="DoAnCuoiKi.UserControls.Footer" %>
 <footer class="footer-distributed">

                <div class="footer-left">
                    <asp:Label ID="lblShopName" runat="server" Text=" <h3>ChaoLong<span> Electronic</span></h3> "></asp:Label>
                    <p class="footer-links">
                        <a href="#">Trang chủ</a>
                        ·
                    <a href="#">Sản Phẩm</a>
                        ·
                    <a href="#">Blog</a>
                        ·
                    <a href="#">Giới Thiệu</a>
                        ·
                    <a href="#">Liên Hệ</a>
                    </p>

                      <asp:Label ID="lblCopyRight" CssClass="footer-company-name" runat="server" Text="ChaoLong Electronic &copy; 2015 "></asp:Label>
                    
                </div>

                <div class="footer-center">

                    <div>
                        <i class="fa fa-map-marker"></i>

                          <asp:Label ID="lblAddress" runat="server" Text="227, Nguyen Van Cu, Ho Chi Minh City, Vietnam"></asp:Label>
                       
                    </div>

                    <div>
                        <i class="fa fa-phone"></i>
                        <asp:Label ID="lblPhone" runat="server" Text="+1 555 123456"></asp:Label>
                    </div>

                    <div>
                        <i class="fa fa-envelope"></i>
                       
                        <p>
                            <asp:HyperLink ID="lnkEmail" runat="server" NavigateUrl="mailto:support@chaolong.com" Text="support@chaolong.com"></asp:HyperLink>
    

                        </p>
                    </div>

                </div>

                <div class="footer-right">

                    <p class="footer-company-about">
                        <asp:Label ID="lblInfor" runat="server" Text="Thông tin về công ty</br>Sứ mệnh của chúng tôi là nâng cao chất lượng cuộc sống khách hàng.Chúng tôi hiểu rằng sự hợp tác của quý vị có ý nghĩa vô cùng quan trọng với sự thành công của Công ty chúng tôi.Rất mong sẽ được hợp tác cùng quý khách hàng! "></asp:Label>                     
                    </p>

                    <div class="footer-icons">
                        <asp:HyperLink ID="lnkFacebbok" runat="server" NavigateUrl="#"><i class="fa fa-facebook"></i></asp:HyperLink>
                         <asp:HyperLink ID="lnkTwitter" runat="server" NavigateUrl="#"><i class="fa fa-twitter"></i></asp:HyperLink>
                         <asp:HyperLink ID="lnkLinkedin" runat="server" NavigateUrl="#"><i class="fa fa-linkedin"></i></asp:HyperLink>
                         <asp:HyperLink ID="lnkGithub" runat="server" NavigateUrl="#"><i class="fa fa-github"></i></asp:HyperLink>

                    </div>
                </div>
            </footer>