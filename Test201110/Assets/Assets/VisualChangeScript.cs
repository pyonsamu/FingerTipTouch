using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualChangeScript : MonoBehaviour {

    Vector3 OculusTouchPosi;
    public GameObject feild;
    public GameObject cameraObj;
    public GameObject controller_left;

    //この2つはDebugの時のみInspectorで指定
    public GameObject endObj;
    public GameObject tipObj;

    public float rayDist = 2.0f;
    public float tipToObjDist = 1.0f;

    public bool DebugMode = true;

    Vector3 mouseOrigin;
    private bool mouseFlag = false;
    //private GameObject pointObj;

    public static bool mixExtendDeviceFrag = false; //200727 kataoka デバイス伸縮と組み合わせるフラグ

    // Use this for initialization
    void Start () {

        //if(tipObj != null && endObj != null)
        //{
        //    pointObj = Instantiate(endObj, (endObj.transform.position + tipObj.transform.position) * 0.5f, Quaternion.identity, this.transform);
        //}

    }
	
	// Update is called once per frame
	void Update () {

        //OclusTouchBotton();

        #region 事前準備(Device直下に生成される先端と後端を検索)
        if (tipObj == null)
        {
            tipObj = GameObject.Find("Device_Tip");
        }
        if (endObj == null)
        {
            endObj = GameObject.Find("Device_End");
        }
        //if (tipObj != null && endObj != null && pointObj == null)
        //{
        //    pointObj = Instantiate(endObj, (endObj.transform.position + tipObj.transform.position) * 0.5f, Quaternion.identity, this.transform);
        //}
        #endregion


        if (DebugMode)
        {
            #region tipとマウス同期
            if (Input.GetMouseButtonDown(0))
            {
                mouseFlag = true;
                mouseOrigin = Input.mousePosition;

            }
            else if (Input.GetMouseButtonUp(0))
            {
                mouseFlag = false;
            }
            //Debug.Log(mouseFlag);
            if (mouseFlag)
            {
                Vector3 position = Input.mousePosition - mouseOrigin;
                Debug.Log(position.ToString());
                tipObj.transform.position += new Vector3(position.x / 100.0f, 0.0f, position.y / 100.0f);
                mouseOrigin = Input.mousePosition;
            }
            #endregion
        }
        else
        {
            //tipとコントローラの同期→子Objectにすることで解決
            //tipObj.transform.position = 5.0f * OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch) + 1.0f * Vector3.down;
            //transform.position = 5.0f * OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch) + 1.0f * Vector3.down;

        }

        //左のコントローラで机の位置制御
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            //Debug.Log("左人差し指トリガーを握っている " + OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).ToString());
            //feild.transform.position = new Vector3(feild.transform.position.x, controller_left.transform.position.y - 0.5f, feild.transform.position.z);
            feild.transform.position = new Vector3(controller_left.transform.position.x, controller_left.transform.position.y - 0.5f, controller_left.transform.position.z + 4.1f);
        }

        if ((OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && mixExtendDeviceFrag) || DebugMode)
        {
            //Debug.Log("右人差し指トリガーを握っている");
            ObjDistFromRayCast();
        }


        // Rキーで位置トラッキングをリセットする
        if (Input.GetKeyDown(KeyCode.R))
        {
            OVRManager.display.RecenterPose();
        }
    }

    void OclusTouchBotton() //HMDかぶらないと反応しない（参考：https://framesynthesis.jp/tech/unity/touch/）
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("Aボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            Debug.Log("Bボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("Xボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            Debug.Log("Yボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            Debug.Log("メニューボタン（左アナログスティックの下にある）を押した");
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Debug.Log("右人差し指トリガーを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            Debug.Log("右中指トリガーを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            Debug.Log("左人差し指トリガーを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            Debug.Log("左中指トリガーを押した");
        }
    }

    void ObjDistFromRayCast()
    {
        //Rayの飛ばせる距離
        float distance = rayDist * Vector3.Distance(endObj.transform.position, tipObj.transform.position - endObj.transform.position);

        //Rayの生成と可視化
        //Ray ray = new Ray(tipObj.transform.position, new Vector3(0, -1, 0) * distance);

        //Rayの生成と可視化(相対位置だといまいち上手く判定しなかったからGameObject同士でRayを生成)
        //tipが先端，endeはRayの終点
        Ray ray = new Ray(endObj.transform.position, tipObj.transform.position - endObj.transform.position);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 3);

        ////Rayが当たったオブジェクトの情報を入れる箱
        //RaycastHit hit;

        ////もしRayにオブジェクトが衝突したら（おそらく最初のオブジェクトを出力）
        ////                ↓Ray  ↓Rayが当たったオブジェクト ↓距離
        //if (Physics.Raycast(ray, out hit, distance))
        //{
        //    //Rayが当たるオブジェクトがあった場合はそのオブジェクト名をログに表示
        //    Debug.Log(hit.collider.gameObject.name + " " + hit.point.ToString());

        //    //当たったObjectの親の名前がfieldオブジェクトの名前と同じとき
        //    if (hit.transform.parent.name == feild.name)
        //    {
        //        //Debug.Log(hit.collider.gameObject.name + " " + hit.point.ToString() + " " + hit.distance.ToString());

        //        if (tipObj.transform.position.y != hit.point.y)
        //        {
        //            feild.transform.position += new Vector3(0, tipObj.transform.position.y - hit.point.y, 0);
        //            cameraObj.transform.position += new Vector3(0, tipObj.transform.position.y - hit.point.y, 0);
        //        }

        //    }
        //    //Instantiate(endObj, hit.point, Quaternion.identity);

        //}

        float min_y = 1000.0f;
        Vector3 hitPoint = Vector3.zero;

        //Rayによる衝突判定（Rayに衝突したオブジェクトを全部見たいときはこっち）
        foreach (RaycastHit hitObj in Physics.RaycastAll(ray))
        {

            //Debug.Log(hitObj.collider.gameObject.transform.name + " " + hitObj.point.ToString());
            //feild.transform.position = new Vector3(feild.transform.position.x, (tipObj.transform.position.y + endObj.transform.position.y)/2.0f, feild.transform.position.z);
            //当たったObjectの親の名前がfieldオブジェクトの名前と同じとき
            if (hitObj.transform.parent.name == feild.name)
            {
                //Debug.Log(hit.collider.gameObject.name + " " + hit.point.ToString() + " " + hit.distance.ToString());
                if(tipObj.transform.position.y - hitObj.point.y < min_y)
                {
                    min_y = tipObj.transform.position.y - hitObj.point.y;
                    hitPoint = hitObj.point;
                }
                

            }
        }

        if (tipObj.transform.position.y != hitPoint.y && hitPoint != Vector3.zero)
        {
            feild.transform.position += new Vector3(0, tipObj.transform.position.y - hitPoint.y, 0);
            cameraObj.transform.position += new Vector3(0, tipObj.transform.position.y - hitPoint.y, 0);
        }

    }

}
