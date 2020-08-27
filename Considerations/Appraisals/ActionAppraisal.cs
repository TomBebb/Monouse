using System;

namespace Monuse.Considerations.Appraisals
{
    /// <summary>
    ///     Wraps a Func / C# action for use as an Appraisal without having to create a subclass
    /// </summary>
    public class ActionAppraisal<TContext> : Appraisal<TContext>
    {
        private readonly Func<TContext, float> _appraisalAction;


        public ActionAppraisal(string name, Func<TContext, float> appraisalAction) : base(name)
        {
            _appraisalAction = appraisalAction;
        }


        public override float GetScore(TContext context)
        {
            return _appraisalAction(context);
        }
    }
}