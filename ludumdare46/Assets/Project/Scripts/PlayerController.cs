using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movmentSpeed = 10f;
    private bool isGrave = false;
    [SerializeField] private float interactTime = 2f;
    private float downTime, upTime, pressTime = 0f;
    private bool keyIsDown = false;
    private bool graveIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovment = Input.GetAxis("Horizontal");
        float verticalMovment = Input.GetAxis("Vertical");

        if (verticalMovment > 0 || verticalMovment < 0)
        {
            transform.position += transform.up *verticalMovment* movmentSpeed * Time.deltaTime;
        }
        if (horizontalMovment > 0 || horizontalMovment < 0)
        {
            transform.position += transform.right * horizontalMovment* movmentSpeed * Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && isGrave)
        {
            downTime = Time.time;
            pressTime = downTime + interactTime;
            keyIsDown = true;
        }
        if (Input.GetKeyUp(KeyCode.E) && isGrave)
        {
            if (Time.time < pressTime)
            {
                Debug.Log("interacted with grave");
            }
        }
        if(Time.time >= pressTime && keyIsDown)
        {
            Debug.Log("dig up grave");
            keyIsDown = false;
        }



    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Grave"))
        {
            Debug.Log("grave");
            isGrave = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Grave"))
        {
            Debug.Log("grave left");
            isGrave = false;
        }
    }

}
