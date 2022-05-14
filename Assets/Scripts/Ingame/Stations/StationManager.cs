using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{   
   public float animation_time = 0.5f;

   public Station[] stations;

   public int activeStation = 0;

   private void Start() {
       for (int i = 0; i < stations.Length; i++)
       {
           stations[i].gameObject.SetActive(i == activeStation);
       }
   }

   public void ActiveStation(int idx)
   {
       if(idx < 0 || idx >= stations.Length) return;
       stations[activeStation].gameObject.SetActive(false);
       stations[idx].gameObject.SetActive(true);
       activeStation = idx;
   }
}
