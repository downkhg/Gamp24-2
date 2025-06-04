using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dynamic : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public int score;

    public Gun gun;
    public Vector3 vDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            vDir = Vector3.right;
            //Vector3 vScale = transform.localScale;
            //vScale.x = 1;
            //transform.localScale = vScale;
            transform.localRotation = Quaternion.identity;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            vDir = Vector3.left;
            //Vector3 vScale = transform.localScale;
            //vScale.x = -1;
            //transform.localScale = vScale;
            transform.localRotation = Quaternion.AngleAxis(180,Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);

        if (Input.GetKeyDown(KeyCode.Z))
            gun.Shot(vDir, GetComponent<Player>());

    }

    private void OnDestroy()
    {
        //Instantiate(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"OnCollisionEnter:{collision.gameObject.name}");
        //if(collision.gameObject.name == "cherry")
        if (collision.gameObject.tag == "Item")
        {
            score++;
            //Destroy(this.gameObject); //함정
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ////콜라이더에 사용하면 걸리는 느낌이 난다. 그러므로 트리거를 사용한다.
        //Debug.Log($"OnCollisionEnter:{collision.gameObject.name}");
        ////if(collision.gameObject.name == "cherry")
        //if (collision.gameObject.tag == "Item")
        //{
        //    score++;
        //    //Destroy(this.gameObject); //함정
        //    Destroy(collision.gameObject);
        //}
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), $"Score:{score}");
    }
}
