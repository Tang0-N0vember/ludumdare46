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

    private bool isDead = false;

    public MyInt ArmLeft, ArmRight, LegLeft, LegRight, Head, Lung, Hart, Brain;

    protected float Timer;

    public class MyInt
    {
        public MyInt(int MyIntValue, string PartName) {
            this.MyIntValue = MyIntValue;
            this.PartName = PartName;
        }

        public int MyIntValue { get; set; }
        public string PartName { get; set; }
        public override string ToString() => MyIntValue.ToString();
    }
    private void Start()
    {
        BodyPartList = new List<MyInt>();

        BodyPartList.Add(ArmLeft=new MyInt(startingBodyPartStat,"left arm"));
        BodyPartList.Add(ArmRight = new MyInt(startingBodyPartStat,"right arm"));
        BodyPartList.Add(LegLeft = new MyInt(startingBodyPartStat,"left leg"));
        BodyPartList.Add(LegRight = new MyInt(startingBodyPartStat,"right leg"));
        BodyPartList.Add(Head = new MyInt(startingBodyPartStat,"head"));
        BodyPartList.Add(Lung = new MyInt(startingBodyPartStat,"lung"));
        BodyPartList.Add(Hart = new MyInt(startingBodyPartStat,"hart"));
        BodyPartList.Add(Brain = new MyInt(startingBodyPartStat,"brain"));
    }
    private void Update()
    {
        if (!isDead)
        {
            Timer += Time.deltaTime;
            if (Timer >= damageTimer)
            {
                Timer = 0f;
                foreach (MyInt i in BodyPartList)
                {
                    i.MyIntValue--;
                    Debug.Log(i.MyIntValue);
                }
            }
        }


        foreach (MyInt i in BodyPartList)
        {
            //nur bei hirn und herz
            if (i.MyIntValue <= 0)
            {
                isDead = true;
                Debug.Log("Game Over");
            }
        }

    }
    public void takeDamage(int damageValue)
    {
        foreach (MyInt i in BodyPartList)
        {
            i.MyIntValue-=damageValue;
        }
    }
    public bool vipreAttack(int damageValue, int vimpireHealth)
    {
        if (gameObject.GetComponent<MonsterStats>().getCurrentAttack >= vimpireHealth)
        {
            return true;
        }
        else
        {
            int randomNum = Random.Range(0, 5);
            BodyPartList[randomNum].MyIntValue -= damageValue;
            return false;
        }
    }
}
