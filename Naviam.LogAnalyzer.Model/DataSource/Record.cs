namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System.Collections.Generic;
    using Naviam.DataAnalyzer.Model.Filter;

    public class Record
    {
        public IEnumerable<Column> Columns { get; set; }

        public IEnumerable<MapInfo> Map { get; set; }

        public bool IsMatch(IEnumerable<Filter> filters)
        {
            throw new System.NotImplementedException();
        }

    }
}

