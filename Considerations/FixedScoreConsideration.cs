using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monuse.Actions;
using Monuse.Considerations.Appraisals;

namespace Monuse.Considerations
{
    /// <summary>
    ///     A choice with a fixed score.
    ///     Suitable for testing certain scenarios.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class FixedScoreConsideration<TContext> : Consideration<TContext>
    {
        /// <summary>
        ///     The score of this consideration.
        /// </summary>
        public readonly float Score;

        public FixedScoreConsideration(string name, float score = 1f, Action<TContext> action = null) : base(name,
            action)
        {
            Score = score;
        }

        public virtual IEnumerable<Appraisal<TContext>> Appraisals => Enumerable.Empty<Appraisal<TContext>>();

        public override float GetScore(TContext context)
        {
            return Score;
        }

        public override void FormatTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(ToString());
        }

        public override string ToString()
        {
            return $"{Name}: fixed at {Score}";
        }
    }
}