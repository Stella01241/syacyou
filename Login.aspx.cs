using syacyou.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace syacyou
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
        protected void Loginn_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtAccount.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                this.ErrorMsg.Text = "請輸入帳號密碼";
                this.ErrorMsg.Visible = true;
                return;
            }
            if (LoginHelper.TryLogin(txtAccount.Text, txtPassword.Text))
            {
                Response.Redirect("Purchase_Home.aspx");
            }
            else
            {
                this.ErrorMsg.Text = "帳號或密碼錯誤";
                this.ErrorMsg.Visible = true;
                return;
            }


        }
    }

}