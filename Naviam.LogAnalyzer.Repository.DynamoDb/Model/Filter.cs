namespace Naviam.DataAnalyzer.Repository.DynamoDb.Model
{
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable("Filter")]
    public class Filter
    {
        [DynamoDBHashKey]
        public string DataSourceId { get; set; }
        [DynamoDBRangeKey]
        public string Id { get; set; }

        public string Name { get; set; }

        // http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ArbitraryDataMappingHLAPI.html
        // [DynamoDBProperty(typeof(DimensionTypeConverter))]
        public string Criteria { get; set; }
    }
}
