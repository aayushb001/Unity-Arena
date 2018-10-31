using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject leaderboard;
    public GameObject namePanel;
    public InputField namefield;
    public static string playerName;
    public Component content;
    Text leaderText;
    List<PlayerData> pdList;
    void Start()
    {
        leaderText = content.GetComponent<Text>();
        leaderboard.SetActive(false);
    }
        
    public void startGame()
    {
        name = namefield.text.Trim();
        if (name.Length > 0)
        {
            playerName = name;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void playGame() {
        namePanel.SetActive(true);
        namefield.Select();
        namefield.ActivateInputField();
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void showLeaderboard()
    {
        leaderboard.SetActive(true);
        pdList = loadData();
        string displayText = "";
        if (pdList != null) {
            foreach (PlayerData data in pdList) {
                Debug.Log(data.name + ":   " + data.score + "||");
                displayText += data.name + ":   " + data.score + System.Environment.NewLine;
            }
        }
        leaderText.text = displayText;
    }

    public void hideLeaderboard()
    {
        leaderboard.SetActive(false);
    }

    public List<PlayerData> loadData()
    {
        if (System.IO.File.Exists(Application.dataPath + "/score.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/score.sav", FileMode.Open);
            List<PlayerData> pd = bf.Deserialize(stream) as List<PlayerData>;
            stream.Close();
            return pd;
        }
        return null;
    }
}
