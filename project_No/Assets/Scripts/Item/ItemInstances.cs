using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstances
{
    public List<Transform> itemTransforms = new List<Transform>();

    public void Destory()
    {
        foreach (Transform item in itemTransforms)
        {
            GameObject.Destroy(item.gameObject);
        }
    }
}
