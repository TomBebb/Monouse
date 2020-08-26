using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monuse.Utils;

namespace Monuse.Actions
{
    /// <summary>
    ///     Combines actions into one.
    /// </summary>
    /// <typeparam name="TContext">AI context</typeparam>
    public class CompositeAction<TContext> : IAction<TContext>, IPrintable<TContext>
    {
        public readonly IList<IAction<TContext>> Actions;
        public readonly string Name;

        public CompositeAction(string name, IEnumerable<IAction<TContext>> actions)
        {
            Name = name;
            Actions = actions.ToList();
        }

        public void Execute(TContext context)
        {
            foreach (var action in Actions)
                action.Execute(context);
        }

        public void PrintTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.AppendFormat("{0}:", Name);
            var actionTabs = new string('\t', tabCount + 1);
            foreach (var action in Actions)
            {
                builder.AppendLine();
                builder.Append(actionTabs);


                action.PrintTo(context, builder, tabCount + 1);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}