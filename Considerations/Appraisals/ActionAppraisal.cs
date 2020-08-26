using System;
using System.Text;

namespace Monuse.Considerations.Appraisals
{
    /// <summary>
    ///     wraps a Func for use as an Appraisal without having to create a subclass
    /// </summary>
    public class ActionAppraisal<TContext> : IAppraisal<TContext>
    {
        private readonly Func<TContext, float> _appraisalAction;
        private readonly string _name;


        public ActionAppraisal(string name, Func<TContext, float> appraisalAction)
        {
            _name = name;
            _appraisalAction = appraisalAction;
        }


        public float GetScore(TContext context)
        {
            return _appraisalAction(context);
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