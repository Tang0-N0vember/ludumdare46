using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireScript : MonoBehaviour
{
    [SerializeField] private GameObject vampireFront;
    [SerializeField] private GameObject vampireAttack;
    [SerializeField] private GameObject monster;
    private Transform monsterPos;
    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.FindGameObjectWithTag("Monster");
        monsterPos = monster.transform;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AttackWait());

        
    }
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(1);
        vampireFront.SetActive(false);
        vampireAttack.SetActive(true);
        transform.position = Vector2.MoveTowards(transform.position, monsterPos.position, 5f * Time.deltaTime);
        if (Vector2.Distance(transform.position, monsterPos.position) == 0f)
        {
            Destroy(gameObject);
        }
    }
}
