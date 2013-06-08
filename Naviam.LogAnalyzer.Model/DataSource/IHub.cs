namespace Naviam.DataAnalyzer.Model.DataSource
{
    using System.Collections.Generic;

    public interface IHub 
    {
        IEnumerable<ISubscriber> ActiveConnections { get;set; }

        void RegisterSubscriber(ISubscriber subscriber);

        void UnregisterSubscriber(ISubscriber subscriber);

        void NotifySubscribers();

    }
}

