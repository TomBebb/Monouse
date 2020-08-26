namespace Monuse.Considerations
{
    public class AllOrNothingConsideration<T> : BaseConsideration<T>
    {
        private readonly float _threshold;


        public AllOrNothingConsideration(string debugName, float threshold = 0) : base(debugName)
        {
            _threshold = threshold;
        }


        public override float GetScore(T context)
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