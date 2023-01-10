using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCatAPI_Lib.Tools.Database;
using Npgsql;

namespace TheCatAPI_Lib.Tools.Database
{
    public class DML
    {
        /// <summary>
        ///  Executar Query no banco de dados 
        /// </summary>
        /// <param name="oConnString"> Chave de Conexão no banco de dados</param>
        /// <param name="p_Select"> Query (Select a ser executado no banco de dados) podemos passar mais de uma query no final colocar (;)
        ///                         para iniciar uma novo select podendo caso informe mais de 1 select coloque (;) sempre no termino </param>
        /// <returns> Resultado do Query.</returns>
        public DataSet ExecuteSelect(String oConnString, String p_Select)
        {
            DataSet oReturn = new DataSet();
            try
            {
                using (NpgsqlConnection dbConnection = new NpgsqlConnection(oConnString))
                {
                    IDbCommand selectCommand = dbConnection.CreateCommand();
                    selectCommand.CommandText = p_Select;
                    IDbDataAdapter dbDataAdapter = new NpgsqlDataAdapter();
                    dbDataAdapter.SelectCommand = selectCommand;
                    dbDataAdapter.Fill(oReturn);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oReturn;
        }

        public void ExecuteDML(String oConnString, String queryString)
        {
            try
            {
                using (NpgsqlConnection dbConnection = new NpgsqlConnection(oConnString))
                {
                    dbConnection.Open();
                    IDbCommand selectCommand = dbConnection.CreateCommand();
                    selectCommand.CommandText = queryString;
                    selectCommand.ExecuteNonQuery();
                    dbConnection.Close();
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Executando Teste de Conexão 
        /// </summary>
        /// <param name="oConnString"> Chave de conexão a ser testado</param>
        /// <returns></returns>
        /// <summary>
        /// Executando Teste de Conexão 
        /// </summary>
        /// <param name="oConnString"> Chave de conexão a ser testado</param>
        /// <returns></returns>
        public String ExecuteTest(String oConnString)
        {
            String oReturn = "";
            try
            {
                NpgsqlConnection dbConnection = new NpgsqlConnection(oConnString);
                dbConnection.Open();
                oReturn = "Connection Sucess|" + dbConnection.Database.ToString() + " State :" + dbConnection.State.ToString();
            }
            catch (Exception ex)
            {
                oReturn = "Error Connection|" + ex.Message.ToString();
            }
            return oReturn;
        }
    }
}
