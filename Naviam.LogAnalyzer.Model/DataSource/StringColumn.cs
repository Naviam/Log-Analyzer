namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System;

    using Naviam.DataAnalyzer.Model.Filter;

    public class StringColumn : Column
    {
        public string Value { get; set; }

        public override void Check(Condition condition)
        {
            throw new NotImplementedException();
        }
    }
}

