using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int totalScore = 0;	//ここで合計スコアを管理していく
	public int totalBom = 0;	//ここでボス数を管理していく
	public bool bomTap = false;	//playerて使用するplayer自身をタップしたかどうかのフラグ

	public Canvas gameoverCamvas;
	public bool gameOver = false;	//GameOver用のフラグ。player側て制御する

	void Start () {
			gameoverCamvas.enabled = false;
	}	
	void Update () {
		if(gameOver){
			Debug.Log("gameover");
			gameoverCamvas.enabled = true;
		}
	}
}
