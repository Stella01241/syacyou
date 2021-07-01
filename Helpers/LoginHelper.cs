using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace syacyou.Helpers
{
    public class LoginHelper
    {
        private const string _sessionKey = "IsLogined";
        private const string _sessionkey_Account = "Account";

        public static bool HasLogined()
        {
            var val = HttpContext.Current.Session[_sessionKey];

            if (val != null)
                return true;
            else
                return false;
        }
        public static bool TryLogin(string account, string pwd)
        {
            if (LoginHelper.HasLogined())
                return true;

            AccountManger manager = new AccountManger();
            var model = manager.GetAccount(account);

            // READ DB And check account / pwd

            //假如Dt沒有資料回傳False
            if (model == null || string.Compare(pwd, model.Password, false) != 0)
            {
                return false;
            }
            //抓資料庫的密碼來做比對

            HttpContext.Current.Session[_sessionkey_Account] = account;
            //return true;

            HttpContext.Current.Session[_sessionKey] = new LoginInfo()
            {
                Account = model.Account,
                Account_Sid = model.Account_Sid,
                Password = model.Password
            };

            return true;
        }
        public static void Logout()
        {
            if (!LoginHelper.HasLogined())
                return;

            HttpContext.Current.Session.Remove(_sessionKey);
        }
    }
}