using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public int id;
    public string name;
    public ItemData()
    {
        this.id = 0;
        this.name = "none";
    }
    public ItemData(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
