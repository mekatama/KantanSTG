using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public GameObject[] enemyObject;	//敵のプレハブを配列で管理
	public GameObject enemyHolder;		//敵のプレハブをヒエラルキー画面でまとめるため
	public float timeOut;				//敵を出現させたい時間間隔
	private float timeElapsed;			//時間を仮に格納する変数
	public int moveSpeed = 1;			//enemyの左右移動速度
	GameObject gameController;			//検索したオブジェクト入れる用
	private int eType;					//enemyの種類

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	void Update () {
		//時間チェック
		timeElapsed += Time.deltaTime;	//経過時間の保存
        if(timeElapsed >= timeOut) {	//指定した経過時間に達したら
			EnemyGo();
		}
	}

	public void EnemyGo(){
		//ランダムで出現位置を決める
		float x_pos = Random.Range(-2.0f,2.0f); 
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();

		//難易度で出現する敵の種類を決める
		if(gc.totalLevel < 3){
			eType = 0;
		}else if(gc.totalLevel >= 3 && gc.totalLevel < 6){
			eType = Random.Range(0,2);
		}else if(gc.totalLevel >= 6 && gc.totalLevel < 9){
			eType = Random.Range(0,3);
		}else if(gc.totalLevel >= 9){
			eType = Random.Range(0,4);
		}

		//敵を生成する
		GameObject enemy = (GameObject)Instantiate(
			enemyObject[eType],	//■仮で0を入れている。0～4を想定
			new Vector2(x_pos, transform.position.y),
			transform.rotation
		);
		//親オブジェクトの設定
		enemy.transform.parent = enemyHolder.transform;

		//生成時にaddforce
		//EnemyのRigidbodyを取得して、左右移動する
		Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();	//コンポーネント取得
		//左右移動、難易度でアップ(左右はランダム)
		//難易度で落下速度アップ
		int LRran = Random.Range(0,2);
		if(LRran == 0){
			enemyRigidbody.AddForce(new Vector2(gc.totalLevel, gc.totalLevel));
		}else{
			enemyRigidbody.AddForce(new Vector2(gc.totalLevel * -1, gc.totalLevel));
		}
	
		timeElapsed = 0.0f;			//リセット
	}
}