using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monuse.Actions;
using Monuse.Considerations.Appraisals;

namespace Monuse.Considerations
{
    public class FixedScoreConsideration<TContext> : IConsideration<TContext>
    {
        public float Score;

        public FixedScoreConsideration(string debugName, float score = 1f)
        {
            Name = debugName;
            Score = score;
        }

        public IEnumerable<IAppraisal<TContext>> Appraisals => Enumerable.Empty<IAppraisal<TContext>>();
        public IAction<TContext> Action { get; set; }

        public string Name { get; }

        public float GetScore(TContext context)
        {
            return Score;
        }

        public void PrintTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Score);
        }
    }
}