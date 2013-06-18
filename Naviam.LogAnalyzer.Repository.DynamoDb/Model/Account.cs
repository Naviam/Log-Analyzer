namespace Naviam.DataAnalyzer.Repository.DynamoDb.Model
{
    using System;

    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable("Account")]
    public class Account
    {
        [DynamoDBHashKey]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
