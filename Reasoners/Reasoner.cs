using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monuse.Considerations;
using Monuse.Utils;

namespace Monuse.Reasoners
{
    public abstract class Reasoner<TContext> : IFormattable<TContext>
    {
        private readonly IList<Consideration<TContext>> _considerations = new List<Consideration<TContext>>();

        public readonly string Name;
        private Action<string> _handleDebug;
        private bool _shouldDebug;
        public Consideration<TContext> DefaultConsideration;

        protected Reasoner(string name, Consideration<TContext> defaultConsideration)
        {
            Name = name;
            DefaultConsideration = defaultConsideration;
        }

        public IEnumerable<Consideration<TContext>> Considerations => _considerations;

        public IEnumerable<Consideration<TContext>> AllConsiderations =>
            _considerations.Concat(new[] {DefaultConsideration});

        public void FormatTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Name);
            builder.Append(": ");
            builder.Append(GetType().Name);
            var tabs = new string('\t', tabCount + 1);
            builder.AppendLine();
            builder.Append("Considerations:");

            if (DefaultConsideration != null)
            {
                builder.AppendLine();
                builder.Append("Default: ");
                DefaultConsideration.FormatTo(context, builder, tabCount + 1);
            }

            foreach (var consideration in _considerations)
            {
                builder.AppendLine();
                builder.Append(tabs);
                consideration.FormatTo(context, builder, tabCount + 1);
            }
        }

        public void RequestDebug(Action<string> handler)
        {
            _shouldDebug = true;
            _handleDebug = handler;
        }

        public Actions.Action<TContext> Select(TContext context)
        {
            var consideration = SelectBestConsideration(context);
            Console.WriteLine($"Selected: {consideration}");
            if (consideration.Action == null)
                throw new ApplicationException($"Chosen consideration {consideration} has no Action!");

            return consideration.Action;
        }

        protected virtual Consideration<TContext> SelectBestConsideration(TContext context)
        {
            if (_shouldDebug)
            {
                var textBuilder = new StringBuilder();
                FormatTo(context, textBuilder, 0);
                _shouldDebug = false;
                _handleDebug?.Invoke(textBuilder.ToString());
            }

            return null;
        }

        public Reasoner<TContext> AddConsideration(Consideration<TContext> consideration)
        {
            _considerations.Add(consideration);
            return this;
        }

        public Reasoner<TContext> RemoveConsideration(Consideration<TContext> consideration)
        {
            _considerations.Remove(consideration);
            return this;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}