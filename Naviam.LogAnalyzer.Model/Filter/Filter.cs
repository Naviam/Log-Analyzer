namespace Naviam.DataAnalyzer.Model.Filter
{
    using System.Collections.Generic;

    public class Filter
    {
        public IEnumerable<Condition> Conditions { get; set; }

        public CompareOperations CompareOperetion { get; set; }

    }

}

