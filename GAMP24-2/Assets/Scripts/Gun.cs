using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform trMozzle;
    public GameObject prefabBullet;
    public float shotPower = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update xis called once per frame
    void Update()
    {
        
    }

    public void Shot(Vector3 dir, Player player)
    {
        GameObject objBullet = Instantiate(prefabBullet, trMozzle.position, Quaternion.identity);
        Bullet bullet = objBullet.GetComponent<Bullet>();
        bullet.playerMaster = player;
        Rigidbody2D rigidbody2D = objBullet.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(dir * shotPower);
        Destroy(objBullet, 1);
    }
}
