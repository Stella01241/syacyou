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
    public partial class Purchase_Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_init(object sender, EventArgs e)
        {
            

        }

            protected void Purchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase_Home.aspx");
        }

        protected void Product_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }

     

        protected void repInvoice1_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                DBbase.Product_Delete(cmdArguSid, Account_Sid);
                Response.Redirect("Purchase_Create.aspx");

            }
        }

        protected void Btn_Create_Click(object sender, EventArgs e)
        {
            string querryString = Request.QueryString["Purchase_Number"];
           

            //判斷有幾個不能夠是空值也不能是輸入空白鍵
            if (!string.IsNullOrWhiteSpace(this.txtPurchase.Text) && !string.IsNullOrWhiteSpace(this.txtPurchase_Time.Text) )
            {
                ProductModel model = new ProductModel();
                model.Purchase_Number = this.txtPurchase.Text; 
                model.Shipping_Time = this.txtPurchase_Time.Text;
                


                DataTable IDdt = DBHelper.Purchase_Read(model.Purchase_Number);
                if (IDdt.Rows.Count != 0)
                {
                    this.Label1.Text = "已重複輸入";
                    this.Label1.Visible = true;

                    return;
                }
               DBHelper.Purchase_Create(model);
                this.Label1.Visible = false;
                Response.Write("<script>alert('新增成功');window.location.href='./Purchase_Home.aspx'</script>");


            }
            else
            {
                this.Label1.Text = "單據編號及日期為必填";
                this.Label1.Visible =true;
                return;
            }

        }

        protected void Btn_Canel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase_Home.aspx");
        }
    }
}