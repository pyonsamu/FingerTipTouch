using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2 : MonoBehaviour
{
    public GameObject target;
    private Vector3 f;
    private Vector3 v;
    private Vector3 prev;
    private Vector3 a;
    private float m;
    private Rigidbody rb;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = target.GetComponent<Rigidbody>();
        v = rb.velocity;
        prev = rb.velocity;
        m = rb.mass;

    }

    // Update is called once per frame
    void Update()
    {
        v = rb.velocity;
        if ((Time.time - timer) > 0.1)
        {
            a = (v - prev) * 10;
        }
        f = -1 * m * a;
        Debug.Log(f);
    }
}
