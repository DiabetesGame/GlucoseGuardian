using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjState : MonoBehaviour
{
    [SerializeField] GameObject sadCellState;
    [SerializeField] GameObject happyCellState;
    // Start is called before the first frame update
    private void OnEnable()
    {
        sadCellState.SetActive(true);
        happyCellState.SetActive(false);
    }
}
