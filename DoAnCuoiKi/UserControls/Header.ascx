<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="DoAnCuoiKi.UserControls.Header" %>
<div class="container-fluid header-container">
    <div class="col-xs-12 col-sm-12 col-md-3 logo-holder">
        <div class="logo">
            <a runat="server" href="~/" title="Home">
                <img runat="server" src="~/Catalog/logo.png" alt="logo.png" title="logo">
            </a>
        </div>
    </div>
    <div class="col-xs-12 col-sm-12 col-md-6 mid-holder">
        <div class="contact-row">
            <div class="phone inline">
                <span class="glyphicon glyphicon-earphone"></span>
                <asp:Label ID="lblPhone" runat="server" Text=" 0988 765 321"></asp:Label>

            </div>
            <div class="mail inline">
                <span class="glyphicon glyphicon-envelope"></span>
                <asp:Label ID="lblEmail" runat="server" Font-Italic="true" Text="support@chaolong.com"></asp:Label>
            </div>
        </div>
        <div class="search-area">
            <div id="search-form">
                <div class="control-group">
                    <input type="hidden" name="type" value="product">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="search-field" placeholder="Tìm kiếm..."></asp:TextBox>

                    <button id="btnGo" runat="server" onServerClick="onBtnGoClick" class="search-button" style="color: white;">
                        <span class="glyphicon glyphicon-search"></span>

                    </button>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xs-12 col-sm-12 col-md-3 cart-holder">
        <div class="cart-row">
            <div id="basket">
                <asp:HyperLink ID="lnkCart" runat="server" NavigateUrl="~/ShoppingCart.aspx">
                    <div class="cart-count">
                        <img runat="server" src="~/Catalog/icon-cart.png" alt="icon-cart.png" title="">
                        <asp:Label ID="lblBadgeCount" CssClass="badge count" runat="server" Text="0"></asp:Label>
                    </div>
                    <div class="cart-total-price">
                        <span>Giỏ Hàng</span>
                        <asp:Label ID="lblValue" runat="server" CssClass="value" Text="&nbsp;0&nbsp;"></asp:Label>
                        <asp:Label ID="lblCurrency" runat="server" CssClass="currency" Text="VND"></asp:Label>
                    </div>
                </asp:HyperLink>
            </div>
        </div>
    </div>

</div>

<SCRIPT type=text/javascript>
    function doClick(buttonName,e)
    {
        var key;

         if(window.event)
              key = window.event.keyCode;     //IE
         else
              key = e.which;     //firefox
    
        if (key == 13)
        {
            //Get the button the user wants to have clicked
            var btn = document.getElementById("btnGo");
            if (btn != null)
            { //If we find the button click it
                btn.click();
                event.keyCode = 0
            }
        }
   }
</SCRIPT>