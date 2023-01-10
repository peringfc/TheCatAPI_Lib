using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;
using TheCatAPI_Lib.Structure.SiteTheCatAPI;
using TheCatAPI_Lib.Structure.Tools;
using TheCatAPI_Lib.Tools.Database;

namespace TheCatAPI_Lib.TheCatAPI.SiteAPI
{
    public class Synchronism
    {

        //public List<StruLog> LoadTheCatAPI()
        public List<Stru_Log> LoadTheCatAPI()
        {
            List<Stru_Log> ListStruLog = new List<Stru_Log>();
            Stru_Log oStruLog = new Stru_Log();

            /// Processo de consulta de dados na API
            List<Stru_Breed> oReturnList = new List<Stru_Breed>();
            try
            {
                CreateDB oCreateDB = new CreateDB();
                oCreateDB.Create();

                TheCatAPI_Lib.TheCatAPI.SiteAPI.TheCatAPI oTheCatAPI = new TheCatAPI_Lib.TheCatAPI.SiteAPI.TheCatAPI();
                oReturnList = oTheCatAPI.ListBreedTheCatAPI();
                ListStruLog = Add(oReturnList);
                //load_images();

            }


            catch (Exception ex)
            {
                Stru_Log oStruLogErro = new Stru_Log();
                oStruLogErro.DateCreate = DateTime.Now;
                oStruLogErro.ClassName = "Synchronism.LoadTheCatAPI";
                oStruLogErro.Level = 1;
                oStruLogErro.Message = ex.Message;
            }

            /// Carregar dados no banco de dados 
            /// Normatizar dados para o processo 

            return ListStruLog;
        }

