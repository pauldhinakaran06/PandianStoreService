using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandianStore_DAL;

namespace PandianStore_BLL
{
    public class Login_BLL
    {
        public string CheckloginDetails_BLL(string str_param)
        {
            Login_DAL obj = new Login_DAL();
            string Action = string.Empty, UserName = string.Empty,Password=string.Empty, UserRole=string.Empty;

            Action=str_param.Split('^')[0];
            UserName = str_param.Split('^')[1];
            Password = str_param.Split('^')[2];
            UserRole = str_param.Split('^')[3];

            return obj.CheckloginDetails_DAL(Action,UserName,Password,UserRole);
        }
    }
}