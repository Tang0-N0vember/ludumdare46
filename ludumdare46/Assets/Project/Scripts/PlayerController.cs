using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movmentSpeed = 10f;
    private bool isGrave = false;
    [SerializeField] private float interactTime = 2f;
    [SerializeField] private GameObject grave;
    private float downTime, upTime, pressTime = 0f;
    private bool keyIsDown = false;
    private bool isGraveNowOpen;
    private bool isGraveOpen;
    private bool isDiging = false;

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
            transform.position += transform.up * verticalMovment * movmentSpeed * Time.deltaTime;
        }
        if (horizontalMovment > 0 || horizontalMovment < 0)
        {
            transform.position += transform.right * horizontalMovment * movmentSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && isGrave && !isGraveOpen)
        {
            downTime = Time.time;
            pressTime = downTime + interactTime;
            keyIsDown = true;
            isDiging = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (isGrave)
            {
                if (Time.time < pressTime)
                {
                    Debug.Log("interacted with grave");
                }
            }
            keyIsDown = false;
        }
        if (Time.time >= pressTime && keyIsDown && isDiging)
        {
            Debug.Log("dug up grave");
            isGraveNowOpen = true;
            keyIsDown = false;
        }
        if (isGraveNowOpen)
        {
            grave.GetComponent<GraveScript>().graveState = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Grave"))
        {
            Debug.Log("grave");
            grave = collider.gameObject;
            isGrave = true;
            isGraveOpen = collider.gameObject.GetComponent<GraveScript>().graveState;
            /*if (isGraveNowOpen)
            {
                collider.gameObject.GetComponent<GraveScript>().graveState = true;
                //collider.gameObject.GetComponent<GraveScript>().createItem();
            }*/
        }
        /*if (collider.gameObject.CompareTag("Item"))
        {
            Debug.Log("Item picked up");
            Destroy(collider.gameObject);
        }*/
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Grave"))
        {
            Debug.Log("grave left");
            isGrave = false;
            isDiging = false;
            isGraveNowOpen = false;
        }
    }

}
