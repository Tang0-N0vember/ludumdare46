using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    [SerializeField] private GameLogic logic;
    [SerializeField] private GameObject eye1;
    [SerializeField] private GameObject eye2;
    [SerializeField] private GameObject eye3;
    [SerializeField] private GameObject eye4;

    // Start is called before the first frame update
    void Start()
    {
        eye2.SetActive(false);
        eye3.SetActive(false);
        eye4.SetActive(false);
    }
    private void Update()
    {
        if(logic.GetComponent<GameLogic>().getDetectionCounter==1)
        {
            eye1.SetActive(false);
            eye2.SetActive(true);
            eye3.SetActive(false);
            eye4.SetActive(false);
        }
        if (logic.GetComponent<GameLogic>().getDetectionCounter == 2)
        {
            eye1.SetActive(false);
            eye2.SetActive(false);
            eye3.SetActive(true);
            eye4.SetActive(false);
        }
        if (logic.GetComponent<GameLogic>().getDetectionCounter == 3)
        {
            eye1.SetActive(false);
            eye2.SetActive(false);
            eye3.SetActive(false);
            eye4.SetActive(true);
        }
    }
}
