using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bll;
using dto;

namespace test_crear_form.Controllers
{
    public class DefaultController : ApiController
    {
        GeneraFrmBLL _bll;
        // GET: api/Default
        public IEnumerable<TipoCampoDTO> Get()
        {
            _bll = new GeneraFrmBLL();

            List<TipoCampoDTO> lista = (List<TipoCampoDTO>)_bll.GetTipoCampoList();

            return lista;
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
