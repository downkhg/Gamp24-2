using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{gameObject.name}[{gameObject.tag}].OnTriggerEnter2D[{collision.gameObject.name}/{collision.gameObject.tag}]");
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Dynamic>().score += this.score;
        }
    }
}
