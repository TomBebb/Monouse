using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monuse.Actions
{
    public abstract class ActionWithOptions<TContext, TOption> : IAction<TContext>
    {
        public readonly IList<IActionOptionAppraisal<TContext, TOption>> Appraisals =
            new List<IActionOptionAppraisal<TContext, TOption>>();

        public readonly string Name;

        protected ActionWithOptions(string name)
        {
            Name = name;
        }

        public abstract void Execute(TContext context);

        public void PrintTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Name);
        }


        public TOption GetBestOption(TContext context, IList<TOption> options)
        {
            var result = default(TOption);
            var bestScore = float.MinValue;

            foreach (var option in options)
            {
                var current = Appraisals.Sum(t => t.GetScore(context, option));

                if (!(current > bestScore)) continue;
                bestScore = current;
                result = option;
            }

            return result;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}