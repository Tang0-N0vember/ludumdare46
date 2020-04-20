using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
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
}
