using ArdalisRating.PolicyRater;
using ArdalisRating.PolicyRater.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.RaterPolicyFactory
{
    public class PolicyRaterFactory : IPolicyRaterFactory
    {

        public Rater CreateRater(Policy policy)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.PolicyRater.{policy.Type}PolicyRater"),
                        null);
            }
            catch
            {
                return new UnknownPolicyRater();
            }
        }
    }

    public interface IPolicyRaterFactory
    {
        Rater CreateRater(Policy policy);
    }
}
