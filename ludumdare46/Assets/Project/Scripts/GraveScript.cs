using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveScript : MonoBehaviour
{
    [SerializeField]private bool isOpen = false;

    [SerializeField] private GameObject item;
    private bool itemIsCreated = false;
    private bool playIsOnGrave = false;

    public bool graveState
    {
        get { return isOpen; }
        set { isOpen = value; }

    }
    public bool playerGraveState
    {
        get { return playIsOnGrave; }
        set { playIsOnGrave = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen&& !itemIsCreated)
        {
            Instantiate(item);
            itemIsCreated = true;
        }
    }
    /*
    public void createItem()
    {
        if (isOpen && !itemIsCreated)
        {
            Instantiate(item);
            itemIsCreated = true;
        }
    }*/
}
