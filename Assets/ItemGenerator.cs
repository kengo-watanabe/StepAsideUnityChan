using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    //carprefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject TrafficConePrefab;
    //スタート地点
    private int startpos = -160;
    //ゴール地点
    private int goalpos = 120;
    //アイテムを出すｘ方向の範囲
    private float posRange = 3.4f;

	// Use this for initialization
	void Start () {
        //一定の距離ごとにアイテムを生成
        for(int i = startpos; i < goalpos; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(0, 10);
            if(num >= 1){
                //コーンをx軸方向に１直線に配置
                for(float j = -1;j <= 1;j += 0.4f)
                {
                    GameObject cone = Instantiate(TrafficConePrefab) as GameObject;
                    cone.transform.position = new Vector3(posRange * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for(int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン表示、30%車配置、10%何もなし
                    if(1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }else if(7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
