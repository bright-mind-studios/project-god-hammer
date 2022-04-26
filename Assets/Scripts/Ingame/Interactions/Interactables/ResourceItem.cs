using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceItem<R>: GrabInteractable where R : Resource 
{
    public R resource;
}
