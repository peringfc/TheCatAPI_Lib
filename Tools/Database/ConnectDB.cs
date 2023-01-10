using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCatAPI_Lib.Structure.Config; 

namespace TheCatAPI_Lib.Tools.Database
{
    public class ConnectDB
    {
        public string StringConnect()
        {
            string mySqlConnStr = string.Empty;
            try
            {
                string oJsonConfig = System.IO.File.ReadAllText(@"appsettings.json");
                StruConfig oStrincConnect = JsonConvert.DeserializeObject<StruConfig>(oJsonConfig);

                mySqlConnStr = $"User ID ={oStrincConnect.ConnectionStrings.MYSQL_USER}; " +
                    $" Password ={oStrincConnect.ConnectionStrings.MYSQL_PASSWORD}; " +
                    $" Host ={oStrincConnect.ConnectionStrings.MYSQL_DBHOST}; " +
                    $" Port = {oStrincConnect.ConnectionStrings.MYSQL_DBPORT}; Database = {oStrincConnect.ConnectionStrings.MYSQL_DATABASE};" +
                    $" Pooling = true; "; 


            }
            catch (Exception)
            {
                throw;
            }
            return mySqlConnStr;
        }
    }
}
