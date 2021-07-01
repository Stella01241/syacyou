using syacyou.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syacyou
{
    public class AccountManger
    {

        public static string GetConnectionString()
        {
            var manage = System.Configuration.ConfigurationManager.ConnectionStrings["systemDataBase"];

            if (manage == null)
                return string.Empty;
            else
                return manage.ConnectionString;
        }
        //抓帳號資料
        public LoginInfo GetAccount(string account)
        {
            string connectionString = GetConnectionString();
            string queryString =
                $@" SELECT * FROM UserAccount
                    WHERE UserAccount.Account = @Account;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Account", account);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    LoginInfo model = null;

                    while (reader.Read())
                    {
                        model = new LoginInfo();
                        model.Account = (string)reader["Account"];
                        model.Password = (string)reader["Password"];
                        model.Account_Sid = (int)reader["Account_Sid"];
                    }
                    reader.Close();
                    return model;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}