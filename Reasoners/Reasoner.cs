using System;
using System.Collections.Generic;
using System.Text;
using Monuse.Actions;
using Monuse.Considerations;
using Monuse.Utils;

namespace Monuse.Reasoners
{
    public abstract class Reasoner<TContext> : IFormattable<TContext>
    {
        public readonly IList<IConsideration<TContext>> Considerations = new List<IConsideration<TContext>>();

        public readonly string Name;
        public IConsideration<TContext> DefaultConsideration;
        private bool _shouldDebug;
        private System.Action<string> _handleDebug;

        public void RequestDebug(System.Action<string> handler)
        {
            _shouldDebug = true;
        }

        protected Reasoner(string name = "")
        {
            Name = name;
        }

        public void FormatTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Name);
            builder.Append(": ");
            builder.Append(GetType().Name);
            var tabs = new string('\t', tabCount + 1);

            foreach (var consideration in Considerations)
            {
                builder.AppendLine();
                builder.Append(tabs);
                consideration.FormatTo(context, builder, tabCount + 1);
            }
        }

        public Actions.Action<TContext> Select(TContext context)
        {
            var consideration = SelectBestConsideration(context);
            return consideration?.Action;
        }

        protected virtual IConsideration<TContext> SelectBestConsideration(TContext context)
        {
            if (_shouldDebug)
            {
                var textBuilder = new StringBuilder();
                FormatTo(context, textBuilder, 0);
                _shouldDebug = false;
                _handleDebug(textBuilder.ToString());
            }

            return null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}