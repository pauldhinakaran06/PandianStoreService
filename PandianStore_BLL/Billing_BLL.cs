using PandianStore_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandianStore_BLL
{
    public class Billing_BLL
    {
        public string BillingProcess_BLL(string str_param)
        {
            Billing_DAL obj = new Billing_DAL();
            string Action = string.Empty, CustomerDetails = string.Empty, BillItems_Data = string.Empty, UserID = string.Empty,
                InvoiceNo = string.Empty, TotalAmount = string.Empty, PaymentTerms = string.Empty;

            Action = str_param.Split('^')[0];
            CustomerDetails = str_param.Split('^')[1];
            BillItems_Data = str_param.Split('^')[2];
            InvoiceNo = str_param.Split('^')[3];
            TotalAmount = str_param.Split('^')[4];
            PaymentTerms = str_param.Split('^')[5];
            UserID = str_param.Split('^')[6];

            return obj.BillingProcess_DAL(Action, CustomerDetails, BillItems_Data, InvoiceNo, TotalAmount , PaymentTerms, UserID);
        }
    }
}
