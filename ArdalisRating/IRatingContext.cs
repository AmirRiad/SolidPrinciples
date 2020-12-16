using ArdalisRating.Infrastureture;
using ArdalisRating.PolicyRater.Abstract;

namespace ArdalisRating
{
    public interface IRatingContext : ILogger, IDeserializer, IPolicyFileLoader
    {
        Rater CreateRater(Policy policy);
        
    }

    public interface IDeserializer
    {
        Policy DeSerializePolicy(string policyJson);
    }

    public  interface IPolicyFileLoader
    {
        string LoadPolicyFile();
    }
}
