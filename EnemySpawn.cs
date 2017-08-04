using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public GameObject[] enemyObject;	//敵のプレハブを配列で管理
	public GameObject enemyHolder;		//敵のプレハブをヒエラルキー画面でまとめるため
	public float timeOut;				//敵を出現させたい時間間隔
	private float timeElapsed;			//時間を仮に格納する変数
	public int moveSpeed = 1;			//enemyの左右移動速度
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;	//経過時間の保存
        if(timeElapsed >= timeOut) {	//指定した経過時間に達したら
			EnemyGo();
		}
	}

	public void EnemyGo(){
		//ランダムで出現位置を決める
		float x_pos = Random.Range(-2.0f,2.0f); 
		//敵を生成する
		GameObject enemy = (GameObject)Instantiate(	//プレハフ生成
			enemyObject[0],	//■仮で0を入れている。0～4を想定
			new Vector2(x_pos, transform.position.y),
			transform.rotation
		);
		//親オブジェクトの設定
		enemy.transform.parent = enemyHolder.transform;

		//生成時にaddforce
		//EnemyのRigidbodyを取得して、左右移動する
		Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();	//コンポーネント取得
		//左右移動、仮の数値
		enemyRigidbody.AddForce(new Vector2(10, 0));

		timeElapsed = 0.0f;			//リセット
	}
}