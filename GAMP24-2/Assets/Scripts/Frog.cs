using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    public float curTime = -1;
    public float time;

    public bool isJump;
    public bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
            Move();

        if (curTime < 0) //-1 < 0 -> T
        {
            Debug.Log($"Start");
            curTime = 0; // 0
        }


        if (curTime >= 0)
        {
            curTime += Time.deltaTime;
        }


        if (curTime >= time)
        {
            Debug.Log($"Jump!");
            Jump();
            isJump = true;
            isMove = true;
            curTime = -1;
        }
    }


    private void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void Jump()
    {
        isJump = true;
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
        isMove = false;
    }
}
