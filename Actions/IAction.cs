namespace Monuse.Actions
{
    /// <summary>
    /// An action an AI entity can do
    /// E.g. in a shooter these would include:
    ///
    /// Reloading
    /// Shooting the player
    /// Taking cover.
    /// </summary>
    /// <typeparam name="TContext">AI context</typeparam>
    public interface IAction<in TContext>
    {
        /// <summary>
        /// Do the action.
        /// </summary>
        /// <param name="context">AI context</param>
        void Execute(TContext context);
    }
}