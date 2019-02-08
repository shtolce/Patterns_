using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.Iterator
{
    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
        public abstract int Count { get; protected set;}
        public abstract object this[int index] { get;set; }
    }
    public class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList _items = new ArrayList();

        public override object this[int index]
        {
            get => _items[index];
            set => _items.Insert(index,value);
        }

        public override int Count
        {
            get { return _items.Count; }
            protected set { }
        }

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }
    public class ConcreteIterator:Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current=0;
        public ConcreteIterator(Aggregate aggregate)
        {
            this._aggregate = aggregate;
        }
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }
        public override object First()
        {
            return _aggregate[0];
        }
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count)
                ret = _aggregate[_current];

            _current++;

            return ret;
        }
    }







}
