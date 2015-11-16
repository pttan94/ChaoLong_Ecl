using DoAnCuoiKi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi
{
    public partial class Search : System.Web.UI.Page
    {
        WebEntities db = new WebEntities();
        string keyword = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            keyword = RouteData.Values["keyWord"] == null ? null : RouteData.Values["keyWord"].ToString();
            if (!IsPostBack)
            {

                Products.title = "Kết quả tìm kiếm" + " (" + GetProductsMatch(keyword).Count() + ")";
              
                Products.setProviders(getProviders());


            }
            Page.Title = "Kết quả tìm kiếm";
            Products.setProductList(GetProductsMatch(keyword));
            

        }

        public IQueryable<HienThiSanPham> GetProductsMatch(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                char[] wordSeparators = new char[] { ',', ';', '.', '!', '?', '-', ' ' };
                string[] words = keyword.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
                string[] paras = new string[5];

                // add the words as stored procedure parameters
                int index = 0;
                for (int i = 0; i <= words.GetUpperBound(0) && index < 5; i++)
                {
                    // ignore short words
                    if (words[i].Length > 2)
                    {
                        paras[index] = words[i];
                        index++;
                    }
                }

                var result = from p in db.TimKiemSanPham(false, paras[0], paras[1], paras[2], paras[3], paras[4])
                             select new HienThiSanPham
                             {
                                 TenSP = p.TenSP,
                                 GiaMoi = p.GiaMoi,
                                 GiaCu = p.GiaCu,
                                 TenNCC=p.TenNCC,
                                 AnhHienThi = p.HinhAnhURL

                             };

                return result.AsQueryable();
            }
            return Enumerable.Empty<HienThiSanPham>().AsQueryable();
            

        }
        public List<string> getProviders()
        {
            var result = from p in db.NhaCungCaps
                         select p.TenNCC;
            return result.ToList();

        }
    }
}