using System.Text;

namespace Monuse.Utils
{
    public interface IPrintable<in TContext>
    {
        void PrintTo(TContext context, StringBuilder builder, int tabCount);
    }
}