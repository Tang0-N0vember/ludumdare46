using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveScript : MonoBehaviour
{
    [SerializeField] private bool isRichGrave = false;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool itemIsCreated = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject itempos;
    [SerializeField] private GameObject monster;

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
            if (isRichGrave)
            {
                int randomNum = Random.Range(1, 4);
                if (randomNum == 1)
                {
                    Debug.Log("Rats attack");
                    int attackValue = Random.Range(10, 30);
                    Debug.Log("Damage" + attackValue);
                    monster.GetComponent<BodypartStats>().takeDamage(attackValue);

                    creatItem();
                }
                if(randomNum==2)
                {
                    Debug.Log("Vimpire attack");
                    int attackValue = Random.Range(50, 70);
                    Debug.Log("Damage: " + attackValue);
                    int vimpireHealth = Random.Range(150, 250);
                    if (monster.GetComponent<BodypartStats>().vipreAttack(attackValue, vimpireHealth))
                    {
                        Debug.Log("Monster won!");
                        creatItem();
                    }
                }
                if(randomNum == 3)
                {
                    creatItem();
                }
            }
            else
            {
                if (Random.value >= 0.5)
                {
                    Debug.Log("Rats attack");
                    int attackValue = Random.Range(10, 30);
                    Debug.Log("Rats attack Value"+attackValue);
                    monster.GetComponent<BodypartStats>().takeDamage(attackValue);
                }
                creatItem();


            }
        }
    }
    private void creatItem()
    {
        GameObject newItem = Instantiate(item);
        newItem.transform.parent = itempos.transform;
        newItem.transform.position = new Vector3(itempos.transform.position.x, itempos.transform.position.y);
        itemIsCreated = true;
    }
}
