using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
//	GameObject enemy;				//検索したオブジェクト入れる用
	public int enemyHp;				//敵のHP
	public int enemyScore;			//敵のスコア
//	public int moveSpeed = 2;		//enemyの左右移動速度
	GameObject gameController;		//検索したオブジェクト入れる用
	public GameObject item = null;	//Enemyから出現させるアイテム

	void Start(){
//		enemy = GameObject.FindWithTag ("Enemy");					//Enemyタグのオブジェクトを探す
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	void Update () {
		//rbって仮の変数にRigidbody2Dコンポーネントを入れる
//		Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
		//移動させる(左右反転処理している)
//		rb.velocity = new Vector2(transform.localScale.x * moveSpeed, rb.velocity.y);
	}


	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		//通常弾との判定
		if(other.tag == "Bullet"){
//			Debug.Log("hit!!");
			if(enemyHp > 0){
				enemyHp -= 1;
//				Debug.Log("EneyHP=" + enemyHp);
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
