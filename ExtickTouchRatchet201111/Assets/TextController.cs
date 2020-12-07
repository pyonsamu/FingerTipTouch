using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public TextMesh text;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            text.text = "A手法";
        }else if (Input.GetKeyDown(KeyCode.B))
        {
            text.text = "B手法";
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            text.text = "C手法";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            text.text = "D手法";
        }

    }
}
