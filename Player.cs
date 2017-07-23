using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	GameObject playey;								//検索したオブジェクト入れる用
	public int moveSpeed = 2;						//移動速度
	public GameObject bulletObject = null;			//弾プレハブ
	GameObject tapArea;								//検索したオブジェクト入れる用
	private bool shotFlag = false;					//ショット一回だけ発射処理用フラグ
	public Transform bulletStartPosition = null;	//弾の発射位置を取得するボーン
	public int rapidMax;							//連射数の最大値
	public int rapidNum = 0;						//連射数カウント用

	void Start () {
		playey = GameObject.FindWithTag ("Player");		//Playerタグのオブジェクトを探す
		tapArea = GameObject.FindWithTag ("TapArea");	//TapAreaタグのオブジェクトを探す
	}
	
	void FixedUpdate () {
		//rbって仮の変数にRigidbody2Dコンポーネントを入れる
		Rigidbody2D rb = playey.GetComponent<Rigidbody2D>();
		//移動させる(左右反転処理している)
		rb.velocity = new Vector2(transform.localScale.x * moveSpeed, rb.velocity.y);

		//rbって仮の変数にRigidbody2Dコンポーネントを入れる
		Tap t = tapArea.GetComponent<Tap>();
		//自機の弾発射フラグと、Tapのフラグを見て弾を発射する
		if(shotFlag == false){
			if(t.gamenTap){
				if(rapidMax > rapidNum){
					Debug.Log("shot");
					//弾を生成する位置を指定する
					Vector2 vecBulletPos = bulletStartPosition.position;
					Instantiate(bulletObject, vecBulletPos, transform.rotation);			//プレハフ生成
					shotFlag = true;
					rapidNum += 1;
				}
			}
		}
		//タップ離すと初期化する
		if(t.gamenTap == false){
			shotFlag = false;
		}
	}

	//接触判定
	void OnCollisionEnter2D(Collision2D col){
		//左右の壁との接触時
		if(col.gameObject.tag == "Wall"){
			//tempって仮の変数にlocalScaleコンポーネントを入れる
			Vector2 temp = gameObject.transform.localScale;
			temp.x *= -1;							//左右反転させる
			gameObject.transform.localScale = temp;	//元に戻す
		}

		//フェンスとの接触時
		if(col.gameObject.tag == "MissLine"){
			Destroy(gameObject);
		}
	}
}
