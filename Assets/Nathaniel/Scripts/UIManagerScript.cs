using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


/// <summary>
/// This script needs to be put on the trigger objects that you want to spin,
/// and it has to be put on an empty so you only need to reference it once
/// 
/// The objects that you're spinning need to be children of the trigger as shown in the RigTesting scene
/// </summary>
public class UIManagerScript : MonoBehaviour
{
    SpinObject spinScript;
    ToolTip toolTipScript;
    ControllerData controllerData;
    MyOptions gameManager;
    bool triggerChecking;

    private void Start()
    {
        gameManager = MyOptions.instance;
    }

    //Reference this in the onhover event on each controller
    public void HoverEvent(HoverEnterEventArgs args)
    {
        controllerData = args.interactorObject.transform.gameObject.GetComponentInParent<ControllerData>();

        if (args.interactableObject.transform.gameObject.TryGetComponent<SpinObject>(out spinScript))
        {
            spinScript.SpinThing();
            StartCoroutine(TriggerCheck());
            triggerChecking = true;
        }
        else if (args.interactableObject.transform.gameObject.TryGetComponent<ToolTip>(out toolTipScript))
        {
            toolTipScript.ShowTip();
        }
        else
        {
            Debug.Log("Thing not found");
        }
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        if (args.interactableObject.transform.gameObject.TryGetComponent<ToolTip>(out toolTipScript))
        {
            toolTipScript.HideTip();
        }
        if (triggerChecking)
        {
            StopCoroutine(TriggerCheck());
            triggerChecking = false;
        }

    }

    IEnumerator TriggerCheck()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (controllerData.triggered && triggerChecking)
            {
                Debug.Log("Selected " + spinScript.tag);
                gameManager.DifficultySelect(spinScript.tag);
                triggerChecking = false;
            }
        }
    }
}
