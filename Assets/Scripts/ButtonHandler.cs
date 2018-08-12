using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {

    public Text highScore;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("HighScore").ToString() != null) {
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame() {
        SceneManager.LoadScene("Orbace");
    }

    public void Restart() {
        PlayerPrefs.SetInt("TempScore", 0);
        PlayerPrefs.SetFloat("Difficulty", 0);
        SceneManager.LoadScene("Orbace");
    }

    public void Quit() {
        Application.Quit();
    }
    
    public void MainMenu() {
        SceneManager.LoadScene("Main");
    }


}
