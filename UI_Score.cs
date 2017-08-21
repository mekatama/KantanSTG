using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour {
	public Text scoreLabel;	//スコア表示をするオブジェクト用
	GameObject gameController;	//検索したオブジェクト入れる用

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		scoreLabel.text = "Score : " + gc.totalScore.ToString("000000");	
	}
}
