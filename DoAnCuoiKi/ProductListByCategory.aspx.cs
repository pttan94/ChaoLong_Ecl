using DoAnCuoiKi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi
{
    public partial class ProductList : System.Web.UI.Page
    {
        WebEntities db = new WebEntities();
        string categoryName = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryName = RouteData.Values["categoryName"] == null ? null : RouteData.Values["categoryName"].ToString();
            if (!IsPostBack)
            {
              
                Products.title = categoryName;
                Page.Title = categoryName;
                Products.setProviders(GetProviderByCategory(categoryName));

              
            }
            Products.setProductList(GetProductsByCategory(categoryName));
           
        
        }

        public IQueryable<HienThiSanPham> GetProductsByCategory(string catName)
        {
            var result = (from p in db.SanPhams
                          from d in db.DanhMucSanPhams
                          from c in db.NhaCungCaps
                          from h in db.HinhAnhSanPhams
                          where p.ID_DanhMuc == d.ID && p.ID_NhaCC == c.ID
                                  && p.ID == h.IDSP && h.LaAnhHienThi == true
                          select new HienThiSanPham
                         {
                             ID = p.ID,
                             TenSP = p.TenSP,
                             GiaMoi = p.GiaMoi,
                             GiaCu = p.GiaCu,
                             TenDM = d.TenDM,
                             TenNCC = c.TenNCC,
                             AnhHienThi = h.HinhAnhURL
                         });


            if (!String.IsNullOrEmpty(catName))
            {
                result = result.Where(p =>
                          String.Compare(p.TenDM, catName) == 0);
            }

            return result;

        }
        public List<string> GetProviderByCategory(string catName)
        {
            var result = (from p in db.SanPhams
                          from d in db.DanhMucSanPhams
                          from c in db.NhaCungCaps
                          where p.ID_DanhMuc == d.ID && p.ID_NhaCC == c.ID
                                  && d.TenDM==catName
                          select c.TenNCC);

            return result.ToList();
        }
    }
}