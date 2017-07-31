using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour {
	public bool gamenTap = false;	//タップエリアをタップしたかどうかのフラグ
	public bool bomTap = false;		//playerをタップしたかどうかのフラグ

	void Update () {
		GameObject obj = getClickObject();	//タップしたオブジェクトを入れる
		//タップした判定
		if(Input.GetMouseButtonDown(0)){
			if(obj.tag == "Player"){
//				Debug.Log("BOM!!");
				bomTap = true;
			}else{
//				Debug.Log("gamenTap");				
				gamenTap = true;
			}
		}

		//離した判定
		if(Input.GetMouseButtonUp(0)){
			bomTap = false;
			gamenTap = false;
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
