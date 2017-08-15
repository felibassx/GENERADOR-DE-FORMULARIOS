using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dto
{
    public class GrupoCtrlDTO
    {
        [SourceNames("id")]
        public int id { get; set; }

        [SourceNames("nombre")]
        public string nombre { get; set; }
    }
}
