using System;
using System.Linq;
using Monuse.Considerations;
using Monuse.Utils;

namespace Monuse.Reasoners
{
    /// <summaScory>
    ///     Chooses a random consideration based on its weight
    ///     </summary>
    ///     <typeparam name="TContext"></typeparam>
    public sealed class WeightBasedRandomReasoner<TContext> : Reasoner<TContext>
    {
        private readonly Random _rng;
        public readonly float Threshold;

        public WeightBasedRandomReasoner(Random rng, float threshold = 0f,
            string name = null) : base(name)
        {
            _rng = rng;
            Threshold = threshold;
        }

        protected override IConsideration<TContext> SelectBestConsideration(TContext context)
        {
            var scoresAndOptions = Considerations
                .Select(consideration => (consideration.GetScore(context), consideration))
                .Where(scoreConsideration => scoreConsideration.Item1 > Threshold)
                .ToArray();

            var totalScore = scoresAndOptions.Select(scoreAndOption => scoreAndOption.Item1).Sum();
            var destScore = _rng.Next(0f, totalScore);

            foreach (var scoreAndOption in scoresAndOptions)
            {
                float score;
                IConsideration<TContext> option;

                (score, option) = scoreAndOption;
                destScore -= score;

                if (!(destScore <= 0f)) continue;
                return option;
            }

            return null;
        }
    }
}