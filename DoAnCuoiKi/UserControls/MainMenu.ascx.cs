using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi.UserControls
{
    public partial class MainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<DanhMucSanPham> GetCategories()
        {
            var _db = new WebEntities();
            IQueryable<DanhMucSanPham> query = _db.DanhMucSanPhams;
            return query;
        }
    }
}