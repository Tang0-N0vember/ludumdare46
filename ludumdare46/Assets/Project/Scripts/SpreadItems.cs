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
    [SerializeField] private GameObject ArmItem;
    [SerializeField] private GameObject HeadItem;
    [SerializeField] private GameObject BrainItem;
    [SerializeField] private GameObject HartItem;
    [SerializeField] private GameObject LungItem;

    
    
    
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
