using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOptions : MonoBehaviour
{
    public static MyOptions instance;

    public int gameDifficulty;
    public int time;

    public bool quitGame;
    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetGlucose(int input)
    {
        gameDifficulty = input;
    }
    public void SetTime(int input)
    {
        time = input;
    }
    public void DifficultySelect(string tag)
    {
        switch (tag)
        {
            case "Easy":
                gameDifficulty = 0;
                Debug.Log("Easy selected");
                //Start easy animation
                break;

            case "Medium":
                gameDifficulty = 1;
                Debug.Log("MeduimSelected");
                //Start Medium Animation
                break;

            case "Hard":
                gameDifficulty = 2;
                Debug.Log("HardSelected");
                //Start Hard Animation for both food and camera
                break;

            //By default the difficulty is set to easy
            default:
                gameDifficulty = 0;
                break;
        }

        Debug.Log("Selected " + tag + "/Difficulty " + gameDifficulty);
    }
}
