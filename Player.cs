using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	GameObject playey;								//検索したオブジェクト入れる用
	GameObject tapArea;								//検索したオブジェクト入れる用
	GameObject gameController;						//検索したオブジェクト入れる用
	public GameObject bulletObject = null;			//弾プレハブ
	public GameObject bomObject = null;				//BOMプレハブ
	public Transform bulletStartPosition = null;	//弾の発射位置を取得するボーン
	public int moveSpeed = 2;						//player移動速度
	public int rapidMax;							//player連射数の最大値
	public int rapidNum = 0;						//player連射数カウント用
	private bool shotFlag = false;					//ショット一回だけ発射処理用フラグ
	public bool bomFlag = false;					//BOM一回だけ発射処理用フラグ
	AudioSource audioSource;						//AudioSourceコンポーネント取得用
	public AudioClip audioClipShot;					//ShotSE
	public AudioClip audioClipBom;					//BomSE
	public AudioClip audioClipItem;					//ItemSE

	void Start () {
		playey = GameObject.FindWithTag ("Player");					//Playerタグのオブジェクトを探す
		tapArea = GameObject.FindWithTag ("TapArea");				//TapAreaタグのオブジェクトを探す
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		audioSource = gameObject.GetComponent<AudioSource>();		//AudioSourceコンポーネント取得
	}
	
	void Update () {
		//rbって仮の変数にRigidbody2Dコンポーネントを入れる
		Rigidbody2D rb = playey.GetComponent<Rigidbody2D>();
		//移動させる(左右反転処理している)
		rb.velocity = new Vector2(transform.localScale.x * moveSpeed, rb.velocity.y);

		//tって仮の変数にtapAreaコンポーネントを入れる
		Tap t = tapArea.GetComponent<Tap>();
		//自機の弾発射フラグと、tapAreaのフラグを見て弾を発射する
		if(shotFlag == false){
			if(t.gamenTap){
				if(rapidMax > rapidNum){
//					Debug.Log("shot");
					//弾を生成する位置を指定する
					Vector2 vecBulletPos = bulletStartPosition.position;
					Instantiate(bulletObject, vecBulletPos, transform.rotation);			//プレハフ生成
					shotFlag = true;
					t.gamenTap = false;
//					Debug.Log(t.gamenTap);
					rapidNum += 1;
					audioSource.clip = audioClipShot;				//SE決定
					audioSource.Play ();							//SE再生
				}
			}
		}

		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//BOM発射処理
		//残りボム数を見て発射できるかどうか分岐する
		if(gc.totalBom > 0){
			if(bomFlag == false){
				if(t.bomTap){
	//				Debug.Log("bom shoot !!");
					//BOMを生成する位置を指定する
					Vector2 vecBulletPos = bulletStartPosition.position;
					Instantiate(bomObject, vecBulletPos, transform.rotation);	//プレハフ生成
					bomFlag = true;		//画面外でボムか消えたらBOM側でfalseにする
					gc.totalBom -= 1;	//BOM使用で残弾を減らす
					audioSource.clip = audioClipBom;				//SE決定
					audioSource.Play ();							//SE再生
				}
			}
		}
		//タップ離すと初期化する
		if(t.gamenTap == false){
			shotFlag = false;
		}
		if(t.bomTap == false){
			bomFlag = false;
		}
	}

	//接触判定
	void OnCollisionEnter2D(Collision2D col){
		//左右の壁との接触時
		if(col.gameObject.tag == "WallSide"){
			//tempって仮の変数にlocalScaleコンポーネントを入れる
			Vector2 temp = gameObject.transform.localScale;
			temp.x *= -1;							//左右反転させる
			gameObject.transform.localScale = temp;	//元に戻す
		}
		//フェンスとの接触時
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		if(col.gameObject.tag == "MissLine"){
			gc.gameOver = true;		//GameOverフラグをon
			Destroy(gameObject);
		}
	}
	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Item"){
			audioSource.clip = audioClipItem;				//SE決定
			audioSource.Play ();							//SE再生
		}
	}
}
