using Monuse.Actions;

namespace Monuse.Considerations
{
    /// <summary>
    ///     Calculates score by adding scores of appraisals.
    ///     If any appraisal score is less than a threshold, calculated score is 0.
    /// </summary>
    /// <typeparam name="TContext">The AI context.</typeparam>
    public class AllOrNothingConsideration<TContext> : AppraisalConsideration<TContext>
    {
        private readonly float _threshold;

        /// <summary>
        ///     Create a new consideration.
        /// </summary>
        /// <param name="name">The name of the consideration.</param>
        /// <param name="threshold">The value scores must be above.</param>
        public AllOrNothingConsideration(string name, Action<TContext> action, float threshold = 0) : base(name, action)
        {
            _threshold = threshold;
        }


        public override float GetScore(TContext context)
        {
            var sum = 0f;
            foreach (var approach in Appraisals)
            {
                var score = approach.GetScore(context);
                if (score <= _threshold)
                    return 0;

                sum += score;
            }

            return sum;
        }
    }
}