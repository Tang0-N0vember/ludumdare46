using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    [SerializeField] private GameObject mond;
    [SerializeField] private GameObject pivotPoint;
    [SerializeField] private GameObject logic;
    float interval;
    float speed;

    void Start()
    {
        speed = 5.0f;
        StartCoroutine(RotateForSeconds());
    }

    void Update()
    {

        //mond.transform.RotateAround(pivotPoint.transform.position, Vector3.forward ,-(/*(Mathf.PI*2)/*/logic.GetComponent<GameLogic>().getMaxGameTimer)/2 *Time.deltaTime);

        //Debug.Log("MONDPOSITION" + (- (logic.GetComponent<GameLogic>().getMaxGameTimer) / 2 * Time.deltaTime));
    }

    IEnumerator RotateForSeconds() //Call this method with StartCoroutine(RotateForSeconds());
    {
        float time = logic.GetComponent<GameLogic>().getMaxGameTimer;     //How long will the object be rotated?

        while (time > 0)     //While the time is more than zero...
        {
            mond.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, -Time.deltaTime * speed);     //...rotate the object.
            time -= Time.deltaTime;     //Decrease the time- value one unit per second.

            yield return null;     //Loop the method.
        }

    }
}
