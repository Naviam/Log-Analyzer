namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System;

    using Naviam.DataAnalyzer.Model.Filter;

    public class StringColumn : Column
    {
        public string Value { get; set; }

        public override void Check(Criterion criterion)
        {
            throw new NotImplementedException();
        }
    }
}

