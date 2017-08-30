using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissLineFall : MonoBehaviour {
	private int enemyTamaruNum;			//敵がたまった数
	private float nextTime;
	public float interval = 1.0f;		//点滅周期
	public Renderer rend;				//点滅させたいオブジェクトを入れる用
	GameObject gameController;			//検索したオブジェクト入れる用
	AudioSource audioSource;			//AudioSourceコンポーネント取得用
	private bool warningFlag = false;	//SE再生制御用

	void Start () {
		nextTime = Time.time;										//現時刻を代入
		rend = GetComponent<Renderer>();							//点滅させたいオブジェクトを入れる用
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		audioSource = GetComponent<AudioSource>();					//AudioSourceコンポーネント取得
	}

	void Update(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//フェンスに接触した敵の数によって、フェンス点滅
		if(!gc.gameOver){
			if(enemyTamaruNum == 2){
				//呼び出されたら
				if(Time.time > nextTime){
					rend.enabled = !rend.enabled;	//表示反転
					nextTime += interval;			//次に点滅する時間をセット
					if(warningFlag == false){
						audioSource.Play ();		//SE再生
						warningFlag = true;			
					}
				}else{
					rend.enabled = true;			//強制的に表示on
					warningFlag = false;
				}
			}else{
				audioSource.Stop ();				//SE停止
			}
		}

		//フェンスに接触した敵の数によって、フェンス落下
		if(enemyTamaruNum == 3){
			audioSource.Stop ();		//SE停止
			rend.enabled = true;		//表示on
			//FreezePositionを無効化する
			gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		}
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Enemy"){
			enemyTamaruNum += 1;
		}
	}

	//他のオブジェクとの当たり判定が解消されたとき判定
	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "Enemy"){
			enemyTamaruNum -= 1;
			rend.enabled = true;	//表示on
		}
	}
}
