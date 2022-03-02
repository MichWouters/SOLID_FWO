using System;
using ArdalisRating.Raters;

namespace ArdalisRating.Factory
{
    public class RaterFactory
    {
        public Rater Create(Policy policy)
        {
            switch (policy.Type)
            {
                // 3. Business Logic
                case PolicyType.Auto:
                    return new AutoPolicyRater(policy);
                case PolicyType.Land:
                    return new LandPolicyRater(policy);
                case PolicyType.Life:
                    return new LifePolicyRater(policy);
                case PolicyType.Fire:
                    return new FirePolicyRater(policy);
                default:
                    throw new ArgumentException("Unknown policy");
            }
        }
    }
}
