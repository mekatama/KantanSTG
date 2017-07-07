using UnityEngine;
using System.Collections;

public class Item_powerup : MonoBehaviour {
	public int itemPowerUp = 1;	//パワーアップ数値

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}

}
