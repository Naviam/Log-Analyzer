namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System;

    using Naviam.DataAnalyzer.Model.Filter;

    public class DateColumn : Column
    {
        public DateTime Value { get; set; }

        public override void Check(Criterion criterion)
        {
            throw new NotImplementedException();
        }

    }

}

