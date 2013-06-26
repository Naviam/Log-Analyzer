namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System.Collections.Generic;
    using Naviam.DataAnalyzer.Model.Filter;

    public class DataSource
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Filter> Filters { get; set; }

        //TODO: create separate class for map
        public IEnumerable<MapInfo> Map { get; set; }

        public DataSourceTypes DataSourceType { get; set; }
    }
}

