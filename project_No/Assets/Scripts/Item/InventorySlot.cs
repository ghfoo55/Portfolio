using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    public ItemType[] allowedItems = new ItemType[0];

    [NonSerialized]
    public InventoryObject parent;
    [NonSerialized]
    public GameObject slotUI;

    [NonSerialized]
    public Action<InventorySlot> OnPreUpdate;
    [NonSerialized]
    public Action<InventorySlot> OnPostUpdate;

    public NewItem item;
    public int amount;

    public ItemObject itemObject
    {
        get
        {
            return item.id >= 0 ? parent.database.itemObjects[item.id] : null;
        }
    }

    public InventorySlot() => UpdateSlot(new NewItem(), 0);
    public InventorySlot(NewItem item, int amount) => UpdateSlot(item, amount);

    public void AddItem(NewItem item, int amount) => UpdateSlot(item, amount);

    public void RemoveItem() => UpdateSlot(new NewItem(), 0);

    public void AddAmount(int value) => UpdateSlot(item, amount += value);

    public void UpdateSlot(NewItem item, int amount)
    {
        if(amount <= 0)
        {
            item = new NewItem();
        }

        OnPreUpdate?.Invoke(this);

        this.item = item;
        this.amount = amount;

        OnPostUpdate?.Invoke(this);
    }

    public bool CanPlaceInSlot(ItemObject itemObject)
    {
        if(allowedItems.Length <= 0 || itemObject == null || itemObject.data.id < 0)
        {
            return true;
        }
        foreach(ItemType type in allowedItems)
        {
            if(itemObject.type == type)
            {
                return true;
            }
        }

        return false;
    }
}
