using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    [SerializeField] private GameObject mond;
    [SerializeField] private GameObject pivotPoint;
    [SerializeField] private GameObject logic;
    
    void Update()
    {
        mond.transform.RotateAround(pivotPoint.transform.position, Vector3.forward ,-((Mathf.PI*2)/logic.GetComponent<GameLogic>().getMaxGameTimer)/2 *Time.deltaTime);
    }
}
