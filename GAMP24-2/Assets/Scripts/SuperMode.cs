using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMode : MonoBehaviour
{
    public float time;
    public bool isUse;
    public bool Use { get { return isUse; } }
    public SpriteRenderer spriteRenderer;

    IEnumerator ProccessTime()
    {
        isUse = true;
        yield return new WaitForSeconds(time);
        GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
        isUse = false;
    }

    public void OnMode()
    {
        StartCoroutine(ProccessTime());
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isUse) OnMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUse)
        {
            if (spriteRenderer.color == Color.white)
                spriteRenderer.color = Color.clear;
            else if (spriteRenderer.color == Color.clear)
                spriteRenderer.color = Color.white;
        }
    }
}
