namespace Naviam.DataAnalyzer.Model.Filter
{
    using Naviam.DataAnalyzer.Model.DataSource;

    public class Condition
    {
        public string ColumnName { get; set; }

        public string StringValue { get; set; }

        public Operations Operation { get; set; }

    }
}

