using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuickSlotkeyInput : MonoBehaviour
{
    PlayerInput inputAction;

    Player player;

    public InventoryObject inventoryObject;    
    private void Awake()
    {        
        inputAction = new();
    }

    private void Start()
    {
        player = GameManager.Inst.MainPlayer;
    }

    private void OnEnable()
    {
        inputAction.QuickSlot.Enable();
        inputAction.QuickSlot.Quick1.performed += Quick1;
        inputAction.QuickSlot.Quick2.performed += Quick2;
        inputAction.QuickSlot.Quick3.performed += Quick3;
    }

    private void OnDisable()
    {
        inputAction.QuickSlot.Quick3.performed -= Quick3;
        inputAction.QuickSlot.Quick2.performed -= Quick2;
        inputAction.QuickSlot.Quick1.performed -= Quick1;
        inputAction.QuickSlot.Disable();
    }

    private void Quick1(InputAction.CallbackContext _)
    {
        ItemUse(inventoryObject.Slots[0]);
    }
    private void Quick2(InputAction.CallbackContext _)
    {
        ItemUse(inventoryObject.Slots[1]);
    }
    private void Quick3(InputAction.CallbackContext _)
    {
        ItemUse(inventoryObject.Slots[2]);
    }

    private void ItemUse(InventorySlot slot)
    {
        ItemObject itemObject = slot.itemObject;

        foreach (ItemBuff buff in itemObject.data.buffs)
        {
            if (buff.stat == CharacterAttribute.Health)
            {
                player.hp += buff.value;
            }
            if (buff.stat == CharacterAttribute.Stamina)
            {
                player.stamina += buff.value;
            }
            else
            {
                player.hp = player.maxHP;
            }
        }

        inventoryObject.UseItem(slot);
        
    }

}
