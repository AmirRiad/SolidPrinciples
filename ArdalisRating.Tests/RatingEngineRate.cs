using ArdalisRating.Infrastureture;
using ArdalisRating.RaterPolicyFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;

namespace ArdalisRating.Tests
{
    [TestClass]
    public class RatingEngineRate
    {
[TestMethod]
public void ReturnsRatingOf10000For200000LandPolicy()
{
    var policy = new Policy
    {
        Type = PolicyType.Land,
        BondAmount = 200000,
        Valuation = 200000
    };
    string json = JsonConvert.SerializeObject(policy);
    File.WriteAllText("policy.json", json);

            ILogger log = new Logger();
            IPolicyRaterFactory policyRaterFactory = new PolicyRaterFactory();
            IPolicyFileLoader policyFileLoader = new FilePolicyResource();
            IDeserializer deserializer = new SerializePolicyFile();
            IRatingContext context = new DefaultRatingContext(policyRaterFactory, deserializer, policyFileLoader, log);
            var engine = new RatingEngine(context);
            engine.Rate();
    var result = engine.Rating;

    Assert.AreEqual(10000, result);
}

        [TestMethod]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);
            ILogger log = new Logger();
            IPolicyRaterFactory policyRaterFactory = new PolicyRaterFactory();
            IPolicyFileLoader policyFileLoader = new FilePolicyResource();
            IDeserializer deserializer = new SerializePolicyFile();
            IRatingContext context = new DefaultRatingContext(policyRaterFactory, deserializer, policyFileLoader, log);
            var engine = new RatingEngine(context);
            engine.Rate();
            var result = engine.Rating;

            Assert.AreEqual(0, result);
        }
    }
}
