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

    private AudioSource [] sounds;
    private AudioSource hitSound;
    private AudioSource punchSound;

    private bool isFighting = false;


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

        sounds = GetComponents<AudioSource>();
        hitSound = sounds[0];
        punchSound = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
        followSpeed = (float)gameObject.GetComponent<MonsterStats>().getCurrentMovement/50f;
        if (!isFighting)
        {
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
    }

    public void attackRight()
    {
        punchSound.Play();

        isFighting = true;
        monsterFront.SetActive(false);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(false);
        monsterLeftHit.SetActive(false);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(true);
        monsterRightHit.SetActive(false);
        StartCoroutine(AnimationCoroutine());
    }
    public void hitRight()
    {
        hitSound.Play();

        isFighting = true;
        monsterFront.SetActive(false);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(false);
        monsterLeftHit.SetActive(false);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(false);
        monsterRightHit.SetActive(true);
        StartCoroutine(AnimationCoroutine());
    }
    public void attackLeft()
    {
        punchSound.Play();

        isFighting = true;
        monsterFront.SetActive(false);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(true);
        monsterLeftHit.SetActive(false);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(false);
        monsterRightHit.SetActive(false);
        StartCoroutine(AnimationCoroutine());
    }
    public void hitLeft()
    {
        hitSound.Play();

        isFighting = true;
        monsterFront.SetActive(false);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(false);
        monsterLeftHit.SetActive(true);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(false);
        monsterRightHit.SetActive(false);
        StartCoroutine(AnimationCoroutine());
    }
    IEnumerator AnimationCoroutine()
    {
        yield return new WaitForSeconds(1);
        monsterFront.SetActive(false);
        monsterBack.SetActive(false);

        monsterLeft.SetActive(false);
        monsterLeftAttack.SetActive(false);
        monsterLeftHit.SetActive(false);

        monsterRight.SetActive(false);
        monsterRightAttack.SetActive(false);
        monsterRightHit.SetActive(false);
        isFighting =false;
    }



}
