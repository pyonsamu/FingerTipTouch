using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallibrationBase : MonoBehaviour {

    int callib_count = 0;           // yama 180201 Oculus Touchの座標をいくつ取得したか
    Vector3 rHand_pos, lHand_pos;   // yama 180201 左右のOculus Touchの座標 
    //float offset = 0.38f;            // yama 180201 Oculus Touchを置いた際の、中心から接地面までの距離
    float offset = 0.0f;            // yama 180201 Oculus Touchを置いた際の、中心から接地面までの距離

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    /// <summary>
    /// 左右のOculus Touchの座標をもとに接地面の座標を算出
    /// </summary>
    void Set_Position()
    {
        if (callib_count == 2)
        {
            float base_y = (rHand_pos.y + lHand_pos.y) / 2 - offset;
            Debug.Log(base_y);
            this.transform.position = new Vector3(this.transform.position.x, base_y, this.transform.position.z);
        }
    }
}
