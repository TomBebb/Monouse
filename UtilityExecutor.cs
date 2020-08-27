using Monuse.Reasoners;

namespace Monuse
{
    public class UtilityExecutor<TContext>
    {
        private readonly TContext _context;
        public readonly Reasoner<TContext> RootReasoner;

        public UtilityExecutor(TContext context, Reasoner<TContext> rootSelector)
        {
            _context = context;
            RootReasoner = rootSelector;
        }

        public void Process()
        {
            var action = RootReasoner.Select(_context);
            action.Execute(_context);
        }
    }
}