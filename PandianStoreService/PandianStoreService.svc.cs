using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using PandianStore_BLL;

namespace PandianStoreService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PandianStoreService : IPandianStoreService
    {
        public string GetServiceCall(string str_PageName, string str_param)
        {
            if (str_PageName == "login")
            {
                Login_BLL objBLL = new Login_BLL();
                return objBLL.CheckloginDetails_BLL(str_param);
            }
            

            return "";
        }
        public string PostServiceCall(string str_PageName, string str_param)
        {
            if (str_PageName == "MasterData")
            {
                MasterData_BLL objBLL = new MasterData_BLL();
                return objBLL.GetMasterData_BLL(str_param);
            }
            else if (str_PageName == "Billing")
            {
                Billing_BLL objBLL = new Billing_BLL();
                return objBLL.BillingProcess_BLL(str_param);
            }
            else if (str_PageName == "ReturnData")
            {
                ReturnProducts_BLL objBLL = new ReturnProducts_BLL();
                return objBLL.ReturnInvoiceDetails_BLL(str_param);
            }
            return "";
        }
    }
}
