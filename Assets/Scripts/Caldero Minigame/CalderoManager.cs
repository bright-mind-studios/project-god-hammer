using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class CalderoManager : MonoBehaviour
{
    private bool _minigameStarted, _nextFase;
    public int _progressFase;

    public Transform fase1, fase2, fase3, fase4, fase5;

    public List<Transform> bubblesFase1 = new List<Transform>();
    public List<Transform> bubblesFase2 = new List<Transform>();
    public List<Transform> bubblesFase3 = new List<Transform>();
    public List<Transform> bubblesFase4 = new List<Transform>();
    public List<Transform> bubblesFase5 = new List<Transform>();

    private void Awake()
    {
        _minigameStarted = false;
        _nextFase = false;
        _progressFase = 0;

        bubblesFase1 = GetAllChilds(fase1);
        bubblesFase2 = GetAllChilds(fase2);
        bubblesFase3 = GetAllChilds(fase3);
        bubblesFase4 = GetAllChilds(fase4);
        bubblesFase5 = GetAllChilds(fase5);

        bubblesFase2.Reverse();
        bubblesFase4.Reverse();
    }

    private void Update()
    {
        if (!_minigameStarted)
            StartCoroutine(ShowBubbles());
    }

    private List<Transform> GetAllChilds(Transform _t)
    {
        List<Transform> ts = new List<Transform>();

        foreach (Transform t in _t)
        {
            ts.Add(t);
            t.gameObject.SetActive(false);
            if (t.childCount > 0)
                ts.AddRange(GetAllChilds(t));
        }

        return ts;
    }

    public void AdvanceProgress()
    {
        _progressFase++;
    }

    private IEnumerator ShowBubbles()
    {
        _minigameStarted = true;
        var timeBetweenBubblesF1 = new WaitForSeconds(0.3f);
        var timeBetweenBubblesF2 = new WaitForSeconds(0.2f);
        var timeBetweenBubblesF3 = new WaitForSeconds(0.1f);
        var timeBetweenBubblesF4 = new WaitForSeconds(0.05f);
        var timeBetweenBubblesF5 = new WaitForSeconds(0.01f);
        var timeCheckFaseComplete = new WaitForSeconds(0.1f);

        foreach (var bubble in bubblesFase1)
        {
            while (_progressFase < bubblesFase1.IndexOf(bubble) - 4)
            {
                yield return timeBetweenBubblesF1;
            }

            bubble.gameObject.SetActive(true);
            yield return timeBetweenBubblesF1;
        }

        while (!_nextFase)
        {
            _nextFase = CheckFaseComplete(bubblesFase1);
            yield return timeCheckFaseComplete;
        }

        _nextFase = false;
        _progressFase = 0;

        foreach (var bubble in bubblesFase2)
        {
            while (_progressFase < bubblesFase2.IndexOf(bubble) - 4)
            {
                yield return timeBetweenBubblesF2;
            }

            bubble.gameObject.SetActive(true);
            yield return timeBetweenBubblesF2;
        }
        
        while (!_nextFase)
        {
            _nextFase = CheckFaseComplete(bubblesFase2);
            yield return timeCheckFaseComplete;
        }

        _nextFase = false;
        _progressFase = 0;

        foreach (var bubble in bubblesFase3)
        {
            while (_progressFase < bubblesFase3.IndexOf(bubble) - 4)
            {
                yield return timeBetweenBubblesF3;
            }

            bubble.gameObject.SetActive(true);
            yield return timeBetweenBubblesF3;
        }
        
        while (!_nextFase)
        {
            _nextFase = CheckFaseComplete(bubblesFase3);
            yield return timeCheckFaseComplete;
        }

        _nextFase = false;
        _progressFase = 0;

        foreach (var bubble in bubblesFase4)
        {
            while (_progressFase < bubblesFase4.IndexOf(bubble) - 4)
            {
                yield return timeBetweenBubblesF4;
            }

            bubble.gameObject.SetActive(true);
            yield return timeBetweenBubblesF4;
        }
        
        while (!_nextFase)
        {
            _nextFase = CheckFaseComplete(bubblesFase4);
            yield return timeCheckFaseComplete;
        }

        _nextFase = false;
        _progressFase = 0;

        foreach (var bubble in bubblesFase5)
        {
            while (_progressFase < bubblesFase5.IndexOf(bubble) - 4)
            {
                yield return timeBetweenBubblesF5;
            }

            bubble.gameObject.SetActive(true);
            yield return timeBetweenBubblesF5;
        }
        
        while (!_nextFase)
        {
            _nextFase = CheckFaseComplete(bubblesFase5);
            yield return timeCheckFaseComplete;
        }

        _progressFase = 0;

        //_minigameStarted = false;
    }

    bool CheckFaseComplete([NotNull] List<Transform> bubblesFase)
    {
        if (bubblesFase == null) throw new ArgumentNullException(nameof(bubblesFase));
        return bubblesFase.All(bubble => !bubble.gameObject.activeInHierarchy);
    }


}