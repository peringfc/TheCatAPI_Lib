using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TheCatAPI_Lib.Structure.Tools;

namespace TheCatAPI_Lib.Tools.ClientWEB
{
    public class Client
    {
        /// <summary>
        /// Processo de chamadas simples via URL e Metodo HTTP.
        /// </summary>
        /// <param name="p_url">URL que sera chamada/ executada</param>
        /// <param name="p_name"> Nome da Chamada para registro de de logs</param>
        /// <returns> retorno de Objeto com estrutura de tempo , codigo de retorno tamanho da mensagem</returns>
        public Stru_Request get(string p_url, string p_name)
        {
            Stru_Request responseBody = new Stru_Request();
            var stopwatch = new Stopwatch();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    stopwatch.Start();
                    HttpResponseMessage result = client.GetAsync(p_url).Result;

                    /// Processo nao esta sendo da forma Implicida por futura munda ou estruturacao nova na estrutura 
                    /// caso necessario.
                    /// 
                    responseBody.Id = Guid.NewGuid().ToString();
                    responseBody.Name = p_name;
                    responseBody.URL = p_url;
                    responseBody.Context = result.Content.ReadAsStringAsync().Result; ;
                    responseBody.Size = result.Content.ReadAsStringAsync().Result.Length.ToString();
                    responseBody.codestatus = result.StatusCode.ToString();
                    responseBody.TimeLatency = stopwatch.ElapsedTicks.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return responseBody;
        }
    }
}
