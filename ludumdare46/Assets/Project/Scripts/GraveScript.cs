using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveScript : MonoBehaviour
{
    [SerializeField] private bool isRichGrave = false;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool itemIsCreated = false;
    [SerializeField] private bool enemyIsCreated = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject itempos;
    [SerializeField] private GameObject enemySpawnPoint;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject vampire;
    [SerializeField] private GameObject rat;
    [SerializeField] private GameObject graveOpne;
    [SerializeField] private GameObject graveClose;

    public GameObject item;

    //Klimpf Addition
    public event Action dugUpGrave;
    private AudioSource [] sounds;
    private AudioSource ratSound;
    private AudioSource itemSound;

    private bool isGrailGrave = false;
    public bool grailGrave
    {
        get { return isGrailGrave; }
        set { isGrailGrave = value; }
    }
    
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
        //Klimpf Addition
        sounds = GetComponents<AudioSource>();
        ratSound = sounds[0];
        itemSound = sounds[1];

        monster = GameObject.FindGameObjectWithTag("Monster");
        itempos = GameObject.FindGameObjectWithTag("ItemPos");
        //itempos = player.transform.Find("ItemPos").GetComponent<GameObject>();
    }
    void Update()
    {
        if (isOpen && !itemIsCreated && !enemyIsCreated)
        {
            graveClose.SetActive(false);
            graveOpne.SetActive(true);
            //Klimpf Addition
            dugUpGrave?.Invoke();

            if (isRichGrave)
            {
                int randomNum = UnityEngine.Random.Range(1, 4);
                if (randomNum == 1)
                {

                    creatRat();
                    Debug.Log("Rats attack");
                    int attackValue = UnityEngine.Random.Range(1, 10);
                    Debug.Log("Damage" + attackValue);
                    monster.GetComponent<BodypartStats>().takeDamage(attackValue);
                    monster.GetComponent<MonsterFollow>().hitRight();
                    creatItem();
                }
                if(randomNum==2)
                {
                    creatVampire();
                    Debug.Log("Vimpire attack");
                    int attackValue = UnityEngine.Random.Range(30, 50);
                    Debug.Log("Damage: " + attackValue);
                    int vimpireHealth = UnityEngine.Random.Range(100, 200);
                    if (monster.GetComponent<BodypartStats>().vipreAttack(attackValue, vimpireHealth))
                    {
                        monster.GetComponent<MonsterFollow>().attackRight();
                        Debug.Log("Monster won!");
                        creatItem();
                    }
                    else
                    {
                        monster.GetComponent<MonsterFollow>().hitRight();
                    }
                }
                if(randomNum == 3)
                {
                    creatItem();
                }
            }
            else
            {
                if (UnityEngine.Random.value >= 0.5)
                {

                    creatRat();
                    Debug.Log("Rats attack");
                    int attackValue = UnityEngine.Random.Range(1, 10);
                    Debug.Log("Rats attack Value"+attackValue);
                    monster.GetComponent<BodypartStats>().takeDamage(attackValue);
                    monster.GetComponent<MonsterFollow>().hitRight();
                }
                creatItem();
                
            }
        }
    }
    private void creatItem()
    {
        itemSound.Play();
        GameObject newItem = Instantiate(item);
        newItem.transform.parent = itempos.transform;
        newItem.transform.position = new Vector3(itempos.transform.position.x, itempos.transform.position.y);
        itemIsCreated = true;
    }
    private void creatRat()
    {
        ratSound.Play();
        GameObject newRat = Instantiate(rat);
        newRat.transform.parent = enemySpawnPoint.transform;
        Destroy(newRat, 3f);
        enemyIsCreated = true;
    }
    private void creatVampire()
    {
        GameObject newVampire = Instantiate(vampire);
        newVampire.transform.parent = enemySpawnPoint.transform;
        newVampire.transform.position = enemySpawnPoint.transform.position;
        enemyIsCreated = true;
    }
}
