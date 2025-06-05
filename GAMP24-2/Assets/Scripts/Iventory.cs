using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iventory : MonoBehaviour
{
    public List<Item> listItems;

    public void SetItem(Item item)
    {
        listItems.Add(item);
    }

    public void RemoveItem(Item item)
    {
        listItems.Remove(item);
    }

    int idx;

    private void OnGUI()
    {
        int w = 100;
        int h = 20;

        for (int y = 0; y < listItems.Count; y++)
        {
            if (GUI.Button(new Rect(w * idx, h * y, w, h), $"[{y}]:{listItems[idx].name}"))
            {
                listItems[y].Use(this.gameObject);
                RemoveItem(listItems[y]);
            }
        }
    }
}
