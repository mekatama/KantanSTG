using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HighScore : MonoBehaviour {
	public Text highScoreLabel;	//ハイスコア用のtext

	void Start () {
		//ハイスコアの表示
		highScoreLabel.text = "HighScore:" + PlayerPrefs.GetInt("HighScore");
	}
	
	void Update () {
		
	}
}
