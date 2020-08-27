using System;
using Monuse;
using Monuse.Actions;
using Monuse.Considerations;
using Monuse.Considerations.Appraisals;
using Monuse.Reasoners;
using Monuse.Utils;

namespace Example1
{
    public class AIDemo
    {
        public int Counter;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var demo = new AIDemo {Counter = 1};

            var moveAction = new ActionExecutor<AIDemo>("MoveAction", d => Console.WriteLine("MOVING"));

            var reasoner = new WeightBasedRandomReasoner<AIDemo>("AIDemo reasoner", new Random())
            {
                DefaultConsideration = new FixedScoreConsideration<AIDemo>("DefaultConsideration", 0.1f,
                    new ActionExecutor<AIDemo>("DefaultAction", d2 => Console.WriteLine("DEFAULT")))
            };

            var moveConsideration = new SumOfChildrenConsideration<AIDemo>("MoveConsideration", moveAction);

            moveConsideration.AddAppraisal(new ActionAppraisal<AIDemo>("CheckCounter",
                d => MathExt.Clamp((float) Math.Pow(d.Counter / 40f, 2f), 0f, 1f)));

            reasoner.Considerations.Add(moveConsideration);

            var executor = new UtilityExecutor<AIDemo>(demo, reasoner);


            string line;

            while ((line = Console.ReadLine()?.ToLower()) != null && line != "q" && line != "quit")
            {
                if (line == "debug") reasoner.RequestDebug(Console.WriteLine);

                if (int.TryParse(line, out var newCounter)) demo.Counter = newCounter;
                executor.Process();
            }
        }
    }
}