namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System.Collections.Generic;

    public class DataSource : DataSourceBase
    {
        public object RequestParameters { get; set; }

        public object ResponseParameters { get; set; }

        public object Credentials { get; set; }

        public object Endpoint { get; set; }

        public IEnumerable<MapInfo> Map { get; set; }

        public void AddRequestParameter()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveRequestParameter()
        {
            throw new System.NotImplementedException();
        }

        public void AddResponseParameter()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveResponseParameter()
        {
            throw new System.NotImplementedException();
        }

    }
}

