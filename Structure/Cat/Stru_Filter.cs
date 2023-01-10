using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCatAPI_Lib.Structure.Cat
{
    public class Stru_Filter
    {
        public string order { get; set; }
        public List<Stru_Item_Filter> items { get; set; }
    }

    public class Stru_Item_Filter
    {
        public string field { get; set; }
        public string field_value { get; set; }
    }
}
