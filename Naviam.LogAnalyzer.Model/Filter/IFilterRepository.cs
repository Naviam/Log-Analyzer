namespace Naviam.DataAnalyzer.Model.Filter
{
    using System.Collections.Generic;

    public interface IFilterRepository
    {
        Filter GetFilter(string id, string dataSourceId);

        IEnumerable<Filter> GetFilters(string dataSourceId);

        string AddFilter(Filter filter, string dataSourceId);

        Filter UpdateFilter(Filter filter, string dataSourceId);

        void DeleteFilter(string id, string dataSourceId);

        void DeleteFilters(string dataSourceId);
    }
}
