namespace Monuse.Considerations.Appraisals
{
    public interface IAppraisal<T>
    {
        float GetScore(T context);
    }
}