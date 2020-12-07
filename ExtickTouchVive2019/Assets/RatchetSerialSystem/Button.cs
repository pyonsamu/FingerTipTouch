using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public GameObject serialhandler;
    private SerialHandler sh;
    // Start is called before the first frame update
    void Start()
    {
        sh = serialhandler.GetComponent<SerialHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        sh.Write("1");
    }
}
