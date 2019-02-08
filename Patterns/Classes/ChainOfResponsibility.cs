using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.ChainOfResponsibility
{
    public abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest(ref int condition);
    }
    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(ref int condition)
        {
            if (condition == 1)
                Console.WriteLine("Handler1 is running");
            else if (Successor != null)
            {
                Successor.HandleRequest(ref condition);
            }
        }
    }
    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(ref int condition)
        {
            if (condition == 2)
            {
                Console.WriteLine("Handler2 is running");
                condition = 1;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(ref condition);
            }
        }
    }



}
