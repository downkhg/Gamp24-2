using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int nHP;
    public int nDemage;

    public void Attack(Player target)
    {
        target.nHP = target.nHP - this.nDemage;
    }
    public bool Death()
    {
        if (nHP > 0)
            return false;
        else
            return true;
    }

    public int idx;
    private void OnGUI()
    {
        GUI.Box(new Rect(100*idx, 0, 100, 20), $"{gameObject.name}");
        GUI.Box(new Rect(100 * idx, 20, 100, 20), $"Atk:{nDemage}");
        GUI.Box(new Rect(100 * idx, 40, 100, 20), $"HP: {nHP}");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
