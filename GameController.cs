using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int totalScore = 0;		//ここで合計スコアを管理していく
	public int totalBom = 0;		//ここでボス数を管理していく
	public int totalLevel = 0;		//ここで難易度を管理していく
	public int totalKills = 0;		//ここで撃破数を管理していく
	public int totalBomAttack = 0;	//ここでボム使用数を管理していく
	public int adjust_Kills = 0;	//調整用の数値(撃破数)
	public int adjust_BomAttack = 0;//調整用の数値(撃破数)
	public bool bomTap = false;		//playerて使用するplayer自身をタップしたかどうかのフラグ

	public Canvas gameoverCamvas;
	public bool gameOver = false;	//GameOver用のフラグ。player側て制御する

	void Start () {
		gameoverCamvas.enabled = false;	//GameOverUI非表示
	}	
	void Update () {
		//GameOverUIの表示判定
		if(gameOver){
			Debug.Log("gameover");
			gameoverCamvas.enabled = true;	//GameOverUI表示
		}
		//難易度計算
		totalLevel = (totalKills / adjust_Kills) + (totalBomAttack / adjust_BomAttack); 
	}
}
