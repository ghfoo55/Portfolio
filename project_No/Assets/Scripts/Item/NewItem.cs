using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NewItem
{
    public int id = -1;
    public string name;

    public ItemBuff[] buffs;

    public NewItem()
    {
        id = -1;
        name = "";
    }

    public NewItem(ItemObject itemObject)
    {
        name = itemObject.name;
        id = itemObject.data.id;

        buffs = new ItemBuff[itemObject.data.buffs.Length];
        for (int i = 0; i < buffs.Length; ++i)
        {
            buffs[i] = new ItemBuff(itemObject.data.buffs[i].min, itemObject.data.buffs[i].max)
            {
                stat = itemObject.data.buffs[i].stat
            };
        }
    }
}
