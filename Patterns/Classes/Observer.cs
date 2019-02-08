using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.Observer
{
    public interface IObservable
    {
        List<IObserver> observers { get; set; }
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    public class ConcreteObservable:IObservable
    {
        public ConcreteObservable()
        {
            observers = new List<IObserver>();

        }
        public List<IObserver> observers { get; set; }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void NotifyObservers()
        {
            foreach (var obs in observers)
                obs.update();
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }
    }



    public interface IObserver
    {
        void update();
    }
    public class ConcreteObserver1 : IObserver
    {
        public void update()
        {
            Console.WriteLine(this.ToString());
        }
    }
    public class ConcreteObserver2 : IObserver
    {
        public void update()
        {
            Console.WriteLine(this.ToString());
        }
    }







}
