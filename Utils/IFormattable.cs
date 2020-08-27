using System.Text;

namespace Monuse.Utils
{
    /// <summary>
    ///     For pretty-printing AI structures
    /// </summary>
    /// <typeparam name="TContext">AI context</typeparam>
    public interface IFormattable<in TContext>
    {
        /// <summary>
        ///     Append pretty-printed AI structure to string builder.
        /// </summary>
        /// <param name="context">AI context.</param>
        /// <param name="builder">String builder to append to.</param>
        /// <param name="tabCount">Number of tabs.</param>
        void FormatTo(TContext context, StringBuilder builder, int tabCount);
    }
}