using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBom : MonoBehaviour {
	public float bulletMoveSpeed = 10.0f;	//1秒間に弾が進む距離
	public bool bomDestroy = false;			//BOMか消えたフラグ

	void Start(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletMoveSpeed);
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {

		if(other.tag == "Wall"){
			bomDestroy = true;		//BOMか消えたフラグon。playerで使用する
			Destroy( gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
		}

		if(other.tag == "Enemy"){
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
		}
	}
}
