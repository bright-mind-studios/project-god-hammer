using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public class EnableEffect : IEffect
    {
        private GameObject gameObject;
        private float time;
        private bool enable;

        public EnableEffect(GameObject gameObject, float time, bool enable)
        {
            this.gameObject = gameObject;
            this.time = time;
            this.enable = enable;
        }

        public IEnumerator Execute()
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(enable);
        }        
    }

}