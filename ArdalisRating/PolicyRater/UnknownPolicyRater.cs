using ArdalisRating.Infrastureture;
using ArdalisRating.PolicyRater.Abstract;

namespace ArdalisRating.PolicyRater
{
    public class UnknownPolicyRater : Rater
    {
        public override void Rate(Policy policy)
        {
            new Logger().LogInfo("Unknown policy type");
        }
    }
}
