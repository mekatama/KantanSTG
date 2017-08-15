using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int enemyHp;					//敵のHP
	public int enemyScore;				//敵のスコア
	GameObject gameController;			//検索したオブジェクト入れる用
	public GameObject item = null;		//Enemyから出現させるアイテム
	public int itemGoParam;				//アイテム出現確率(0=アイテム出ない、1=必ずアイテム出る)
	public int itemGoParamBom;			//ボム攻撃時アイテム出現確率(0=アイテム出ない、1=必ずアイテム出る)
	AudioSource audioSource;			//AudioSourceコンポーネント取得用
	public AudioClip audioClipHit;		//HitSE
	public AudioClip audioClipDestroy;	//DestroySE
	public int bomScoreRate;			//ボムのスコア倍率

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		audioSource = gameObject.GetComponent<AudioSource>();		//AudioSourceコンポーネント取得
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		//通常弾との判定
		if(other.tag == "Bullet"){
			audioSource.clip = audioClipHit;				//SE決定
			audioSource.Play ();							//SE再生
//			Debug.Log("hit!!");
			if(enemyHp > 0){
				enemyHp -= 1;
//				Debug.Log("EneyHP=" + enemyHp);
			}
			if(enemyHp <= 0){
//				audioSource.clip = audioClipDestroy;			//SE決定
				AudioSource.PlayClipAtPoint( audioClipDestroy, transform.position);	//SE再生(Destroy対策用)
//				audioSource.Play ();							//SE再生
				//gcって仮の変数にGameControllerのコンポーネントを入れる
				GameController gc = gameController.GetComponent<GameController>();
				gc.totalScore = gc.totalScore + enemyScore;	//スコア加算
				gc.totalKills += 1;							//撃破数加算
				//このGameObjectを［Hierrchy］ビューから削除する
				Destroy(gameObject);
				//itemGoParam分の一の確率でボムアイテムを落とす
				if (Random.Range (0, itemGoParam) == itemGoParam - 1) {
					Instantiate (item, transform.position, transform.rotation);
				}
			}
		}

		//Bomとの判定
		if(other.tag == "Bom"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			//スコア加算
			gc.totalScore = gc.totalScore + (enemyScore * bomScoreRate);//スコア加算
			gc.totalKills += 1;											//撃破数加算
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
			//itemGoParam分の一の確率でボムアイテムを落とす
			if (Random.Range (0, itemGoParamBom) == itemGoParamBom - 1) {
				Instantiate (item, transform.position, transform.rotation);
			}
		}
	}
}
