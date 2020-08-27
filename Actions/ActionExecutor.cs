using System;
using System.Text;
using Monuse.Utils;

namespace Monuse.Actions
{
    /// <summary>
    ///     Ann action wrapping a C# closure object action for easy construction
    /// </summary>
    /// <typeparam name="TContext">AI context</typeparam>
    public sealed class ActionExecutor<TContext> : Action<TContext>
    {
        private readonly System.Action<TContext> _action;

        public ActionExecutor(string name, System.Action<TContext> action): base(name)
        {
            _action = action;
        }

        public override void Execute(TContext context)
        {
            _action(context);
        }

        public override void FormatTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Name);
        }
    }
}