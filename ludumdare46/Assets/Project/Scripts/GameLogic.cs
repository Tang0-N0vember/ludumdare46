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
    [SerializeField] private int maxDetection;
    private float currentGameTimer;
    private int detectionCounter;
    public GraveScript grailGrave;

    [SerializeField] private BodypartStats stats;

    private AudioSource[] sounds;
    private AudioSource winSound;
    private AudioSource loseSound;

    public int getDetectionCounter
    {
        get { return detectionCounter; }
    }

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
        guard1.caught += Enemies_caught;
        guard2.caught += Enemies_caught;
        guard3.caught += Enemies_caught;
        guard4.caught += Enemies_caught;
        guard5.caught += Enemies_caught;
        guard6.caught += Enemies_caught;
        guard7.caught += Enemies_caught;
        grailGrave.dugUpGrave += GrailGrave_dugUpGrave;
        currentGameTimer = gameTimer;
        stats.died += Stats_died;

        sounds = GetComponents<AudioSource>();
        winSound = sounds[0];
        loseSound = sounds[1];
    }

    private void Stats_died()
    {
        StartCoroutine(LoseSound());
    }

    public float getCurrentGameTimer
    {
        get { return currentGameTimer; }
    }
    public float getMaxGameTimer
    {
        get { return gameTimer; }
    }

    private void Enemies_caught()
    {
        Debug.Log("Caught");
        GameOver();
    }

    private void GrailGrave_dugUpGrave()
    {
        StartCoroutine(WinSound());
        
    }

    public void GameWon()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator WinSound()
    {
        winSound.Play();
        Time.timeScale = 0;
        yield return new WaitForSeconds(4);
        Time.timeScale = 1;
        GameWon();
    }

    IEnumerator LoseSound()
    {
        loseSound.Play();
        yield return new WaitForSeconds(4);
        GameOver();
    }

    private void Enemies_detectionAdded()
    {
        detectionCounter++;
        Debug.Log("DETECTION");
        Debug.Log(detectionCounter);
        if (detectionCounter > maxDetection)
            StartCoroutine(LoseSound());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grailGrave);


        currentGameTimer -= Time.deltaTime;
        //Debug.Log("TIME: "+currentGameTimer);
        if (currentGameTimer <= 0f)
        {
            StartCoroutine(LoseSound());
            //currentGameTimer = gameTimer;

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
