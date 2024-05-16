using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    [Header("Object Pools")]
    [SerializeField] ObjPool glucose;
    [SerializeField] ObjPool insulin;

    [Header("Menus")]
    [SerializeField] TMP_Text glucoseText;
    [SerializeField] TMP_Text insulinText;
    [SerializeField] TMP_Text timeText;

    private int glucoseTotal;
    private float currentTime = 0f; // Current time of the timer
    // Start is called before the first frame update
    void Start()
    {
        glucoseTotal = MyOptions.instance.glucose;
        StartCoroutine(updateBoard());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScoreBoardUpdate()
    {
        glucoseText.text = (glucoseTotal - glucose.totalNum).ToString();
        insulinText.text = (9 - insulin.totalNum).ToString();
    }
    public IEnumerator updateBoard()
    {
        while (true)
        {   
            // Update current time
            currentTime += Time.deltaTime;

            // Calculate minutes and seconds
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            // Display timer
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // UpdateBoard
            ScoreBoardUpdate();
            yield return null;
        }
    }
}
