using TheCatAPI_Lib.Structure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCatAPI_Lib.Tools.ClientWEB;
using Newtonsoft.Json;
using TheCatAPI_Lib.Structure.SiteTheCatAPI;
using TheCatAPI_Lib.Structure.Tools;

namespace TheCatAPI_Lib.TheCatAPI.SiteAPI
{
    public class TheCatAPI
    {
        /// <summary>
        ///  Processo de chamada de APIs
        /// </summary>
        /// 
        Client oAPI = new Client();

        /// <summary>
        ///  Processo de sincronização dos dados TheCatAPI
        ///  Processo consulta a o Site https://api.thecatapi.com/v1/breeds
        ///  e Carrega informações na base de dados.
        /// </summary>
        public void synchronization()
        {
        }

        /// <summary>
        /// Processo que realiza pesquisa no Portal TheCatAPI pesquisando todas as Racas de animais na base de origem da base de dados
        /// </summary>
        /// <returns> Json com informações de todas as racas cadastras nos portal.
        /// </returns>
        public List<Stru_Breed> ListBreedTheCatAPI()
        {
            List<Stru_Breed> oListBreedsFullSite = new List<Stru_Breed>();
            try
            {
                string p_url = "https://api.thecatapi.com/v1/breeds";
                string p_name = "Listar todas as Raças do Site (https://thecatapi.com/)";
                /// estrutura de retorno de chamadas http.
                Stru_Request oRequest = new Stru_Request();
                oRequest = oAPI.get(p_url, p_name);
                oListBreedsFullSite = JsonConvert.DeserializeObject<List<Stru_Breed>>(oRequest.Context);
            }
            catch (Exception)
            {
                throw;
            }
            return oListBreedsFullSite;
        }



        public List<Stru_Images> ListBreedImagens( string p_category)
        {
            List<Stru_Images> oListBreedimanges = new List<Stru_Images>();
            try
            {
                string p_url = $"https://api.thecatapi.com/v1/images/search?limit=100&mime_types=&order=Random&size=small&page=0&category_ids={p_category.Trim().TrimEnd()}";
                string p_name = "Listar todas as Raças do Site (https://thecatapi.com/)";
                /// estrutura de retorno de chamadas http.
                Stru_Request oRequest = new Stru_Request();
                oRequest = oAPI.get(p_url, p_name);
                oListBreedimanges = JsonConvert.DeserializeObject<List<Stru_Images>>(oRequest.Context);
            }
            catch (Exception)
            {
                throw;
            }
            return oListBreedimanges;
        }
    }
}
