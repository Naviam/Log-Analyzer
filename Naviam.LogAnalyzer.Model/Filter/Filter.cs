namespace Naviam.DataAnalyzer.Model.Filter
{
    using System.Collections.Generic;

    public class Filter
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Criterion> Criteria { get; set; }

        public CompareOperations CompareOperetion { get; set; }

    }

}

