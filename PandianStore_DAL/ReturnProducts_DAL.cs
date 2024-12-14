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
    public class ReturnProducts_DAL
    {
        string strResult;
        public string ReturnInvoiceDetails_DAL(string Action,string InvoiceID,string UserID,string Data)
        {
            strResult = string.Empty;
            string connectionString = ConfigurationManager.ConnectionStrings["PandianDB"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Sp_Return_Details", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@P_Action", SqlDbType.VarChar).Value = Action.ToString();
                        command.Parameters.Add("@P_InvoiceID", SqlDbType.VarChar).Value = InvoiceID;
                        command.Parameters.Add("@P_UserID", SqlDbType.VarChar).Value = UserID.ToString();
                        command.Parameters.Add("@P_Data", SqlDbType.VarChar).Value = Data.ToString();
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
