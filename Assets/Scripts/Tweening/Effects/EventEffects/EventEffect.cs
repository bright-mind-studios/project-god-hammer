using System;
using System.Collections;

namespace Tweening
{
    public abstract class EventEffect : IEffect
    {
        protected event Action action = delegate { };

        public EventEffect(Action action)
        {
            this.action = action;
        }
        public IEnumerator Execute()
        {
            return InvokeAction();
        }

        public abstract IEnumerator InvokeAction();
    }

}