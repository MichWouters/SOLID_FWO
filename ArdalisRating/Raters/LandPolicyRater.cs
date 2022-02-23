namespace ArdalisRating.Raters
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(Policy policy) : base(policy)
        {
        }

        public override void Rate(RatingEngine engine)
        {
            Logger.Log("Rating LAND policy...");
            Logger.Log("Validating policy.");
            if (Policy.BondAmount == 0 || Policy.Valuation == 0)
            {
                Logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }

            if (Policy.BondAmount < 0.8m * Policy.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
                return;
            }

            engine.Rating = Policy.BondAmount * 0.05m;
        }
    }
}