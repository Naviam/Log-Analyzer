namespace Naviam.DataAnalyzer.Repository.DynamoDb
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Naviam.DataAnalyzer.Model.Filter;
    using DynamoDb = Naviam.DataAnalyzer.Repository.DynamoDb.Model;

    public class FilterRepository: DynamoDbRepository, IFilterRepository
    {
        public Filter GetFilter(string id, string dataSourceId)
        {
            var result = this.Context.Load<DynamoDb.Filter>(dataSourceId, id);
            return Mapper.Map<DynamoDb.Filter, Filter>(result);
        }

        public IEnumerable<Filter> GetFilters(string dataSourceId)
        {
            var res = this.Context.Query<DynamoDb.Filter>(dataSourceId).ToList();
            return res.Select(Mapper.Map<DynamoDb.Filter, Filter>);
        }

        public string AddFilter(Filter filter, string dataSourceId)
        {
            if (string.IsNullOrEmpty(filter.Id))
            {
                filter.Id = GetNewKey();
            }
            var flt = Mapper.Map<Filter, DynamoDb.Filter>(filter);
            flt.DataSourceId = dataSourceId;
            this.Context.Save(flt);
            return filter.Id;
        }

        public Filter UpdateFilter(Filter filter, string dataSourceId)
        {
            var flt = Mapper.Map<Filter, DynamoDb.Filter>(filter);
            flt.DataSourceId = dataSourceId;
            this.Context.Save(flt);
            return filter;

        }

        public void DeleteFilter(string id, string dataSourceId)
        {
            this.Context.Delete<DynamoDb.Filter>(dataSourceId, id);
        }

        public void DeleteFilters(string dataSourceId)
        {
            foreach (var var in this.GetFilters(dataSourceId))
            {
                this.Context.Delete<DynamoDb.Filter>(dataSourceId,var.Id);
            }
        }
    }
}
