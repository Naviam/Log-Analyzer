using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naviam.DataAnalyzer.Services.Messaging.DataSource
{
    public class AddDataSourceRequest
    {
        public string DataSourceName { get; set; }
        public string AccountId { get; set; }
    }
}
