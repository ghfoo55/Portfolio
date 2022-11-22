using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItem : MonoBehaviour
{
    public InventoryObject inventoryObject;
    public ItemDataBase itemData;
    public Button button;
    public Button button2;
    private void Start()
    {
        button = GetComponent<Button>();
        button2 = GetComponent<Button>();
    }

    private void Awake()
    {
        button.onClick.AddListener(AddNewItem);
        button2.onClick.AddListener(ClearInventory);
    }
    public void AddNewItem()
    {        
        if(itemData.itemObjects.Length > 0)
        {
            ItemObject newItemObject = itemData.itemObjects[Random.Range(0, itemData.itemObjects.Length)];
            NewItem newItem = new NewItem(newItemObject);

            inventoryObject.AddItem(newItem, 1);
        }
    }

    public void ClearInventory()
    {
        inventoryObject?.Clear();
    }
}
