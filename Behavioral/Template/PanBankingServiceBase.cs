using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public abstract class PanBankingServiceBase<T> where T: BakedPanFood, new() //without new we cannot create instance for T
    {
        private T _item;

        public T Prepare()
        {
            _item = new T();

            PrepareCrust();

            AddToppings();

            Cover();

            Bake();

            Slice();

            return _item;
        }

        protected abstract void Slice();
        protected abstract void Bake();
        protected abstract void AddToppings();
        protected abstract void PrepareCrust();

        protected virtual void Cover()
        {
            // does nothing by default
            // Act as a hook, to be implemented by the derived class if needed
        }
    }
}
