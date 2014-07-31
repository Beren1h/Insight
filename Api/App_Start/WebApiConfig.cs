using Api.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //JsonSerializerSettings jSettings = new Newtonsoft.Json.JsonSerializerSettings();
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jSettings;
            //config.Formatters.Clear();
            //config.Formatters.Add(new Abc());

            //config.Formatters.Add(new BsonMediaTypeFormatter());
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
            //config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new ObjectIdJsonConverter());

            config.EnableCors();

            //config.Formatters.FormUrlEncodedFormatter.AddRequestHeaderMapping("", "", "", true, new MediaTypeHeaderValue("application/x-www-form-urlencoded"));
                       

            //config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings();
                        //config.Formatters.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
            //config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            //config.Formatters.JsonFormatter.AddQueryStringMapping("returnType", "json", "application/json");
            //config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            //config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            


            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
