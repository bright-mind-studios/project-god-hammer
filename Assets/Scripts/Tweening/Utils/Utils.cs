using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public class TweenUtils : MonoBehaviour
    {
        public static Vector2 SmoothLerp(Vector2 a, Vector2 b, float t)
        {
            Vector2 l = Vector2.Lerp(a, b, t);
            Vector2 a1 = Vector2.Lerp(a, l, t);
            Vector2 a2 = Vector2.Lerp(l, b, t);
            return Vector2.Lerp(a1, a2, t);
        }

        public static float SmoothLerp(float a, float b, float t)
        {
            float l = Mathf.Lerp(a, b, t);
            float a1 = Mathf.Lerp(a, l, t);
            float a2 = Mathf.Lerp(l, b, t);
            return Mathf.Lerp(a1, a2, t);
        }

        public static Color SmoothLerp(Color a, Color b, float t)
        {
            Color l = Color.Lerp(a, b, t);
            Color a1 = Color.Lerp(a, l, t);
            Color a2 = Color.Lerp(l, b, t);
            return Color.Lerp(a1, a2, t);
        }

        public static Vector3 SmoothLerp(Vector3 a, Vector3 b, float t)
        {
            Vector3 l = Vector3.Lerp(a, b, t);
            Vector3 a1 = Vector3.Lerp(a, l, t);
            Vector3 a2 = Vector3.Lerp(l, b, t);
            return Vector3.Lerp(a1, a2, t);
        }
    }

}