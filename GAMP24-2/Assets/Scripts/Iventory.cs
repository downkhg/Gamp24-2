using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iventory : MonoBehaviour
{
    public List<ItemData> listItems = new List<ItemData>();

    public bool SetItem(ItemData item)
    {
        if (item != null)
        {
            Debug.LogWarning($"Item is {item.name}!");
            listItems.Add(item);
            Debug.LogWarning($"Inventory is {listItems[listItems.Count-1].name}!");
            return true;
        }
        else
        {
            Debug.LogError("Item is null!");
            return false;
        }
    }

    public void RemoveItem(ItemData item)
    {
        listItems.Remove(item);
    }

    public int idx;

    private void OnGUI()
    {
        int w = 100;
        int h = 20;

        for (int y = 0; y < listItems.Count; y++)
        {
            if (listItems[y] != null)
            {
                if (GUI.Button(new Rect(w * idx, h * y, w, h), $"[{y}]:{listItems[y].name}"))
                {
                    listItems[y].Use(this.gameObject);
                    RemoveItem(listItems[y]);
                }
            }
        }
    }

    public bool InitChitItem(ItemDataManager itemDataManager)
    {
        if (itemDataManager != null)
        {
            SetItem(itemDataManager.Find("cherry"));
            SetItem(itemDataManager.Find("gem"));
            SetItem(itemDataManager.Find("cherry"));
            SetItem(itemDataManager.Find("gem"));
            SetItem(itemDataManager.Find("cherry"));
            SetItem(itemDataManager.Find("gem"));
            return true;
        }
        else
            Debug.LogError("InitChitItem Failed!");

        return false;
    }

    private void Start()
    {
        //ItemDataManager itemDataManager = GameManager.instacne.itemDataManager;
        ////싱글톤을 활용했다하더라도 객체생성순서에 따른 호출에 오류가 발생가능성이 높음.
        //InitChitItem(itemDataManager);
    }
}
