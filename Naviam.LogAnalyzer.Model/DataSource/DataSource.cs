namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System;
    using System.Collections.Generic;
    using Naviam.DataAnalyzer.Model.Filter;

    public class DataSource
    {
        public Guid Id { get; set; }

        public List<Filter> Filters { get; set; }

        public IEnumerable<MapInfo> Map { get; set; }
    }
}

