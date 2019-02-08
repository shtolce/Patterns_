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
using Patterns.Classes.Strategy;
using Patterns.Classes.Observer;
using Patterns.Classes.Command;
using Patterns.Classes.Iterator;
using Patterns.Classes.State;
using Patterns.Classes.Interpreter;
using Patterns.Classes.ChainOfResponsibility;
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

        /// <summary>
        /// Вызов прототипа
        /// </summary>
        private static void StrategyRun()
        {
            var contextStr = new Classes.Strategy.Context(new ConcreteStrategy1());
            contextStr.ExecuteAlgoritm();
        }
        /// <summary>
        /// Вызов наблюдателя
        /// </summary>
        private static void ObserverRun()
        {
            IObservable observer = new ConcreteObservable();
            observer.AddObserver(new ConcreteObserver1());
            observer.AddObserver(new ConcreteObserver2());
            observer.NotifyObservers();

        }
        /// <summary>
        /// Паттерн команда
        /// </summary>
        private static void CommandRun()
        {
            Invoker inv = new Invoker();
            Receiver rec = new Receiver();
            inv.SetCommand(new ConcreteCommand(rec));
            inv.Run();


        }
        /// <summary>
        /// Iterator pattern
        /// </summary>
        private static void IteratorRun()
        {
            Aggregate aggregate = new ConcreteAggregate();
            aggregate[0] = "1";
            aggregate[1] = "2";
            aggregate[2] = "3";

            Console.ForegroundColor =ConsoleColor.Cyan;
            Iterator iterator = aggregate.CreateIterator();
            object item = iterator.First();
            Console.WriteLine(item.ToString());
            while (!iterator.IsDone())
                Console.WriteLine(iterator.Next().ToString());


        }
        /// <summary>
        /// State Pattern
        /// </summary>
        private static void StateRun()
        {
                Classes.State.Context context = new Classes.State.Context(new StateA());
                context.Request();
                Console.WriteLine(context.state);
                context.Request();
                Console.WriteLine(context.state);

        }
        /// <summary>
        /// interpreter pattern
        /// </summary>
        private static void InterpreterRun()
        {
            ContextI cont = new ContextI();
            cont.SetVariable("x", 33);
            cont.SetVariable("y", 133);
            AbstractExpression exp = new NonterminalExpression(new TerminalExpression("x"), new TerminalExpression("y"));
            int res = (int)exp.Interpret(cont);
            Console.WriteLine(res);
        }
        /// <summary>
        /// ChainOfResponsibilityPattern
        /// </summary>
        private static void ChainOfResponsibilityRun()
        {
            int condition = 2;
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            h1.Successor = h2;
            h2.Successor = h1;
            h1.HandleRequest(ref condition);

        }

        static void Main(string[] args)
        {
            ChainOfResponsibilityRun();


        }

    }
}
