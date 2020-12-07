using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldScript : MonoBehaviour
{

    public Text txt;
    public Text txt2;
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
        string str = txt.text;
        Debug.Log(str);
        sh_sol.Write("0;");
        sh_mor.Write(str+";");
        GetComponent<InputField>().text="";
        txt2.text = str;
        
    }

    public void sendSolenoid()
    {
        sh_sol.Write("1;");
    }
}
