using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType : int
{
    Weapon = 0,
    HealthPotion = 1,
    StaminaPotion = 2,
    Defult
}

[CreateAssetMenu(fileName ="Item", menuName = "Inventory System/Items/Item")]
public class ItemObject : ScriptableObject
{
    public ItemType type;
    public bool stackable;

    public Sprite icon;
    public GameObject modelPrefab;

    public NewItem data = new NewItem();

    public List<string> boneNames = new List<string>();

    [TextArea(15, 20)]
    public string description;

    private void OnValidate()
    {
        boneNames.Clear();

        if(modelPrefab == null || modelPrefab.GetComponentInChildren<SkinnedMeshRenderer>() == null)
        {
            return;
        }

        SkinnedMeshRenderer renderer = modelPrefab.GetComponentInChildren<SkinnedMeshRenderer>();
        Transform[] bones = renderer.bones;

        foreach(Transform t in bones)
        {
            boneNames.Add(t.name);
        }
    }

    public NewItem CreateItem()
    {
        NewItem newItem = new NewItem(this);
        return newItem;
    }
}
