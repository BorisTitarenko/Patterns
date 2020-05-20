using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
        public abstract int Count { get; protected set; }
        public abstract float this[int index] { get; set; }
    }

    public class RadioStation : Aggregate
    {
        private readonly List<float> _frequencies;

        public RadioStation(List<float> freq) {
            _frequencies = freq;
        }
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public override int Count
        {
            get { return _frequencies.Count; }
            protected set { }
        }

        public override float this[int index]
        {
            get { return _frequencies[index]; }
            set { _frequencies.Insert(index, value); }
        }
    }
    public abstract class Iterator
    {
        public abstract float First();
        public abstract float Next();
        public abstract bool IsDone();
        public abstract float CurrentItem();
    }

    public class ConcreteIterator : Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current;

        public ConcreteIterator(Aggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        public override float First()
        {
            return _aggregate[0];
        }

        public override float Next()
        {
            float ret = 0;

            _current++;

            if (_current < _aggregate.Count)
            {
                ret = _aggregate[_current];
            }

            return ret;
        }

        public override float CurrentItem()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}
