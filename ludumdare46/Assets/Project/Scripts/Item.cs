using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum myEnum{ Leg, Arm, Lung, Hart, Head,Brain, Grail, Hint };
    [SerializeField] private myEnum ItemType;
    [SerializeField] private int statPoints=0;
    private GameObject monster;

    private GameObject[] graves;

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
        if (ItemType.ToString() == "Hint")
        {
            if (graves == null)
            {
                graves = GameObject.FindGameObjectsWithTag("Grave");
            }
            foreach (GameObject grave in graves)
            {
                //Debug.Log(grave.GetComponent<GraveScript>().item.GetComponent<Item>().getItemType);

                if (grave.GetComponent<GraveScript>().item.GetComponent<Item>().getItemType.ToString()=="Grail")
                {
                     Debug.Log("grail pos found");
                    float xDistance = grave.transform.position.x - gameObject.transform.position.x;
                    float yDistance = grave.transform.position.y - gameObject.transform.position.y;
                    if (Mathf.Abs(xDistance) > Mathf.Abs(yDistance))
                    {
                        if (xDistance > 0)
                        {
                            
                            Debug.Log("East");
                        }
                        else
                        {
                            //transform.Rotate(0, 0, -90);
                            transform.rotation = Quaternion.Euler(0, 0, 180);
                            Debug.Log("West");
                        }
                    }
                    else
                    {
                        if (yDistance > 0)
                        {
                            //transform.Rotate(0, 0, 180);
                            transform.rotation = Quaternion.Euler(0, 0, -900);
                            Debug.Log("North");
                        }
                        else
                        {
                            transform.rotation = Quaternion.Euler(0, 0, 90);
                            Debug.Log("South");
                        }
                    }

                }
            }

        }
        //Debug.Log(ItemType.ToString());

        Destroy(gameObject, 2f);
    }
}
