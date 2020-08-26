using System.Linq;
using Monuse.Considerations;

namespace Monuse.Reasoners
{
    /// <summary>
    ///     The Consideration with the highest score is selected
    /// </summary>
    public class HighestScoreReasoner<T> : Reasoner<T>
    {
        public HighestScoreReasoner(string name = null) : base(name)
        {
        }

        protected override IConsideration<T> SelectBestConsideration(T context)
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