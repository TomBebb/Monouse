using System;

namespace Monuse.Actions
{
    public class LogAction<T> : IAction<T>
    {
        private readonly string _text;

        public LogAction(string text)
        {
            _text = text;
        }


        public void Execute(T context)
        {
            Console.WriteLine(_text);
        }
    }
}