namespace Naviam.DataAnalyzer.Services.WebApi.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Naviam.DataAnalyzer.Model.DataSource;

    public class DataSourceController : ApiController
    {
        /// <summary>
        /// data source repository.
        /// </summary>
        private readonly IDataSourceRepository repository;

        public DataSourceController(IDataSourceRepository repository)
        {
            this.repository = repository;
        }

        // GET api/datasource?id=880557C8E4FC4D199912CE215090DCBD
        public HttpResponseMessage Get(string id)
        {
            var data = this.repository.GetDataSource(id);

            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
                /*
                var notFoundMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                notFoundMessage.Headers.Add("InternalError", "Users not found");
                return notFoundMessage;
                */
            }

            var newMessage = this.Request.CreateResponse<DataSource>(HttpStatusCode.OK, /*there is ahould be mapping data object with domain object*/ data);
            return newMessage;
        }


        public HttpResponseMessage Get(int accountId)
        {
            return null;
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
