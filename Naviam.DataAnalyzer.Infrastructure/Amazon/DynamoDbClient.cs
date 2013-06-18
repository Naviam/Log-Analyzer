namespace Naviam.DataAnalyzer.Infrastructure.Amazon
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using global::Amazon.DynamoDBv2;
    using global::Amazon.DynamoDBv2.Model;

    public class DynamoDbClient : IDisposable
    {
        private const int UpdateStatusRepeatCount = 12;
        private const int UpdateStatusRepeatTimeOut = 10000;

        readonly AmazonDynamoDBClient client = null;

        public DynamoDbClient()
            : base()
        {
            var config = new AmazonDynamoDBConfig();
            client = new AmazonDynamoDBClient(config);
        }

        public CreateTableResponse CreateTable(CreateTableRequest request)
        {
            return client.CreateTable(request);
        }

        public bool CreateTableAndReadyForUse(CreateTableRequest request)
        {
            var status = client.CreateTable(request).CreateTableResult.TableDescription.TableStatus;
            var count = 0;
            while (!status.Equals("ACTIVE", StringComparison.InvariantCultureIgnoreCase) && count < UpdateStatusRepeatCount)
            {
                Thread.Sleep(UpdateStatusRepeatTimeOut);
                status = client.DescribeTable(new DescribeTableRequest { TableName = request.TableName }).DescribeTableResult.Table.TableStatus;
                count++;
            }
            return (status.Equals("ACTIVE", StringComparison.InvariantCultureIgnoreCase));
        }

        public DeleteTableResponse DropTable(DeleteTableRequest request)
        {
            return client.DeleteTable(request);
        }

        public bool DropTableReadyForUse(DeleteTableRequest request)
        {
            var count = 0;
            var list = client.ListTables(new ListTablesRequest()).ListTablesResult.TableNames;
            if (list.Contains(request.TableName))
            {
                client.DeleteTable(request);
            }

            while (list.Contains(request.TableName) && count < UpdateStatusRepeatCount)
            {
                Thread.Sleep(UpdateStatusRepeatTimeOut);
                list = client.ListTables(new ListTablesRequest()).ListTablesResult.TableNames;
                count++;
            }

            return list.Contains(request.TableName);
        }

        public DescribeTableResponse GetDescriptionTable(DescribeTableRequest request)
        {
            return client.DescribeTable(request);
        }

        public List<string> GetTableList()
        {
            return client.ListTables(new ListTablesRequest()).ListTablesResult.TableNames;
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
