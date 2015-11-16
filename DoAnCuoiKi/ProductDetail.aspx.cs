using DoAnCuoiKi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi
{
    public partial class ProductDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = Page.RouteData.Values["productName"] == null ? "Chi tiết Sản phẩm" : Page.RouteData.Values["productName"].ToString();


        }
        public IQueryable<HienThiSanPham> GetProduct(
                     [QueryString("id")] int? productId,
                       [RouteData] string productName)
        {
            var _db = new WebEntities();

            var query = from p in _db.SanPhams
                        from h in _db.HinhAnhSanPhams
                        where p.ID == h.IDSP
                        select new HienThiSanPham
                        {
                            ID = p.ID,
                            TenSP = p.TenSP,
                            GiaMoi = p.GiaMoi,
                            GiaCu = p.GiaCu,
                            MoTaSP = p.MotaSP,
                            KhuyenMai = p.KhuyenMai,
                            TenDM = p.DanhMucSanPham.TenDM,
                            TenNCC = p.NhaCungCap.TenNCC,
                            ThongTinSP = p.ThongTinSP,
                            TinhTrang = p.TinhTrangSP,
                            ChinhSachBH = p.ChinhSachBH,
                            HienGiaCu = p.HienThiGiaCu,
                            HienThi = p.HienThi,
                            SLTon = p.SLton,
                            Anhs = p.HinhAnhSanPhams.Select(i => i.HinhAnhURL).ToList(),
                            AnhHienThi = p.HinhAnhSanPhams.Where(i => i.LaAnhHienThi == true).FirstOrDefault().HinhAnhURL.ToString()

                        };
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ID == productId);
            }
            else if (!String.IsNullOrEmpty(productName))
            {
                query = query.Where(p =>
                          String.Compare(p.TenSP, productName) == 0);
            }
            else
            {
                query = null;
            }



            return query;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Label l = productDetail.FindControl("lblProductID") as Label;
            TextBox t = productDetail.FindControl("txtQuantity") as TextBox;
            int quan = Int16.Parse(t.Text);
            Response.Redirect("~/AddToCart.aspx?productID=" + l.Text + "&quantity=" + quan);
        }

        protected void productDetail_DataBound(object sender, EventArgs e)
        {


        }
    }

}