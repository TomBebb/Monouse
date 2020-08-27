using System.Linq;
using Monuse.Considerations;

namespace Monuse.Reasoners
{
    /// <summary>
    ///     The first Consideration to score above the score of the Default Consideration is selected
    /// </summary>
    /// <typeparam name="TContext">The AI context.</typeparam>
    public class FirstScoreReasoner<TContext> : Reasoner<TContext>
    {
        public FirstScoreReasoner(string name) : base(name)
        {
        }

        protected override Consideration<TContext> SelectBestConsideration(TContext context)
        {
            base.SelectBestConsideration(context);
            var defaultScore = DefaultConsideration.GetScore(context);

            var first = Considerations
                .FirstOrDefault(consideration => consideration.GetScore(context) >= defaultScore);

            return first ?? DefaultConsideration;
        }
    }
}