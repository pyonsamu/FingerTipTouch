using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControll : MonoBehaviour {
    public GameObject Device;
    public GameObject[] Objs;
    
    private GameObject _parent;

    // Use this for initialization
    void Start()
    {
        //foreach (GameObject gameObject in Objs)
        //{
        //    //親オブジェクトを取得
        //    _parent = gameObject.transform.root.gameObject;

        //    Debug.Log("Parent:" + _parent.name);
        //}

    }
	
	// Update is called once per frame
	void Update () {
		
        if(Objs.Length != 0 && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            foreach(GameObject gameObj in Objs)
            {
                //if (gameObj.GetComponent<MeshRenderer>().enabled)
                if (gameObj.activeInHierarchy)
                {
                    //親オブジェクトを取得
                    _parent = gameObj.transform.root.gameObject;

                    _parent.transform.position = new Vector3(Device.transform.position.x, _parent.transform.position.y, Device.transform.position.z);
                    //gameObj.transform.position = new Vector3(Device.transform.position.x, gameObj.transform.position.y, Device.transform.position.z);

                    Debug.Log("Parent:" + _parent.name);
                }
            }
        }
	}
}
