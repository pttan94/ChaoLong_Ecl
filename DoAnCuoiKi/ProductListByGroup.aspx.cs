using DoAnCuoiKi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi
{
    public partial class ProductListByGroup : System.Web.UI.Page
    {
        WebEntities db = new WebEntities();
        public string groupName = null;
   
        protected void Page_Load(object sender, EventArgs e)
        {
         
            groupName = Page.RouteData.Values["GroupName"] == null ? null : Page.RouteData.Values["GroupName"].ToString();
            if (!IsPostBack)
            {
                Page.Title = groupName;
                Products.title = groupName;
                Products.setProviders(getProviders());
            }
            Products.setProductList(GetProductsByGroup(groupName));
        }

        public IQueryable<HienThiSanPham> GetProductsByGroup(string groupName)
        {
            var result = (from g in db.TheLoaiSPs
                          from p in g.SanPhams
                          from c in db.NhaCungCaps
                          from h in db.HinhAnhSanPhams
                          where p.ID_NhaCC == c.ID
                                  && p.ID == h.IDSP && h.LaAnhHienThi == true
                          select new HienThiSanPham
                          {
                              ID = p.ID,
                              TenSP = p.TenSP,
                              GiaMoi = p.GiaMoi,
                              GiaCu = p.GiaCu,
                              TenNCC = c.TenNCC,
                              TenTheLoai = g.TenTL,
                              AnhHienThi = h.HinhAnhURL
                          });


            if (!String.IsNullOrEmpty(groupName))
            {
                result = result.Where(p =>
                          p.TenTheLoai == groupName);
            }

            return result;

        }

        public List<string> getProviders()
        {
            var result = from p in db.NhaCungCaps
                         select p.TenNCC;
            return result.ToList();

        }
    }
}