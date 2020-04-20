using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private WayPointHandler guard1;
    [SerializeField] private WayPointHandler guard2;
    [SerializeField] private WayPointHandler guard3;
    [SerializeField] private WayPointHandler guard4;
    [SerializeField] private WayPointHandler guard5;
    [SerializeField] private WayPointHandler guard6;
    [SerializeField] private WayPointHandler guard7;
    [SerializeField] private PlayerController player;
    //[SerializeField] private
    [SerializeField] private float gameTimer;
    private float currentGameTimer;
    private int detectionCounter;
    public GraveScript grailGrave;

    // Start is called before the first frame update
    void Start()
    {
        detectionCounter = 0;
        guard1.detectionAdded += Enemies_detectionAdded;
        guard2.detectionAdded += Enemies_detectionAdded;
        guard3.detectionAdded += Enemies_detectionAdded;
        guard4.detectionAdded += Enemies_detectionAdded;
        guard5.detectionAdded += Enemies_detectionAdded;
        guard6.detectionAdded += Enemies_detectionAdded;
        guard7.detectionAdded += Enemies_detectionAdded;
        grailGrave.dugUpGrave += GrailGrave_dugUpGrave;
        currentGameTimer = gameTimer;
        
    }

    private void GrailGrave_dugUpGrave()
    {
        GameWon();
    }

    public void GameWon()
    {
        SceneManager.LoadScene(2);
    }

    private void Enemies_detectionAdded()
    {
        detectionCounter++;
        Debug.Log("DETECTION");
        Debug.Log(detectionCounter);
        if (detectionCounter >= 3)
            GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grailGrave);


        currentGameTimer -= Time.deltaTime;
        /*Debug.Log("TIME");
        Debug.Log(currentGameTimer);*/
        if(currentGameTimer <= 0f)
        {
            //GameOver();
            currentGameTimer = gameTimer;

        }

        /*if(player.GetDetectedScore() >= 3)
        {
            GameOver();
        }*/
    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }
}
