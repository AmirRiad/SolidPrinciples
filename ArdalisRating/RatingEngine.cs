using ArdalisRating.Infrastureture;
using ArdalisRating.PolicyRater;
using ArdalisRating.RaterPolicyFactory;
using System;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }


        public IRatingContext Context { get; set; } 

        public RatingEngine(IRatingContext context)
        {
            Context = context;
        }

        public void Rate()
        {
            Context.LogInfo("Starting rate.");
            Context.LogInfo("Loading policy.");
            string policyJson = Context.LoadPolicyFile();
            var policy = Context.DeSerializePolicy(policyJson);
            var rater = Context.CreateRater(policy);
            rater.Rate(policy);
            Rating = rater.Rating;
            Context.LogInfo("Rating completed.");
        }


    

       


       

    }
}
