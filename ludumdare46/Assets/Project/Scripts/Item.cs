using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum myEnum{ Leg, Arm, Lung, Hart, Head, Grail };
    [SerializeField]private myEnum ItemType;

    public myEnum getItemType
    {
        get { return ItemType; }

    }
    private void Update()
    {
        //if(ItemType.ToString()=="Arm")
        //Debug.Log(ItemType.ToString());

    }
}
