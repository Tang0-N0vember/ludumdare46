using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
    [SerializeField] private GameObject monsterFront;
    [SerializeField] private GameObject monsterBack;
    [SerializeField] private GameObject monsterRight;
    [SerializeField] private GameObject monsterRightAttack;
    [SerializeField] private GameObject monsterRightHit;
    [SerializeField] private GameObject monsterLeft;
    [SerializeField] private GameObject monsterLeftAttack;
    [SerializeField] private GameObject monsterLeftHit;


    [SerializeField] private float followSpeed;

    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").transform;
        followSpeed = (float)gameObject.GetComponent<MonsterStats>().getCurrentMovement/50f;

        monsterFront.SetActive(true);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(false);
        monsterLeftHit.SetActive(false);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(false);
        monsterRightHit.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        followSpeed = (float)gameObject.GetComponent<MonsterStats>().getCurrentMovement/50f;
        if (Vector2.Distance(transform.position, player.position) > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);


            float xDistance = player.transform.position.x - gameObject.transform.position.x;
            float yDistance = player.transform.position.y - gameObject.transform.position.y;
            if (Mathf.Abs(xDistance) > Mathf.Abs(yDistance))
            {
                if (xDistance > 0)
                {
                    Debug.Log("East");
                    monsterFront.SetActive(false);
                    monsterBack.SetActive(false);
                    monsterLeft.SetActive(false);
                    monsterRight.SetActive(true);
                }
                else
                {
                    Debug.Log("West");
                    monsterFront.SetActive(false);
                    monsterBack.SetActive(false);
                    monsterLeft.SetActive(true);
                    monsterRight.SetActive(false);
                }
            }
            else
            {
                if (yDistance > 0)
                {
                    Debug.Log("North");
                    monsterFront.SetActive(false);
                    monsterBack.SetActive(true);
                    monsterLeft.SetActive(false);
                    monsterRight.SetActive(false);
                }
                else
                {
                    Debug.Log("South");
                    monsterFront.GetComponent<Animator>().SetBool("gehen", true);
                    monsterFront.SetActive(true);
                    monsterBack.SetActive(false);
                    monsterLeft.SetActive(false);
                    monsterRight.SetActive(false);
                }
            }
        }
        else
        {
           monsterFront.GetComponent<Animator>().SetBool("gehen", false);
            monsterFront.SetActive(true);
            monsterBack.SetActive(false);
            monsterLeft.SetActive(false);
            monsterRight.SetActive(false);
        }
    }

    public void attackRight()
    {
        monsterFront.SetActive(false);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(false);
        monsterLeftHit.SetActive(false);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(true);
        monsterRightHit.SetActive(false);
    }
    public void hitRight()
    {
        monsterFront.SetActive(false);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(false);
        monsterLeftHit.SetActive(false);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(false);
        monsterRightHit.SetActive(true);
    }
    public void attackLeft()
    {
        monsterFront.SetActive(false);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(true);
        monsterLeftHit.SetActive(false);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(false);
        monsterRightHit.SetActive(false);
    }
    public void hitLeft()
    {
        monsterFront.SetActive(false);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(false);
        monsterLeftHit.SetActive(true);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(false);
        monsterRightHit.SetActive(false);
    }



}
