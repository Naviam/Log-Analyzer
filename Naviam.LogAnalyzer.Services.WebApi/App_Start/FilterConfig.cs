﻿using System.Web;
using System.Web.Mvc;

namespace Naviam.DataAnalyzer.Services.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}