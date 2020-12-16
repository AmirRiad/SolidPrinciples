using ArdalisRating.Infrastureture;
using ArdalisRating.PolicyRater.Abstract;
using System;

namespace ArdalisRating.PolicyRater
{
    public class AutoPolicyRater : Rater
    {
        public override void Rate(Policy policy)
        {
            new Logger().LogInfo("Rating AUTO policy...");
            new Logger().LogInfo("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                new Logger().LogInfo("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    Rating = 1000m;
                    return ;
                }
                Rating = 900m;
            }

        
        }
    }
}
