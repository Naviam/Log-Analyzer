namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System;
    using System.Collections.Generic;
    using Naviam.DataAnalyzer.Model.Filter;

    public class DataSourceBase
    {
        public Guid Id { get; set; }

        public List<Filter> Filters { get; set; }

        public virtual object Name
        {
            get;
            set;
        }

        public virtual object Account
        {
            get;
            set;
        }
    }
}

