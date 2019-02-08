using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.Strategy
{

    /// <summary>
 /// Strategy pattern
 /// </summary>
    interface IStrategy
    {
        void Algoritm();
    }
    class ConcreteStrategy1 : IStrategy
    {
        void IStrategy.Algoritm()
        {
            Console.WriteLine("Algoritm1");
        }
    }

    class Context
    {
        IStrategy ContextStrategy { get; set; }
        public Context(IStrategy str)
        {
            this.ContextStrategy = str;
        }
        public void ExecuteAlgoritm()
        {
            ContextStrategy.Algoritm();
        }
    }






}
