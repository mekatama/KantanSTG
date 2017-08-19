using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_Controller : MonoBehaviour {
	public Text highScoreLabel;	//ハイスコア用のtext

	public void Start () {
		//ハイスコアの表示
		highScoreLabel.text = "HighScore:" + PlayerPrefs.GetInt("HighScore");
	}

	void Update(){
		//backキー
		if (Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();	//アプリ終了
		}
	}

	//スタートボタン用の制御関数
	public void OnStartButtonClicked(){
		SceneManager.LoadScene("Main");	//シーンのロード
	}

	//遊び方ボタン用の制御関数
	public void OnHowToPlayButtonClicked(){
		SceneManager.LoadScene("HowToPlay");	//シーンのロード
	}

	//タイトルに戻るボタン用の制御関数
	public void OnReturnTitleButtonClicked(){
		SceneManager.LoadScene("Title");	//シーンのロード
	}
	
	//アプリ終了
	public void OnExitButtonClicked(){
		Application.Quit();
		Debug.Log("exit");
	}
}
