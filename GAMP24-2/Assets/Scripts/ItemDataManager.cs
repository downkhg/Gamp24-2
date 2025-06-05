using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    public List<Item> listItems = new List<Item>();


    public void Init()
    {
        listItems.Add(this.AddComponent<Item>());
        listItems.Add(this.AddComponent<Item>());

        listItems[0].name = "cherry";
        listItems[1].name = "zem";
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
