using System.Collections.Generic;
using System.Linq;

namespace Monuse.Actions
{
    /// <summary>
    /// Combines actions into one.
    /// </summary>
    /// <typeparam name="TContext">AI context</typeparam>
    public class CompositeAction<TContext> : IAction<TContext>
    {
        public readonly List<IAction<TContext>> Actions;

        public CompositeAction(IEnumerable<IAction<TContext>> actions)
        {
            Actions = actions.ToList();
        }

        public void Execute(TContext context)
        {
            foreach (var action in Actions)
                action.Execute(context);
        }
    }
}