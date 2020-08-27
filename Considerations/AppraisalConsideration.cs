using System.Collections.Generic;
using System.Text;
using Monuse.Actions;
using Monuse.Considerations.Appraisals;

namespace Monuse.Considerations
{
    /// <summary>
    ///     A choice that can check appraisal scores.
    /// </summary>
    /// <typeparam name="TContext">The AI context.</typeparam>
    public abstract class AppraisalConsideration<TContext> : Consideration<TContext>
    {
        private readonly IList<Appraisal<TContext>> _appraisals = new List<Appraisal<TContext>>();


        protected AppraisalConsideration(string name, Action<TContext> action) : base(name, action)
        {
        }

        public IEnumerable<Appraisal<TContext>> Appraisals => _appraisals;

        public override void FormatTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.AppendFormat("consideration {0}: {1}", Name, GetScore(context));

            var appraisalTabs = new string('\t', tabCount + 1);

            foreach (var appraisal in _appraisals)
            {
                builder.AppendLine();
                builder.Append(appraisalTabs);
                appraisal.FormatTo(context, builder, tabCount + 1);
            }
        }

        /// <summary>
        ///     Add an appraisal to the consideration.
        /// </summary>
        /// <param name="appraisal">The appraisal to add.</param>
        public void AddAppraisal(Appraisal<TContext> appraisal)
        {
            _appraisals.Add(appraisal);
        }


        /// <summary>
        ///     Remove an appraisal to the consideration.
        /// </summary>
        /// <param name="appraisal">The appraisal to remove.</param>
        public void RemoveAppraisal(Appraisal<TContext> appraisal)
        {
            _appraisals.Remove(appraisal);
        }
    }
}