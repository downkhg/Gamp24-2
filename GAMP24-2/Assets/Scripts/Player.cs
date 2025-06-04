using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int nHP;
    public int nDemage;
    public int nLv = 1;
    public int nExp;
    public int nMaxExp = 100;

    public void LvUp()
    {
        if(nExp > nMaxExp)
        {
            nLv++;
            nDemage++;
            nHP += 10;
            nExp -= nMaxExp;
        }
    }

    public void GetExp(Player target)
    {
        nExp += target.nExp;
    }

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
        int w = 100;
        int h = 20;
        int y = 0;

        GUI.Box(new Rect(w*idx, h*y, w, h), $"{gameObject.name}[{nLv}]"); y++;
        GUI.Box(new Rect(w * idx, h*y, w, h), $"Atk:{nDemage}"); y++;
        GUI.Box(new Rect(w * idx, h*y, w, h), $"HP: {nHP}"); y++;
        GUI.Box(new Rect(w * idx, h*y, w, h), $"Exp: {nExp}/{nMaxExp}"); y++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LvUp();
    }
}
