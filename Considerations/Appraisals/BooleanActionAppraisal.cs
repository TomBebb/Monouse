using System;
using System.Text;

namespace Monuse.Considerations.Appraisals
{
    /// <summary>
    ///     wraps a Func for use as an Appraisal without having to create a subclass
    /// </summary>
    public class BooleanActionAppraisal<TContext> : IAppraisal<TContext>
    {
        private readonly Func<TContext, bool> _appraisalAction;
        private readonly string _name;
        private readonly float _scoreMultiplier;


        public BooleanActionAppraisal(string name, Func<TContext, bool> appraisalAction, float scoreMultiplier = 1f)
        {
            _name = name;
            _appraisalAction = appraisalAction;
            _scoreMultiplier = scoreMultiplier;
        }


        public float GetScore(TContext context)
        {
            return _appraisalAction(context) ? _scoreMultiplier : 0f;
        }

        public void PrintTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(_name);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}