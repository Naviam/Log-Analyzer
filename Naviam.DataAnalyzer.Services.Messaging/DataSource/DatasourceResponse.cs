using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naviam.DataAnalyzer.Services.Messaging.DataSource
{
    public class DatasourceResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<MapInfoResponse> Fields { get; set; }
    }

    public class MapInfoResponse
    {
        public string Id { get; set; }
        public string FieldName { get; set; }
        public int FieldType { get; set; }
    }
}
