using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * File name: GameController.cs
 * Author's Name: Justin Frasca
 * Student Id: 101020604
**/

public class GameController : MonoBehaviour {

	[SerializeField]
	Text LifeLabel;

	[SerializeField]
	Text HighScoreLabel;                   // labels 

	[SerializeField]
	Text ScoreLabel;

	[SerializeField]
	Text GameOverLabel;

	[SerializeField]
	Button RestartButton;

	[SerializeField]
	Button StartBtn;

	[SerializeField]
	Text PlayNow;


	private AudioSource BackgroundMusic;   // background music

	private int PlayerScore = 0;
	private int PlayerLife = 3;






	public int Score {                 // collecting and storing score (updating text label)
		get { return PlayerScore; }       
		set {
			PlayerScore = value;
			ScoreLabel.text = "Score: " + PlayerScore;
		}


	}

	public int Life {
		get {
			return PlayerLife;     // taking lifes (updating text label)
		}
		set {
			PlayerLife = value;
			if (PlayerLife <= 0) {  //game over
				GameOver ();

			} else {

				LifeLabel.text = "Life: " + PlayerLife;

			}
		
		}
	}
	private void initialize(){       // game 

		Score = 0;
		Life = 3;


		GameOverLabel.gameObject.SetActive (false);
		HighScoreLabel.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		LifeLabel.gameObject.SetActive (true);
		ScoreLabel.gameObject.SetActive (true);
		StartBtn.gameObject.SetActive (false);
		PlayNow.gameObject.SetActive (false);


	}

	private void StartGame(){      // start menu

		GameOverLabel.gameObject.SetActive (false);
		HighScoreLabel.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		LifeLabel.gameObject.SetActive (false);
		ScoreLabel.gameObject.SetActive (false);
		StartBtn.gameObject.SetActive (true);
		ScoreLabel.gameObject.SetActive (false);
		PlayNow.gameObject.SetActive (true);

	}

	private void GameOver (){   // game over reset game

		GameOverLabel.gameObject.SetActive (true);
		HighScoreLabel.gameObject.SetActive (true);
		RestartButton.gameObject.SetActive (true);
		LifeLabel.gameObject.SetActive (false);
		ScoreLabel.gameObject.SetActive (false);
		HighScoreLabel.text = "High Score: " + Score;
	}


	void Start () {
		StartGame ();
		BackgroundMusic = gameObject.GetComponent<AudioSource> ();  // audio
	

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RestartButtonClick(){

		initialize ();  // restart game   
	}

	public void StartBtnClick ()
	{
		initialize ();  // start game 
	}
}

