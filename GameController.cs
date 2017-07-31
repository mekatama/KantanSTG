using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int totalScore = 0;	//ここで合計スコアを管理していく
	public int totalBom = 0;	//ここでボス数を管理していく
	public bool bomTap = false;	//playerて使用するplayer自身をタップしたかどうかのフラグ
}
