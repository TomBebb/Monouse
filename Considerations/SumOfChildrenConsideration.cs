using System.Linq;

namespace Monuse.Considerations
{
    public class SumOfChildrenConsideration<T> : BaseConsideration<T>
    {
        public SumOfChildrenConsideration(string name) : base(name)
        {
        }

        public override float GetScore(T context)
        {
            return Appraisals.Aggregate(0f, (current, t) => current + t.GetScore(context));
        }
    }
}