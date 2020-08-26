using Monuse.Utils;

namespace Monuse.Considerations.Appraisals
{
    public interface IAppraisal<TContext> : IPrintable<TContext>
    {
        float GetScore(TContext context);
    }
}