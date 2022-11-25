using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterAttribute
{    
    Health,
    Stamina
}


[Serializable]
public class ItemBuff
{
    public CharacterAttribute stat;
    public int value;

    [SerializeField]
    public int min;

    [SerializeField]
    public int max;

    public int Min => min;
    public int Max => max;

    public ItemBuff(int min, int max)
    {
        this.min = min;
        this.max = max;

        GenerateValue();
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }

    public void AddValue(ref int v)
    {
        v += value;
    }
}
