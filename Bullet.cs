using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float bulletMoveSpeed = 10.0f;	//1秒間に弾が進む距離

	void Start(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletMoveSpeed);
	}

	void Update() {
		//1秒間の移動量
//		Vector2 vecAddPos = (transform.up * bulletMoveSpeed);
		//移動量、回転量には Time.deltaTime をかけて実行環境(フレーム数の差)による違いが出ないようにします
//		transform.position += (vecAddPos) * Time.deltaTime);
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Wall"){
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy( gameObject);
		}
	}
}
