<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DoAnCuoiKi._Default" %>

<%@ Register Src="~/UserControls/ProductListByGroup.ascx" TagPrefix="uc" TagName="ProductListByGroup" %>

<asp:Content ID="Slider" ContentPlaceHolderID="MainContent" runat="server">
    <div id="slider">
        <ul class="slides" style="list-style-type: none">
            <li>
                <a href="#">
                    <img src="Catalog/Slides/slideshow_1.png">
                </a>
            </li>
            <li>
                <a href="#">
                    <img src="Catalog/Slides/slideshow_2.png">
                </a>
            </li>
            <li>
                <a href="#">
                    <img src="Catalog/Slides/slideshow_3.png">
                </a>
            </li>
        </ul>
        <div class="row">
            <div class="col-xs-8 col-xs-offset-4 col-sm-4 col-sm-offset-8 col-md-3 col-md-offset-9">
                <ul class="direction">
                    <li>1</li>
                    <li>2</li>
                    <li>3</li>
                </ul>
            </div>
        </div>
    </div>
    <script>
        var dics = $('ul.direction li');
        var images = $('ul.slides li');
        var lastElem = images.length - 1;
        var target = 0;
        dics.first().addClass('active');
        images.hide().first().show();

        function sliderResponse(target) {
            images.hide().eq(target).fadeIn(300);
            dics.removeClass('active').eq(target).addClass('active');
        }
        dics.click(function () {
            if (!$(this).hasClass('active')) {
                target = $(this).index();
                sliderResponse(target);
                resetTiming();
            }
        });
        function sliderTiming() {
            target = $('ul.direction li.active').index();
            target === lastElem ? target = 0 : target = target + 1;
            sliderResponse(target);
        }
        function resetTiming() {
            clearInterval(timingRun);
            timingRun = setInterval(function () { sliderTiming(); }, 5000);
        }

        $('.next').click(function () {
            target = $('ul.direction li.active').index();
            target === lastElem ? target = 0 : target = target + 1;
            sliderResponse(target);
            resetTiming();
        });
        $('.prev').click(function () {
            target = $('ul.direction li.active').index();
            target === 0 ? target = lastElem : target = target - 1;
            sliderResponse(target);
            resetTiming();
        });
        var timingRun = setInterval(function () { sliderTiming(); }, 5000);

    </script>

</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="ExtraContent" runat="server">
    <uc:ProductListByGroup runat="server" id="ProductListByGroup1" />
    <uc:ProductListByGroup runat="server" id="ProductListByGroup2" />
    <uc:ProductListByGroup runat="server" id="ProductListByGroup3" />
</asp:Content>

