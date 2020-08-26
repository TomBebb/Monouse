using System.Collections.Generic;
using Monuse.Actions;
using Monuse.Considerations.Appraisals;

namespace Monuse.Considerations
{
    public interface IConsideration<T>
    {
        IReadOnlyList<IAppraisal<T>> Appraisals { get; }
        IAction<T> Action { get; set; }
        string DebugName { get; }

        float GetScore(T context);
    }
}