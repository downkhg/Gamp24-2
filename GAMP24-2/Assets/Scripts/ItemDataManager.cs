using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class ItemData
{
    public string name;
    public int score;

    public ItemData(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public void Use(GameObject caster)
    {
        Debug.Log($"{name}.Use({caster.name})");
        caster.gameObject.GetComponent<Dynamic>().score += this.score;
    }
}

public class ItemDataManager : MonoBehaviour
{
    public List<ItemData> listItemDatas;

    public void Init()
    {
        listItemDatas = new List<ItemData>();
        listItemDatas.Add(new ItemData("cherry",1));
        listItemDatas.Add(new ItemData("gem",10));
    }

    public ItemData Find(string name)
    {
        return listItemDatas.Find(x => x.name == name);
    }
}
