using DoAnCuoiKi.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;


namespace DoAnCuoiKi
{
    public partial class PayBill : System.Web.UI.Page
    {
        public decimal total;
        public string ShoppingCartId { get; set; }
        public int Quantity { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (ShoppingCartAction usersShoppingCart = new ShoppingCartAction())
            {
                decimal cartTotal = 0;
                cartTotal = usersShoppingCart.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    //  lblTotal.Text = String.Format("{0:n0} VNĐ", cartTotal);
                    // Label total = cartTotal;
                    lblTotal.Text = Convert.ToString(cartTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    //ShoppingCartTitle.Text = "<h1>Giỏ hàng của bạn đang trống<h1>";
                    //UpdateBtn.Visible = false;

                }


            }
        }
        private WebEntities _db = new WebEntities();
        public const string CartSessionKey = "CartId";
        //   ShoppingCartAction actions = new ShoppingCartAction();
        public List<SanPhamDuocChon> GetShoppingCartItems()
        {
            ShoppingCartAction actions = new ShoppingCartAction();
            return actions.GetCartItems();
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
        public void InsertOrder()
        {

            string email = "thaontt94@gmail.com";
            string status = "Đang xử lí";
            var OrderItem = new DonHang();

            OrderItem.EmailNguoiMua = email;
            OrderItem.TenNguoiNhan = txtTen.Text;
            OrderItem.SDTNguoiNhan = txtSDT.Text;
            OrderItem.DiaChiNhan = txtDiaChi.Text;
            OrderItem.TrangThai = status;
            OrderItem.NgayLap = DateTime.Now;
            OrderItem.TongTien = Convert.ToDouble(lblTotal.Text);

            _db.DonHangs.Add(OrderItem);
            _db.SaveChanges();

        }
        public void InsertDetail()
        {

            var madh = (from madhitem in _db.DonHangs orderby madhitem.ID descending select madhitem.ID).First();
            //  Label2.Text = madh.ToString();
            //  madh.First();
            var CTDH = new ChiTietDonHang();
            for (int i = 0; i < CartList.Rows.Count; i++)
            {
                CTDH.ID_DH = madh;
                CTDH.ID_SP = Convert.ToInt32(CartList.Rows[i].Cells[0].Text);
                CTDH.DonGia = Convert.ToDouble(CartList.Rows[i].Cells[2].Text);

                TextBox quantityTextBox = new TextBox();
                quantityTextBox = (TextBox)CartList.Rows[i].FindControl("txtQuantity");
                CTDH.SoLuongMua = Convert.ToInt16(quantityTextBox.Text.ToString());
                _db.ChiTietDonHangs.Add(CTDH);

                var myItem = (from c in _db.SanPhams where c.ID == CTDH.ID_SP select c).SingleOrDefault();
                myItem.SLton = myItem.SLton - CTDH.SoLuongMua;

                _db.SaveChanges();
            }

        }
        public void EmptyCart()
        {
            ShoppingCartAction usersShoppingCart = new ShoppingCartAction();
            usersShoppingCart.EmptyCart();
        }

        protected void SendMail()
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("chaolongteam@gmail.com");
            msg.To.Add("trang.itus@gmail.com");
            msg.Subject = "ChaoLong Electronic";

            var madh = (from madhitem in _db.DonHangs orderby madhitem.ID descending select madhitem.ID).First();
            msg.Body = "<strong>ChaoLong Electronic đã nhận đơn hàng " + madh.ToString() + "</strong><br/><br/>Kính chào quý khách,<br/><br/>Cám ơn quý khách đã mua sắm tại ChaoLong Electronic,<br/><br>ChaoLong Electronic vừa nhận được đơn hàng của quý khách và đang tiến hành xác nhận thông tin. Mã đơn hàng của quý khách là: " + madh.ToString() + "<br/><br/>ChaoLong Electronic trân trọng cảm ơn!<br/>";
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            System.Net.NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "chaolongteam@gmail.com";
            NetworkCred.Password = "chaolong123";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Send(msg);

        }
        protected void bnThanhToan_Click(object sender, EventArgs e)
        {

            InsertOrder();
            InsertDetail();
            SendMail();

            //Label1.Text = " ĐƠN HÀNG ĐÃ ĐƯỢC ĐẶT THÀNH CÔNG ! VUI LÒNG KIỂM TRA MAIL ĐỂ   ";
            EmptyCart();
            CartList.DataSource = null;
            CartList.DataBind();


            formInfo.Visible = false;
            divButton.Visible = false;

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông báo", "alert('Đơn hàng đã được đặt thành công! Vui lòng kiểm tra email của bạn')", true);
            //Response.Redirect("Default.aspx");
            
            Response.Write("<script>alert('Đơn hàng đã được đặt thành công! Vui lòng kiểm tra email của bạn')</script>");
            Response.Write("<script>window.location.href='./';</script>");

        }
    }
}