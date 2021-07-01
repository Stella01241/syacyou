using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace syacyou
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Purchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase_Home.aspx");
        }

        protected void Product1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }
    }
}