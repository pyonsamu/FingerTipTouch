﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_ObjBottom : MonoBehaviour {

    string device_n = "Device"; // yama 180122 デバイスのオブジェクト名
    string function = "GetTips";    // yama 180122 オブジェクトの先端座標を渡す変数名

    GameObject point;
    Vector3 vec;
    GameObject device;

    // Use this for initialization
    void Start () {
        Matrix4x4 thisMatrix = transform.localToWorldMatrix;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        Vector3 CreateVer = Vector3.zero; 

        // yama 171221 オブジェクトの頂点探索
        foreach (Vector3 vertex in vertices)
        {
            if(vertex.y < CreateVer.y)
            {
                // yama 171221 ローカル座標においてY軸上で最も下に位置する点の検出
                CreateVer = vertex;
            }
        }

        // yama 171221 オブジェクトの先端に空オブジェクトを生成
        point = new GameObject();
        vec = thisMatrix.MultiplyPoint3x4(CreateVer);
        point.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //Debug.Log("mesh1 vertex at " + thisMatrix.MultiplyPoint3x4(CreateVer));
        point.name = this.name + "_Tip";

        // yama 171221 空オブジェクト以外を作成する際に使用，オブジェクトの大きさなどを指定
        Transform pointTrans = point.transform;
        pointTrans.localPosition = vec;
        //Transform cubeTrans = point.transform;
        //cubeTrans.localScale = Vector3.one * 0.03f;

        // yama 171221 作成した空オブジェクトをデバイスオブジェクトの子オブジェクトに変更
        device = GameObject.Find(device_n);
        point.transform.parent = device.transform;
        // yama 181031 デバイスの子オブジェクトだとOculusTouchとの位置関係をもとに座標を求めることが難しかったため，オブジェクトの作成場所を変更
        //point.transform.parent = (device.transform.root.gameObject).transform;
        //point.transform.parent = (device.transform.parent.gameObject).transform;

        // yama 171221 スクリプトを取り付けたオブジェクトの先端座標を渡す
        device.SendMessage(function, point);

    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("point: x = " + point.transform.position.x + ", y = " + point.transform.position.y + ", z = " + point.transform.position.z);
    }
}
