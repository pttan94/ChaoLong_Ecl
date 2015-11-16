using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi
{
    public partial class OrderManager : System.Web.UI.Page
    {
        private WebEntities _db = new WebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }
        protected void BindGridView()
        {
            var dh = (from c in _db.DonHangs select c);
            GridView2.DataSource = dh.ToList();
            GridView2.DataBind();

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void bnThanhToan_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged2(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridView1.EditIndex = e.NewEditIndex;
            //var dh = (from c in _db.DonHangs select c);
            //GridView1.DataSource = dh.ToList();
            //GridView1.DataBind();
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            // TextBox TextBox1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("textBox1");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowEditing2(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            BindGridView();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;

            BindGridView();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)GridView2.DataKeys[e.RowIndex].Value;
            var student = (from i in _db.DonHangs
                           where i.ID == id
                           select i).FirstOrDefault();


            TextBox txt = GridView2.Rows[e.RowIndex].FindControl("txt_TrangThai") as TextBox;
            student.TrangThai = (GridView2.Rows[e.RowIndex].FindControl("txt_TrangThai") as TextBox).Text;

            // Update changes in database table
            Label9.Text = student.TrangThai;
            _db.SaveChanges();

            GridView2.EditIndex = -1;

            BindGridView();
        }

        protected void LkB1_Click(object sender, EventArgs e)
        {
            TextBox txtID = (TextBox)GridView2.FooterRow.FindControl("txt_ID_search");
            TextBox txtEmail = (TextBox)GridView2.FooterRow.FindControl("txt_EmailNguoiMua_search");
            TextBox txtNguoiNhan = (TextBox)GridView2.FooterRow.FindControl("txt_TenNguoiNhan_search");
            TextBox txtSDT = (TextBox)GridView2.FooterRow.FindControl("txt_SDTNguoiNhan_search");
            TextBox txtDiachi = (TextBox)GridView2.FooterRow.FindControl("txt_DiaChiNhan_search");
            TextBox txtTT = (TextBox)GridView2.FooterRow.FindControl("txt_TrangThai_search");
            TextBox txtNgayLap = (TextBox)GridView2.FooterRow.FindControl("txt_NgayLap_search");
            TextBox txtTongTien = (TextBox)GridView2.FooterRow.FindControl("txt_TongTien_search");
            if (txtID.Text != "")
            {
                int id = Convert.ToInt32(txtID.Text);
                var dh = (from i in _db.DonHangs where i.ID == id select i);
                GridView2.DataSource = dh.ToList();
                GridView2.DataBind();
            }
            else if (txtEmail.Text != "")
            {
                string email = txtEmail.Text;
                var dh = (from i in _db.DonHangs where i.EmailNguoiMua.Contains(email) select i);
                GridView2.DataSource = dh.ToList();
                GridView2.DataBind();
            }
            else if (txtNguoiNhan.Text != "")
            {
                string ten = txtNguoiNhan.Text;
                var dh = (from i in _db.DonHangs where i.TenNguoiNhan.Contains(ten) select i);
                GridView2.DataSource = dh.ToList();
                GridView2.DataBind();
            }
            else if (txtSDT.Text != "")
            {
                string sdt = txtSDT.Text;
                var dh = (from i in _db.DonHangs where i.SDTNguoiNhan.Contains(sdt) select i);
                GridView2.DataSource = dh.ToList();
                GridView2.DataBind();
            }
            else if (txtDiachi.Text != "")
            {
                string diachi = txtDiachi.Text;
                var dh = (from i in _db.DonHangs where i.DiaChiNhan.Contains(diachi) select i);
                GridView2.DataSource = dh.ToList();
                GridView2.DataBind();
            }
            else if (txtTT.Text != "")
            {
                string tt = txtTT.Text;
                var dh = (from i in _db.DonHangs where i.TrangThai.Contains(tt) select i);
                GridView2.DataSource = dh.ToList();
                GridView2.DataBind();
            }
            else if (txtNgayLap.Text != "")
            {
                DateTime ngaylap = Convert.ToDateTime(txtNgayLap.Text);
                var dh = (from i in _db.DonHangs where i.NgayLap >= ngaylap select i);
                GridView2.DataSource = dh.ToList();
                GridView2.DataBind();
            }
            else if (txtTongTien.Text != "")
            {
                float tongtien = Convert.ToInt32(txtTongTien.Text);
                var dh = (from i in _db.DonHangs where i.TongTien >= tongtien select i);
                GridView2.DataSource = dh.ToList();
                GridView2.DataBind();
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindGridView();
        }


    }
}