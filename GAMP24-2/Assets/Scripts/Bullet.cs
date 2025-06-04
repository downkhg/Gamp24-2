using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player playerMaster;
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
        if (collision.tag == "Monster")
        {
            Player playerTarget = collision.gameObject.GetComponent<Player>();

            if (playerTarget && playerMaster)
            {
                SuperMode superMode = collision.GetComponent<SuperMode>();

                if (!superMode.Use)
                {
                    playerMaster.Attack(playerTarget);
                    Destroy(this.gameObject);
                    superMode.OnMode();
                    if (playerTarget.Death())
                    {
                        playerMaster.GetExp(playerTarget);
                        playerMaster.LvUp();
                       
                        Destroy(collision.gameObject);
                    }
                }
            }
        } 
    }
}
