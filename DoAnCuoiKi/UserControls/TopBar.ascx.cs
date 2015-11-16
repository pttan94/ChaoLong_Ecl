using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi.UserControls
{
    public partial class TopBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("Administrator"))
            {
                adminLink.Visible = true;
            }

        }
        public IQueryable<TheLoaiSP> getProductGroups()
        {
            var _db = new WebEntities();
            IQueryable<TheLoaiSP> query = _db.TheLoaiSPs;
            return query;

        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
          
        }
    }
}