namespace Monuse.Actions
{
    public interface IActionOptionAppraisal<T, U>
    {
        float GetScore(T context, U option);
    }
}