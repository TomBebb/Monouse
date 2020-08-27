using Monuse.Reasoners;

namespace Monuse
{
    public sealed class UtilityExecutor<TContext>
    {
        private readonly TContext _context;
        public readonly Reasoner<TContext> RootReasoner;
        public readonly float UpdatePeriod;
        private float _untilUpdate;

        public UtilityExecutor(TContext context, Reasoner<TContext> rootSelector, float updatePeriod = 0.05f)
        {
            _context = context;
            RootReasoner = rootSelector;
            UpdatePeriod = updatePeriod;
            _untilUpdate = updatePeriod;
        }

        public void Update(float dt)
        {
            _untilUpdate -= dt;
            if (!(_untilUpdate < 0)) return;
            _untilUpdate = UpdatePeriod;

            var action = RootReasoner.Select(_context);
            action?.Execute(_context);
        }
    }
}