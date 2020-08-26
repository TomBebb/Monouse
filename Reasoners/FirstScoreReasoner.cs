using System.Linq;
using Monuse.Considerations;

namespace Monuse.Reasoners
{
    /// <summary>
    ///     The first Consideration to score above the score of the Default Consideration is selected
    /// </summary>
    public class FirstScoreReasoner<T> : Reasoner<T>
    {
        protected override IConsideration<T> SelectBestConsideration(T context)
        {
            var defaultScore = DefaultConsideration.GetScore(context);

            var first = Considerations
                .FirstOrDefault(consideration => consideration.GetScore(context) >= defaultScore);

            return first ?? DefaultConsideration;
        }
    }
}