using PandianStore_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandianStore_BLL
{
    public class ReturnProducts_BLL
    {
        public string ReturnInvoiceDetails_BLL(string str_param)
        {
            ReturnProducts_DAL obj = new ReturnProducts_DAL();
            string Action = string.Empty, UserID = string.Empty,InvoiceID = string.Empty,Data=string.Empty;

            Action = str_param.Split('^')[0];
            InvoiceID = str_param.Split('^')[1];
            UserID = str_param.Split('^')[2];
            Data = str_param.Split('^')[3];

            return obj.ReturnInvoiceDetails_DAL(Action, InvoiceID,UserID,Data);
        }
    }
}
