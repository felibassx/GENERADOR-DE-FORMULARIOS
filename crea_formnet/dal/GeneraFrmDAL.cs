using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dto;


namespace dal
{
    public class GeneraFrmDAL
    {

        /// <summary>
        /// Obtener listado de tipos de control
        /// </summary>
        /// <returns></returns>
        public IList<TipoCampoDTO> GetTipoCampoList()
        {
            try
            {
                IList<TipoCampoDTO> listado = Helper.getObject<TipoCampoDTO>("sp_get_tipoCampo");
                return listado;
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
                Dictionary<string,object> parametros = new Dictionary<string,object>();
                parametros.Add("id",id);

                TipoCampoDTO obj = Helper.getObject<TipoCampoDTO>("sp_get_tipoCampoPorId",parametros,true);
                return obj;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Obtener listado de eventos
        /// </summary>
        /// <returns></returns>
        public IList<EventoControlDTO> GetEventos()
        {
            try
            {
                IList<EventoControlDTO> listado = Helper.getObject<EventoControlDTO>("sp_get_eventoControl");
                return listado;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
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
                IList<GrupoCtrlDTO> listado = Helper.getObject<GrupoCtrlDTO>("sp_get_grupoControles");
                return listado;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        public ControlDTO GetControl(int id)
        {
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("id_control", id);

                ControlDTO obj = Helper.getObject<ControlDTO>("sp_get_control_por_id", parametros, true);
                return obj;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

    }
}
