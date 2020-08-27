using System;

namespace Monuse.Considerations.Appraisals
{
    /// <summary>
    ///     wraps a Func for use as an Appraisal without having to create a subclass
    /// </summary>
    public class BooleanActionAppraisal<TContext> : Appraisal<TContext>
    {
        private readonly Func<TContext, bool> _appraisalAction;
        private readonly float _scoreMultiplier;


        public BooleanActionAppraisal(string name, Func<TContext, bool> appraisalAction, float scoreMultiplier = 1f) :
            base(name)
        {
            _appraisalAction = appraisalAction;
            _scoreMultiplier = scoreMultiplier;
        }


        public override float GetScore(TContext context)
        {
            return _appraisalAction(context) ? _scoreMultiplier : 0f;
        }
    }
}