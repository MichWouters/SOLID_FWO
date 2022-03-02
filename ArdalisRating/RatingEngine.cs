using ArdalisRating.Factory;
using ArdalisRating.Logging;
using ArdalisRating.Persistence;
using ArdalisRating.Raters;
using ArdalisRating.Serialization;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource FileSource { get; set; } = new FilePolicySource();
        public JsonPolicySerializer JsonSerializer { get; set; } = new JsonPolicySerializer();

        public decimal Rating { get; set; }
        
        public void Rate()
        {
            // Logging
            Logger.Log("Starting rate."); 
            Logger.Log("Loading policy.");

            // Persistence
            string policyJson = FileSource.GetPolicyFromSource("policy.json");

            // Serialization
            Policy policy = JsonSerializer.GetPolicyFromJsonString(policyJson);

            // Create Rater
            var factory = new RaterFactory();
            Rater rater = factory.Create(policy);
            rater.Rate(this);

            Logger.Log("Rating completed.");
        }
    }
}
