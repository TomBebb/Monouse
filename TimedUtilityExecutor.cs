using System;
using Monuse.Reasoners;

namespace Monuse
{
    public sealed class TimedUtilityExecutor<TContext> : UtilityExecutor<TContext>
    {
        public readonly TimeSpan ProcessInterval;
        private TimeSpan _sinceProcess;

        public TimedUtilityExecutor(TContext context, Reasoner<TContext> rootSelector, TimeSpan processInterval) : base(
            context, rootSelector)
        {
            ProcessInterval = processInterval;
        }

        public void Update(TimeSpan span)
        {
            _sinceProcess += span;
            if (_sinceProcess > ProcessInterval)
            {
                _sinceProcess -= ProcessInterval;
                Process();
            }
        }

        public void Update(float elapsedInSeconds)
        {
            Update(TimeSpan.FromSeconds(elapsedInSeconds));
        }
    }
}