using ArdalisRating.Infrastureture;
using ArdalisRating.PolicyRater.Abstract;
using System;

namespace ArdalisRating.PolicyRater
{
    public class LifePolicyRater : Rater
    {
        public override void Rate(Policy policy)
        {
            new Logger().LogInfo("Rating LIFE policy...");
            new Logger().LogInfo("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                new Logger().LogInfo("Life policy must include Date of Birth.");
                return ;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                new Logger().LogInfo("Centenarians are not eligible for coverage.");
                return ;
            }
            if (policy.Amount == 0)
            {
                new Logger().LogInfo("Life policy must include an Amount.");
                return ;
            }
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                Rating = baseRate * 2;
                return;
            }
            Rating = baseRate;
        }
    }
}
