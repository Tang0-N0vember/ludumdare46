using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    //[SerializeField] private
    [SerializeField] private float gameTimer;
    private float currentGameTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentGameTimer = gameTimer;
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
        //Entweder GameOver oder SuccessScreen, je nachdem
    }
}
