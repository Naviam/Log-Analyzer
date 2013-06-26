using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naviam.DataAnalyzer.Model.DataSource;
using Naviam.DataAnalyzer.Services.Contracts.DataSource;
using Naviam.DataAnalyzer.Services.Messaging.DataSource;
using Naviam.DataAnalyzer.Services.MappingExtensions;

namespace Naviam.DataAnalyzer.Services.Concrete
{
    public class DataSourceService : IDataSourceService
    {
        private readonly IDataSourceRepository _dsRepo;

        public DataSourceService (IDataSourceRepository datasourceRepository)
        {
            this._dsRepo = datasourceRepository;
        }

        public AddDataSourceResponse AddDataSource(AddDataSourceRequest request)
        {
            var result = this._dsRepo.AddDataSource(new DataSource { DataSourceType = DataSourceTypes.Unknown, Name = request.DataSourceName }, request.AccountId);
            return new AddDataSourceResponse { Id = result };
        }

        public GetUserDataSourcesResponse GetUserDataSources(GetUserDataSourcesRequest request)
        {
            var result = this._dsRepo.GetDataSources(request.AccountId);
            var response = result.ConvertToGetUserDataSourcesResponse();
            return response;
        }

        public GetDataSourceByIdResponse GetDataSource(GetDataSourceByIdRequest request)
        {
            var result = this._dsRepo.GetDataSource(request.Id, request.AccountId);
            var response = result.ConvertToGetDataSourceByIdResponse();
            return response;
        }

        public Naviam.DataAnalyzer.Services.Messaging.DataSource.RemoveDataSourceResponse RemoveDataSourse(RemoveDataSourceRequest request)
        {
            throw new NotImplementedException();
        }

        public Naviam.DataAnalyzer.Services.Messaging.DataSource.ReceiveIncomingDataResponse ReceiveData(ReceiveIncomingDataRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
