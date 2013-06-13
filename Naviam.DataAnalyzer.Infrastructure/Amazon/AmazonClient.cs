namespace Naviam.DataAnalyzer.Infrastructure.Amazon
{
    public class AmazonClient: IAmazonConfigurable
    {
        public string AmazonPublicKey { get; set; }

        public string AmazonPrivateKey { get; set; }

        public void Initialize(string amazonPublicKey, string amazonPrivateKey)
        {
            throw new System.NotImplementedException();
        }
    }
}
