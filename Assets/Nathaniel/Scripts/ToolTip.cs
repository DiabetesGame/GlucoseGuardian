using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void ShowTip()
    {
        Debug.Log("Showing Tip");
        animator.Play("Base Layer.ShowTooltip");
    }

    public void HideTip()
    {
        Debug.Log("Hiding Tip");
        animator.Play("Base Layer.HideTooltip");
    }
}
