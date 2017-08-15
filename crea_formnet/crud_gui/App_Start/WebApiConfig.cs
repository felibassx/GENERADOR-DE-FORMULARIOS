using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace crud_gui
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            

            config.Routes.MapHttpRoute(
                  name: "HolaMundo",
                  routeTemplate: "api/{controller}/{action}/{id}",
                  defaults: new { controller = "TipoControlCrud", action = "HolaMundo", id = RouteParameter.Optional }
              );

            config.Routes.MapHttpRoute(
                  name: "TipoCampo",
                  routeTemplate: "api/{controller}/{action}/{id}",
                  defaults: new { controller = "TipoControlCrud", action = "GetTipoCampo", id = RouteParameter.Optional }
              );

            config.Routes.MapHttpRoute(
                  name: "Eventos",
                  routeTemplate: "api/{controller}/{action}/{id}",
                  defaults: new { controller = "TipoControlCrud", action = "GetEventos", id = RouteParameter.Optional }
              );

            config.Routes.MapHttpRoute(
                  name: "GrupoControl",
                  routeTemplate: "api/{controller}/{action}/{id}",
                  defaults: new { controller = "TipoControlCrud", action = "GetGrupoControl", id = RouteParameter.Optional }
              );

            config.Routes.MapHttpRoute(
                  name: "GetControlJson",
                  routeTemplate: "api/{controller}/{action}/{id}",
                  defaults: new { controller = "TipoControlCrud", action = "GetControlJson", id = RouteParameter.Optional }
              );
        }
    }
}
