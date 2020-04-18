using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    BodypartStats bodypartStats;
    [SerializeField] private int maxBrain=200, currentBrain=0;
    [SerializeField] private int maxBlood=200, currentBlood=0;
    [SerializeField] private int maxMovemenet=300, currentMovement=0;
    [SerializeField] private int maxAttack=300, currentAttack=0;

    public int getCurrentMovement
    {
        get { return currentMovement; }
    }

    private void Start()
    {
        getBrainStats();
        getBloodStats();
        getMovementStats();
        getAttackStats();
    }
    private void Update()
    {
        getBrainStats();
        getBloodStats();
        getMovementStats();
        getAttackStats();
    }

    private void getBrainStats()
    {
        currentBrain = gameObject.GetComponent<BodypartStats>().Brain.MyIntValue + gameObject.GetComponent<BodypartStats>().Head.MyIntValue;
        if (currentBrain > maxBrain) currentBrain = maxBrain;
    }

    private void getBloodStats()
    {
        currentBlood = gameObject.GetComponent<BodypartStats>().Hart.MyIntValue + gameObject.GetComponent<BodypartStats>().Head.MyIntValue;
        if (currentBlood > maxBlood) currentBlood = maxBlood;
    }
    private void getMovementStats()
    {
        currentMovement = gameObject.GetComponent<BodypartStats>().LegRight.MyIntValue + gameObject.GetComponent<BodypartStats>().LegRight.MyIntValue + gameObject.GetComponent<BodypartStats>().Lung.MyIntValue;
        if (currentMovement > maxMovemenet) currentMovement = maxMovemenet;
    }
    private void getAttackStats()
    {
        currentAttack = gameObject.GetComponent<BodypartStats>().ArmLeft.MyIntValue + gameObject.GetComponent<BodypartStats>().ArmRight.MyIntValue + gameObject.GetComponent<BodypartStats>().Lung.MyIntValue;
        if (currentAttack > maxAttack) currentAttack = maxAttack;
    }
}
