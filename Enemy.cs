using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int enemyHp;				//敵のHP
	public int enemyScore;			//敵のスコア
	GameObject gameController;		//検索したオブジェクト入れる用
	public GameObject item = null;	//Enemyから出現させるアイテム

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		//通常弾との判定
		if(other.tag == "Bullet"){
//			Debug.Log("hit!!");
			if(enemyHp > 0){
				enemyHp -= 1;
				Debug.Log("EneyHP=" + enemyHp);
			}
			if(enemyHp <= 0){
				//gcって仮の変数にGameControllerのコンポーネントを入れる
				GameController gc = gameController.GetComponent<GameController>();
				gc.totalScore = gc.totalScore + enemyScore;
				//このGameObjectを［Hierrchy］ビューから削除する
				Destroy(gameObject);
				//四分の一の確率でボムアイテムを落とす
				if (Random.Range (0, 2) == 0) {
					Instantiate (item, transform.position, transform.rotation);
				}
			}
		}

		//Bomとの判定
		if(other.tag == "Bom"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			//スコア加算
			//【ネタ】ボムの時はスコアがアップする?でも、アイテムは出ない
			gc.totalScore = gc.totalScore + enemyScore;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
