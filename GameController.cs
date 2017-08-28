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
	AudioSource audioSource;		//AudioSourceコンポーネント取得用
	public AudioClip audioClipStart;	//StartSE
	public AudioClip audioClipGameOver;	//GameOverSE
	private bool gameOverSE;			//GameOverSEを一回だけ鳴らす用

	void Start () {
		gameoverCamvas.enabled = false;	//GameOverUI非表示
		audioSource = gameObject.GetComponent<AudioSource>();	//AudioSourceコンポーネント取得
		audioSource.clip = audioClipStart;	//SE決定
		audioSource.Play ();				//SE再生
		gameOverSE = false;					//初期化
	}	
	void Update () {
		//GameOverUIの表示判定
		if(gameOver){
			Debug.Log("gameover");
			gameoverCamvas.enabled = true;			//GameOverUI表示
			//ハイスコアの保存
			if(PlayerPrefs.GetInt("HighScore") < totalScore){
				//ハイスコア保存
				PlayerPrefs.SetInt("HighScore", totalScore);
				Debug.Log("HighScore:" + PlayerPrefs.GetInt("HighScore"));
			}
			//SE制御
			if(gameOverSE == false){
				audioSource.clip = audioClipGameOver;	//SE決定
				audioSource.Play ();					//SE再生
				gameOverSE = true;
			}
		}
		//難易度計算
		totalLevel = (totalKills / adjust_Kills) + (totalBomAttack / adjust_BomAttack); 
	}
}
