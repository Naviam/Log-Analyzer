using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Naviam.DataAnalyzer.UI.Controllers
{
    public class DatasourceConnection:PersistentConnection
    {
        public static Dictionary<string, string> DataSourceConnectionMap
        {
            get
            {
                if (HttpContext.Current.Application["DataSourceConnectionMap"] == null) HttpContext.Current.Application["DataSourceConnectionMap"] = new Dictionary<string, string>();
                return HttpContext.Current.Application["DataSourceConnectionMap"] as Dictionary<string, string>;
            }
        }

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            var dsId = request.QueryString["datasourceId"];
            if (!DataSourceConnectionMap.Keys.Contains(dsId))
                DataSourceConnectionMap.Add(dsId, connectionId);
            return base.OnConnected(request, connectionId);
        }


    }
}
