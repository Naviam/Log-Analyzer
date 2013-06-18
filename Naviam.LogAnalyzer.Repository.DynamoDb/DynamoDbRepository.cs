namespace Naviam.DataAnalyzer.Repository.DynamoDb
{
    using System;

    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;

    public class DynamoDbRepository
    {
        readonly AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();

        readonly AmazonDynamoDBClient client;

        protected readonly DynamoDBContext Context;

        public DynamoDbRepository()
        {
            this.client = new AmazonDynamoDBClient(config);
            this.Context = new DynamoDBContext(client);
        }

        public static string GetNewKey()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
