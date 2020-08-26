using System;

namespace Monuse.Considerations.Appraisals
{
    /// <summary>
    ///     wraps a Func for use as an Appraisal without having to create a subclass
    /// </summary>
    public class BooleanActionAppraisal<T> : IAppraisal<T>
    {
        private readonly Func<T, bool> _appraisalAction;
        private readonly string _name;
        private readonly float _scoreMultiplier;


        public BooleanActionAppraisal(string name, Func<T, bool> appraisalAction, float scoreMultiplier = 1f)
        {
            _name = name;
            _appraisalAction = appraisalAction;
            _scoreMultiplier = scoreMultiplier;
        }


        public float GetScore(T context)
        {
            return _appraisalAction(context) ? _scoreMultiplier : 0f;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}