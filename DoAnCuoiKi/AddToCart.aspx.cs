﻿using DoAnCuoiKi.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString[ "productID"];
            int quantity = Int16.Parse( Request.QueryString["quantity"]);
             int productId;
             if (! String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
             {
                 using (ShoppingCartAction usersShoppingCart = new ShoppingCartAction())
                 {
                     usersShoppingCart.Quantity = quantity;
                      usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                 }
             }
             else{
                 Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.");
                 throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
             }
             Response.Redirect("ShoppingCart.aspx");
          }
        }

}
