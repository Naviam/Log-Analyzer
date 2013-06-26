namespace Naviam.DataAnalyzer.Model.Filter
{
    using Naviam.DataAnalyzer.Model.DataSource;

    public class Criterion
    {
        public string ColumnName { get; set; }

        public string StringValue { get; set; }

        public bool IsExclude { get; set; }

        public Operations Operation { get; set; }

    }
}

