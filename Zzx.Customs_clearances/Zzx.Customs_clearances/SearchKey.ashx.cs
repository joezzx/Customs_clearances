using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Zzx.Customs_clearances
{
    /// <summary>
    /// Summary description for SearchKey1
    /// </summary>
    public class SearchKey : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var key = context.Request["Key"];
            ///....
            ///

            JsonTextWriter json = new JsonTextWriter(new System.IO.StreamWriter());
            json.WriteStartObject();
  
            //result
            context.Response.ContentType = "text/plain";
            context.Response.Write("aaaa");
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}