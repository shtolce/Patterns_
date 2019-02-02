using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Classes.FactoryMethod;
using Patterns.Classes.AbstractFactory;

namespace Patterns
{
    class Program
    {
        /// <summary>
        /// Фабричный метод
        /// </summary>
        private static void FactoryMethodRun()
        {
            Product prA = new CreatorA().Create();
            Product prB = new CreatorB().Create();
            prA.Method1();
            prB.Method1();
        }
        /// <summary>
        /// Абстрактная фабрика
        /// </summary>
        private static void AbstractFactoryRun()
        {
            Product prA = new CreatorA().Create();
            Product prB = new CreatorB().Create();
            prA.Method1();
            prB.Method1();
        }





        static void Main(string[] args)
        {
            AbstractFactoryRun();






        }



    }
}
