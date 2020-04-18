using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveScript : MonoBehaviour
{
    [SerializeField]private bool isOpen = false;
    [SerializeField] private bool itemIsCreated = false;
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject itempos;

    [SerializeField] private GameObject item;
    
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
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //itempos = player.transform.Find("ItemPos").GetComponent<GameObject>();
    }
    void Update()
    {
        if (isOpen && !itemIsCreated)
        {
            GameObject newItem = Instantiate(item);
            newItem.transform.parent = itempos.transform;
            newItem.transform.position = new Vector3(itempos.transform.position.x, itempos.transform.position.y);
            
            itemIsCreated = true;
            
        }
    }
}
