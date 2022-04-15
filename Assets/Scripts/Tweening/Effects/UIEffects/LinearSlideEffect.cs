using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{

    public class LinearSlideEffect : RectTransformEffect
    {
        private readonly Vector2 init_pos, final_pos;
        private readonly float offset_multiplier;
        private readonly float time;

        public LinearSlideEffect(RectTransform rectTransform, Vector2 init_pos, Vector2 final_pos, float offset_multiplier, float time) : base(rectTransform)
        {
            this.init_pos = init_pos;
            this.final_pos = final_pos;
            this.offset_multiplier = offset_multiplier;
            this.time = time;
        }

        public override IEnumerator Tween()
        {
            var current_time = 0f;
            var delta = 1f / time;
            var max_pos = final_pos * offset_multiplier;
            rectTransform.anchoredPosition = init_pos;

            while(rectTransform.anchoredPosition != max_pos)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                rectTransform.anchoredPosition = TweenUtils.SmoothLerp(init_pos, max_pos, t);
                yield return null;
            }

            current_time = 0f;
            var final_time = time * Mathf.Abs(1f - offset_multiplier);

            while(rectTransform.anchoredPosition != final_pos)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                rectTransform.anchoredPosition = TweenUtils.SmoothLerp(max_pos, final_pos, t);
                yield return null;
            }
        }
    }
}