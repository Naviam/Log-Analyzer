namespace Naviam.DataAnalyzer.Model.Account
{
    using System.Collections.Generic;
    using Naviam.DataAnalyzer.Model.DataSource;

    public class Account
    {
        public string Email { get; set; }

        public List<DataSource> DataSources { get; set; }

        public int Id { get; set; }
    }
}
