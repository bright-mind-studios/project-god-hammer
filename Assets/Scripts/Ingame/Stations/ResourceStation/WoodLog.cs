using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweening;
public class WoodLog : MonoBehaviour
{
    [SerializeField] LogMarker marker;
    public Transform show_point, hide_point;
    public float animation_time = 2f;

    [ContextMenu("-- Active")]
    public void active()
    {
        marker.gameObject.SetActive(true);
        StartCoroutine(move(hide_point.position, show_point.position));
    }


    [ContextMenu("-- Hide")]
    public void hide()
    {
        marker.gameObject.SetActive(false);
        StartCoroutine(move(show_point.position, hide_point.position));
    }

    public IEnumerator move(Vector3 startPos, Vector3 finalPos)
    {
        transform.position = startPos;
        var current_time = 0f;
        var delta = 1f / animation_time;
        while(transform.position != finalPos)
        {
            current_time += Time.deltaTime;
            var t = delta * current_time;
            transform.position = TweenUtils.SmoothLerp(startPos, finalPos, t);
            yield return null;
        }        
    }

    public void HideInstant()
    {
        StopAllCoroutines();
        marker.gameObject.SetActive(false);
        transform.position = hide_point.position;
    }
}
