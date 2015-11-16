using DoAnCuoiKi.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi.UserControls
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtSearch.Attributes.Add("onKeyPress", "doClick('"+btnGo.ClientID+"',event)");
            
            }


        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (ShoppingCartAction usersShoppingCart = new ShoppingCartAction())
            {
                lblBadgeCount.Text = usersShoppingCart.GetCount().ToString();
            }
        }
        protected void onBtnGoClick(object sender, EventArgs e)
        {
            string searchStr = txtSearch.Text;
            if (!String.IsNullOrEmpty(searchStr))
            {
                Response.Redirect(GetRouteUrl("ProductSearch", new { keyWord = searchStr }));
                
            }
        
        
        }
    }
}