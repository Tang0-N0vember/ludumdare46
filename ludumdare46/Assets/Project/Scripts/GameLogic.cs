using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private WayPointHandler enemies;
    [SerializeField] private PlayerController player;
    //[SerializeField] private
    [SerializeField] private float gameTimer;
    private float currentGameTimer;
    private int detectionCounter;

    // Start is called before the first frame update
    void Start()
    {
        detectionCounter = 0;
        enemies.detectionAdded += Enemies_detectionAdded;
        currentGameTimer = gameTimer;
    }

    private void Enemies_detectionAdded()
    {
        detectionCounter++;
        if (detectionCounter >= 3)
            GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        currentGameTimer -= Time.deltaTime;

        if(currentGameTimer <= 0f)
        {
            GameOver();
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
