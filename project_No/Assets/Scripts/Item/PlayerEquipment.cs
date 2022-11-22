using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public InventoryObject equipment;

    private EquipmentCombiner combiner;

    private ItemInstances[] itemInstances = new ItemInstances[8];

    public ItemObject[] defalutItemObjects = new ItemObject[8];

    private void Awake()
    {
        combiner = new EquipmentCombiner(gameObject);

        for(int i = 0; i < equipment.Slots.Length; ++i)
        {
            equipment.Slots[i].OnPreUpdate += OnRemoveItem;
            equipment.Slots[i].OnPostUpdate += OnEquipItem;
        }
    }

    private void Start()
    {
        foreach(InventorySlot slot in equipment.Slots)
        {
            OnEquipItem(slot);
        }
    }

    private void OnEquipItem(InventorySlot slot)
    {
        ItemObject itemObject = slot.itemObject;
        if (itemObject == null)
        {
            EuipDefaultItemBy(slot.allowedItems[0]);
            return;
        }

        int index = (int)slot.allowedItems[0];

        switch(slot.allowedItems[0])
        {           
            case ItemType.Weapon :
                itemInstances[index] = EquipMeshItem(itemObject);
                break;
        }
    }

    private ItemInstances EquipSkinnedItem(ItemObject itemObject)
    {
        if(itemObject == null)
        {
            return null;
        }
        Transform itemTransform = combiner.AddLimb(itemObject.modelPrefab, itemObject.boneNames);
        
        ItemInstances instance = new ItemInstances();
        if(itemTransform != null)
        {
            instance.itemTransforms.Add(itemTransform);
            return instance;
        }

        return null;
    }

    private ItemInstances EquipMeshItem(ItemObject itemObject)
    {
        if(itemObject == null)
        {
            return null;
        }

        Transform[] itemTransforms = combiner.AddMesh(itemObject.modelPrefab);
        if(itemTransforms.Length > 0)
        {
            ItemInstances instance = new ItemInstances();
            instance.itemTransforms.AddRange(itemTransforms.ToList());

            return instance;
        }

        return null;
    }

    private void EuipDefaultItemBy(ItemType type)
    {
        int index = (int)type;

        ItemObject itemObject = defalutItemObjects[index];

        switch (type)
        {            
            case ItemType.Weapon:
                itemInstances[index] = EquipMeshItem(itemObject);
                break;
        }
    }

    private void OnDestroy()
    {
        foreach (ItemInstances item in itemInstances)
        {
            item.Destory();
        }
    }

    private void OnRemoveItem(InventorySlot slot)
    {
        ItemObject itemObject = slot.itemObject;
        if(itemObject == null)
        {
            RemoveItemBy(slot.allowedItems[0]);
            return;
        }
        if(slot.itemObject.modelPrefab != null)
        {
            RemoveItemBy(slot.allowedItems[0]);
        }
    }

    private void RemoveItemBy(ItemType type)
    {
        int index = (int)type;
        if (itemInstances[index] != null)
        {
            itemInstances[index].Destory();
            itemInstances[index] = null;
        }
    }
}