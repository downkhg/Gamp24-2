using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData ItemData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{gameObject.name}[{gameObject.tag}].OnTriggerEnter2D[{collision.gameObject.name}/{collision.gameObject.tag}]");
        if(collision.gameObject.tag == "Player")
        {
            //Use(collision.gameObject);
            Iventory inventroy = collision.GetComponent<Iventory>();
            if(inventroy) inventroy.SetItem(ItemData);
        }
    }
}
