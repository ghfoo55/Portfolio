using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemShopUI : InventoryUI
{
    [SerializeField]
    protected GameObject[] slotPrefab;


    public override void CreateSlotUIs()
    {
        slotUIs = new Dictionary<GameObject, InventorySlot>();

        for (int i = 0; i < inventoryObject.Slots.Length; i++)
        {
            GameObject uiGo = slotPrefab[i];                        

            inventoryObject.Slots[i].slotUI = uiGo;
            slotUIs.Add(uiGo, inventoryObject.Slots[i]);

            uiGo.name += ": " + i;
        }
    }
}
