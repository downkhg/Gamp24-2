using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform trMozzle;
    public GameObject objBullet;
    public float shotPower = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update xis called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(objBullet, trMozzle.position, Quaternion.identity);
            Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(Vector3.right * shotPower);
            Destroy(bullet,1);
        }
    }
}
