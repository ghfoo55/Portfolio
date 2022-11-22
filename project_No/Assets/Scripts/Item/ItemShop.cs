using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemShop : InventoryUI
{    
    public InventoryObject playerInventory;
    public InventoryObject itemShop;
    public RectTransform uiGroup;
    Player enterPlayer;

    public ItemObject[] itemObject;

    public int[] itemPrice;
    public GameObject[] ShopSlots;

    public void Enter(Player player)
    {
        enterPlayer = player;
        uiGroup.gameObject.SetActive(true);
    }

    public void Exit()
    {
        uiGroup.gameObject.SetActive(false);
    }

    public void Buy(int index)
    {       
        int price = itemPrice[index];
        if (price > enterPlayer.money)
        {
            return;
        }
        enterPlayer.money -= price;        
        playerInventory.AddItem(new NewItem(itemObject[index]), itemShop.Slots[index].amount);
    }

    public override void CreateSlotUIs()
    {
        slotUIs = new Dictionary<GameObject, InventorySlot>();

        for (int i = 0; i < inventoryObject.Slots.Length; i++)
        {
            GameObject uiGo = ShopSlots[i];

            inventoryObject.Slots[i].slotUI = uiGo;
            slotUIs.Add(uiGo, inventoryObject.Slots[i]);

            uiGo.name += ": " + i;
        }
    }
}
