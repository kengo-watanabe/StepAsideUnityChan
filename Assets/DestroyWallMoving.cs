using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallMoving : MonoBehaviour {

    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんと壁の距離
    private float difference;

	// Use this for initialization
	void Start () {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんと壁の位置の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
		
	}
	
	// Update is called once per frame
	void Update () {
        //Unityちゃんの位置に合わせて壁の位置を移動
        this.transform.position = new Vector3(0, transform.position.y, this.unitychan.transform.position.z - this.difference);
		
        //壁に当たったオブジェクトを破壊

	}

    //トリガーモードでほかのオブジェクトに当たった場合の処理
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
