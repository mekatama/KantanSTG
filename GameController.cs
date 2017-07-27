using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int totalScore = 0;	//ここで合計スコアを管理していく
	public int totalBom = 0;	//ここでボス数を管理していく
	public bool bomTap = false;	//playerて使用するplayer自身をタップしたかどうかのフラグ

	void Update () {
		GameObject obj = getClickObject();	//

		//タップした場所の座標を取得→プレハブ生成
		if(Input.GetMouseButtonDown(0)){
//			Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);	//スクリーン座標

			if(obj.tag == "Player"){
//				Debug.Log("BOM!!" + obj.tag);
				bomTap = true;
			}else{
//				Debug.Log("click=ETC");				
			}
		}
	}

	//タップしたオブジェクト取得関数(とりあえす、詳しい内容は知らない)
	private GameObject getClickObject(){
		GameObject result = null;
		if(Input.GetMouseButtonDown(0)){
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);	//スクリーン座標
			Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
			if(collition2d){
				result = collition2d.transform.gameObject;
			}
		}
		return result;
	}
}