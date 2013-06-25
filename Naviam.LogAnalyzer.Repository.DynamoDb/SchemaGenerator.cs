namespace Naviam.DataAnalyzer.Repository.DynamoDb
{
    using System.Collections.Generic;
    using Amazon.DynamoDBv2.Model;
    using Naviam.DataAnalyzer.Infrastructure.Amazon;

    public class SchemaGenerator
    {
        private readonly DynamoDbClient client;

        public SchemaGenerator()
        {
            client = new DynamoDbClient();
        }

        public void Generate()
        {
            var tables = client.GetTableList();

            // drop tables
            if (tables.Contains("Account"))
            {
                client.DropTableReadyForUse(new DeleteTableRequest { TableName = "Account" });
            }

            if (tables.Contains("DataSource"))
            {
                client.DropTableReadyForUse(new DeleteTableRequest { TableName = "DataSource" });
            }

            if (tables.Contains("Filter"))
            {
                client.DropTableReadyForUse(new DeleteTableRequest { TableName = "Filter" });
            }

            // creat DataSource table
            client.CreateTable(new CreateTableRequest
            {
                TableName = "DataSource",
                AttributeDefinitions = new List<AttributeDefinition>
                                                                    { 
                                                                      new AttributeDefinition { AttributeName = "Id", AttributeType = "S" }, 
                                                                      new AttributeDefinition { AttributeName = "AccountId", AttributeType = "S" } 
                                                                    },
                KeySchema = new List<KeySchemaElement>
                                                            {
                                                                new KeySchemaElement{ AttributeName = "AccountId", KeyType = "HASH"},
                                                                new KeySchemaElement{ AttributeName = "Id", KeyType = "RANGE"}
                                                            },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 10,
                    WriteCapacityUnits = 5
                }
            });

            // creat Account table
            this.client.CreateTable(new CreateTableRequest
                                                        {
                                                            TableName = "Account",
                                                            KeySchema = new List<KeySchemaElement>
                                                                            {
                                                                                new KeySchemaElement{ AttributeName = "Email", KeyType = "HASH"}
                                                                            },
                                                            AttributeDefinitions = new List<AttributeDefinition>
                                                                                    { 
                                                                                        new AttributeDefinition { AttributeName = "Email", AttributeType = "S" } 
                                                                                    },
                                                            ProvisionedThroughput = new ProvisionedThroughput
                                                                                        {
                                                                                            ReadCapacityUnits = 10,
                                                                                            WriteCapacityUnits = 5
                                                                                        }
                                                        });

            // creat Filter table
            client.CreateTable(new CreateTableRequest
                                    {
                                        TableName = "Filter",
                                        AttributeDefinitions = new List<AttributeDefinition>
                                                                        { 
                                                                          new AttributeDefinition { AttributeName = "Id", AttributeType = "S" }, 
                                                                          new AttributeDefinition { AttributeName = "DataSourceId", AttributeType = "S" } 
                                                                        },
                                        KeySchema = new List<KeySchemaElement>
                                                                {
                                                                    new KeySchemaElement{ AttributeName = "DataSourceId", KeyType = "HASH"},
                                                                    new KeySchemaElement{ AttributeName = "Id", KeyType = "RANGE"}
                                                                },
                                        ProvisionedThroughput = new ProvisionedThroughput
                                        {
                                            ReadCapacityUnits = 10,
                                            WriteCapacityUnits = 5
                                        }
                                    });
        }
    }
}
