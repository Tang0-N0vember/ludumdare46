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

    [Header("Doc Direction")]
    [SerializeField] private GameObject docFront;
    [SerializeField] private GameObject docBack;
    [SerializeField] private GameObject docLeft;
    [SerializeField] private GameObject docRight;

    //Klimpf Addition
    private AudioSource diggingSound;

    // Start is called before the first frame update
    void Start()
    {
        diggingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalMovment = Input.GetAxis("Horizontal");
        float verticalMovment = Input.GetAxis("Vertical");

        if (!isDiging)
        {
            docFront.GetComponent<Animator>().SetBool("graben", false);
            if (verticalMovment > 0 || verticalMovment < 0)
            {
                transform.position += transform.up * verticalMovment * movmentSpeed * Time.deltaTime;

            }
            if (horizontalMovment > 0 || horizontalMovment < 0)
            {

                transform.position += transform.right * horizontalMovment * movmentSpeed * Time.deltaTime;
            }
            if (verticalMovment > 0)
            {

                if (horizontalMovment > 0 || horizontalMovment < 0)
                {
                    docFront.SetActive(false);
                    docBack.SetActive(false);
                }
                else
                {
                    docFront.SetActive(false);
                    docBack.SetActive(true);
                    docLeft.SetActive(false);
                    docRight.SetActive(false);
                }
            }
            if (verticalMovment < 0)
            {
                docFront.GetComponent<Animator>().SetBool("gehen", true);
                if (horizontalMovment > 0 || horizontalMovment < 0)
                {
                    docFront.SetActive(false);
                    docBack.SetActive(false);
                }
                else
                {
                    docFront.SetActive(true);
                    docBack.SetActive(false);
                    docLeft.SetActive(false);
                    docRight.SetActive(false);
                }
            }
            if (horizontalMovment > 0)
            {
                if (verticalMovment > 0 || verticalMovment < 0)
                {
                    docFront.SetActive(false);
                    docBack.SetActive(false);
                    docLeft.SetActive(false);
                    docRight.SetActive(true);
                }
                docFront.SetActive(false);
                docBack.SetActive(false);
                docLeft.SetActive(false);
                docRight.SetActive(true);
            }
            if (horizontalMovment < 0)
            {
                if (verticalMovment > 0 || verticalMovment < 0)
                {
                    docFront.SetActive(false);
                    docBack.SetActive(false);
                    docLeft.SetActive(true);
                    docRight.SetActive(false);
                }
                docFront.SetActive(false);
                docBack.SetActive(false);
                docLeft.SetActive(true);
                docRight.SetActive(false);
            }
            if (horizontalMovment == 0 && verticalMovment == 0)
            {
                docFront.GetComponent<Animator>().SetBool("gehen", false);
                docFront.SetActive(true);
                docBack.SetActive(false);
                docLeft.SetActive(false);
                docRight.SetActive(false);
            }
            if (horizontalMovment == 0 && verticalMovment != 0)
            {
                docLeft.SetActive(false);
                docRight.SetActive(false);
            }
            if (horizontalMovment != 0 && verticalMovment == 0)
            {
                docFront.SetActive(false);
                docBack.SetActive(false);
            }
        }
        else
        {
            docFront.GetComponent<Animator>().SetBool("graben", true);
            docFront.SetActive(true);
            docBack.SetActive(false);
            docLeft.SetActive(false);
            docRight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && isGrave && !isGraveOpen)
        {
            downTime = Time.time;
            pressTime = downTime + interactTime;
            keyIsDown = true;
            isDiging = true;
            docFront.GetComponent<Animator>().SetBool("graben", true);

            //Klimpf Addition
            diggingSound.Play();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (isGrave)
            {
                if (Time.time < pressTime)
                {
                    Debug.Log("interacted with grave");
                    isDiging = false;
                }
            }
            keyIsDown = false;
        }
        if (Time.time >= pressTime && keyIsDown && isDiging)
        {
            Debug.Log("dug up grave");
            isGraveNowOpen = true;
            keyIsDown = false;
            docFront.GetComponent<Animator>().SetBool("graben", false);
            //Klimpf Addition
            diggingSound.Stop();
        }
        if (isGraveNowOpen)
        {
            isDiging = false;
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
