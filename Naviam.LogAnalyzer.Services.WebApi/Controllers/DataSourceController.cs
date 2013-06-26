namespace Naviam.DataAnalyzer.Services.WebApi.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Naviam.DataAnalyzer.Services.Contracts.DataSource;
    using Naviam.DataAnalyzer.Services.Messaging.DataSource;
    using Naviam.DataAnalyzer.Services.WebApi.Models.DataSource;

    public class DataSourceController : ApiController
    {
        /// <summary>
        /// data source repository.
        /// </summary>
        private readonly IDataSourceService _dataSourceService;

        public DataSourceController(IDataSourceService service)
        {
            this._dataSourceService = service;
        }

        // GET api/datasource?id=880557C8E4FC4D199912CE215090DCBD
        public HttpResponseMessage Get()
        {
            var data = this._dataSourceService.GetUserDataSources(new GetUserDataSourcesRequest { AccountId = "CA844F2109F848C1998DE9DB2116D6C2" });

            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var restMessage = this.Request.CreateResponse<GetUserDataSourcesResponse>(HttpStatusCode.OK, data);
            return restMessage;
        }

        // GET api/datasource?880557C8E4FC4D199912CE215090DCBD
        public HttpResponseMessage Get(string id)
        {
            var data = this._dataSourceService.GetDataSource(new GetDataSourceByIdRequest { Id = id, AccountId="CA844F2109F848C1998DE9DB2116D6C2" });

            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var restMessage = this.Request.CreateResponse<GetDataSourceByIdResponse>(HttpStatusCode.OK, data);
            return restMessage;
        }


        // POST api/datasource
        public HttpResponseMessage Post([FromBody]DataSourceViewModel model)
        {
            var request = new AddDataSourceRequest { DataSourceName = model.DataSourceName, AccountId = "CA844F2109F848C1998DE9DB2116D6C2" };

            var response = this._dataSourceService.AddDataSource(request);

            var restMessage = this.Request.CreateResponse<AddDataSourceResponse>(HttpStatusCode.OK, response);
            return restMessage;
        }

        // PUT api/datasource/5
        public HttpResponseMessage Put(string id, [FromBody]object value)
        {
            return null;
        }

        // DELETE api/datasource/5
        public HttpResponseMessage Delete(string id)
        {
            return null;
        }
    }
}
