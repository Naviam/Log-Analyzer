using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naviam.DataAnalyzer.Services.Messaging.DataSource;

namespace Naviam.DataAnalyzer.Services.Contracts.DataSource
{
    public interface IDataSourceService
    {
        AddDataSourceResponse AddDataSource(AddDataSourceRequest request);

        GetUserDataSourcesResponse GetUserDataSources(GetUserDataSourcesRequest request);

        GetDataSourceByIdResponse GetDataSource(GetDataSourceByIdRequest request);

        RemoveDataSourceResponse RemoveDataSourse(RemoveDataSourceRequest request);

        ReceiveIncomingDataResponse ReceiveData(ReceiveIncomingDataRequest request);
    }
}
