using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dto
{
    public class ControlDTO
    {
        [SourceNames("id")]
        public int id { get; set; }

        [SourceNames("html_name")]
        public string html_name { get; set; }

        [SourceNames("html_id")]
        public string html_id { get; set; }

        [SourceNames("html_class")]
        public string html_class { get; set; }

        [SourceNames("html_required")]
        public string html_required { get; set; }

        [SourceNames("html_visible")]
        public string html_visible { get; set; }

        [SourceNames("html_value")]
        public string html_value { get; set; }

        [SourceNames("html_text")]
        public string html_text { get; set; }

        [SourceNames("html_largo")]
        public int html_largo { get; set; }

        [SourceNames("html_placeholder")]
        public string html_placeholder { get; set; }

        [SourceNames("tipo_campo_id")]
        public int tipo_campo_id { get; set; }

        [SourceNames("grupo_ctrl_id")]
        public int grupo_ctrl_id { get; set; }

    }
}
