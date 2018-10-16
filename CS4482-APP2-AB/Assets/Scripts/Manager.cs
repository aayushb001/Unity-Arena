using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    //true - player is it and false - enemy is it
    public static bool itState;
    public static float playerScore;
    public static float enemyScore;
    public static float timeRemaining;
    public static string endMessage;
    public static bool gameEnded;
    
    void Start () {
        playerScore = 0;
        enemyScore = 0;
        timeRemaining = 300;
        gameEnded = false;
        float random = Random.Range(0, 10);
        Debug.Log("RAND:" + random);
        if ( random < 5)
        {
            itState = false;
        }
        else
        {
            itState = true;
        }
    }
	
	
	void Update () {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
        } else
        {
            timeRemaining = 0.00f;
            endGame();
        }
	}
    
    public void endGame() {        
        if (playerScore > enemyScore)
        {
            endMessage = "VICTORY";
        }
        else if (playerScore < enemyScore)
        {
            endMessage = "DEFEAT";
        }
        else {
            endMessage = "DRAW";
        }
        gameEnded = true;
        StartCoroutine(ExecuteAfterTime());

    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
