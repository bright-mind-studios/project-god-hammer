using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening{
    public class ScreenSlideEffect : RectTransformEffect
    {
        private readonly Vector3 init_offset, final_offset;
        private readonly float offset_multiplier;
        private readonly float time;

        public ScreenSlideEffect(RectTransform rectTransform, Vector3 init_offset, Vector3 final_offset, float offset_multiplier, float time):
        base(rectTransform)
        {
            this.init_offset = init_offset;
            this.final_offset = final_offset;
            this.offset_multiplier = offset_multiplier;
            this.time = time;
        }

        public override IEnumerator Tween()
        {
            var current_time = 0f;
            var delta = 1f / time;
            var screenSize = new Vector2(Screen.width, Screen.height);
            var init_pos = init_offset * screenSize;
            var final_pos = final_offset * screenSize;
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

