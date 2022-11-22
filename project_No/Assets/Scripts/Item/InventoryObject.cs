using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum InterfaceType
{
    Inventory,
    QuickSlot,
    ItemShop
}


[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public ItemDataBase database;
    public InterfaceType type;

    [SerializeField]
    private Inventory container = new Inventory();

    public Action<ItemObject> OnUseItem;

    public InventorySlot[] Slots => container.slots;

    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            foreach (InventorySlot slot in Slots)
            {
                if (slot.item.id < 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }

    public bool AddItem(NewItem item, int amount)
    {
        if (EmptySlotCount <= 0)
        {
            return false;
        }
        InventorySlot slot = FindItemInInventory(item);
        if (!database.itemObjects[item.id].stackable || slot == null)
        {
            GetEmptySlot().AddItem(item, amount);
        }
        else
        {
            slot.AddAmount(amount);
        }
        return true;
    }

    public void UseItem(InventorySlot slotToUse)
    {
        if(slotToUse.itemObject == null || slotToUse.item.id < 0 || slotToUse.amount <= 0)
        {
            return;
        }

        ItemObject itemObject = slotToUse.itemObject;
        slotToUse.UpdateSlot(slotToUse.item, slotToUse.amount - 1);

        OnUseItem.Invoke(itemObject);
    }

    public InventorySlot FindItemInInventory(NewItem item)
    {
        return Slots.FirstOrDefault(i => i.item.id == item.id);
    }

    public InventorySlot GetEmptySlot()
    {
        return Slots.FirstOrDefault(i => i.item.id < 0);
    }

    public bool IsContainItem(ItemObject itemObject)
    {
        return Slots.FirstOrDefault(i => i.item.id == itemObject.data.id) != null;
    }

    public void SwapItems(InventorySlot itemSlotA, InventorySlot itemSlotB)
    {
        if(itemSlotA == itemSlotB)
        {
            return;
        }
        if(itemSlotB.CanPlaceInSlot(itemSlotA.itemObject) && itemSlotA.CanPlaceInSlot(itemSlotB.itemObject))
        {
            InventorySlot tempSlot = new InventorySlot(itemSlotB.item, itemSlotB.amount);
            itemSlotB.UpdateSlot(itemSlotA.item, itemSlotA.amount);
            itemSlotA.UpdateSlot(tempSlot.item, tempSlot.amount);
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        container.Clear();
    }
}
