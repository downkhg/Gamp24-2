using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responner : MonoBehaviour
{
    public GameObject objPlayer;
    public GameObject prefabPlayer;

    public float curTime = -1;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime < 0 && objPlayer == null) 
        {
            curTime = 0;
        }


        if (curTime >= 0)
        {
            curTime += Time.deltaTime;
        }

  
        if (curTime >= time)
        {
            Debug.Log($"objPlayerEnd");
            objPlayer = Instantiate(prefabPlayer, transform.position, Quaternion.identity);
            curTime = -1;
        }
        
    }
}
