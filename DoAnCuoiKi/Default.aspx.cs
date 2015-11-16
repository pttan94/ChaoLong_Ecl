using DoAnCuoiKi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Entity.Core.Objects;

namespace DoAnCuoiKi
{
    public partial class _Default : Page
    {
        WebEntities db = new WebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitGroup();

 
        }

        private void InitGroup()
        {
            ProductListByGroup1.groupName = getGroupName(1);
            ProductListByGroup2.groupName = getGroupName(2);
            ProductListByGroup3.groupName = getGroupName(3);

            ProductListByGroup1.DataBind();
            ProductListByGroup2.DataBind();
            ProductListByGroup3.DataBind();

        }

        private string getGroupName(int ID)
        {
            var result = from g in db.TheLoaiSPs
                         where g.ID == ID
                         select g.TenTL;
            return result.FirstOrDefault().ToString();
            
        }
        //public IQueryable<SanPham> GetProducts(
        //            [QueryString("id")] int? categoryId,
        //            [RouteData] string categoryName)
        //{
        //    var _db = new WebEntities();
        //    IQueryable<SanPham> query = _db.SanPhams;

        //    if (categoryId.HasValue && categoryId > 0)
        //    {
        //        query = query.Where(p => p.ID_DanhMuc == categoryId);
        //    }

        //    if (!String.IsNullOrEmpty(categoryName))
        //    {
        //        query = query.Where(p =>
        //                            String.Compare(p.DanhMucSanPham.TenDM,
        //                            categoryName) == 0);
        //    }
        //    return query;
        //}

        //public ObjectResult<hienthisp_Result> getProductDetail()
        //{
        //    WebEntities db = new WebEntities();

        //    ObjectResult<hienthisp_Result> query = db.hienthisp();

        //    return query;
        //}
    }
}