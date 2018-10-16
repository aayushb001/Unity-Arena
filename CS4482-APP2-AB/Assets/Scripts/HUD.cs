using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public GameObject itImage;
    public GameObject endPanel;
    public Text endText;
    public Text score;
    public Text time;

    void Awake() {
        Time.timeScale = 1f;
        endPanel.SetActive(false);
    }
    	
	void FixedUpdate () {
        if (Manager.itState) {
            itImage.SetActive(true);
        } else if (!Manager.itState)
        {
            itImage.SetActive(false);
        }

        score.text = "SCORE: " + Manager.playerScore.ToString();
        time.text = "TIME: " + System.Math.Round(Manager.timeRemaining, 2).ToString();

        if (Manager.gameEnded) {
            Time.timeScale = 0f;
            endText.text = Manager.endMessage;
            endPanel.SetActive(true);
        }
	}
}
