using ArdalisRating.Infrastureture;
using ArdalisRating.RaterPolicyFactory;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new Logger();
            log.LogInfo("Ardalis Insurance Rating System Starting...");
            IPolicyRaterFactory policyRaterFactory = new PolicyRaterFactory();
            IPolicyFileLoader policyFileLoader = new FilePolicyResource();
            IDeserializer deserializer = new SerializePolicyFile();
            IRatingContext ratingContext = new DefaultRatingContext(policyRaterFactory, deserializer, policyFileLoader, log);


            var engine = new RatingEngine(ratingContext);
            engine.Rate();

            if (engine.Rating > 0)
            {
                log.LogInfo($"Rating: {engine.Rating}");
            }
            else
            {
                log.LogInfo("No rating produced.");
            }

        }
    }
}
