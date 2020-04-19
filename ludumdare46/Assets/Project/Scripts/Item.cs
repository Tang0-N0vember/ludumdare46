using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum myEnum{ Leg, Arm, Lung, Hart, Head,Brain, Grail };
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
        if (ItemType.ToString() == "Leg")
        {
            if (monster.GetComponent<BodypartStats>().LegLeft.MyIntValue < statPoints|| monster.GetComponent<BodypartStats>().LegRight.MyIntValue < statPoints)
            {
                if(monster.GetComponent<BodypartStats>().LegLeft.MyIntValue<= monster.GetComponent<BodypartStats>().LegRight.MyIntValue)
                {
                    monster.GetComponent<BodypartStats>().LegLeft.MyIntValue = statPoints;
                }
                else
                {
                    monster.GetComponent<BodypartStats>().LegRight.MyIntValue = statPoints;
                }
                
            }
        }
        if (ItemType.ToString() == "Arm")
        {
            if (monster.GetComponent<BodypartStats>().ArmLeft.MyIntValue < statPoints || monster.GetComponent<BodypartStats>().ArmRight.MyIntValue < statPoints)
            {
                if (monster.GetComponent<BodypartStats>().ArmLeft.MyIntValue <= monster.GetComponent<BodypartStats>().ArmRight.MyIntValue)
                {
                    monster.GetComponent<BodypartStats>().ArmLeft.MyIntValue = statPoints;
                }
                else
                {
                    monster.GetComponent<BodypartStats>().ArmRight.MyIntValue = statPoints;
                }

            }
        }
        if (ItemType.ToString() == "Lung")
        {
            if (monster.GetComponent<BodypartStats>().Lung.MyIntValue < statPoints)
            {
                    monster.GetComponent<BodypartStats>().Lung.MyIntValue = statPoints;

            }
        }
        if (ItemType.ToString() == "Hart")
        {
            if (monster.GetComponent<BodypartStats>().Hart.MyIntValue < statPoints)
            {
                monster.GetComponent<BodypartStats>().Hart.MyIntValue = statPoints;

            }
        }
        if (ItemType.ToString() == "Head")
        {
            if (monster.GetComponent<BodypartStats>().Head.MyIntValue < statPoints)
            {
                monster.GetComponent<BodypartStats>().Head.MyIntValue = statPoints;

            }
        }
        if (ItemType.ToString() == "Brain")
        {
            if (monster.GetComponent<BodypartStats>().Brain.MyIntValue < statPoints)
            {
                monster.GetComponent<BodypartStats>().Brain.MyIntValue = statPoints;

            }
        }
        if (ItemType.ToString() == "Grail")
        {
            Debug.Log("Winner Winner Chicken Dinner");
        }
        //Debug.Log(ItemType.ToString());

        Destroy(gameObject, 2f);
    }
}
