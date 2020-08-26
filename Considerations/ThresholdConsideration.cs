namespace Monuse.Considerations
{
    public class ThresholdConsideration<T> : BaseConsideration<T>
    {
        private readonly float _threshold;

        public ThresholdConsideration(string debugName, float threshold) : base(debugName)
        {
            _threshold = threshold;
        }

        public override float GetScore(T context)
        {
            var sum = 0f;
            foreach (var appraisal in Appraisals)
            {
                var score = appraisal.GetScore(context);
                if (score < _threshold)
                    return sum;

                sum += score;
            }

            return sum;
        }
    }
}