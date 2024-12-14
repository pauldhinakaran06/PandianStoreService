using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PandianStore_DAL
{
    public class MasterData_DAL
    {
        string strResult;
        public string GetMasterData_DAL(string Action, string value, string CatID, string BrandID,string SearchValue, string UserID)
        {
            strResult = string.Empty;
            string connectionString = ConfigurationManager.ConnectionStrings["PandianDB"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Sp_Insert_CategoryandBrand", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@P_Action", SqlDbType.VarChar).Value = Action.ToString();
                        command.Parameters.Add("@P_value", SqlDbType.VarChar).Value = value;
                        command.Parameters.Add("@P_CatID", SqlDbType.VarChar).Value = CatID.ToString();
                        command.Parameters.Add("@P_BrandID", SqlDbType.VarChar).Value = BrandID.ToString();
                        command.Parameters.Add("@P_searchValue", SqlDbType.VarChar).Value = SearchValue.ToString();
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