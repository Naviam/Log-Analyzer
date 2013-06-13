using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naviam.DataAnalyzer.Services.Contracts.DataSource;

namespace Naviam.DataAnalyzer.Services.Concrete
{
    public class DataSourceService:IDataSourceService
    {
        public Naviam.DataAnalyzer.Services.Messaging.DataSource.AddDataSourceResponse AddDataSource(Naviam.DataAnalyzer.Services.Messaging.DataSource.AddDataSourceRequest request)
        {
            throw new NotImplementedException();
        }

        public Naviam.DataAnalyzer.Services.Messaging.DataSource.GetUserDataSourcesResponse GetUserDataSource(Naviam.DataAnalyzer.Services.Messaging.DataSource.GetUserDataSourcesRequest request)
        {
            throw new NotImplementedException();
        }

        public Naviam.DataAnalyzer.Services.Messaging.DataSource.GetDataSourceByIdResponse GetDataSource(Naviam.DataAnalyzer.Services.Messaging.DataSource.GetDataSourceByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Naviam.DataAnalyzer.Services.Messaging.DataSource.RemoveDataSourceResponse RemoveDataSourse(Naviam.DataAnalyzer.Services.Messaging.DataSource.RemoveDataSourceRequest request)
        {
            throw new NotImplementedException();
        }

        public Naviam.DataAnalyzer.Services.Messaging.DataSource.ReceiveIncomingDataResponse ReceiveData(Naviam.DataAnalyzer.Services.Messaging.DataSource.ReceiveIncomingDataRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
