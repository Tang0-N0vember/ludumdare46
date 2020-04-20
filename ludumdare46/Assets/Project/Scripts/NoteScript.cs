using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private List<TMPro.TextMeshProUGUI> noteList;
    private List<BodypartStats.MyInt> sortParts;

    [SerializeField] private GameObject Note;

    [SerializeField] private TMPro.TextMeshProUGUI part1;
    [SerializeField] private TMPro.TextMeshProUGUI part2;
    [SerializeField] private TMPro.TextMeshProUGUI part3;
    [SerializeField] private TMPro.TextMeshProUGUI part4;
    [SerializeField] private TMPro.TextMeshProUGUI part5;
    [SerializeField] private TMPro.TextMeshProUGUI part6;
    [SerializeField] private TMPro.TextMeshProUGUI part7;
    [SerializeField] private TMPro.TextMeshProUGUI part8;

    private GameObject monster;

    private bool isPaus=false;


    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.FindGameObjectWithTag("Monster");


        noteList = new List<TMPro.TextMeshProUGUI>();
        noteList.Add(part1);
        noteList.Add(part2);
        noteList.Add(part3);
        noteList.Add(part4);
        noteList.Add(part5);
        noteList.Add(part6);
        noteList.Add(part7);
        noteList.Add(part8);

        sortParts = new List<BodypartStats.MyInt>();

        Note.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPaus=!isPaus;
            Note.SetActive(isPaus);
            UpdateTimeScale();

            sortParts = monster.GetComponent<BodypartStats>().BodyPartList;

            sortParts.Sort((BodypartStats.MyInt a, BodypartStats.MyInt b) => { return a.MyIntValue.CompareTo(b.MyIntValue); });

            for(int i = 0; i < sortParts.Count; i++)
            {
                noteList[i].text = sortParts[i].PartName;
            }

            /*
            foreach (BodypartStats.MyInt part in monster.GetComponent<BodypartStats>().BodyPartList)
            {
                Debug.Log(part.PartName);
            }*/
        }
    }
    private void UpdateTimeScale()
    {
        if(isPaus)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
