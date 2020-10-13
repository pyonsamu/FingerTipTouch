using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public GameObject target;
    public GameObject tipfront;
    public GameObject tipbottom;
    public SerialHandler sh;

    private float timer=0;
    private float timer2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        sh.GetComponent<SerialHandler>().Write(1023.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit");
    }

    private void OnTriggerStay(Collider other)
    {
        if(Time.time - timer > 0.1)
        {
            timer = Time.time;
            RaycastHit[] hit = new RaycastHit[100] ;
            foreach (RaycastHit h in Physics.RaycastAll(tipbottom.transform.position, tipfront.transform.position - tipbottom.transform.position))
            {
                if (h.collider)
                {
                    if (h.collider.tag.Equals("tipfront"))
                    {
                        hit[0] = h;
                    }
                    else if (h.collider.tag.Equals("target"))
                    {
                        hit[1] = h;
                    }
                }
            }
            Debug.Log(hit[1].collider.tag);
            float dis = hit[0].distance - hit[1].distance;

            if (Time.time - timer2 > 0.1)
            {
                timer2 = Time.time;
                moveActuater((int)(dis * 100 * 1023 / 20));
            }
            
            if (dis > 0)
            {

                moveTarget((tipfront.transform.position - tipbottom.transform.position).normalized * dis);
            }
            
        }
        
    }

    private void moveActuater(int dis)
    {
        sh.GetComponent<SerialHandler>().Write((1023-dis).ToString());
        Debug.Log(dis);
    }
    
    private void moveTarget(Vector3 vecpow)
    {
        Debug.Log(vecpow);
        Rigidbody rb = target.GetComponent<Rigidbody>();
        rb.AddForce(vecpow);

    }
}
