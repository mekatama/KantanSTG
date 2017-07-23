using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bom : MonoBehaviour {
	public Text bomLabel;	//スコア表示をするオブジェクト用
	GameObject gameController;	//検索したオブジェクト入れる用

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}
	
	// Update is called once per frame
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		bomLabel.text = gc.totalBom.ToString("000000");			
	}
}
