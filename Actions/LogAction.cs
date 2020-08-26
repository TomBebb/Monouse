using System;
using System.Text;

namespace Monuse.Actions
{
    public class LogAction<TContext> : IAction<TContext>
    {
        private readonly string _text;

        public LogAction(string text)
        {
            _text = text;
        }


        public void Execute(TContext context)
        {
            Console.WriteLine(_text);
        }

        public void PrintTo(TContext context, StringBuilder builder, int tabCount)
        {
            builder.Append(ToString());
        }

        public override string ToString()
        {
            return $"Print: '{_text}'";
        }
    }
}