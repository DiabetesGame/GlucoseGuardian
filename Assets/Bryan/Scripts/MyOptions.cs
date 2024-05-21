using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOptions : MonoBehaviour
{
    public static MyOptions instance;

    public int glucose;
    public int time;
    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetGlucose(int input)
    {
        glucose = input;
    }
    public void SetTime(int input)
    {
        time = input;
    }
}
