using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public GameObject objTarget;
    public float site;

    public float speed;
    public Vector3 vDir;

    public Transform trRetrunPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objTarget == null)
        {
            objTarget = trRetrunPoint.gameObject;
            return;
        }

        Vector3 vTargetPos = objTarget.transform.position;
        Vector3 vPos = this.transform.position;

        Vector3 vDist = vTargetPos - vPos;
        vDir = vDist.normalized;

        float fDist = vDist.magnitude;
        float fMoveFPS = speed * Time.deltaTime;

        Debug.DrawLine(vPos,vPos + vDir * fMoveFPS);

        if (fDist > fMoveFPS)
            transform.position += vDir * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapCircle(this.transform.position, site);

        if(collider != null)
        {
            if (collider.tag == "Player")
                objTarget = collider.gameObject;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, site);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            objTarget = collision.gameObject;
    }
}
