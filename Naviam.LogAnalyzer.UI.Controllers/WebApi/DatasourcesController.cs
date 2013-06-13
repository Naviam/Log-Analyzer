using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Naviam.DataAnalyzer.Services.Contracts.DataSource;

namespace Naviam.DataAnalyzer.UI.Controllers.WebApi
{
    public class DatasourcesController : ApiController, IDataSourceService 
    {
        public Services.Messaging.DataSource.AddDataSourceResponse AddDataSource(Services.Messaging.DataSource.AddDataSourceRequest request)
        {
 	        throw new NotImplementedException();
        }

        public Services.Messaging.DataSource.GetUserDataSourcesResponse GetUserDataSource(Services.Messaging.DataSource.GetUserDataSourcesRequest request)
        {
 	        throw new NotImplementedException();
        }
    }
}
