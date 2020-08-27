using System.Text;
using Microsoft.SqlServer.Server;
using Monuse.Utils;

namespace Monuse.Actions
{
    /// <summary>
    ///     An action an AI entity can do
    ///     E.g. in a shooter these would include:
    ///     Reloading
    ///     Shooting the player
    ///     Taking cover.
    /// </summary>
    /// <typeparam name="TContext">AI context</typeparam>
    public abstract class Action<TContext> : IFormattable<TContext>
    {
        /// <summary>
        /// The name of this action.
        /// </summary>
        public readonly string Name;

        protected Action(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Do the action.
        /// </summary>
        /// <param name="context">AI context</param>
        public abstract void Execute(TContext context);
        

        public virtual void FormatTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}