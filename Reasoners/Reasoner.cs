using System;
using System.Collections.Generic;
using System.Text;
using Monuse.Considerations;
using Monuse.Utils;

namespace Monuse.Reasoners
{
    public abstract class Reasoner<TContext> : IFormattable<TContext>
    {
        public readonly IList<Consideration<TContext>> Considerations = new List<Consideration<TContext>>();

        public readonly string Name;
        private Action<string> _handleDebug;
        private bool _shouldDebug;
        public Consideration<TContext> DefaultConsideration;

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

        public void RequestDebug(Action<string> handler)
        {
            _shouldDebug = true;
        }

        public Actions.Action<TContext> Select(TContext context)
        {
            var consideration = SelectBestConsideration(context);
            return consideration?.Action;
        }

        protected virtual Consideration<TContext> SelectBestConsideration(TContext context)
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