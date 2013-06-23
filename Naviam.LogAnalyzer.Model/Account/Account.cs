namespace Naviam.DataAnalyzer.Model.Account
{
    using System;
    using System.Collections.Generic;
    using Naviam.DataAnalyzer.Model.DataSource;

    public class Account
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime CreationDate { get; set; }

        public List<DataSource> DataSources { get; set; }
    }
}
