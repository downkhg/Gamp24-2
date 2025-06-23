using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIItemButton : MonoBehaviour
{
    public TextMeshPro text;
    public ItemData ItemData;
    // Start is called before the first frame update
   void Set(ItemData itemData)
    {
        text.text = itemData.name;
        ItemData = itemData;
    }

    public void EventClick(GameObject objCastter)
    {
        ItemData.Use(objCastter);
    }
}
