using System.Collections.Generic;
using Monuse.Actions;
using Monuse.Considerations;

namespace Monuse.Reasoners
{
    public abstract class Reasoner<T>
    {
        public readonly IList<IConsideration<T>> Considerations = new List<IConsideration<T>>();
        public IConsideration<T> DefaultConsideration;

        public readonly string Name;

        protected Reasoner(string name = "")
        {
            Name = name;
        }
        public IAction<T> Select(T context)
        {
            var consideration = SelectBestConsideration(context);
            return consideration?.Action;
        }

        protected abstract IConsideration<T> SelectBestConsideration(T context);

        public override string ToString() => Name;
    }
}