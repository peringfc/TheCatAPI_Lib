using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCatAPI_Lib.Structure.Cat;
using TheCatAPI_Lib.Tools.Database; 

namespace TheCatAPI_Lib.Desafio.search
{
    public class Cat
    {

        ConnectDB oConnect = new ConnectDB();
        DML oDML = new DML();

        /// <summary>
        /// Lista todas as racas que se encontram no banco de dados
        /// </summary>
        /// <param name="Format"></param>
        /// <returns></returns>
        public string breeds(string Format)
        {
            return ibreeds(Format); 
        }

        /// <summary>
        /// Processo monta estrutura lista temperamentos do animais e suas quantidades.
        /// </summary>
        /// <param name="Format"></param>
        /// <returns></returns>
        public string temperament_total(string Format)
        {
            return inf_temperament_total(Format);
        }


        public string filter_temperament(string p_temperament, string Format)
        {
            return ifilter_temperament(p_temperament, Format);
        }


        public string filter_origin(string p_origin, string Format)
        {
            return ifilter_origin(p_origin, Format);
        }

        public string OriginTotal( string Format)
        {
            return i_origintotal( Format);
        }


        public string info_breed(string p_id, string Format)
        {
            return inf_breed(p_id,  Format);
        }


        /// <summary>
        ///  Lista todas as racas registaradas no banco dados
        /// </summary>
        /// <returns></returns>
        protected string  ibreeds(string Format)
        { 
            DataSet oSearch = new DataSet("ListBreed");
            string oQuerySearchBreed = "SELECT id, name_cat name FROM cat order by 2 ";
            string oReturn = string.Empty;

            try
            {
                oSearch = oDML.ExecuteSelect(oConnect.StringConnect(), oQuerySearchBreed);
                oSearch.DataSetName= "ListBreed";
                oSearch.Tables[0].TableName = "Breed";

                oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                switch (Format)
                {
                    case "JSON":
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                    case "XML":
                        oReturn = oSearch.GetXml();
                        break;
                    default:
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return oReturn;
        }
        /// <summary>
        /// Lista os temperamentos dos aminais e a quantidade registrado
        /// </summary>
        /// <param name="Format"></param>
        /// <returns></returns>
        protected string inf_temperament_total(string Format)
        {
            DataSet oSearch = new DataSet();
            string oQuerySearchBreed = $"SELECT id_temperament,count(1) total FROM cat_temperament group by id_temperament ";
            string oReturn = string.Empty;

            try
            {
                oSearch = oDML.ExecuteSelect(oConnect.StringConnect(), oQuerySearchBreed);
                oSearch.DataSetName = "ListTemperamentTotal";
                oSearch.Tables[0].TableName = "TemperamentTotal";

                oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                switch (Format)
                {
                    case "JSON":
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                    case "XML":
                        oReturn = oSearch.GetXml();
                        break;
                    default:
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oReturn;
        }


        /// <summary>
        /// Lista as Raca pelo temperamento informado
        /// </summary>
        /// <param name="p_temperament"> informe o temperamento</param>
        /// <param name="Format">JSON / XML</param>
        /// <returns></returns>
        protected string ifilter_temperament(string p_temperament, string Format)
        {
            DataSet oSearch = new DataSet();
            string oQuerySearchBreed = $"SELECT * FROM cat where id in (select id from cat_temperament where upper(id_temperament) = '{p_temperament}' ) order by name_cat ";
            string oReturn = string.Empty;

            try
            {
                oSearch = oDML.ExecuteSelect(oConnect.StringConnect(), oQuerySearchBreed);
                oSearch.DataSetName = "ListTemperament";
                oSearch.Tables[0].TableName = "breed";

                oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                switch (Format)
                {
                    case "JSON":
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                    case "XML":
                        oReturn = oSearch.GetXml();
                        break;
                    default:
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oReturn;
        }


        /// <summary>
        /// Lista as Racas de acordo com a Origem Informada.
        /// </summary>
        /// <param name="p_origin"></param>
        /// <returns></returns>
        protected string ifilter_origin(string p_origin, string Format)
        {
            DataSet oSearch = new DataSet();
            string oQuerySearchBreed = $"SELECT * FROM cat where (upper(origin) = upper('{p_origin}') or upper(country_code) = upper('{p_origin}'))";
            string oReturn = string.Empty;

            try
            {
                oSearch = oDML.ExecuteSelect(oConnect.StringConnect(), oQuerySearchBreed);
                oSearch.DataSetName = "ListOrigen";
                oSearch.Tables[0].TableName = "breed";

                oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                switch (Format)
                {
                    case "JSON":
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                    case "XML":
                        oReturn = oSearch.GetXml();
                        break;
                    default:
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oReturn;
        }

        protected string i_origintotal(string Format)
        {
            DataSet oSearch = new DataSet();
            string oQuerySearchBreed = $"select origin, count(1) total from cat group by origin order by 1";
            string oReturn = string.Empty;

            try
            {
                oSearch = oDML.ExecuteSelect(oConnect.StringConnect(), oQuerySearchBreed);
                oSearch.DataSetName = "ListOrigen";
                oSearch.Tables[0].TableName = "Origin";

                oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                switch (Format)
                {
                    case "JSON":
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                    case "XML":
                        oReturn = oSearch.GetXml();
                        break;
                    default:
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oReturn;
        }


        /// <summary>
        ///  Lista todas as informacoes de uma racao selecionada
        /// </summary>
        /// <returns></returns>
        protected string inf_breed(string p_id, string Format)
        {
            DataSet oSearch = new DataSet();
            string oQuerySearchBreed = $"SELECT * FROM cat where id = '{p_id}' ; SELECT *  FROM cat_image where id = '{p_id}'  ";
            string oReturn = string.Empty;

            try
            {
                oSearch = oDML.ExecuteSelect(oConnect.StringConnect(), oQuerySearchBreed);
                oSearch.DataSetName = "Info";
                oSearch.Tables[0].TableName = "breed";
                oSearch.Tables[1].TableName = "images";

                oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                switch (Format)
                {
                    case "JSON":
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                    case "XML":
                        oReturn = oSearch.GetXml();
                        break;
                    default:
                        oReturn = JsonConvert.SerializeObject(oSearch, Formatting.Indented);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oReturn;
        }



    

    }
}
