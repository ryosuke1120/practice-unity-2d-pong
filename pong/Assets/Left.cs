using UnityEngine;
using System.Collections;

public class Left : MonoBehaviour {
	// static int score;

	public GUIText scoreGUI = 0;
	private int score;
	// private int highScore;

	void Start(){
		score = 0;
		// キーを使って値を取得
		// キーがない場合は第二引数の値を取得
	}

	void AddScore(int s){
		score = score + s;
	}

	// void Update () {
	// 	this.GetComponent<GUIText>().text = "Score : " + score;
	// }

	// スコアの加算
}
