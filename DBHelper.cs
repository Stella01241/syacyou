using syacyou.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syacyou
{
    public class DBHelper
    {
        public static DataTable Purchase_Read(string Purchase_Number)
        {

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Purchase WHERE Purchase_Number = @Purchase_Number";

            List<SqlParameter> parameters = new List<SqlParameter>()

                {
                   new SqlParameter("@Purchase_Number", Purchase_Number),
                };

            var dt = CreateHelper.GetDataTable(queryString, parameters);

            return dt;



        }

        public static DataTable PurchaseDataTable(out int total ,int currentPage,int pageSize =5)
        {
            //建立資料庫字串變數
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=PSI; Integrated Security=true";
            //使用的SQL語法
            string queryString = $@" SELECT  TOP  5 * FROM 
               (
                  SELECT
                    ROW_NUMBER() OVER(ORDER BY　Purchase.Purchase_Number) AS ROWSID,
                    Purchase.*  
                    FROM Purchase
          
               )AS Temp WHERE ROWSID > {pageSize * (currentPage -1 )} AND IsDelete IS NULL;";

            var countQuery = $@"SELECT COUNT ([Purchase_Number]) From [Purchase] WHERE (IsDelete IS NULL)";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉換成SQL可讀懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);


                try
                {
                    //開始連線
                    connection.Open();
                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();
                    //在記憶體中創新空表
                    DataTable dt = new DataTable();
                    //把值塞進空表
                    dt.Load(reader);


                    //關閉資料庫連線
                    reader.Close();

                    var datatotal = CreateHelper.GetScale(countQuery) as int?;
                    total = (datatotal.HasValue) ? datatotal.Value : 0;
                    //回傳dt
                    return dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;

                }
            }
        }
        public void Purchase_Delete(String Purchase_Number, int Account_Sid)
        {

            //使用的SQL語法

            string queryString = $@"UPDATE Purchase SET  IsDelete = @IsDelete  Where Purchase_Number = @Purchase_Number";

            List<SqlParameter> parameters = new List<SqlParameter>()
                {
                   new SqlParameter("@Purchase_Number",Purchase_Number),
                   new SqlParameter("@IsDelete", Account_Sid),                 
                };
            CreateHelper.ExecuteNonQuery(queryString, parameters);


        }
        public static void Purchase_Create(ProductModel Model)
        {

            //使用的SQL語法
            string queryString = $@" INSERT INTO Purchase (Purchase_Number, Shipping_Time,Account_Sid)
                                        VALUES (@Purchase_Number, @Shipping_Time,@Account_Sid);";

            //建立連線
            LoginInfo loginInfo = HttpContext.Current.Session["IsLogined"] as LoginInfo;
            //取得session的使用者名稱
            int Account_Sid = loginInfo.Account_Sid;

            List<SqlParameter> parameters = new List<SqlParameter>()

                {
                   new SqlParameter("@Purchase_Number", Model.Purchase_Number),
                   new SqlParameter("@Shipping_Time",Model.Shipping_Time),
                     new SqlParameter("@Account_Sid",Account_Sid)
                };

            CreateHelper.ExecuteNonQuery(queryString, parameters);

        }


        public void Product_Delete(String Purchase_Number, int Account_Sid)
        {

            //使用的SQL語法

            string queryString = $@"UPDATE Purchase SET  IsDelete = @IsDelete  Where Purchase_Number = @Purchase_Number";

            List<SqlParameter> parameters = new List<SqlParameter>()
                {
                   new SqlParameter("@Purchase_Number",Purchase_Number),
                   new SqlParameter("@IsDelete", Account_Sid),
                };
            CreateHelper.ExecuteNonQuery(queryString, parameters);


        }
    }
}