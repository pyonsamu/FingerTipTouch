using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialHandlerControler : MonoBehaviour
{
    public GameObject serialhandler_mor;
    private SerialHandler2 sh_mor;
    public GameObject serialhandler_sol;
    private SerialHandler2 sh_sol;
    private int prenum = 0;
    // Start is called before the first frame update
    void Start()
    {
        sh_mor = serialhandler_mor.GetComponent<SerialHandler2>();
        sh_sol = serialhandler_sol.GetComponent<SerialHandler2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendMessage(string str)
    {
        //Debug.Log("sendMessage");
        int num = int.Parse(str);
        Debug.Log(prenum - num);
        if (Math.Abs(prenum - num) > 3) 
        {
            sh_sol.Write("0;");
            sh_mor.Write(str + ";");
            prenum = num;
        }

        
    }

    public void datareceived(string str)
    {
        if (int.Parse(str) == 1)
        {
           //Debug.Log(str);
           sh_sol.Write("1;");
        }
    }
}
