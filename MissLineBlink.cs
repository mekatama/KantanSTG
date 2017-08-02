using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissLineBlink : MonoBehaviour {
	private float nextTime;
	public float interval = 1.0f;	//点滅周期
	public Renderer rend;			//

	void Start () {
		nextTime = Time.time;				//現時刻を代入
		rend = GetComponent<Renderer>();	//点滅させたいオブジェクトを入れる用
	}
	
	void Update () {
		//呼び出されたら
		if(Time.time > nextTime){
			rend.enabled = !rend.enabled;	//表示反転
			nextTime += interval;			//次に点滅する時間をセット
		}
	}
}
