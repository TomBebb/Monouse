using System.Collections.Generic;
using Monuse.Actions;
using Monuse.Considerations.Appraisals;
using Monuse.Utils;

namespace Monuse.Considerations
{
    public interface IConsideration<TContext> : IFormattable<TContext>
    {
        IEnumerable<Appraisal<TContext>> Appraisals { get; }
        Action<TContext> Action { get; set; }
        string Name { get; }

        float GetScore(TContext context);
    }
}