using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilCollider : MonoBehaviour
{
    public AnvilStation station;

    public Transform marker;

    public float score = 0;

    public float distance_threshold = 0.1f;

    private bool working = false;

    public Vector3 currentTargetPoint;
    public int strength_level_needed;

    public MaterialPropertyBlock markermpb;

    public void StartEvent(float time = 10f) => StartCoroutine(EventCorroutine(time));

    private void Start() {
        marker.gameObject.SetActive(false);
        markermpb = new MaterialPropertyBlock();
    }
    private IEnumerator EventCorroutine(float time)
    {
        working = true;
        score = 0;
        marker.gameObject.SetActive(true);
        generateRandomPoint();
        yield return new WaitForSeconds(time);
        working = false;
        marker.gameObject.SetActive(false);
        station.UpgradeWeapon(Mathf.CeilToInt(score));
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(!working) return;

        AnvilHammer hammer = other.collider.GetComponent<AnvilHammer>(); 
        if(hammer == null) return;

        Vector3 contactPos = transform.InverseTransformPoint(other.GetContact(0).point);

        Vector2 localContactPos = new Vector2(contactPos.x, contactPos.z);

        if(Vector3.Distance(localContactPos, currentTargetPoint) < distance_threshold)
        {

            score += computeScoreByForce(other.relativeVelocity.magnitude);
            generateRandomPoint();
        }
    }

    internal void StopEvent()
    {
        working = false;
        score = 0;
        marker.gameObject.SetActive(false);
        StopAllCoroutines();
    }

    public void generateRandomPoint()
    {
        var x = Random.Range(-0.4f, 0.4f);
        var y = Random.Range(-0.4f, 0.4f); 
        currentTargetPoint = new Vector2(x, y);
        strength_level_needed = Random.Range(0, station.strenght_levels.Length);
        marker.localPosition = currentTargetPoint;
        Color color = Color.black;
        color[strength_level_needed] = 1.0f;
        markermpb.SetColor("_BaseColor", color);
        marker.GetComponentInChildren<Renderer>().SetPropertyBlock(markermpb);
    }

    public float computeScoreByForce(float force)
    {
        var a = Mathf.Abs(force - station.strenght_levels[strength_level_needed]);
        return a * 0.1f;
    }
}
