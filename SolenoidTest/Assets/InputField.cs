using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{

    public GameObject text;
    public GameObject serialhandler_mor;
    private SerialHandler sh_mor;
    public GameObject serialhandler_sol;
    private SerialHandler sh_sol;
    // Start is called before the first frame update
    void Start()
    {
        sh_mor = serialhandler_mor.GetComponent<SerialHandler>();
        sh_sol = serialhandler_sol.GetComponent<SerialHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendMessage()
    {
        string str = text.GetComponent<Text>().text;
        sh_sol.Write("0;");
        sh_mor.Write(str+";");
    }

    public void sendSolenoid()
    {
        sh_sol.Write("1;");
    }
}
