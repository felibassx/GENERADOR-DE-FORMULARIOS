using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dto;
using dal;
using System.Web.Script.Serialization;

namespace bll.helpers
{
    public class GeneraHtmlTag
    {
        public ControlDTO GeneraTagJson(int id)
        {
            GeneraFrmDAL bll = new GeneraFrmDAL();
            return bll.GetControl(id);
        }

    }
}
