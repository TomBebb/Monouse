using System;
using System.Text;
using Monuse.Utils;

namespace Monuse.Actions
{
    /// <summary>
    ///     Ann action wrapping a C# closure object action for easy construction
    /// </summary>
    /// <typeparam name="TContext">AI context</typeparam>
    public sealed class ActionExecutor<TContext> : IAction<TContext>, IPrintable<TContext>
    {
        private readonly Action<TContext> _action;
        public readonly string Name;

        public ActionExecutor(string name, Action<TContext> action)
        {
            _action = action;
        }

        public void Execute(TContext context)
        {
            _action(context);
        }

        public void PrintTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}