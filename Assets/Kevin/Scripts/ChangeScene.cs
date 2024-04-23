using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   private IEnumerator ChangeScenePlease()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GamePlayScene");
    }
    private void Start()
    {
        StartCoroutine(ChangeScenePlease());
    }
}
