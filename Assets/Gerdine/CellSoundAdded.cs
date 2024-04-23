using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSoundAdded : MonoBehaviour
{
    [SerializeField] Animation openCell;
    [SerializeField] AnimationClip[] animationClips;
    [SerializeField] ParticleSystem change;
    [SerializeField] GameObject HappyCell;
    [SerializeField] AudioSource HappySound; 

    bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOpen)
            {
                CloseCell();
            }
            else
            {
                OpenCell();
            }
            isOpen = !isOpen;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SmokePoof();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            openCell.gameObject.SetActive(false);
            HappyCell.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Glucose"))
        {
            SmokePoof();
            openCell.gameObject.SetActive(false);
            HappyCell.SetActive(true);
            
            // Play the happy sound effect
            HappySound.Play();
        }
    }
    public void OpenCell()
    {
        openCell.clip = animationClips[0];
        openCell.Play();
    }
    public void CloseCell()
    {
        openCell.clip = animationClips[1];
        openCell.Play();
    }
    void SmokePoof()
    {
        change.Play();
    }



}
