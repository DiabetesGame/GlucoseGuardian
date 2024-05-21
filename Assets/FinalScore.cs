using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] TMP_Text difficultyText;
    [SerializeField] TMP_Text timeText;
    // Start is called before the first frame update
    int glucose;
    int time;
    void Start()
    {
        glucose = MyOptions.instance.glucose;
        time = MyOptions.instance.time;

        if (glucose == 10)
        {
            difficultyText.text = "Easy";
        }
        else if (glucose == 15)
        {
            difficultyText.text = "Medium";
        }
        else
        {
            difficultyText.text = "Hard";
        }
        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        // Display timer
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
