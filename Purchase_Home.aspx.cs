using syacyou.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace syacyou
{
    public partial class Purchase_Home : System.Web.UI.Page
    {     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LoginHelper.HasLogined())
            {
                Response.Write("<script>alert('請先登入');window.location.href='./Login.aspx'</script>");
            }
            string currentPage = Request.QueryString["Page"];
            int total;
            if (string.IsNullOrWhiteSpace(currentPage))
            {
                currentPage = "1";
            }

            if(!IsPostBack)
            {
                this.repInvoice.DataSource = DBHelper.PurchaseDataTable(out total,Convert.ToInt32(currentPage));
                PageChange.TotalSize = total;
                this.repInvoice.DataBind();
            }



        }

        protected void Purchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase_Home.aspx");
        }

        protected void Product_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            LoginHelper.Logout();
            Response.Redirect("Login.aspx");
        }

        protected void Create_Purchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase_Create.aspx");
        }

        protected void Dtn_Purchase_Click(object sender, EventArgs e)
        {

        }

        protected void repInvoice_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //抓取按鈕CommandName的值
            string cmdName = e.CommandName;
            //抓取按鈕CommandArgument的值,
            string cmdArguSid = e.CommandArgument.ToString();
            DBHelper DBbase = new DBHelper();

            if ("DeleteItem" == cmdName)
            {
                //取得session
                LoginInfo loginInfo = HttpContext.Current.Session["IsLogined"] as LoginInfo;
                //取得session的使用者名稱
                int Account_Sid = loginInfo.Account_Sid;

                //把值放進Method進行刪除
                DBbase.Purchase_Delete(cmdArguSid, Account_Sid);
                Response.Redirect("Purchase_Home.aspx");
               
            }
        
        }


    
    }
}