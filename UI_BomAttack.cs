using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BomAttack : MonoBehaviour {
	public Text BomAttackLabel;	//レベル表示をするオブジェクト用
	GameObject gameController;	//検索したオブジェクト入れる用

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		BomAttackLabel.text = gc.totalBomAttack.ToString("000000");	
	}
}
