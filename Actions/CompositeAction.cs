using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monuse.Utils;

namespace Monuse.Actions
{
    /// <summary>
    /// Executes multiple actions
    /// </summary>
    /// <typeparam name="TContext">AI context</typeparam>
    public sealed class CompositeAction<TContext> : Action<TContext>
    {
        public readonly IList<Action<TContext>> Actions;

        public CompositeAction(string name, IEnumerable<Action<TContext>> actions): base(name)
        {
            Actions = actions.ToList();
        }

        public override void Execute(TContext context)
        {
            foreach (var action in Actions)
                action.Execute(context);
        }

        public override void FormatTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Name);
            var actionTabs = new string('\t', tabCount + 1);
            foreach (var action in Actions)
            {
                builder.AppendLine();
                builder.Append(actionTabs);

                action.FormatTo(context, builder, tabCount + 1);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}