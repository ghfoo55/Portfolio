using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StaticInventoryUI : InventoryUI
{
    public GameObject[] staticSlots;
       
    public override void CreateSlotUIs()
    {
        slotUIs = new Dictionary<GameObject, InventorySlot>();

        for(int i = 0; i < inventoryObject.Slots.Length; i++)
        {
            GameObject uiGo = staticSlots[i];

            AddEvent(uiGo, EventTriggerType.PointerEnter, delegate { OnEnterSlot(uiGo); });
            AddEvent(uiGo, EventTriggerType.PointerExit, delegate { OnExitSlot(uiGo); });
            AddEvent(uiGo, EventTriggerType.BeginDrag, delegate { OnStartDrag(uiGo); });
            AddEvent(uiGo, EventTriggerType.EndDrag, delegate { OnEndDrag(uiGo); });
            AddEvent(uiGo, EventTriggerType.Drag, delegate { OnDrag(uiGo); });
            AddEvent(uiGo, EventTriggerType.PointerClick, (data) => { OnClick(uiGo, (PointerEventData)data); });

            inventoryObject.Slots[i].slotUI = uiGo;
            slotUIs.Add(uiGo, inventoryObject.Slots[i]);

            uiGo.name += ": " + i;
        }
    }    
}
