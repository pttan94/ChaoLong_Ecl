using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCuoiKi.Logic
{
    public class ShoppingCartAction:IDisposable
    {
        public string ShoppingCartId { get; set; }
        public int Quantity { get; set; }
        

        private WebEntities _db = new WebEntities();
        public const string CartSessionKey = "CartId";
        public void AddToCart(int id)
        {
            // Retrieve the product from the database.
            ShoppingCartId = GetCartId();
            var cartItem = _db.SanPhamDuocChons.SingleOrDefault(
            c => c.IDGioHang == ShoppingCartId
            && c.IDSanPham == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.
                cartItem = new SanPhamDuocChon
                {
                    ID = Guid.NewGuid().ToString(),
                    IDSanPham = id,
                    IDGioHang = ShoppingCartId,
                    SanPham = _db.SanPhams.SingleOrDefault(
                    p => p.ID == id),
                    SoLuong = Quantity,
                    NgayTao = DateTime.Now
                };
                _db.SanPhamDuocChons.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,
                // then add one to the quantity.
                cartItem.SoLuong+=Quantity;
            }
            _db.SaveChanges();
        }
        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }
        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] =
                   HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }
        public List<SanPhamDuocChon> GetCartItems()
        {
            ShoppingCartId = GetCartId();
            return _db.SanPhamDuocChons.Where(
            c => c.IDGioHang == ShoppingCartId).ToList();
        }

        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();
            // Multiply product price by quantity of that product to get
            // the current price for each of those products in the cart.
            // Sum all product price totals to get the cart total.
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in _db.SanPhamDuocChons
                               where cartItems.IDGioHang == ShoppingCartId
                               select (int?)cartItems.SoLuong *
                               cartItems.SanPham.GiaMoi).Sum();
            return total ?? decimal.Zero;
        }

        public ShoppingCartAction GetCart(HttpContext context)
        {
            using (var cart = new ShoppingCartAction())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            using (var db = new WebEntities())
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<SanPhamDuocChon> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.SanPham.ID == CartItemUpdates[i].ProductId)
                            {
                                if (CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.IDSanPham);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.IDSanPham, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            using (var _db = new WebEntities())
            {
                try
                {
                    var myItem = (from c in _db.SanPhamDuocChons where c.IDGioHang == removeCartID && c.SanPham.ID == removeProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.SanPhamDuocChons.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {
            using (var _db = new WebEntities())
            {
                try
                {
                    var myItem = (from c in _db.SanPhamDuocChons where c.IDGioHang == updateCartID && c.SanPham.ID == updateProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.SoLuong = quantity;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();
            var cartItems = _db.SanPhamDuocChons.Where(
                c => c.IDGioHang == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                _db.SanPhamDuocChons.Remove(cartItem);
            }
            // Save changes.             
            _db.SaveChanges();
        }

        public int GetCount()
        {
            ShoppingCartId = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in _db.SanPhamDuocChons
                          where cartItems.IDGioHang == ShoppingCartId
                          select (int?)cartItems.SoLuong).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

        public void MigrateCart(string cartId, string userName)
        {
            var shoppingCart = _db.SanPhamDuocChons.Where(c => c.IDGioHang == cartId);
            foreach (SanPhamDuocChon item in shoppingCart)
            {
                item.IDGioHang = userName;
            }
            HttpContext.Current.Session[CartSessionKey] = userName;
            _db.SaveChanges();
        }
    }
}