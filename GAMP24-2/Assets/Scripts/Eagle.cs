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
        else //이동이 끝났을때
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

        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        collider = Physics2D.OverlapCircle(this.transform.position, circleCollider.radius);

        if (circleCollider != null)
        {
            if (collider.tag == "Player")
            {
                Player playerTarget = collider.gameObject.GetComponent<Player>();
                Player playerME = this.gameObject.GetComponent<Player>();

                if (playerTarget && playerME)
                {
                    SuperMode superMode = collider.GetComponent<SuperMode>();

                    if (!superMode.Use)
                    {
                        playerME.Attack(playerTarget);
                        superMode.OnMode();
                        if (playerTarget.Death())
                            Destroy(collider.gameObject);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, site);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player playerTarget = collision.gameObject.GetComponent<Player>();
            Player playerME = this.gameObject.GetComponent<Player>();

            if (playerTarget && playerME)
            {
                SuperMode superMode = collision.GetComponent<SuperMode>();

                if (!superMode.Use)
                {
                    playerME.Attack(playerTarget);
                    superMode.OnMode();
                    if (playerTarget.Death())
                    {
                        playerME.GetExp(playerTarget);
                        playerME.LvUp();
                        Destroy(collision.gameObject);
                    }
                }
            }
        }
    }
}
