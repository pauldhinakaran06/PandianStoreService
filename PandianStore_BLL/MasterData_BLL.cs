using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using PandianStore_DAL;

namespace PandianStore_BLL
{
    public class MasterData_BLL
    {
        public string GetMasterData_BLL(string str_param)
        {
            MasterData_DAL obj = new MasterData_DAL();
            string Action = string.Empty, value = string.Empty, CatID = string.Empty, UserID = string.Empty, SearchValue = string.Empty, BrandID = string.Empty;

            Action = str_param.Split('^')[0];
            value = str_param.Split('^')[1];
            CatID = str_param.Split('^')[2];
            BrandID = str_param.Split('^')[3];
            SearchValue = str_param.Split('^')[4];
            UserID = str_param.Split('^')[5];

            return obj.GetMasterData_DAL(Action, value, CatID,BrandID, SearchValue, UserID);
        }
    }
}