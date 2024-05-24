using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] TMP_Text difficultyText;
    [SerializeField] TMP_Text timeText;

    [Header("Audio")]
    [SerializeField] EndVoiceOver endVoice;
    [Header("WaitTimes")]
    [SerializeField]
    float pauseForVoice = 2;
    // Start is called before the first frame update
    int glucose;
    int time;
    void Start()
    {
        glucose = MyOptions.instance.gameDifficulty;
        time = MyOptions.instance.time;

        if (glucose == 0)
        {
            difficultyText.text = "Easy";
        }
        else if (glucose == 1)
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
        StartCoroutine(PauseForLoad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator PauseForLoad()
    {
        float time = 0;
        while (time < pauseForVoice) 
        {
            time += Time.deltaTime;
            yield return null;
        }
        if (MyOptions.instance.quitGame)
        {
            endVoice.PlayClip(3);
        }
        else
        {
            endVoice.PlayClip(glucose);
        }
        while (endVoice.audioSource.isPlaying)
        {
            yield return null;
        }
        endVoice.PlayClip(4);
    }
}
