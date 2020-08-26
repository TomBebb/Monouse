using System;

namespace Monuse.Considerations.Appraisals
{
    /// <summary>
    ///     wraps a Func for use as an Appraisal without having to create a subclass
    /// </summary>
    public class ActionAppraisal<T> : IAppraisal<T>
    {
        private readonly Func<T, float> _appraisalAction;
        private readonly string _name;


        public ActionAppraisal(string name, Func<T, float> appraisalAction)
        {
            _name = name;
            _appraisalAction = appraisalAction;
        }


        public float GetScore(T context)
        {
            return _appraisalAction(context);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}