using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
    MonsterStats monsterStats;
    [SerializeField] private float followSpeed;

    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        followSpeed = (float)gameObject.GetComponent<MonsterStats>().getCurrentMovement/50f;
    }

    // Update is called once per frame
    void Update()
    {
        followSpeed = (float)gameObject.GetComponent<MonsterStats>().getCurrentMovement/50f;
        if (Vector2.Distance(transform.position, player.position) > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
        }
    }
    


}
