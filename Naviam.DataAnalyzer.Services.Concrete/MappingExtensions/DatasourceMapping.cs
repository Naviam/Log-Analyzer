using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Naviam.DataAnalyzer.Services.Messaging.DataSource;
using Naviam.DataAnalyzer.Model.DataSource;

namespace Naviam.DataAnalyzer.Services.MappingExtensions
{
    public static class DatasourceMapping
    {
        public static GetDataSourceByIdResponse ConvertToGetDataSourceByIdResponse(this DataSource source)
        {
            return Mapper.Map<DataSource, GetDataSourceByIdResponse>(source);
        }

        public static GetUserDataSourcesResponse ConvertToGetUserDataSourcesResponse(this IEnumerable<DataSource> source)
        {
            return Mapper.Map<IEnumerable<DataSource>, GetUserDataSourcesResponse>(source);
        }
    }
}