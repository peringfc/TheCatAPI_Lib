using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCatAPI_Lib.Structure.SiteTheCatAPI
{
    // Stru_Images myDeserializedClass = JsonConvert.DeserializeObject<List<Stru_Images>>(myJsonResponse);

    public class Stru_Images
    {
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
