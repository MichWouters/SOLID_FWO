using System;

namespace ArdalisRating.Raters
{
    internal class LifePolicyRater : Rater
    {
        public LifePolicyRater(Policy policy)
            : base(policy)
        {
        }

        public override void Rate(RatingEngine engine)
        {
            Logger.Log("Rating LIFE policy...");
            Logger.Log("Validating policy.");
            if (Policy.DateOfBirth == DateTime.MinValue)
            {
                Logger.Log("Life policy must include Date of Birth.");
                return;
            }
            if (Policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                Logger.Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (Policy.Amount == 0)
            {
                Logger.Log("Life policy must include an Amount.");
                return;
            }
            int age = DateTime.Today.Year - Policy.DateOfBirth.Year;
            if (Policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < Policy.DateOfBirth.Day ||
                DateTime.Today.Month < Policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = Policy.Amount * age / 200;
            if (Policy.IsSmoker)
            {
                engine.Rating = baseRate * 2;
            }
            engine.Rating = baseRate;
        }
    }
}