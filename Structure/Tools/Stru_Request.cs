using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCatAPI_Lib.Structure.Tools
{
    /// <summary>
    /// Estrutura de retorno de chamadas para URL e API 
    /// </summary>
    public class Stru_Request
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public string? Context { get; set; }
        public string? Size { get; set; }
        public string? codestatus { get; set; }
        public string? TimeLatency { get; set; }

    }
}
