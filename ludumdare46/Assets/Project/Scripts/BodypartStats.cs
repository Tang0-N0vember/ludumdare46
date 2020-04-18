using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodypartStats : MonoBehaviour
{
    public List<MyInt> BodyPartList;
    [SerializeField] private float damageTimer=3f;
    [SerializeField] private int startingBodyPartStat = 75;

    [SerializeField] private int maxArmLeft=100;
    [SerializeField] private int maxArmRight=100;
    [SerializeField] private int maxLegLeft=100;
    [SerializeField] private int maxLegRight=100;
    [SerializeField] private int maxHead=100;
    [SerializeField] private int maxLung=100;
    [SerializeField] private int maxHart=100;
    [SerializeField] private int maxBrain=100;

    public MyInt ArmLeft, ArmRight, LegLeft, LegRight, Head, Lung, Hart, Brain;

    protected float Timer;

    public class MyInt
    {
        public MyInt(int MyIntValue) => this.MyIntValue = MyIntValue;
        public int MyIntValue { get; set; }
        public override string ToString() => MyIntValue.ToString();
    }
    private void Start()
    {
        BodyPartList = new List<MyInt>();

        BodyPartList.Add(ArmLeft=new MyInt(startingBodyPartStat));
        BodyPartList.Add(ArmRight = new MyInt(startingBodyPartStat));
        BodyPartList.Add(LegLeft = new MyInt(startingBodyPartStat));
        BodyPartList.Add(LegRight = new MyInt(startingBodyPartStat));
        BodyPartList.Add(Head = new MyInt(startingBodyPartStat));
        BodyPartList.Add(Lung = new MyInt(startingBodyPartStat));
        BodyPartList.Add(Hart = new MyInt(startingBodyPartStat));
        BodyPartList.Add(Brain = new MyInt(startingBodyPartStat));

        //foreach (MyInt i in BodyPartList) i.MyIntValue = 75;
    }
    private void Update()
    {

        Timer += Time.deltaTime;
        if(Timer>=damageTimer)
        {
            Timer = 0f;
            foreach (MyInt i in BodyPartList) i.MyIntValue--;
        }


        foreach (MyInt i in BodyPartList)
        {
            if (i.MyIntValue <= 0)
            {
                Debug.Log("Game Over");
            }
        }

    }
}
