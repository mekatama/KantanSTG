using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour {
	public bool gamenTap;

	// Update is called once per frame
	void Update () {
		//タップした判定
		if(Input.GetMouseButtonDown(0)){
			gamenTap = true;
			Debug.Log("tap:" + gamenTap);
		}
		//離した判定
		if(Input.GetMouseButtonUp(0)){
			gamenTap = false;
			Debug.Log("tap:" + gamenTap);
		}
	}
}
