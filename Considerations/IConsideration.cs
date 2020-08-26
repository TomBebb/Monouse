using System.Collections.Generic;
using Monuse.Actions;
using Monuse.Considerations.Appraisals;
using Monuse.Utils;

namespace Monuse.Considerations
{
    public interface IConsideration<TContext> : IPrintable<TContext>
    {
        IEnumerable<IAppraisal<TContext>> Appraisals { get; }
        IAction<TContext> Action { get; set; }
        string Name { get; }

        float GetScore(TContext context);
    }
}