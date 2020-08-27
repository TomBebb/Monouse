using System.Text;
using Monuse.Actions;
using Monuse.Utils;

namespace Monuse.Considerations
{
    /// <summary>
    ///     A choice the AI should consider.
    /// </summary>
    /// <typeparam name="TContext">The AI context.</typeparam>
    public abstract class Consideration<TContext> : IFormattable<TContext>
    {
        /// <summary>
        ///     The name of this consideratoin.
        /// </summary>
        public readonly string Name;

        /// <summary>
        ///     The action to execute if this is chosen by a Reasoner.
        /// </summary>
        public Action<TContext> Action;

        protected Consideration(string name, Action<TContext> action)
        {
            Name = name;
            Action = action;
        }

        public abstract void FormatTo(TContext context, StringBuilder builder, int tabCount);

        /// <summary>
        ///     Get the score of the consideration.
        ///     Higher scores mean this is more likely to be chosen.
        /// </summary>
        /// <param name="context">The AI context.</param>
        /// <returns></returns>
        public abstract float GetScore(TContext context);

        public override string ToString()
        {
            return Name;
        }
    }
}