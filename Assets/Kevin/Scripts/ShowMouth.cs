using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMouth : MonoBehaviour
{
    [SerializeField] GameObject Mouth;
    [SerializeField] Animator JoeEating;
    [SerializeField] GameObject Joe;

    bool MouthActive = false;
    bool JoeEatingActive = false;

    private void Start()
    {
        StartCoroutine("CueMouth");
    }
    void NomNom()
    {

        if (JoeEating == true)
        {
            JoeEating.SetTrigger("Eat");
            JoeEatingActive = false;
            Debug.Log("Yummy");
        }
    }

    private IEnumerator CueMouth() 
    {
        if (MouthActive == false)
        {
            Mouth.SetActive(false);
            Debug.Log("NoMouth");
            JoeEatingActive = true;
            if (JoeEating != null)
            {
                NomNom();
                yield return new WaitForSeconds(2);
                MouthActive = true;
                Mouth.SetActive(true);
                yield return new WaitForSeconds(5.35f);
                Joe.SetActive(false);
                Mouth.SetActive(false);
            }
        }
    }
}
