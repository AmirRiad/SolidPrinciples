using ArdalisRating.Infrastureture;
using ArdalisRating.PolicyRater.Abstract;
using ArdalisRating.RaterPolicyFactory;

namespace ArdalisRating
{
    public class DefaultRatingContext : IRatingContext
    {
        private readonly IDeserializer Deserializer;
        private readonly IPolicyFileLoader PolicyFileLoader;
        private readonly ILogger Logger;

        public IPolicyRaterFactory Factory { get; }

        public DefaultRatingContext(IPolicyRaterFactory _factory,IDeserializer _deserializer, IPolicyFileLoader _policyFileLoader,ILogger _logger)
        {
            Factory = _factory;
            Deserializer = _deserializer;
            PolicyFileLoader = _policyFileLoader;
            Logger = _logger;
        }

     

        public Rater CreateRater(Policy policy)
        {
           return Factory.CreateRater(policy);
        }

        
        public Policy DeSerializePolicy(string policyJson)
        {
           return Deserializer.DeSerializePolicy(policyJson);
        }

        public string LoadPolicyFile()
        {
           return PolicyFileLoader.LoadPolicyFile();
        }
        

       public void LogInfo(string message)
        {
             Logger.LogInfo(message);
        }

       
    }
}
