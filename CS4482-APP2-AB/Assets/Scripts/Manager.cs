using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    //true - player is it and false - enemy is it
    public static bool itState;
    public static float playerScore;
    //public static float enemyScore;
    public static float timeRemaining;
    public static string endMessage;
    public static bool gameEnded;
    public static bool saved;

    void Start () {
        Debug.Log("manager "  + MainMenu.playerName);
        saved = false;
        playerScore = 0;
        //enemyScore = 0;
        timeRemaining = 5;
        gameEnded = false;
        float random = UnityEngine.Random.Range(0, 10);
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

    void FixedUpdate() {
        //player score increases if not tagged.
        if (!Manager.itState) {
            playerScore += 1;
        }
    }

    public void endGame() {        
        if (!Manager.itState)
        {
            endMessage = "VICTORY";
            
        }
        else if (Manager.itState)
        {
            endMessage = "DEFEAT";
        }
        if (saved == false)
        {
            saveData(MainMenu.playerName, playerScore);
            saved = true;
        }        
        gameEnded = true;
        StartCoroutine(ExecuteAfterTime());
    }

    public void saveData(string name, float score) {
        if (playerScore > 0)
        {
            if (File.Exists(Application.dataPath + "/Scripts/score.sav"))
            {
                Debug.Log("SAVE EXISTS");
                BinaryFormatter bf = new BinaryFormatter();
                FileStream stream = new FileStream(Application.dataPath + "/Scripts/score.sav", FileMode.Open);
                List<PlayerData> pd = bf.Deserialize(stream) as List<PlayerData>;
                Debug.Log("BEFORE NEW SAVE: " + pd.Count);
                stream.Close();

                PlayerData data = new PlayerData(name, playerScore);
                Debug.Log("Input: " + name + playerScore);
                BinaryFormatter bf2 = new BinaryFormatter();
                FileStream stream2 = new FileStream(Application.dataPath + "/Scripts/score.sav", FileMode.Create);
                pd.Add(data);
                Debug.Log("ADDED");
                bf2.Serialize(stream2, pd.Count);
                Debug.Log("SERIALIZED");
                stream2.Close();
            }
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream stream = new FileStream(Application.dataPath + "/Scripts/score.sav", FileMode.Create);
                List<PlayerData> pd = new List<PlayerData>();
                PlayerData data = new PlayerData(name, playerScore);
                pd.Add(data);
                bf.Serialize(stream, pd);
                stream.Close();
            }
        }
    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

[Serializable]
public class PlayerData
{
    public string name;
    public float score;

    public PlayerData(string n, float s)
    {
        name = n;
        score = s;
    }
}
