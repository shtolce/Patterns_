using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.AbstractFactory
{
    public class Client:IDisposable
    {
        private AbstractProductA prA;
        private AbstractProductB prB;
        public Client(AbstractFactory fact)
        {
            prA = fact.CreateProductA();
            prB = fact.CreateProductB();
        }
        public void Run()
        {
            Console.WriteLine(prA.GetType().ToString());
            Console.Beep();
        }
        public void Dispose()
        {

        }

    }
    public abstract class AbstractFactory:IDisposable
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();

        public void Dispose()
        {
            object obj = this.GetType().Name;
            Console.WriteLine($"Уничтожаю {obj}",obj);
        }
    }
    public class Factory1:AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }


    public class Factory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }


    public abstract class AbstractProductA
    {
    }
    public abstract class AbstractProductB
    {
    }
    public class ProductA1 : AbstractProductA
    {
        public ProductA1()
        {
            Console.WriteLine("Product A1");
        }
    }
    public class ProductB1 : AbstractProductB
    {
        public ProductB1()
        {
            Console.WriteLine("Product B1");
        }
    }

    public class ProductA2 : AbstractProductA
    {
        public ProductA2()
        {
            Console.WriteLine("Product A2");
        }
    }
    public class ProductB2 : AbstractProductB
    {
        public ProductB2()
        {
            Console.WriteLine("Product B2");
        }
    }






}
