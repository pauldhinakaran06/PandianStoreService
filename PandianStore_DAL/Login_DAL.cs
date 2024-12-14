using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft;
using Newtonsoft.Json;
using System.Configuration;


namespace PandianStore_DAL
{
    public class Login_DAL
    {
        string strResult;
        public string CheckloginDetails_DAL(string Action, string UserName, string Password, string UserRole)
        {
            strResult = string.Empty;
            string connectionString =  ConfigurationManager.ConnectionStrings["PandianDB"].ConnectionString;
            //"Server=(Localdb)\\Store;Database=Store;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_LoginDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@P_Action",SqlDbType.VarChar).Value = Action.ToString();
                        command.Parameters.Add("@P_UserName", SqlDbType.VarChar).Value = UserName.ToString();
                        command.Parameters.Add("@P_Password", SqlDbType.VarChar).Value = Password.ToString();
                        command.Parameters.Add("@P_UserRole", SqlDbType.VarChar).Value = UserRole.ToString();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        strResult = JsonConvert.SerializeObject(dataSet);
                        return strResult;

                    }
                }
            }
            catch (Exception ex) {

                return ex.ToString();
            }

            }
    }
}