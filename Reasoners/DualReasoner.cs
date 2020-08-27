using System;
using System.Linq;
using Monuse.Considerations;

namespace Monuse.Reasoners
{
    public sealed class DualReasoner<TContext> : Reasoner<TContext>
    {
        
        private readonly Random _rng;

        public DualReasoner(Random rng, string name = null): base(name)
        {
            _rng = rng;
        }

        protected override IConsideration<TContext> SelectBestConsideration(TContext context)
        {
            var optionAndScores = Considerations
                
                .Select(consideration => (consideration.Evaluate(context), consideration))
                .Where(scoreConsideration => scoreConsideration.Item1.Weight > 0f)
                .ToArray();

            var highestRankedOptionAndScore = optionAndScores
                .OrderByDescending(optionAndScore => optionAndScore.Item1.Rank)
                .FirstOrDefault();
            
            var 
        }
    }
}