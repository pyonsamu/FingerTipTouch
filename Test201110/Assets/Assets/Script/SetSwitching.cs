using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSwitching : MonoBehaviour {
    public GameObject[] set;
    int count = 0;

    public GameObject device;
    DeviceController dc;

    public Renderer rend;

    // Use this for initialization
    void Start () {

        set[count].SetActive(true);

        for (int i = 1; i < set.Length; i++)
        {
            set[i].SetActive(false);
        }
        count++;

        dc = device.GetComponent<DeviceController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && OVRInput.GetDown(OVRInput.RawButton.Y) || Input.GetKeyDown(KeyCode.Space))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < set.Length; i++)
            {
                if (i == count)
                {
                    set[i].SetActive(true);
                }
                else
                {
                    set[i].SetActive(false);
                }
            }

            Debug.Log("OK:"+set[count].name);
            count++;
            count = count % set.Length;
            
        }

        //伸縮＋映像
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Alpha1:伸縮＋見える");

            //0は，伸縮　1が振動
            dc.Set_FeedbackPattern(0);

            if (count == 0)
            {
                //set[set.Length - 1].SetActive(true);
                MeshRendererSwitch(set[set.Length - 1], true);
            }
            else
            {
                //set[count - 1].SetActive(true);
                MeshRendererSwitch(set[count - 1], true);
            }

            //振動停止
            DeviceController.vibrationFrag = false;
        }

        //伸縮＋見えない
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Alpha2:伸縮＋見えない");

            //0は，伸縮　1が振動
            dc.Set_FeedbackPattern(0);

            if (count == 0)
            {
                //set[set.Length - 1].SetActive(true);
                MeshRendererSwitch(set[set.Length - 1], false);
            }
            else
            {
                //set[count - 1].SetActive(true);
                MeshRendererSwitch(set[count - 1], false);
            }

            //振動停止
            DeviceController.vibrationFrag = false;
        }

        //振動＋見える
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Alpha3:振動＋見える");

            //0は，伸縮　1が振動
            dc.Set_FeedbackPattern(1);

            if (count == 0)
            {
                //set[set.Length - 1].SetActive(true);
                MeshRendererSwitch(set[set.Length - 1], true);
            }
            else
            {
                //set[count - 1].SetActive(true);
                MeshRendererSwitch(set[count - 1], true);
            }
        }

        //触覚なし＋見える
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Alpha4:触覚なし＋見える");

            //0は，伸縮　1が振動
            dc.Set_FeedbackPattern(2);

            if (count == 0)
            {
                //set[set.Length - 1].SetActive(true);
                MeshRendererSwitch(set[set.Length - 1], true);
            }
            else
            {
                //set[count - 1].SetActive(true);
                MeshRendererSwitch(set[count - 1], true);
            }

            //振動停止
            DeviceController.vibrationFrag = false;
        }
    }

    public void MeshRendererSwitch(GameObject game,bool OnOff)
    {
        rend = game.GetComponent<MeshRenderer>();
        rend.enabled = OnOff;
    }

}
