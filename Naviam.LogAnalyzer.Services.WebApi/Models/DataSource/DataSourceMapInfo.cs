using Naviam.DataAnalyzer.Services.WebApi.Models.Base;

namespace Naviam.DataAnalyzer.Services.WebApi.Models.DataSource
{
    public class DataSourceMapInfo:ApiViewModel
    {
        public int FieldType { get; set; }
        public string FieldName { get; set; }
    }
}