using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputZone : MonoBehaviour
{
    public void OutputResourceItem(Resource resource, float scale)
    {
        var resourceItemObject = Instantiate(resource.prefab, transform.position, transform.rotation);
        resourceItemObject.transform.localScale = Vector3.one * scale;
    }
}
