using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum myEnum{ LegLeft,LegRight, ArmLeft,ArmRight, Lung, Hart, Head, Grail };
    [SerializeField] private myEnum ItemType;
    [SerializeField] private int statPoints=0;
    private GameObject monster;

    public myEnum getItemType
    {
        get { return ItemType; }

    }
    private void Start()
    {
        monster = GameObject.FindGameObjectWithTag("Monster");
    }
    private void Update()
    {
        if (ItemType.ToString() == "LegLeft")
        {
            if (monster.GetComponent<BodypartStats>().LegLeft.MyIntValue < statPoints)
            {
                monster.GetComponent<BodypartStats>().LegLeft.MyIntValue = statPoints;
            }
        }
        if (ItemType.ToString() == "LegRight")
        {
            if (monster.GetComponent<BodypartStats>().LegRight.MyIntValue < statPoints)
            {
                monster.GetComponent<BodypartStats>().LegRight.MyIntValue = statPoints;
            }
        }
        //Debug.Log(ItemType.ToString());

        Destroy(gameObject, 2f);
    }
}
