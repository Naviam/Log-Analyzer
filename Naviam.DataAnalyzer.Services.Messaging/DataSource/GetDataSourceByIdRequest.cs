using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naviam.DataAnalyzer.Services.Messaging.DataSource
{
    public class GetDataSourceByIdRequest
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
    }
}
