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

        public WeightBasedRandomReasoner(string name, Random rng, Consideration<TContext> defaultConsideration,
            float threshold = 0f) : base(name, defaultConsideration)
        {
            _rng = rng;
            Threshold = threshold;
        }

        protected override Consideration<TContext> SelectBestConsideration(TContext context)
        {
            base.SelectBestConsideration(context);
            var scoresAndOptions = AllConsiderations
                .Select(consideration => (consideration.GetScore(context), consideration))
                .Where(scoreConsideration => scoreConsideration.Item1 > Threshold)
                .ToArray();

            var totalScore = scoresAndOptions.Select(scoreAndOption => scoreAndOption.Item1).Sum();
            var destScore = _rng.Next(0f, totalScore);

            Console.WriteLine($"Total score: {totalScore}; Chosen: {destScore}");

            foreach (var scoreAndOption in scoresAndOptions)
            {
                float score;
                Consideration<TContext> option;

                (score, option) = scoreAndOption;
                destScore -= score;

                if (!(destScore <= 0f)) continue;
                Console.WriteLine($"Chosen: {option}");
                return option;
            }

            return null;
        }
    }
}