using DoAnCuoiKi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnCuoiKi.UserControls
{
    public partial class ProductList : System.Web.UI.UserControl
    {
        WebEntities db = new WebEntities();
        string providerName = null;
        float minPrice = -1;
        float maxPrice = -1;
        public string title {get;set;}

        List<float> priceList = new List<float> { 0, 1000000, 3000000, 6000000, 10000000, 1000000000 };
        Boolean PriceOrderAsc = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblHeader.Text = "<h1 class=\"section-title\" name=\"title\">" + title + "</h1>";
                UpdateProviders();
                UpdateProductList();
            }
               

        }

        private void UpdateProviders()
        {
            ProviderList.DataBind();
            ProviderList.Items.Insert(0, new ListItem("--Tất cả--", "0"));
        }

        private void UpdateProductList()
        {
            if (ProviderList.SelectedIndex == 0)
            { providerName = null; }
            else
            {
                providerName = ProviderList.SelectedItem.Text;
            }

            int index = Prices.SelectedIndex;
            if (index > 0)
            {
                minPrice = priceList[index - 1];
                maxPrice = priceList[index];
            }
            else
            {
                minPrice = maxPrice = -1;
            }

            PriceOrderAsc = PriceOrders.SelectedIndex == 0 ? true : false;


            List<HienThiSanPham> currentDatasource = productList.DataSource as List<HienThiSanPham>;
            var result=new List<HienThiSanPham>();
            if (!String.IsNullOrEmpty(providerName))
            {
                result = currentDatasource.Where(p =>
                            String.Compare(p.TenNCC, providerName) == 0).ToList();
            }
            else result = currentDatasource;

            if (minPrice >= 0 && maxPrice >= 0)
            {
                result = result.Where(p =>
                     p.GiaMoi >= minPrice && p.GiaMoi <= maxPrice).ToList();

            }
            if (PriceOrderAsc)
            {
                result = result.OrderBy(p => p.GiaMoi.Value).ToList();
            }
            else
            {
                result = result.OrderByDescending(p => p.GiaMoi.Value).ToList();
            }

            productList.DataSource = result;
            productList.DataBind();      
        }

      
        public void setProviders(List<string> list)
        {
            ProviderList.DataSource = list;

        }
        public void setProductList(IQueryable<HienThiSanPham> listofProducts)
        {
            productList.DataSource = listofProducts.ToList();

        }

        protected void ProviderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProductList();         
        }

        protected void productList_PreRender(object sender, EventArgs e)
        {

            UpdateProductList();  
       
        }

        protected void productList_DataBound(object sender, EventArgs e)
        {
            ProductListPagerCombo.Visible = ProductListPagerCombo.TotalRowCount > ProductListPagerCombo.PageSize;
        }

        protected void PriceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProductList();  
        }

        protected void PriceOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProductList();  
        }

        }
        
    }