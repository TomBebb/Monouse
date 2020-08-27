using System;
using System.Linq;
using Monuse.Considerations;

namespace Monuse.Reasoners
{
    /// <summary>
    ///     Selects a random score above a threshold.
    /// </summary>
    /// <typeparam name="TContext">The AI context.</typeparam>
    public class RandomScoreAboveThresholdReasoner<TContext> : Reasoner<TContext>
    {
        private readonly Random _rng;
        public readonly float Threshold;

        public RandomScoreAboveThresholdReasoner(Random rng, float threshold = 0f, bool debugEnabled = false,
            string name = null) : base(name)
        {
            _rng = rng;
            Threshold = threshold;
        }

        protected override Consideration<TContext> SelectBestConsideration(TContext context)
        {
            var options = Considerations
                .Select(consideration => (consideration.GetScore(context), consideration))
                .Where(scoreConsideration => scoreConsideration.Item1 > Threshold)
                .Select(scoreConsideration => scoreConsideration.consideration)
                .ToArray();

            return options.Length == 0 ? DefaultConsideration : options[_rng.Next(options.Length)];
        }
    }
}