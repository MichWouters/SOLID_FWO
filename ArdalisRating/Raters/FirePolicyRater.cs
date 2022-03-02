using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Raters
{
    internal class FirePolicyRater: Rater
    {
        public FirePolicyRater(Policy policy) : base(policy)
        {
        }

        public bool IsShitOnFire { get; set; } = true;

        public override void Rate(RatingEngine engine)
        {
            if (IsShitOnFire)
            {
                Console.WriteLine("AAAAAAAAAAAAAA");
            }
        }
    }
}
