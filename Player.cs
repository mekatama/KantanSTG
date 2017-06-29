using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	GameObject gameController;	//検索したオブジェクト入れる用
	public int moveSpeed = 2;	//移動速度

	void Start () {
		gameController = GameObject.FindWithTag ("Player");	//Playerタクのオブジェクトを探す
	}
	
	void FixedUpdate () {
		//rbって仮の変数にRigidbody2Dコンポーネントを入れる
		Rigidbody2D rb = gameController.GetComponent<Rigidbody2D>();
		//移動させる
		rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
	}
}
