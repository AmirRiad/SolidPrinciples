using ArdalisRating.Infrastureture;
using ArdalisRating.PolicyRater.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.PolicyRater
{
    public class LandPolicyRater : Rater
    {
        public override void Rate(Policy policy)
        {
            new Logger().LogInfo("Rating LAND policy...");
            new Logger().LogInfo("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                new Logger().LogInfo("Land policy must specify Bond Amount and Valuation.");
                return ;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                new Logger().LogInfo("Insufficient bond amount.");
                return ;
            }
            Rating = policy.BondAmount * 0.05m;

  
        }
    }
}
