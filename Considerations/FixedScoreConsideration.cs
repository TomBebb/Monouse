using System.Collections.Generic;
using Monuse.Actions;
using Monuse.Considerations.Appraisals;

namespace Monuse.Considerations
{
    public class FixedScoreConsideration<T> : IConsideration<T>
    {
        public float Score;

        public FixedScoreConsideration(string debugName, float score = 1f)
        {
            DebugName = debugName;
            Score = score;
        }

        public IReadOnlyList<IAppraisal<T>> Appraisals => null;
        public IAction<T> Action { get; set; }

        public string DebugName { get; }

        public float GetScore(T context)
        {
            return Score;
        }
    }
}