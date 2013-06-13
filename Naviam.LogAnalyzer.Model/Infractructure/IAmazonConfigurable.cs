namespace Naviam.DataAnalyzer.Model.Infractructure
{
    public interface IAmazonConfigurable
    {
        /// <summary>
        /// Gets or sets the amazon public key.
        /// </summary>
        string AmazonPublicKey { get; set; }

        /// <summary>
        /// Gets or sets the amazon private key.
        /// </summary>
        string AmazonPrivateKey { get; set; }

        void Initialize(string amazonPublicKey, string amazonPrivateKey);
    }
}
