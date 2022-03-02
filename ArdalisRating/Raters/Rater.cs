using ArdalisRating.Logging;

namespace ArdalisRating.Raters
{
    public abstract class Rater
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        public Policy Policy { get; private set; }

        protected Rater(Policy policy)
        {
            Policy = policy;
        }

        public abstract void Rate(RatingEngine engine);
    }
}