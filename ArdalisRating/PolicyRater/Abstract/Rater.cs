namespace ArdalisRating.PolicyRater.Abstract
{
    public abstract class Rater
    {
        public decimal Rating { get; set; }

        public abstract void Rate(Policy policy);

    }
}
