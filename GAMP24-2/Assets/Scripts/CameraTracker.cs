using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject objTarget;

    public float speed;
    public Vector3 vDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objTarget == null) return;

        Vector3 vTargetPos = objTarget.transform.position;
        Vector3 vPos = this.transform.position;
        vTargetPos.z = vPos.z;

        Vector3 vDist = vTargetPos - vPos;
        vDir = vDist.normalized;

        float fDist = vDist.magnitude;
        float fMoveFPS = speed * Time.deltaTime;

        Debug.DrawLine(vPos, vPos + vDir * fMoveFPS);

        if (fDist > fMoveFPS)
            transform.position += vDir * speed * Time.deltaTime;
    }
}
