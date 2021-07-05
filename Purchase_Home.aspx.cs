using syacyou.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

     
        protected void Create_Purchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase_Create.aspx");
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

   
        protected void Export(CrystalDecisions.Shared.ExportFormatType FileType, string FileName)//使用ExportToStream方式匯出
        {
            //create CrystalReport object
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();


            //load report
            report.Load(Server.MapPath("CrystalReport2.rpt"));


            System.IO.Stream stream = report.ExportToStream(FileType);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            //export file
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);//excel檔名

            switch (FileType)
            {
                case CrystalDecisions.Shared.ExportFormatType.Excel:
                    Response.ContentType = "application/vnd.ms-excel";
                    break;
                case CrystalDecisions.Shared.ExportFormatType.PortableDocFormat:
                    Response.ContentType = "application/pdf";
                    break;
                case CrystalDecisions.Shared.ExportFormatType.WordForWindows:
                    Response.ContentType = "application/vnd.ms-word";
                    break;
            }

            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.Close();
        }

        protected void Export(CrystalDecisions.Shared.ExportFormatType FileType, string FileName, bool ExportModel)//使用ExportToHttpResponse方式匯出
        {
            //create CrystalReport object
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
          //load report
            report.Load(Server.MapPath("CrystalReport2.rpt"));
            report.ExportToHttpResponse(FileType, Response, ExportModel, FileName);//ExportModel{true:匯出檔案,false:用browse開啓檔案}
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
       
            //使用ExportToHttpResponse方式匯出
            Export(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "test.pdf", true);
        }

        protected void LogoutBtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            LoginHelper.Logout();
        }

        //private void BindReport()
        //{
        //    string strProvider = "Server=(local);DataBase=pubs;UID=sa;PWD=";
        //    CrystalReport2 oCR = new CrystalReport2();
        //    Dataset1 ds = new Dataset1();
        //    SqlConnection MyConn = new SqlConnection(strProvider);
        //    MyConn.Open();
        //    string strSel = "Select * from Stores";
        //    SqlDataAdapter MyAdapter = new SqlDataAdapter(strSel, MyConn);
        //    MyAdapter.Fill(ds, "stores");
        //    oCR.SetDataSource(ds);
        //    this.CrystalReportViewer1.ReportSource = oCR;
        //}
    }
}