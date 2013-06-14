namespace Naviam.DataAnalyzer.Services.WebApi.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Naviam.DataAnalyzer.Services.Contracts.DataSource;
    using Naviam.DataAnalyzer.Services.Messaging.DataSource;

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
        public HttpResponseMessage Get(Guid id)
        {
            var data = this._dataSourceService.GetDataSource(new GetDataSourceByIdRequest { Id = id });

            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var newMessage = this.Request.CreateResponse<GetDataSourceByIdResponse>(HttpStatusCode.OK, data);
            return newMessage;
        }


        // POST api/datasource
        public HttpResponseMessage Post([FromBody]object value)
        {
            return null;
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
