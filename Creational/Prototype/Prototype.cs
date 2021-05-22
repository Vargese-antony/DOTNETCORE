using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype_Pattern
{
    public class OrderInfo
    {
        public int Id;
        public OrderInfo(int id)
        {
            Id = id;
        }
    }
    public abstract class Prototype
    {
        public abstract Prototype ShallowCopy();
        public abstract Prototype DeepCopy();

        public abstract void Debug();
    }
}
