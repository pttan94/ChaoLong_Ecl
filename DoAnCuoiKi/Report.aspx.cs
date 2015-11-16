using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DoAnCuoiKi
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static int GetQuarter(DateTime date)
        {
            if (date.Month >= 4 && date.Month <= 6)
                return 2;
            else if (date.Month >= 7 && date.Month <= 9)
                return 3;
            else if (date.Month >= 10 && date.Month <= 12)
                return 4;
            else
                return 1;

        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Web_ChaoLong;Integrated Security=True");

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            label4.Text = Calendar1.SelectedDate.ToString();
        }
        WebEntities db = new WebEntities();
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (cbxreport.Items.FindByValue("0").Selected == true)
            {
                if (cbxSP.Items.FindByValue("0").Selected == true)
                {
                    DateTime dt = Convert.ToDateTime(label4.Text);
                    string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    DataSet ds;
                    SqlDataAdapter da;

                    conn.Open();
                    da = new SqlDataAdapter("report_DM_thang", conn);
                    //command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add("@thang", SqlDbType.Int).Value = Convert.ToInt32(month);
                    //command.Parameters.Add("@nam", SqlDbType.Int).Value = Convert.ToInt32(year);

                    SqlCommand sql = new SqlCommand("exec report_DM_thang " + Convert.ToInt32(month) + "," + Convert.ToInt32(year), conn);
                    ds = new DataSet();
                    da = new SqlDataAdapter(sql);
                    da.Fill(ds);

                    Chart1.DataSource = ds.Tables[0];
                    //  Chart1.Visible = true;
                    Chart1.Series["Series1"].XValueMember = "TenDM";
                    Chart1.Series["Series1"].YValueMembers = "DoanhThu";
                    Chart1.DataBind();
                    conn.Close();

                }
                if (cbxSP.Items.FindByValue("1").Selected == true)
                {
                    DateTime dt = Convert.ToDateTime(label4.Text);
                    string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    DataSet ds;
                    SqlDataAdapter da;

                    conn.Open();

                    SqlCommand sql = new SqlCommand("exec SP_SP_thang " + Convert.ToInt32(month) + "," + Convert.ToInt32(year), conn);
                    ds = new DataSet();
                    da = new SqlDataAdapter(sql);
                    da.Fill(ds);

                    Chart1.DataSource = ds.Tables[0];
                    //  Chart1.Visible = true;
                    Chart1.Series["Series1"].XValueMember = "TenSP";
                    Chart1.Series["Series1"].YValueMembers = "DoanhThu";
                    Chart1.DataBind();
                    conn.Close();

                }
            }
            else if (cbxreport.Items.FindByValue("1").Selected == true)
            {
                if (cbxSP.Items.FindByValue("0").Selected == true)
                {
                    DateTime dt = Convert.ToDateTime(label4.Text);
                    string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    DataSet ds;
                    SqlDataAdapter da;

                    conn.Open();

                    SqlCommand sql = new SqlCommand("exec sp_nam_DM " + Convert.ToInt32(year), conn);
                    ds = new DataSet();
                    da = new SqlDataAdapter(sql);
                    da.Fill(ds);

                    Chart1.DataSource = ds.Tables[0];
                    //  Chart1.Visible = true;
                    Chart1.Series["Series1"].XValueMember = "TenDM";
                    Chart1.Series["Series1"].YValueMembers = "DoanhThu";
                    Chart1.DataBind();
                    conn.Close();

                }
                if (cbxSP.Items.FindByValue("1").Selected == true)
                {
                    DateTime dt = Convert.ToDateTime(label4.Text);
                    string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    DataSet ds;
                    SqlDataAdapter da;

                    conn.Open();

                    SqlCommand sql = new SqlCommand("exec sp_nam_SP " + Convert.ToInt32(year), conn);
                    ds = new DataSet();
                    da = new SqlDataAdapter(sql);
                    da.Fill(ds);

                    Chart1.DataSource = ds.Tables[0];
                    //  Chart1.Visible = true;
                    Chart1.Series["Series1"].XValueMember = "TenSP";
                    Chart1.Series["Series1"].YValueMembers = "DoanhThu";
                    Chart1.DataBind();
                    conn.Close();
                }
            }
            else if (cbxreport.Items.FindByValue("2").Selected == true)
            {
                if (cbxSP.Items.FindByValue("0").Selected == true)
                {

                    DateTime dt = Convert.ToDateTime(label4.Text);
                    //  string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    int quy = GetQuarter(dt);
                    DataSet ds;
                    SqlDataAdapter da;
                    int x;
                    //x = GetQuarter(dt);
                    //Label5.Text = quy.ToString();
                    conn.Open();

                    SqlCommand sql = new SqlCommand("exec sp_quy_DM " + quy + "," + Convert.ToInt32(year), conn);
                    ds = new DataSet();
                    da = new SqlDataAdapter(sql);
                    da.Fill(ds);

                    Chart1.DataSource = ds.Tables[0];
                    //  Chart1.Visible = true;
                    Chart1.Series["Series1"].XValueMember = "TenDM";
                    Chart1.Series["Series1"].YValueMembers = "DoanhThu";
                    Chart1.DataBind();
                    conn.Close();
                }
                if (cbxSP.Items.FindByValue("1").Selected == true)
                {
                    DateTime dt = Convert.ToDateTime(label4.Text);
                    //  string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    int quy = GetQuarter(dt);
                    DataSet ds;
                    SqlDataAdapter da;

                    conn.Open();

                    SqlCommand sql = new SqlCommand("exec SP_quy_SP " + quy + "," + Convert.ToInt32(year), conn);
                    ds = new DataSet();
                    da = new SqlDataAdapter(sql);
                    da.Fill(ds);

                    Chart1.DataSource = ds.Tables[0];
                    //  Chart1.Visible = true;
                    Chart1.Series["Series1"].XValueMember = "TenSP";
                    Chart1.Series["Series1"].YValueMembers = "DoanhThu";
                    Chart1.DataBind();
                    conn.Close();
                }
            }

        }
    }
}