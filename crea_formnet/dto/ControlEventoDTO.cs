using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dto
{
    public class ControlEventoDTO
    {
        [SourceNames("id")]
        public int id { get; set; }

        [SourceNames("control_id")]
        public int control_id { get; set; }

        [SourceNames("nombre_fnc_js")]
        public string nombre_fnc_js { get; set; }

        [SourceNames("evento_control_id")]
        public int evento_control_id { get; set; }
    }
}
