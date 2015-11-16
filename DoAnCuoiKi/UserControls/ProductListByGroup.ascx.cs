using DoAnCuoiKi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi.UserControls
{
    public partial class ProductListByGroup : System.Web.UI.UserControl
    {
        WebEntities db = new WebEntities();
        public string groupName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                productList.DataSource = GetProductsByGroup(groupName);
                productList.DataBind();

                lblTitle.Text = string.Format("<h1>{0}</h1>", groupName);

                btnSeemore.NavigateUrl = GetRouteUrl("ProductByGroupRoute", new { GroupName = groupName.Trim() });
            }

            
        }

        public List<HienThiSanPham> GetProductsByGroup(string groupName)
        {
            var result = (from t in db.TheLoaiSPs
                          from p in t.SanPhams
                          from h in db.HinhAnhSanPhams
                          where t.TenTL == groupName  
                                  && p.ID == h.IDSP && h.LaAnhHienThi == true
                          select new HienThiSanPham
                          {
                              ID = p.ID,
                              TenSP = p.TenSP,
                              GiaMoi = p.GiaMoi,
                              GiaCu = p.GiaCu,
                              AnhHienThi = h.HinhAnhURL
                          });
            if (result.Count() > 10)
            {
                result = result.Take(10);
            }
            return result.ToList();
        }
    }
}