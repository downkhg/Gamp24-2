using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responner : MonoBehaviour
{
    public GameObject objPlayer;
    public GameObject prefabPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objPlayer == null)
        {
            objPlayer = Instantiate(prefabPlayer, transform.position, Quaternion.identity);
        }
    }
}
