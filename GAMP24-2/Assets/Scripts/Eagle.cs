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

    public Transform trPatrolPoint;

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
        else
        {
            if (objTarget.gameObject.name == trRetrunPoint.name)
                objTarget = trPatrolPoint.gameObject;

            else if (objTarget.gameObject.name == trPatrolPoint.name)
                objTarget = trRetrunPoint.gameObject;
        }
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
        Player playerTarget = collision.gameObject.GetComponent<Player>();
        Player playerME = this.gameObject.GetComponent<Player>();

        if(playerTarget && playerME)
        {
            playerME.Attack(playerTarget);

            if(playerTarget.Death())
                Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            objTarget = collision.gameObject;
    }
}
