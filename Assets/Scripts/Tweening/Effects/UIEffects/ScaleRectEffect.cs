using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public class ScaleRectEffect : RectTransformEffect
    {
        private readonly Vector3 init_scale, final_scale;
        private float offset_multiplier;
        private readonly float time;

        public ScaleRectEffect(RectTransform rectTransform, Vector3 init_scale, Vector3 final_scale, float offset_multiplier, float time):
        base(rectTransform)
        {
            this.init_scale = init_scale;
            this.final_scale= final_scale;
            this.offset_multiplier = Mathf.Max(0, offset_multiplier);
            this.time = time;
        }

        public override IEnumerator Tween()
        {
            var current_time = 0f;
            var delta = 1f / time;
            rectTransform.localScale = init_scale;
            var max_scale = final_scale * offset_multiplier;

            while(rectTransform.localScale != max_scale)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                rectTransform.localScale = TweenUtils.SmoothLerp(init_scale, max_scale, t);
                yield return null;
            }

            current_time = 0f;
            var final_time = time * Mathf.Abs(1f - offset_multiplier);

            while(rectTransform.localScale != final_scale)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                rectTransform.localScale = TweenUtils.SmoothLerp(max_scale, final_scale, t);
                yield return null;
            }
        }
    }

}