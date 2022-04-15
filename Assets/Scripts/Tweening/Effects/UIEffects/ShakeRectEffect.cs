using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public class ShakeRectEffect : RectTransformEffect
    {
        private readonly float WiggleSpeed;
        private readonly float maxRotation;
        private readonly float atenuation;

        public ShakeRectEffect(RectTransform rectTransform, float wiggleSpeed, float maxRotation, float atenuation = 0.8f) : base(rectTransform)
        {
            WiggleSpeed = wiggleSpeed;
            this.maxRotation = maxRotation;
            this.atenuation = Mathf.Clamp(atenuation, 0.1f, 0.9f);
        }

        public override IEnumerator Tween()
        {
            var rotateTo = new Quaternion
            {
                eulerAngles = new Vector3(0, 0, maxRotation)
            };
            
            var currentRotation = rectTransform.rotation.z;
            var nextRotation = maxRotation * -1f;

            var time = 0f;

            while(Mathf.Abs(nextRotation) > 0.15f)
            {
                time += Time.deltaTime * WiggleSpeed;
                var newRotation = Mathf.Lerp(currentRotation, nextRotation, time);
                rotateTo.eulerAngles = new Vector3(0, 0, newRotation);
                rectTransform.rotation = rotateTo;
                if(time >= 1)
                {
                    currentRotation = nextRotation;
                    nextRotation = (nextRotation * atenuation) * -1;
                    time = 0;
                }
                yield return null;
            }
            rotateTo.eulerAngles = Vector3.zero;
            rectTransform.rotation = rotateTo;
        }
    }

}
