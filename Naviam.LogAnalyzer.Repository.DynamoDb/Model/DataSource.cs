namespace Naviam.DataAnalyzer.Repository.DynamoDb.Model
{
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable("DataSource")]
    public class DataSource
    {
        [DynamoDBRangeKey]
        public string Id { get; set; }
        [DynamoDBHashKey]
        public string AccountId { get; set; }
        
        // http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ArbitraryDataMappingHLAPI.html
        // [DynamoDBProperty(typeof(DimensionTypeConverter))]
        public string Map { get; set; }
        public string Name { get; set; }

        public int DataSourceType { get; set; }
        public string Info { get; set; }
       
    }
}
