using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClock : MonoBehaviour
{
    [SerializeField] private float gameTimer;
    private float currentGameTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentGameTimer = gameTimer;
        if (currentGameTimer <= 0f)
        {
            Debug.Log("Game Over");

        }
    }

    // Update is called once per frame
    void Update()
    {

        currentGameTimer -= Time.deltaTime;
    }
    public float getCurrentGameTimer
    {
        get { return currentGameTimer; }
    }
    public float getMaxGameTimer
    {
        get { return gameTimer; }
    }
}
