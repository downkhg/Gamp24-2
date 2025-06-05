using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        //name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(GameObject caster)
    {
        Debug.Log($"{name}.Use({caster.name})");
        caster.gameObject.GetComponent<Dynamic>().score += this.score;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{gameObject.name}[{gameObject.tag}].OnTriggerEnter2D[{collision.gameObject.name}/{collision.gameObject.tag}]");
        if(collision.gameObject.tag == "Player")
        {
            //Use(collision.gameObject);
            Iventory inventroy = collision.GetComponent<Iventory>();
            if(inventroy) inventroy.SetItem(this);
        }
    }
}
