using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public class ScaleBoundRectEffect : RectTransformEffect
    {
        private readonly Vector3 maxSize;
        private readonly float speed;
        private readonly YieldInstruction wait;

        public ScaleBoundRectEffect(RectTransform rectTransform, Vector3 maxSize, float speed, YieldInstruction wait) : 
        base (rectTransform)
        {
            this.maxSize = maxSize;
            this.speed = speed;
            this.wait = wait;
        }

        public override IEnumerator Tween()
        {
            var time = 0f;
            var currentScale = rectTransform.localScale;
            
            while(rectTransform.localScale != maxSize)
            {
                time += Time.deltaTime * speed;
                var scale = Vector3.Lerp(currentScale, maxSize, time);
                rectTransform.localScale = scale;
                yield return null;
            }

            yield return wait;

            currentScale = rectTransform.localScale;
            time = 0f;

            while (rectTransform.localScale != Vector3.one)
            {
                time += Time.deltaTime * speed;
                var scale = Vector3.Lerp(currentScale, Vector3.one, time);
                rectTransform.localScale = scale;
                yield return null;
            }
        }
    }

}