using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public GameObject enemyObject = null;	//敵のプレハブ
	public float timeOut;					//敵を出現させたい時間間隔
	private float timeElapsed;				//時間を仮に格納する変数
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;	//経過時間の保存
        if(timeElapsed >= timeOut) {	//指定した経過時間に達したら
			//ランダムで出現位置を決める
			float x_pos = Random.Range(-2.0f,2.0f); 
			//敵を生成する
			Instantiate(enemyObject,new Vector2(x_pos, transform.position.y),transform.rotation);	//プレハフ生成
			timeElapsed = 0.0f;			//リセット
		}
	}
}