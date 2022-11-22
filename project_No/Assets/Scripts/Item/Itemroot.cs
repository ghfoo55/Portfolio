using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemroot : MonoBehaviour
{
    public ItemObject itemObject;
    public InventoryObject inventoryObject;
    public ItemDataBase itemData;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(inventoryObject.AddItem(new NewItem(itemObject), 1))
            {
                Destroy(this.gameObject);
            }                
        }
    }
}