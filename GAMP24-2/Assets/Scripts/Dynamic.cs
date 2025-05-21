using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
            transform.position += Vector3.right * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += Vector3.left * speed* Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
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
            //Destroy(this.gameObject); //����
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ////�ݶ��̴��� ����ϸ� �ɸ��� ������ ����. �׷��Ƿ� Ʈ���Ÿ� ����Ѵ�.
        //Debug.Log($"OnCollisionEnter:{collision.gameObject.name}");
        ////if(collision.gameObject.name == "cherry")
        //if (collision.gameObject.tag == "Item")
        //{
        //    score++;
        //    //Destroy(this.gameObject); //����
        //    Destroy(collision.gameObject);
        //}
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 300, 200), $"Score:{score}");
    }
}
