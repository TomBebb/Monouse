using System;
using System.Linq;
using Monuse.Considerations;
using Monuse.Utils;

namespace Monuse.Reasoners
{
    public sealed class WeightBasedRandomReasoner<T> : Reasoner<T>
    {
        private readonly Random _rng;
        public readonly float Threshold;

        public WeightBasedRandomReasoner(Random rng, float threshold = 0f,
            string name = null) : base(name)
        {
            _rng = rng;
            Threshold = threshold;
        }

        protected override IConsideration<T> SelectBestConsideration(T context)
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
                IConsideration<T> option;
                
                (score, option) = scoreAndOption;
                destScore -= score;

                if (!(destScore <= 0f)) continue;
                return option;
            }

            return null;
        }
    }
}