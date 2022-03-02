using ArdalisRating.Logging;
using System;

namespace ArdalisRating.Raters
{
    public class AutoPolicyRater: Rater
    {
        public AutoPolicyRater(Policy policy): base(policy)
        {
            
        }

        public override void Rate(RatingEngine engine)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(Policy.Make))
            {
                Logger.Log("Auto policy must specify Make");
                return;
            }
            if (Policy.Make == "BMW")
            {
                if (Policy.Deductible < 500)
                {
                    engine.Rating = 1000m;
                }
                engine.Rating = 900m;
            }
        }
    }
}