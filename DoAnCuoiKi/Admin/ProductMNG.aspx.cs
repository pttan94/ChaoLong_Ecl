using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi.AdminSection
{
    public partial class ProductMNG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new WebEntities();
            GridProducts.DataSource = db.SanPhams.ToList();
            GridProducts.DataBind(); 

        }
    }
}