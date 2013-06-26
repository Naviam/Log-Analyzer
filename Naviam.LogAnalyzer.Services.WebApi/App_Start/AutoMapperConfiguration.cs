using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Naviam.DataAnalyzer.Model.DataSource;
using Naviam.DataAnalyzer.Services.Messaging.DataSource;
using Naviam.DataAnalyzer.Services.WebApi.Models.DataSource;

namespace Naviam.DataAnalyzer.Services.WebApi.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ConfigureDataSourceMapping();
        }

        private static void ConfigureDataSourceMapping()
        {
            Mapper.CreateMap<DataSource, DatasourceResponse>();
            Mapper.CreateMap<DataSource, GetDataSourceByIdResponse>();
            Mapper.CreateMap<IEnumerable<DataSource>, GetUserDataSourcesResponse>().ForMember(
                resp => resp.DataSources, opt => opt.MapFrom(source => source));
        }
    }
}