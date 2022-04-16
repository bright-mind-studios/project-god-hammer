using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tweening
{
    public abstract class ImageEffect : IEffect
    {
        protected Image image;

        public ImageEffect(Image image){
            this.image = image;
        }

        public IEnumerator Execute() 
        {
            IEnumerator b = Tween();
            return b;
        }

        public abstract IEnumerator Tween();
    }

}
