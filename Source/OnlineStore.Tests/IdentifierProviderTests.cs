namespace OnlineStore.Tests
{
    using NUnit.Framework;
    using Services;

    [TestFixture]
    class IdentifierProviderTests
    {
        [Test]
        public void EncodingAndDecodingDoesntChangeTheId()
        {
            const int Id = 6347;
            IIdentifierProvider provider = new IdentifierProvider();
            var encodedId = provider.EncodeId(Id);
            var decodedId = provider.DecodeId(encodedId);
            Assert.AreEqual(Id, decodedId);
        }
    }
}
