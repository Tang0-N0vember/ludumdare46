using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadItems : MonoBehaviour
{
    public GameObject[] graves;
    public List<GameObject> ItemtList;

    [Header("non Body Parts")]
    [SerializeField] private GameObject GrailItem;
    [SerializeField] private GameObject HintItem;

    [Header("Body Parts")]
    [SerializeField] private GameObject LegItem;
    [SerializeField] private GameObject LegItem1;
    [SerializeField] private GameObject LegItem2;

    [SerializeField] private GameObject ArmItem;
    [SerializeField] private GameObject ArmItem1;
    [SerializeField] private GameObject ArmItem2;

    [SerializeField] private GameObject HeadItem;
    [SerializeField] private GameObject HeadItem1;
    [SerializeField] private GameObject HeadItem2;

    [SerializeField] private GameObject BrainItem;
    [SerializeField] private GameObject BrainItem1;
    [SerializeField] private GameObject BrainItem2;

    [SerializeField] private GameObject HartItem;
    [SerializeField] private GameObject HartItem1;
    [SerializeField] private GameObject HartItem2;

    [SerializeField] private GameObject LungItem;
    [SerializeField] private GameObject LungItem1;
    [SerializeField] private GameObject LungItem2;

    //Klimpf Addition
    [SerializeField] private GameLogic logic;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        ItemtList = new List<GameObject>();
        ItemtList.Add(HintItem);

        ItemtList.Add(LegItem);
        ItemtList.Add(ArmItem);
        ItemtList.Add(HeadItem);
        ItemtList.Add(BrainItem);
        ItemtList.Add(HartItem);
        ItemtList.Add(LungItem);


        
        graves = GameObject.FindGameObjectsWithTag("Grave");
        int gravsCount = graves.Length;
        Debug.Log("Graves: "+gravsCount);
        int randomGraveForGrail = Random.Range(0, gravsCount);
        Debug.Log("Grail Grave:"+ randomGraveForGrail);

        //Klimpf Addition
        logic.grailGrave = graves[randomGraveForGrail].GetComponent<GraveScript>();

        graves[randomGraveForGrail].GetComponent<GraveScript>().item = GrailItem;
        for(int i = 0; i < gravsCount; i++)
        {
            if (i != randomGraveForGrail)
            {
                int randomItem = Random.Range(0, ItemtList.Count);
                graves[i].GetComponent<GraveScript>().item = ItemtList[randomItem];
            }
        }
    }
}
