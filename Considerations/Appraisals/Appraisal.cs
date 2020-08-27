using System.Text;
using Monuse.Utils;

namespace Monuse.Considerations.Appraisals
{
    /// <summary>
    /// Used to gauge score 
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class Appraisal<TContext> : IFormattable<TContext>
    {
        
        /// <summary>
        /// The name of this appraisal.
        /// </summary>
        public readonly string Name;

        protected Appraisal(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Get the score of this appraisal.
        /// The higher this is, the more chance the action associated will be ran.
        /// </summary>
        /// <param name="context">The AI context.</param>
        /// <returns>The score.</returns>
        public abstract float GetScore(TContext context);

        public void FormatTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}