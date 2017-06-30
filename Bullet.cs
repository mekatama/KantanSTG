using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float bulletMoveSpeed = 10.0f;	//1秒間に弾が進む距離
	GameObject playey;						//検索したオブジェクト入れる用

	void Start(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletMoveSpeed);
		playey = GameObject.FindWithTag ("Player");		//Playerタグのオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {

		if(other.tag == "Wall"){
			//pって仮の変数にPlayerコンポーネントを入れる
			Player p = playey.GetComponent<Player>();
			p.rapidNum -= 1;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy( gameObject);
		}

		if(other.tag == "Enemy"){
			//pって仮の変数にPlayerコンポーネントを入れる
			Player p = playey.GetComponent<Player>();
			p.rapidNum -= 1;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