        protected List<Stru_Log> Add(List<Stru_Breed> ListBreed)
        {
            ConnectDB oConnect = new ConnectDB();
            DML oDML = new DML();

            string oStringConnectGeral = oConnect.StringConnect();

            string sCommand = "INSERT INTO Cat(id,name_cat,cfa_url,vetstreet_url,vcahospitals_url,temperament,origin,country_codes," +
                " country_code,description,life_span,indoor,lap,alt_names,adaptability,affection_level,child_friendly,dog_friendly,energy_level," +
                " grooming,health_issues,intelligence,shedding_level,social_needs,stranger_friendly,vocalisation,experimental," +
                " hairless,naturals,rare,rex,suppressed_tail,short_legs,wikipedia_url,hypoallergenic,reference_image_id,cat_friendly,bidability , " +
                " weightimperial  , weightmetric " +
                ") Values " +
                " (@id,@name ,@cfa_url ,@vetstreet_url ," +
                " @vcahospitals_url ,@temperament ,@origin ," +
                " @country_codes ,@country_code ,@description ," +
                " @life_span ,@indoor ,@lap ,@alt_names ," +
                " @adaptability ,@affection_level ,@child_friendly ," +
                " @dog_friendly ,@energy_level ,@grooming ,@health_issues ," +
                " @intelligence ,@shedding_level ,@social_needs ," +
                " @stranger_friendly ,@vocalisation ,@experimental ," +
                " @hairless ,@natural ,@rare ,@rex ," +
                " @suppressed_tail ,@short_legs ,@wikipedia_url ," +
                " @hypoallergenic ,@reference_image_id ,@cat_friendly ," +
                " @bidability, @weightimperial  , @weightmetric)";

            List<Stru_Log> ListStruLog = new List<Stru_Log>();
            Stru_Log oStruLog = new Stru_Log();


            oStruLog.IdLog = "-- Start --";
            oStruLog.TextLog = $"Total de registros pesquisados {ListBreed.Count.ToString()}";
            oStruLog.DateCreate = DateTime.Now;
            oStruLog.ClassName = "Synchronism.Add";
            oStruLog.Level = 0;

            int oCount = 0;

            ListStruLog.Add(oStruLog);

            using (NpgsqlConnection dbConnection = new NpgsqlConnection(oStringConnectGeral))
            {
                dbConnection.Open();

                for (int i = 0; i < ListBreed.Count; i++)
                {
                    try
                    {
                        try
                        {
                            NpgsqlCommand command = new NpgsqlCommand(sCommand, dbConnection);

                            command.Parameters.AddWithValue("@id", ListBreed[i].id);
                            command.Parameters.AddWithValue("@name", ListBreed[i].name);
                            command.Parameters.AddWithValue("@cfa_url", ListBreed[i].cfa_url);
                            command.Parameters.AddWithValue("@vetstreet_url", ListBreed[i].vetstreet_url);
                            command.Parameters.AddWithValue("@vcahospitals_url", ListBreed[i].vcahospitals_url);
                            command.Parameters.AddWithValue("@temperament", ListBreed[i].temperament);
                            command.Parameters.AddWithValue("@origin", ListBreed[i].origin);
                            command.Parameters.AddWithValue("@country_codes", ListBreed[i].country_codes);
                            command.Parameters.AddWithValue("@country_code", ListBreed[i].country_code);
                            command.Parameters.AddWithValue("@description", ListBreed[i].description);
                            command.Parameters.AddWithValue("@life_span", ListBreed[i].life_span);
                            command.Parameters.AddWithValue("@indoor", ListBreed[i].indoor);
                            command.Parameters.AddWithValue("@lap", ListBreed[i].lap);
                            command.Parameters.AddWithValue("@alt_names", ListBreed[i].alt_names);
                            command.Parameters.AddWithValue("@adaptability", ListBreed[i].adaptability);
                            command.Parameters.AddWithValue("@affection_level", ListBreed[i].affection_level);
                            command.Parameters.AddWithValue("@child_friendly", ListBreed[i].child_friendly);
                            command.Parameters.AddWithValue("@dog_friendly", ListBreed[i].dog_friendly);
                            command.Parameters.AddWithValue("@energy_level", ListBreed[i].energy_level);
                            command.Parameters.AddWithValue("@grooming", ListBreed[i].grooming);
                            command.Parameters.AddWithValue("@health_issues", ListBreed[i].health_issues);
                            command.Parameters.AddWithValue("@intelligence", ListBreed[i].intelligence);
                            command.Parameters.AddWithValue("@shedding_level", ListBreed[i].shedding_level);
                            command.Parameters.AddWithValue("@social_needs", ListBreed[i].social_needs);
                            command.Parameters.AddWithValue("@stranger_friendly", ListBreed[i].stranger_friendly);
                            command.Parameters.AddWithValue("@vocalisation", ListBreed[i].vocalisation);
                            command.Parameters.AddWithValue("@experimental", ListBreed[i].experimental);
                            command.Parameters.AddWithValue("@hairless", ListBreed[i].hairless);
                            command.Parameters.AddWithValue("@natural", ListBreed[i].natural);
                            command.Parameters.AddWithValue("@rare", ListBreed[i].rare);
                            command.Parameters.AddWithValue("@rex", ListBreed[i].rex);
                            command.Parameters.AddWithValue("@suppressed_tail", ListBreed[i].suppressed_tail);
                            command.Parameters.AddWithValue("@short_legs", ListBreed[i].short_legs);
                            command.Parameters.AddWithValue("@wikipedia_url", ListBreed[i].wikipedia_url);
                            command.Parameters.AddWithValue("@hypoallergenic", ListBreed[i].hypoallergenic);
                            command.Parameters.AddWithValue("@reference_image_id", ListBreed[i].reference_image_id);
                            command.Parameters.AddWithValue("@cat_friendly", ListBreed[i].cat_friendly);
                            command.Parameters.AddWithValue("@bidability", ListBreed[i].bidability);
                            command.Parameters.AddWithValue("@weightimperial", ListBreed[i].weight.imperial);
                            command.Parameters.AddWithValue("@weightmetric", ListBreed[i].weight.metric);

                            command.ExecuteNonQuery();

                            List<string> oCategory = new List<string>();
                            oCategory.Add("4"); // Ocuulos
                            oCategory.Add("1"); // Chapeu

                            for (int ri = 0; ri < oCategory.Count; ri++)
                            {

                                TheCatAPI oTheCatAPI = new TheCatAPI();
                                List<Stru_Images> oStru_Images = new List<Stru_Images>();

                                oStru_Images = oTheCatAPI.ListBreedImagens(oCategory[ri]);

                                for (int y = 0; y < 3; y++)
                                {
                                    try
                                    {
                                        NpgsqlCommand command_tmp = new NpgsqlCommand($"INSERT INTO cat_image(id, url,width,height,category_id) " +
                                            $" VALUES ('{ListBreed[i].id}', '{oStru_Images[y].url}',{oStru_Images[y].width},{oStru_Images[y].height},'{oCategory[ri]}');", dbConnection);
                                        command_tmp.ExecuteNonQuery();
                                    }
                                    catch (Exception) { }
                                }

                            }

                            oCount++;
                        }
                        catch (Exception ex)
                        {
                            Stru_Log oStruLogErroadd = new Stru_Log();
                            oStruLogErroadd.IdLog = ListBreed[i].id;
                            oStruLogErroadd.TextLog = ListBreed[i].name;
                            oStruLogErroadd.DateCreate = DateTime.Now;
                            oStruLogErroadd.ClassName = "Synchronism.Add";
                            oStruLogErroadd.Level = 1;
                            oStruLogErroadd.Message = ex.Message;

                            ListStruLog.Add(oStruLogErroadd);
                        }


                        string[] oTemp = ListBreed[i].temperament.Split(',');

                        foreach (var xTemp in oTemp)
                        {
                            try
                            {
                                NpgsqlCommand command_tmp = new NpgsqlCommand($"INSERT INTO temperament(id_temperament, temperament) VALUES ('{xTemp.Trim().TrimEnd().TrimStart()}', '{xTemp.Trim().TrimEnd().TrimStart()}');", dbConnection);
                                command_tmp.ExecuteNonQuery();
                            }
                            catch (Exception) { }
                            try
                            {
                                NpgsqlCommand command_tmp_cat = new NpgsqlCommand($"INSERT INTO cat_temperament(id, id_temperament) VALUES ('{ListBreed[i].id}', '{xTemp.Trim().TrimEnd().TrimStart()}');", dbConnection);
                                command_tmp_cat.ExecuteNonQuery();
                            }
                            catch (Exception) { }

                        }

                       


                    }
                    catch (Exception ex)
                    {
                        Stru_Log oStruLogErro = new Stru_Log();
                        oStruLogErro.IdLog = ListBreed[i].id;
                        oStruLogErro.TextLog = ListBreed[i].name;
                        oStruLogErro.DateCreate = DateTime.Now;
                        oStruLogErro.ClassName = "Synchronism.Add";
                        oStruLogErro.Level = 1;
                        oStruLogErro.Message = ex.Message;

                        ListStruLog.Add(oStruLogErro);
                    }

                }
                dbConnection.Close();


                oStruLog.IdLog = "-- End --";
                oStruLog.TextLog = $"Total de registros adicionados {oCount.ToString()} de  {ListBreed.Count.ToString()}";
                oStruLog.DateCreate = DateTime.Now;
                oStruLog.ClassName = "Synchronism.Add";
                oStruLog.Level = 0;
                ListStruLog.Add(oStruLog);
            }

            return ListStruLog;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void load_images()
        {
            List<string> oCategory = new List<string>();
            oCategory.Add("4"); // Ocuulos
            oCategory.Add("1"); // Chapeu

            ConnectDB oConnect = new ConnectDB();
            DML oDML = new DML();

            using (NpgsqlConnection dbConnection = new NpgsqlConnection(oConnect.StringConnect()))
            {
                dbConnection.Open();
                for (int i = 0; i < oCategory.Count; i++)
                {
                    for (int x = 0; x < 20; x++)
                    {
                        TheCatAPI oTheCatAPI = new TheCatAPI();
                        List<Stru_Images> oStru_Images = new List<Stru_Images>();

                        oStru_Images = oTheCatAPI.ListBreedImagens(oCategory[i]);

                        for (int y = 0; y < oStru_Images.Count; y++)
                        {
                            try
                            {
                                NpgsqlCommand command_tmp = new NpgsqlCommand($"INSERT INTO cat_image(id, url,width,height,category_id) " +
                                    $" VALUES ('{oStru_Images[y].id}', '{oStru_Images[y].url}',{oStru_Images[y].width},{oStru_Images[y].height},'{oCategory[i]}');", dbConnection);
                                command_tmp.ExecuteNonQuery();
                            }
                            catch (Exception) { }
                        }
                    }
                }
                dbConnection.Close();
            }
        }
    }
}