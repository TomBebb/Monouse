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

        public IEnumerable<Appraisal<TContext>> Appraisals => Enumerable.Empty<Appraisal<TContext>>();
        public Action<TContext> Action { get; set; }

        public string Name { get; }

        public float GetScore(TContext context)
        {
            return Score;
        }

        public void FormatTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Score);
        }
    }
}