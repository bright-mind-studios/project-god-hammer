using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweening;

public class ChestStation : MonoBehaviour
{
    [SerializeField] Transform sections;
    [SerializeField] float rotation_time = 1f;

    [SerializeField] float current_angle = 0;

    public void rotate(int dir){
        StopAllCoroutines();
        StartCoroutine(rotateSections(current_angle, dir));
        current_angle += 90 * dir;
    }

    private IEnumerator rotateSections(float init_angle, int dir)
    {
        var current_time = 0f;
        var delta = 1 / rotation_time; 
        var angle = init_angle;        
        var final_angle = init_angle + 90 * dir;   
        sections.rotation = Quaternion.AngleAxis(current_angle, Vector3.right);     
        while(dir == 1 ? angle < final_angle : angle > final_angle)
        {
            current_time += Time.deltaTime;
            var t = delta * current_time;     
            angle = init_angle + t * 90 * dir;
            sections.rotation = Quaternion.AngleAxis(angle, Vector3.right);
            yield return null;
        }
        sections.rotation = Quaternion.AngleAxis(final_angle, Vector3.right);           
    }

}
