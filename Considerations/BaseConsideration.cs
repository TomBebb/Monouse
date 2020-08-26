using System.Collections.Generic;
using Monuse.Actions;
using Monuse.Considerations.Appraisals;

namespace Monuse.Considerations
{
    public abstract class BaseConsideration<T> : IConsideration<T>
    {
        private readonly List<IAppraisal<T>> _appraisals = new List<IAppraisal<T>>();

        protected BaseConsideration(string debugName)
        {
            DebugName = debugName;
        }

        public IReadOnlyList<IAppraisal<T>> Appraisals => _appraisals;

        public IAction<T> Action { get; set; }
        public string DebugName { get; protected set; }
        public abstract float GetScore(T context);

        public BaseConsideration<T> AddAppraisal(IAppraisal<T> appraisal)
        {
            _appraisals.Add(appraisal);
            return this;
        }

        public override string ToString()
        {
            return DebugName;
        }
    }
}