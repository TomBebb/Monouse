using Monuse.Reasoners;

namespace Monuse
{
    public sealed class AI<T>
    {
        private readonly T _context;
        public readonly Reasoner<T> RootReasoner;
        public readonly float UpdatePeriod;
        private float _untilUpdate;

        public AI(T context, Reasoner<T> rootSelector, float updatePeriod = 0.05f)
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