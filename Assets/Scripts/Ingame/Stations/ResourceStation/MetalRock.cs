using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweening;

public class MetalRock : MonoBehaviour
{
    [SerializeField] GameObject orePrefab;
    [SerializeField] Metal[] metals;

    public LayerMask mask;

    public Transform limit_up, limit_down, default_point, show_point, hide_point;

    public float offset = 100f;
    public float animation_time = 2f;

    public int num_ores = 6;

    private Mesh mesh;

    private List<GameObject> ores_spawned;

    private void Start() {
        mesh = GetComponent<MeshFilter>().mesh;
        ores_spawned = new List<GameObject>();
    }

    [ContextMenu("-- Active")]
    public void active()
    {
        Clear();
        for (int i = 0; i < num_ores; i++)
        {
            GenerateMetalOre();
        } 
        StartCoroutine(move(hide_point.position, show_point.position));
    }


    [ContextMenu("-- Hide")]
    public void hide()
    {
        Clear();
        StartCoroutine(move(show_point.position, hide_point.position));
    }


    
    private void Clear()
    {
        foreach (var item in ores_spawned)
        {
            if(item != null) Destroy(item);
        }
        ores_spawned.Clear();
    }

    private void GenerateMetalOre()
    {
        var delta = Random.Range(0f, 1f);
        var d = Random.insideUnitCircle;
        var direction = new Vector3(d.x, 0, d.y);
        var origin = Vector3.Lerp(limit_down.position, limit_up.position, delta) - direction * offset;
        GameObject m;
        if(Physics.Raycast(origin, direction, out RaycastHit hit, offset, mask))
        {
            m = Instantiate(orePrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up), transform); 
        }
        else
        {
            m = Instantiate(orePrefab, default_point.position, default_point.rotation, transform); 
        }
        int random = Random.Range(0, metals.Length);
        m.GetComponent<MetalFragment>().SetMetal(metals[random]);
        ores_spawned.Add(m);
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
}
