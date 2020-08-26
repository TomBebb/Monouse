using System.Collections.Generic;
using System.Linq;

namespace Monuse.Actions
{
    public abstract class ActionWithOptions<TContext, U> : IAction<TContext>
    {
        protected List<IActionOptionAppraisal<TContext, U>> _appraisals = new List<IActionOptionAppraisal<TContext, U>>();

        public abstract void Execute(TContext context);


        public U GetBestOption(TContext context, IList<U> options)
        {
            var result = default(U);
            var bestScore = float.MinValue;

            foreach (var option in options)
            {
                var current = _appraisals.Sum(t => t.GetScore(context, option));

                if (!(current > bestScore)) continue;
                bestScore = current;
                result = option;
            }

            return result;
        }


        public ActionWithOptions<TContext, U> AddScorer(IActionOptionAppraisal<TContext, U> scorer)
        {
            _appraisals.Add(scorer);
            return this;
        }
    }
}