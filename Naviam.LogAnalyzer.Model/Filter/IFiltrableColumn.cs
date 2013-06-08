namespace Naviam.DataAnalyzer.Model.Filter
{
    public interface IFiltrableColumn
    {
        void Check(Condition condition);
    }
}
