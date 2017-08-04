using UnityEngine;
using System.Collections;

public class Item_bomAdd : MonoBehaviour {
	public int itemBomAdd = 1;	//ボム数
	GameObject gameController;	//ボム数表示を管理しているオブジェクト

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			//ボム数加算
			gc.totalBom = gc.totalBom + itemBomAdd;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
