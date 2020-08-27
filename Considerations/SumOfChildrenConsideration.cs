using System.Linq;
using Monuse.Actions;

namespace Monuse.Considerations
{
    /// <summary>
    ///     Calculates score by adding scores of appraisals.
    /// </summary>
    /// <typeparam name="TContext">The AI context</typeparam>
    public class SumOfChildrenConsideration<TContext> : AppraisalConsideration<TContext>
    {
        public SumOfChildrenConsideration(string name, Action<TContext> action) : base(name, action)
        {
        }

        public override float GetScore(TContext context)
        {
            return Appraisals.Aggregate(0f, (current, t) => current + t.GetScore(context));
        }
    }
}