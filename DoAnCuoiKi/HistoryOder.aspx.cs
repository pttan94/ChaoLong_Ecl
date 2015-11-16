using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi
{
    public partial class HistoryOder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //var db = new WebEntities();

            //gvHistoryOder.DataSource = db.DonHangs.ToList();
            //gvHistoryOder.DataBind(); 
            Page.Title = "Lịch sử đặt hàng";
        }

        //public IQueryable<HienThiLichSu> getHistoyOder([QueryString("email")] string? emailID, [RouteData] string productName)
        //{
        //    var _db = new WebEntities();

        //    var query = from sp in _db.SanPhams
        //                from h in _db.HinhAnhSanPhams
        //                from dh in _db.DonHangs
        //                from tl in _db.TheLoaiSPs
        //                from ct in _db.ChiTietDonHangs

        //                where ((sp.ID == ct.ID_SP) && (sp.ID == h.IDSP) && (sp.ID == tl.ID) && (sp.ID == ct.DonGia))

        //                select new HienThiLichSu
        //                {
        //                    ID = ct.ID_DH,
        //                    anhHienThi = sp.HinhAnhSanPhams.Where(i => i.LaAnhHienThi == true).FirstOrDefault().HinhAnhURL.ToString(),
        //                    tenSP = sp.TenSP,
        //                    tenTheLoai = tl.TenTL,
        //                    emailNguoiMua = dh.EmailNguoiMua,
        //                    donGia = ct.DonGia,
        //                    thanhTien = dh.TongTien
        //                };
        //    //if (emailID.HasValue && emailID != null)
        //    //{
        //    //    query = query.Where(dh => String.Compare(dh.emailNguoiMua, emailID) == 0);
        //    //}
        //    //else if (!String.IsNullOrEmpty(emailID))
        //    //{
        //    //    query = query.Where(dh => String.Compare(dh.emailNguoiMua, emailID) ==0);
        //    //}

        //    return query;
        //}

    }
}