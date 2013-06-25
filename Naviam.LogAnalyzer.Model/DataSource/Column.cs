namespace Naviam.DataAnalyzer.Model.DataSource
{
    using Naviam.DataAnalyzer.Model.Filter;

    public abstract class Column : IFiltrableColumn
    {
        public string Name { get; set; }

        public abstract void Check(Criterion criterion);
    }
}

