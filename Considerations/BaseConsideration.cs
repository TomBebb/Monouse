using System.Collections.Generic;
using System.Text;
using Monuse.Actions;
using Monuse.Considerations.Appraisals;

namespace Monuse.Considerations
{
    public abstract class BaseConsideration<TContext> : IConsideration<TContext>
    {
        private readonly IList<IAppraisal<TContext>> _appraisals = new List<IAppraisal<TContext>>();


        protected BaseConsideration(string name)
        {
            Name = name;
        }

        public IEnumerable<IAppraisal<TContext>> Appraisals => _appraisals;
        public IAction<TContext> Action { get; set; }
        public string Name { get; protected set; }
        public abstract float GetScore(TContext context);

        public void PrintTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.AppendFormat("consideration {0}: {1}", Name, GetScore(context));

            var appraisalTabs = new string('\t', tabCount + 1);

            foreach (var appraisal in _appraisals)
            {
                builder.AppendLine();
                builder.Append(appraisalTabs);
                appraisal.PrintTo(context, builder, tabCount + 1);
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public void AddAppraisal(IAppraisal<TContext> appraisal)
        {
            _appraisals.Add(appraisal);
        }

        public void RemoveAppraisal(IAppraisal<TContext> appraisal)
        {
            _appraisals.Remove(appraisal);
        }
    }
}