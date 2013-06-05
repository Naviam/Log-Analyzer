using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Linq;

namespace Naviam.DataAnalyzer.UI.Controllers
{
    public class TestApiController : ApiController
    {
        // POST api/<controller>
        public void Post(string userId, string datasourceId, [FromBody]JObject value)
        {
            var conid = DatasourceConnection.DataSourceConnectionMap[datasourceId];
            
            var connection = GlobalHost.ConnectionManager.GetConnectionContext<DatasourceConnection>();
            connection.Connection.Send(conid, value);
            //connection.Connection.Broadcast(value);
        }
   }
}