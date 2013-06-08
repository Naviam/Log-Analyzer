namespace Naviam.DataAnalyzer.Model.DataSource
{
    using Naviam.DataAnalyzer.Model.Filter;

    public class IntColumn : Column
    {
        public int Value { get; set; }

        public override void Check(Condition condition)
        {
            throw new System.NotImplementedException();
        }

    }
}

