using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opossum : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{this.gameObject.name}.OnCollisionEnter2D{collision.gameObject.name}/{collision.gameObject.tag}");
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            //Instantiate(collision.gameObject);
            //SceneManager.LoadScene(0); 
        }  
    }
}
