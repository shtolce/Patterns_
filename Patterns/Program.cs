using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Classes.FactoryMethod;
using Patterns.Classes.AbstractFactory;
using Patterns.Classes.Builder;
using Patterns.Classes.Prototype;
using Patterns.Classes.Singleton;
using System.Threading;

namespace Patterns
{
    class Program
    {
        /// <summary>
        /// Фабричный метод
        /// </summary>
        private static void FactoryMethodRun()
        {
            Patterns.Classes.FactoryMethod.Product prA = new CreatorA().Create();
            Patterns.Classes.FactoryMethod.Product prB = new CreatorB().Create();
            prA.Method1();
            prB.Method1();
        }
        /// <summary>
        /// Абстрактная фабрика
        /// </summary>
        private static void AbstractFactoryRun()
        {
            using (Client cl = new Client(new Factory2()))
            {
                cl.Run();
            }
        }
        private static void BuilderRun()
        {
            Builder builder1 = new ConcreteBuilder();
            Director director = new Director(builder1);
            director.Construct();
            Patterns.Classes.Builder.Product product = builder1.GetResult();
            Console.WriteLine(product.parts[1]);

        }
        /// <summary>
        /// Вызов прототипа
        /// </summary>
        private static void PrototypeRun()
        {
            PrototypeClient client = new PrototypeClient();
            client.operation();
        }
        /// <summary>
        /// Вызов простого синглтона, плохо работает в многопоточной среде
        /// </summary>
        private static void SingletonRun()
        {
            Computer comp = new Computer();
            comp.Launch("fucking OS");
            Console.WriteLine(comp.Os.Name);
        }
        private static void SingletonMultiThreadRun()
        {
            (new Thread(() =>
            {
                Computer comp = new Computer();
                comp.Launch("win10");
                Console.WriteLine(comp.Os.Name);
            })).Start() ;
            Computer comp2 = new Computer();
            comp2.Os = Os.getInstance("win8");
            Console.WriteLine(comp2.Os.Name);

        }
        static void Main(string[] args)
        {
            SingletonMultiThreadRun();
        }

    }
}
