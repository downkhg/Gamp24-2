using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraTracker cameraTracker;
    public Responner responnerPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTracker.objTarget == null)
        {
            cameraTracker.objTarget = responnerPlayer.objPlayer;
        }
    }
}
