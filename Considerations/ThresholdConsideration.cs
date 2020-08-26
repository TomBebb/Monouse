namespace Monuse.Considerations
{
    public class ThresholdConsideration<T> : BaseConsideration<T>
    {
        private readonly float _threshold;

        public ThresholdConsideration(string name, float threshold) : base(name)
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