<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderManager.aspx.cs" Inherits="DoAnCuoiKi.OrderManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main0" class="container">
        <div class="b-summary__head clearfix">
            <h2 class="labeltext">Quản Lí Đơn Hàng</h2>
            <hr />
            </div>
    </div>
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"

         OnRowCancelingEdit="GridView2_RowCancelingEdit" CellPadding="4" ForeColor="#5798CF"

         OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating"

         OnRowDeleting="GridView2_RowDeleting" Width="677px" ShowFooter="True"

         OnSelectedIndexChanging="GridView2_SelectedIndexChanging" OnPageIndexChanging="GridView2_PageIndexChanging">

 

        <Columns>

        <asp:TemplateField>

            <ItemTemplate>

                <asp:LinkButton ID="LB1" runat="server" CommandName="Edit">Edit</asp:LinkButton>

              <%--  <asp:LinkButton ID="LB2" runat="server" CommandName="Delete">Delete</asp:LinkButton>--%>

            </ItemTemplate>

            <EditItemTemplate>

                <asp:LinkButton ID="LB3" runat="server" CommandName="Update">Update</asp:LinkButton>

                <asp:LinkButton ID="LB4" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>

            </EditItemTemplate>

            <FooterTemplate>

                <asp:LinkButton ID="LkB1" runat="server" CommandName="Search" OnClick ="LkB1_Click">Search</asp:LinkButton>

            </FooterTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="ID">

            <ItemTemplate>

                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>

            </ItemTemplate>

            <EditItemTemplate>

                <asp:TextBox ID="txt_ID" runat="server" Text='<%# Eval("ID") %>'></asp:TextBox>

            </EditItemTemplate>

            <FooterTemplate>

                <asp:TextBox ID="txt_ID_search" runat="server"></asp:TextBox>

            </FooterTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="EmailNguoiMua">

            <ItemTemplate>

                <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmailNguoiMua") %>'></asp:Label>

            </ItemTemplate>

            <EditItemTemplate>

                <asp:TextBox ID="txt_EmailNguoiMua" runat="server" Text='<%# Eval("EmailNguoiMua") %>'></asp:TextBox>

            </EditItemTemplate>

            <FooterTemplate>

                <asp:TextBox ID="txt_EmailNguoiMua_search" runat="server"></asp:TextBox>

            </FooterTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="TenNguoiNhan">

            <ItemTemplate>

                <asp:Label ID="Label3" runat="server" Text='<%# Eval("TenNguoiNhan") %>'></asp:Label>

            </ItemTemplate>

            <EditItemTemplate>

                <asp:TextBox ID="txt_TenNguoiNhan" runat="server" Text='<%# Eval("TenNguoiNhan") %>'></asp:TextBox>

            </EditItemTemplate>

            <FooterTemplate>

                <asp:TextBox ID="txt_TenNguoiNhan_search" runat="server"></asp:TextBox>

            </FooterTemplate>

        </asp:TemplateField>

            <asp:TemplateField HeaderText="SDTNguoiNhan">

            <ItemTemplate>

                <asp:Label ID="Label4" runat="server" Text='<%# Eval("SDTNguoiNhan") %>'></asp:Label>

            </ItemTemplate>

            <EditItemTemplate>

                <asp:TextBox ID="txt_SDTNguoiNhan" runat="server" Text='<%# Eval("SDTNguoiNhan") %>'></asp:TextBox>

            </EditItemTemplate>

            <FooterTemplate>

                <asp:TextBox ID="txt_SDTNguoiNhan_search" runat="server"></asp:TextBox>

            </FooterTemplate>

        </asp:TemplateField>

              <asp:TemplateField HeaderText="DiaChiNhan">

            <ItemTemplate>

                <asp:Label ID="Label5" runat="server" Text='<%# Eval("DiaChiNhan") %>'></asp:Label>

            </ItemTemplate>

            <EditItemTemplate>

                <asp:TextBox ID="txt_DiaChiNhan" runat="server" Text='<%# Eval("DiaChiNhan") %>'></asp:TextBox>

            </EditItemTemplate>

            <FooterTemplate>

                <asp:TextBox ID="txt_DiaChiNhan_search" runat="server"></asp:TextBox>

            </FooterTemplate>

        </asp:TemplateField>

            <asp:TemplateField HeaderText="TrangThai">

            <ItemTemplate>

                <asp:Label ID="Label6" runat="server" Text='<%# Eval("TrangThai") %>'></asp:Label>

            </ItemTemplate>

            <EditItemTemplate>

                <asp:TextBox ID="txt_TrangThai" runat="server" Text='<%# Eval("TrangThai") %>'></asp:TextBox>

            </EditItemTemplate>

            <FooterTemplate>

                <asp:TextBox ID="txt_TrangThai_search" runat="server"></asp:TextBox>

            </FooterTemplate>

        </asp:TemplateField>

             <asp:TemplateField HeaderText="NgayLap">

            <ItemTemplate>

                <asp:Label ID="Label7" runat="server" Text='<%# Eval("NgayLap") %>'></asp:Label>

            </ItemTemplate>

            <EditItemTemplate>

                <asp:TextBox ID="txt_NgayLap" runat="server" Text='<%# Eval("NgayLap") %>'></asp:TextBox>

            </EditItemTemplate>

            <FooterTemplate>

                <asp:TextBox ID="txt_NgayLap_search" runat="server"></asp:TextBox>

            </FooterTemplate>

        </asp:TemplateField>

            <asp:TemplateField HeaderText="TongTien">

            <ItemTemplate>

                <asp:Label ID="Label8" runat="server" Text='<%# Eval("TongTien") %>'></asp:Label>

            </ItemTemplate>

            <EditItemTemplate>

                <asp:TextBox ID="txt_TongTien" runat="server" Text='<%# Eval("TongTien") %>'></asp:TextBox>

            </EditItemTemplate>

            <FooterTemplate>

                <asp:TextBox ID="txt_TongTien_search" runat="server"></asp:TextBox>

            </FooterTemplate>

        </asp:TemplateField>

        </Columns>

 

        <HeaderStyle BackColor="#5798CF" Font-Bold="True" ForeColor="White" />       

        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

        <FooterStyle BackColor="#ff9751" />

    </asp:GridView>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ExtraContent" runat="server">
    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
</asp:Content>
