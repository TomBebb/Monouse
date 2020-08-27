using System.Linq;
using Monuse.Considerations;

namespace Monuse.Reasoners
{
    /// <summary>
    ///     The Consideration with the highest score is selected
    /// </summary>
    /// <typeparam name="TContext">The AI context.</typeparam>
    public class HighestScoreReasoner<TContext> : Reasoner<TContext>
    {
        public HighestScoreReasoner(string name = null) : base(name)
        {
        }

        protected override Consideration<TContext> SelectBestConsideration(TContext context)
        {
            var highest = Considerations
                .Select(consideration => (consideration.GetScore(context), consideration))
                .Where(scoreConsideration => scoreConsideration.Item1 > 0f)
                .OrderByDescending(scoreConsideration => scoreConsideration.Item1)
                .FirstOrDefault()
                .consideration;

            return highest ?? DefaultConsideration;
        }
    }
}