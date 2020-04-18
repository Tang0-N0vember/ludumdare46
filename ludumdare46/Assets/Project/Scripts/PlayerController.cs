using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movmentSpeed = 10f;
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
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Grave")
        {

        }
    }
}
