using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tweening
{
    public class ImageColorEffect : ImageEffect
    {
        private Color color;
        private float time;

        public ImageColorEffect(Image target, Color color, float time) : base(target)
        {
            this.color = color;
            this.time = time;
        }

        public override IEnumerator Tween()
        {
            var current_time = 0f;
            var delta = 1f / time;
            var current_color = image.color;

            while(image.color != color)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                image.color = Color.Lerp(current_color, color, t);
                yield return null;
            }
        }
    }

}