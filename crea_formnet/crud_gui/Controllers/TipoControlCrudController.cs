using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bll;
using bll.helpers;
using dto;

namespace crud_gui.Controllers
{
    public class TipoControlCrudController : ApiController
    {
        // GET: api/TipoControlCrud
        GeneraFrmBLL _bll;
        GeneraHtmlTag _htmltag;
            
       // GET: api/Default
        public IEnumerable<TipoCampoDTO> GetTipoCampo()
        {
            try
            {
                _bll = new GeneraFrmBLL();

                List<TipoCampoDTO> lista = (List<TipoCampoDTO>)_bll.GetTipoCampoList();

                return lista;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public IEnumerable<EventoControlDTO> GetEventos()
        {
            try
            {
                _bll = new GeneraFrmBLL();

                List<EventoControlDTO> lista = (List<EventoControlDTO>)_bll.GetEventos();

                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<GrupoCtrlDTO> GetGrupoControl()
        {
            try
            {
                _bll = new GeneraFrmBLL();

                List<GrupoCtrlDTO> lista = (List<GrupoCtrlDTO>)_bll.GetGrupoControl();

                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ControlDTO GetControlJson(int id)
        {
            try
            {
                _htmltag = new GeneraHtmlTag();

                return _htmltag.GeneraTagJson(id);
            } 
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }

        
    }
}
