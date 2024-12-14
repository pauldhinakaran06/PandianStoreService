using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PandianStore_DAL
{
    public class Billing_DAL
    {
        string strResult;
        public string BillingProcess_DAL(string Action, string CustomerDetails, string BillItems_Data, string InvoiceNo, string TotalAmount , string PaymentTerms, string UserID)
        {
            strResult = string.Empty;
            string connectionString = ConfigurationManager.ConnectionStrings["PandianDB"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Sp_BillingandPayment_Details", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@P_Action", SqlDbType.VarChar).Value = Action.ToString();
                        command.Parameters.Add("@P_CustomerDetails", SqlDbType.VarChar).Value = CustomerDetails;
                        command.Parameters.Add("@P_BillItems_Data", SqlDbType.VarChar).Value = BillItems_Data;
                        command.Parameters.Add("@P_InvoiceNo", SqlDbType.VarChar).Value = InvoiceNo;
                        command.Parameters.Add("@P_TotalAmount", SqlDbType.VarChar).Value = TotalAmount;
                        command.Parameters.Add("@P_PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms.ToString();
                        command.Parameters.Add("@P_UserID", SqlDbType.VarChar).Value = UserID.ToString();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        strResult = JsonConvert.SerializeObject(dataSet);
                        return strResult;

                    }
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }
    }
}
