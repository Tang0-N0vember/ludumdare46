using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Script : MonoBehaviour
{
    [SerializeField] private Image movementImage;
    [SerializeField] private Image brainImage;
    [SerializeField] private Image bloodImage;
    [SerializeField] private Image attackImage;

    private GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        monster= GameObject.FindGameObjectWithTag("Monster");
    }

    // Update is called once per frame
    void Update()
    {
        movementImage.fillAmount =((100f/300f) * (float)monster.GetComponent<MonsterStats>().getCurrentMovement)/100f;
        brainImage.fillAmount = ((100f / 200) * (float)monster.GetComponent<MonsterStats>().getCurrentBrain) / 100f;
        bloodImage.fillAmount = ((100f / 200) * (float)monster.GetComponent<MonsterStats>().getCurrentBlood) / 100f;
        attackImage.fillAmount = ((100f / 300) * (float)monster.GetComponent<MonsterStats>().getCurrentBrain) / 100f;
    }
}
