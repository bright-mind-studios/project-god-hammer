using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public abstract class RectTransformEffect : IEffect
    {
        protected readonly RectTransform rectTransform;
    
        protected RectTransformEffect(RectTransform rectTransform){
            this.rectTransform = rectTransform;
        }

        public IEnumerator Execute()
        {
            return Tween();
        }

        public abstract IEnumerator Tween();
    }
    
}