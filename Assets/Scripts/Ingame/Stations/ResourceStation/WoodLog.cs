using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweening;
using UnityEngine.Events;

public class WoodLog : MonoBehaviour
{
    [SerializeField] LogMarker marker;
    public Transform show_point, hide_point;
    public float animation_time = 2f;

    public UnityEvent OnFinishEvent;

    [ContextMenu("-- Active")]
    public void active()
    {
        marker.gameObject.SetActive(true);
        StartCoroutine(move(hide_point.position, show_point.position, false));
    }


    [ContextMenu("-- Hide")]
    public void hide()
    {
        marker.gameObject.SetActive(false);
        StartCoroutine(move(show_point.position, hide_point.position, true));
    }

    public IEnumerator move(Vector3 startPos, Vector3 finalPos, bool finished)
    {
        if (!finished) gameObject.layer = 30;
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
        if (finished)
        {
            gameObject.layer = 31;
            OnFinishEvent?.Invoke();
        }
    }

    public void HideInstant()
    {
        StopAllCoroutines();
        gameObject.layer = 31;
        marker.gameObject.SetActive(false);
        transform.position = hide_point.position;
    }
}
