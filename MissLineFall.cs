using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissLineFall : MonoBehaviour {
	private int enemyTamaruNum;	//敵がたまった数

	void Update(){
		//フェンスに接触した敵の数によって、フェンス落下
		if(enemyTamaruNum == 3){
			//FreezePositionを無効化する
			gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		}
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Enemy"){
			enemyTamaruNum += 1;
//			Debug.Log("tamaru = " + enemyTamaruNum);
		}
	}

	//他のオブジェクとの当たり判定が解消されたとき判定
	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "Enemy"){
			enemyTamaruNum -= 1;
//			Debug.Log("tamaru = " + enemyTamaruNum);
		}
	}
}
