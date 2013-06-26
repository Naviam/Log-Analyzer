using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Naviam.DataAnalyzer.Services.WebApi.Models.Base;

namespace Naviam.DataAnalyzer.Services.WebApi.Models.DataSource
{
    public class DataSourceViewModel:ApiViewModel
    {
        public string DataSourceName { get; set; }
        public List<DataSourceMapInfo> Fields { get; set; }

    }
}