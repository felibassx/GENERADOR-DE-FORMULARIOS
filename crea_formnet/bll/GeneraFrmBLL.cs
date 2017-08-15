using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using dto;

namespace bll
{
    public class GeneraFrmBLL
    {
        GeneraFrmDAL _dal;

        /// <summary>
        /// Obtener listado de tipos de control desde la capa de negocio
        /// </summary>
        /// <returns></returns>
        public IList<TipoCampoDTO> GetTipoCampoList()
        {
            try
            {
                _dal = new GeneraFrmDAL();
                return _dal.GetTipoCampoList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Obtener tipo de control desde la capa de negocio a través del id
        /// </summary>
        /// <returns></returns>
        public TipoCampoDTO GetTipoCampo(int id)
        {
            try
            {
                _dal = new GeneraFrmDAL();
                return _dal.GetTipoCampo(id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Obtener listado de eventos para controels js
        /// </summary>
        /// <returns></returns>
        public IList<EventoControlDTO> GetEventos()
        {
            try
            {
                _dal = new GeneraFrmDAL();
                return _dal.GetEventos();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +" Detalle: "+ ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Obtener listado de grupos
        /// </summary>
        /// <returns></returns>
        public IList<GrupoCtrlDTO> GetGrupoControl()
        {
            try
            {
                _dal = new GeneraFrmDAL();
                return _dal.GetGrupoControl();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }
    }
}
