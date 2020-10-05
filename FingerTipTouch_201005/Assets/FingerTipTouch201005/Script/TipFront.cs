using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipFront : MonoBehaviour
{

    public int stay = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        stay++;
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        stay--;
    }
}
