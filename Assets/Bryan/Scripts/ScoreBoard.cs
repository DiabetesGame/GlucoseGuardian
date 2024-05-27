using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [Header("End Scene")]
    [SerializeField] string endScene;

    [Header("Object Pools")]
    [SerializeField] ObjPool glucose;
    [SerializeField] ObjPool insulin;

    [Header("Menus")]
    [SerializeField] TMP_Text glucoseText;
    [SerializeField] TMP_Text insulinText;
    [SerializeField] TMP_Text timeText;

    [Header("Fade In Object")]
    [SerializeField] Renderer planeRenderer; // Renderer of the plane to control opacity

    private int glucoseTotal;
    private float currentTime = 0f; // Current time of the timer
    private SceneChange sceneChange;
    private Material planeMaterial;

    // Start is called before the first frame update
    void Start()
    {
        sceneChange = GetComponent<SceneChange>();
        if (MyOptions.instance.gameDifficulty == 0)
        {
            glucoseTotal = 4;
        }
        else if(MyOptions.instance.gameDifficulty == 1)
        {
            glucoseTotal = 8;
        }
        else if (MyOptions.instance.gameDifficulty == 2)
        {
            glucoseTotal = 12;
        }
        else
        {
            glucoseTotal = 4;
        }
        planeMaterial = planeRenderer.material;
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
        MyOptions.instance.SetTime(Mathf.FloorToInt(currentTime));
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

            if (glucose.totalNum == glucoseTotal)
            {
                StartCoroutine(FadeInObject());
                while (true)
                {
                    yield return null;
                }
            }

            yield return null;
        }
    }

    private IEnumerator FadeInObject()
    {
        float duration = 2f; // Duration of the fade in seconds
        float elapsedTime = 0f;

        Color initialColor = planeMaterial.color;
        Color finalColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration);
            planeMaterial.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            yield return null;
        }
        planeMaterial.color = finalColor; // Ensure it's fully opaque at the end
        sceneChange.ChangeScene(endScene);
    }
    public void QuitGame()
    {
        MyOptions.instance.quitGame = true;
        sceneChange.ChangeScene(endScene);
    }

    public bool IsTimerRunning()
    {
        return glucose.totalNum != glucoseTotal;
    }

}
