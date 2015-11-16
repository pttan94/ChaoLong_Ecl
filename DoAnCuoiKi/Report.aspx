<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="DoAnCuoiKi.Report" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main0" class="container b_summary">
        <div class="b-summary__head clearfix">
            <h2 class="labeltext">TK DOANH THU </h2>
            <br />

        </div>

        <div>
            <asp:Label ID="Label1" runat="server" Text="Loại báo cáo :"></asp:Label>
            <asp:DropDownList ID="cbxreport" runat="server" Width="200px">
                <asp:ListItem Text="Theo Tháng" Value="0"></asp:ListItem>
                <asp:ListItem Text="Theo Năm" Value="1"></asp:ListItem>
                <asp:ListItem Text="Theo Quý" Value="2"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Báo cáo theo :"></asp:Label>
            <asp:DropDownList ID="cbxSP" runat="server" Width="200px">
                <asp:ListItem Text="Theo Nhóm Sản Phẩm" Value="0"></asp:ListItem>
                <asp:ListItem Text="Theo Sản Phẩm" Value="1"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Lập" OnClick="Button1_Click" Width="54px" />
        </div>
        <br />
        <%--  </div>--%>
        <%--<div class="row">--%>
        <div class="col-xs-4">
            <!-- Set Div As your requirement -->
            <asp:Label ID="Label3" runat="server" Text="Ngày Lập :"></asp:Label>
            &nbsp;
            <asp:Label ID="label4" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp; &nbsp; &nbsp;<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Width="375px"></asp:Calendar>
        </div>

        <div class="cos-xs-8">
            <asp:Chart ID="Chart1" runat="server" Width="652px">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>
    <%--          </div>--%>

    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ExtraContent" runat="server">
</asp:Content>
