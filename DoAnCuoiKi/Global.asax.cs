using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using DoAnCuoiKi.Models;
using DoAnCuoiKi.Logic;
using System.Net;

namespace DoAnCuoiKi
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer(new ProductDatabaseInitializer());

            // Add Routes.
            RegisterCustomRoutes(RouteTable.Routes);

            // Create the administrator role and user.
            //RoleAction roleActions = new RoleAction();
            //roleActions.createAdmin();
        }
        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "ProductsByCategoryRoute",
                "DanhMuc/{categoryName}",
                "~/ProductListByCategory.aspx"
            );
            routes.MapPageRoute(
                "ProductByNameRoute",
                "SanPham/{productName}",
                "~/ProductDetail.aspx"
            );
            routes.MapPageRoute(
               "ProductByGroupRoute",
               "NhomSanPham/{groupName}",
               "~/ProductListByGroup.aspx"
           );
            routes.MapPageRoute(
              "ProductSearch",
              "TimKiemSanPham/{keyWord}",
              "~/Search.aspx"
          );
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Response.Write("<h2>Error Page</h2>");

            // Get the exception details
            Exception exc = Server.GetLastError();
            Response.Write("Sorry for the inconvenience that may have been caused to you.");
            Response.Write("<b>Error Message</b><p>" + exc.Message + "</p><br>");

            // Clear the error from the server
            Server.ClearError();

            // Report to Administrator
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string MailBody = "Website user is getting bad experience on you website. Find the details below:<br><br>";
            MailBody = MailBody + "<br><br><b>Error on Page (Target Webpage): </b>" + url;
            MailBody = MailBody + "<br><br><b>Link on Webpage (Source Webpage): </b>" + Request.UrlReferrer;
            MailBody = MailBody + "<br><br><b>Error Message: </b>" + exc.Message;
            MailBody = MailBody + "<br><br><b>Trace Message: </b>" + exc.StackTrace;

            // Other browser based stuffs
            MailBody = MailBody + "<br><br><b>Platform: </b>" + Request.Browser.Platform;
            MailBody = MailBody + "<br><br><b>Browser: </b>" + Request.Browser.Browser;
            MailBody = MailBody + "<br><br><b>Browser Type: </b>" + Request.Browser.Type;
            MailBody = MailBody + "<br><br><b>Browser Version: </b>" + Request.Browser.Version;

            string MailResponse = sendmail("trang.itus@gmail.com", "Bad Experience", MailBody);
            Response.Write("<br><br><b>Note: </b>" + MailResponse.ToString());
        }

        private string sendmail(string ToEmailAdd, string MailSubject, string MailMessageHTMLString)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            message.To.Add(new System.Net.Mail.MailAddress(ToEmailAdd));
            message.From = new System.Net.Mail.MailAddress("chaolongteam@gmail.com");//, "ChaolongElectronic.Net");
            message.Subject = MailSubject;
            message.Body = MailMessageHTMLString;
            message.IsBodyHtml = true;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            client.Port = 587;
            client.Host = "smtp.gmail.com";
            //            System.Net.NetworkCredential nc = new System.Net.NetworkCredential("abhimanyukumarvatsa@itorian.com", "*****");

            System.Net.NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "chaolongteam@gmail.com";
            NetworkCred.Password = "chaolong123";
            client.UseDefaultCredentials = false;
            client.Credentials = NetworkCred;

            try
            {
                client.Send(message);
                return "Automated System success to report this to the Administrator.";
            }
            catch
            {
                return "Automated System not success to report this to the Administrator.";
            }


            //======

        }





    }
}