using DoAnCuoiKi.Logic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ShoppingCartAction usersShoppingCart = new ShoppingCartAction())
            {
                decimal cartTotal = 0;
                cartTotal = usersShoppingCart.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:n0} VNĐ", cartTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    ShoppingCartTitle.Text = "<h1>Giỏ hàng của bạn đang trống<h1>";
                    UpdateBtn.Visible = false;
                    bnThanhToan.Visible = false;

                }

                Page.Title = "Giỏ Hàng";
            }

        }
        public List<SanPhamDuocChon> GetShoppingCartItems()
        {
            ShoppingCartAction actions = new ShoppingCartAction();
            return actions.GetCartItems();
        }

        public List<SanPhamDuocChon> UpdateCartItems()
        {
            using (ShoppingCartAction usersShoppingCart = new ShoppingCartAction())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartAction.ShoppingCartUpdates[] cartUpdates = new ShoppingCartAction.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt16(rowValues["IDSanPham"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("txtQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CartList.DataBind();
                lblTotal.Text = String.Format("{0:n0} VNĐ", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetCartItems();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
        }

        protected void bnThanhToan_Click(object sender, EventArgs e)
        {
            //Label l = productDetail.FindControl("lblProductID") as Label;
            //TextBox t = productDetail.FindControl("txtQuantity") as TextBox;
            //int quan = Int16.Parse(t.Text);
            //Response.Redirect("~/AddToCart.aspx?productID=" + l.Text + "&quantity=" + quan);
            Response.Redirect("~/PayBill.aspx");
        }

        //protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)
        //{
        //    using (ShoppingCartAction usersShoppingCart = new ShoppingCartAction())
        //    {
        //        Session["payment_amt"] = usersShoppingCart.GetTotal();
        //    }
        //    Response.Redirect("Checkout/CheckoutStart.aspx");
        //}

    }
}