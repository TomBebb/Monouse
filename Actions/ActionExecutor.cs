using System;

namespace Monuse.Actions
{
    
    /// <summary>
    /// Ann action wrapping a C# closure object action for easy construction
    /// </summary>
    /// <typeparam name="TContext">AI context</typeparam>
    public sealed class ActionExecutor<TContext> : IAction<TContext>
    {
        private readonly Action<TContext> _action;

        public ActionExecutor(Action<TContext> action)
        {
            _action = action;
        }

        public void Execute(TContext context)
        {
            _action(context);
        }
    }
}