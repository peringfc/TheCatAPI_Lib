using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TheCatAPI_Lib.Tools.Database;

namespace TheCatAPI_Lib.Tools.Database
{
    public class CreateDB
    {
        ConnectDB oConnect = new ConnectDB();
        DML oDML = new DML();

        public void Create()
        {
    

            string oStringConnectGeral = oConnect.StringConnect();
            string oStringConnect = oConnect.StringConnect();

            List<string> otables = new List<string>();
            otables.Add("temperament");
            otables.Add("cat");
            otables.Add("cat_temperament");
            otables.Add("cat_image");

            for (int i = 0; i < otables.Count; i++)
            {
                String databasesQuery = $"SELECT * FROM information_schema.tables WHERE table_name = '{otables[i].ToString()}';";
                try
                {
                    DataSet oReturn = oDML.ExecuteSelect(oStringConnectGeral, databasesQuery);
                    if (oReturn.Tables[0].Rows.Count == 0)
                    {
                        switch (otables[i].ToString())
                        {
                            case "temperament":
                                CreateTable_temperament();
                                break;
                            case "cat":
                                CreateTable_Cat();
                                break;
                            case "cat_temperament":
                                CreateTable_cat_temperamentt();
                                break;
                            case "cat_image":
                                CreateTable_cat_image();
                                break;

                                
                            default:
                                break;
                        }
                        
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

      
        }


        protected void CreateTable_Cat()
        {

            string oStringConnect = oConnect.StringConnect();

            string QueryCat = " CREATE TABLE cat( " +
                "   id                 VARCHAR(50) NOT NULL PRIMARY KEY " +
                " , weightimperial     VARCHAR(8) NOT NULL             " +
                " , weightmetric       VARCHAR(6) NOT NULL             " +
                " , name_cat           VARCHAR(20) NOT NULL            " +
                " , cfa_url            VARCHAR(58)                     " +
                " , vetstreet_url      VARCHAR(57)                     " +
                " , vcahospitals_url   VARCHAR(70)                     " +
                " , temperament        VARCHAR(97) NOT NULL            " +
                " , origin             VARCHAR(20) NOT NULL            " +
                " , country_codes      VARCHAR(2) NOT NULL             " +
                " , country_code       VARCHAR(2) NOT NULL             " +
                " , description        VARCHAR(454) NOT NULL           " +
                " , life_span          VARCHAR(7) NOT NULL             " +
                " , indoor             INTEGER  NOT NULL               " +
                " , lap                INTEGER                         " +
                " , alt_names          VARCHAR(83)                     " +
                " , adaptability       INTEGER  NOT NULL               " +
                " , affection_level    INTEGER  NOT NULL               " +
                " , child_friendly     INTEGER  NOT NULL               " +
                " , dog_friendly       INTEGER  NOT NULL               " +
                " , energy_level       INTEGER  NOT NULL               " +
                " , grooming           INTEGER  NOT NULL               " +
                " , health_issues      INTEGER  NOT NULL               " +
                " , intelligence       INTEGER  NOT NULL               " +
                " , shedding_level     INTEGER  NOT NULL               " +
                " , social_needs       INTEGER  NOT NULL               " +
                " , stranger_friendly  INTEGER  NOT NULL               " +
                " , vocalisation       INTEGER  NOT NULL               " +
                " , experimental       INTEGER  NOT NULL               " +
                " , hairless           INTEGER  NOT NULL               " +
                " , naturals           INTEGER  NOT NULL               " +
                " , rare               INTEGER  NOT NULL               " +
                " , rex                INTEGER  NOT NULL               " +
                " , suppressed_tail    INTEGER  NOT NULL               " +
                " , short_legs         INTEGER  NOT NULL               " +
                " , wikipedia_url      VARCHAR(50)                     " +
                " , hypoallergenic     INTEGER  NOT NULL               " +
                " , reference_image_id VARCHAR(10)                     " +
                " , cat_friendly       INTEGER                         " +
                " , bidability         INTEGER                         " +
                " )";

            oDML.ExecuteDML(oStringConnect, QueryCat);

        }
        protected void CreateTable_temperament()
        {
            string oStringConnect = oConnect.StringConnect();
            string Querytemperament = " CREATE TABLE temperament( " +
                "   id_temperament     VARCHAR(50) NOT NULL PRIMARY KEY " +
                " , temperament        VARCHAR(50) NOT NULL            " +
                " )";

            oDML.ExecuteDML(oStringConnect, Querytemperament);
        }

        protected void CreateTable_cat_temperamentt()
        {
            string oStringConnect = oConnect.StringConnect();
            string Querycat_temperament = " CREATE TABLE cat_temperament( " +
                "   id                    VARCHAR(50) NOT NULL " +
                " , id_temperament        VARCHAR(50) NOT NULL  " +
            " ) ";
            oDML.ExecuteDML(oStringConnect, Querycat_temperament);
            oDML.ExecuteDML(oStringConnect, "ALTER TABLE cat_temperament ADD CONSTRAINT cat_temperament_uk UNIQUE (id, id_temperament);");
        }

        protected void CreateTable_cat_image()
        {
            string oStringConnect = oConnect.StringConnect();
            string Querycat_temperament = " CREATE TABLE cat_image( id VARCHAR(50) NOT NULL "+
                            "  , url    VARCHAR(100) NOT NULL "+ 
                            "  , width  INTEGER NOT NULL  "+
                            "  ,height INTEGER  NOT NULL ,category_id VARCHAR(50)" + 
            " ) ";
            oDML.ExecuteDML(oStringConnect, Querycat_temperament);
            oDML.ExecuteDML(oStringConnect, "ALTER TABLE cat_image ADD CONSTRAINT cat_image_uk UNIQUE (id, url);");
        }

    }
}
