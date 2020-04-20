using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI_Script : MonoBehaviour
{
    [SerializeField] private GameObject story;
    [SerializeField] private GameObject startScreen;

    // Start is called before the first frame update
    void Start()
    {
        story.SetActive(false);
        startScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }

        if (Input.anyKeyDown)
        {
            if (startScreen.activeInHierarchy)
            {

            }
        }

        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
