using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialHandler : MonoBehaviour
{
    public GameObject SerialHandlerControler;
    private SerialHandlerControler shc;
    // Start is called before the first frame update
    void Start()
    {
        shc = SerialHandlerControler.GetComponent<SerialHandlerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Write(string str)
    {
        shc.sendMessage(str);
    }
}
