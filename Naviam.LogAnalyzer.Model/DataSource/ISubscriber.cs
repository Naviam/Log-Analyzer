namespace Naviam.DataAnalyzer.Model.DataSource
{
    public interface ISubscriber 
    {
        void Update(Record record);
    }
}

