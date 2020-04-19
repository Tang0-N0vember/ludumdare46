﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using V_AnimationSystem;

public class WayPointHandler : MonoBehaviour
{

    private const float speed = 3f;
    private const float sprintSpeed = 6f;

    [SerializeField] private List<Vector3> waypointList;
    [SerializeField] private List<float> waitTimeList;
    private int waypointIndex;

    [SerializeField] private string idleAnimation = "dZombie_Idle";
    [SerializeField] private string walkAnimation = "dZombie_Walk";

    [SerializeField] private float idleFrameRate = 1f;
    [SerializeField] private float walkFrameRate = 1f;
    [SerializeField] private Vector3 aimDirection;

    [SerializeField] private PlayerController player;
    [SerializeField] private Transform pfFieldOfView;
    [SerializeField] private float fov = 90f;
    [SerializeField] private float viewDistance = 50f;

    private FieldOfView fieldOfView;
    private bool seen;

    [SerializeField] private float detectTimer;
    private float currentDetectTimer;
    [SerializeField] private float attackTimer;

    private int discoveredCount;

    //private V_UnitSkeleton unitSkeleton;
    //private V_UnitAnimation unitAnimation;
    //private AnimatedWalker animatedWalker;

    private enum State
    {
        Waiting,
        Moving,
        AttackingPlayer,
        Busy,
        Seeing,
    }

    private State state;
    private float waitTimer;
    //private UnitAnimType attackUnitAnim;
    private Vector3 lastMoveDir;

    private void Start()
    {
        Debug.Log("It works");
        Transform bodyTransform = transform.Find("Body");
        //unitSkeleton = new V_UnitSkeleton(1f, bodyTransform.TransformPoint, (Mesh mesh) => bodyTransform.GetComponent<MeshFilter>().mesh = mesh);
        //unitAnimation = new V_UnitAnimation(unitSkeleton);
        //animatedWalker = new AnimatedWalker(unitAnimation, UnitAnimType.GetUnitAnimType(idleAnimation), UnitAnimType.GetUnitAnimType(walkAnimation), idleFrameRate, walkFrameRate);
        state = State.Waiting;
        waitTimer = waitTimeList[0];
        lastMoveDir = aimDirection;
        //attackUnitAnim = UnitAnimType.GetUnitAnimType("dMarine_Attack");

        fieldOfView = Instantiate(pfFieldOfView, null).GetComponent<FieldOfView>();
        fieldOfView.SetFoV(fov);
        fieldOfView.SetViewDistance(viewDistance);

        //seen = false;
        currentDetectTimer = detectTimer;
        discoveredCount = 0;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Waiting:
            case State.Moving:
                HandleMovement();
                FindTargetPlayer();
                break;
            case State.AttackingPlayer:
                HandleMovement();
                AttackPlayer();
                break;
            case State.Busy:
                break;
            case State.Seeing:
                SeePlayer();
                break;
        }
        //unitSkeleton.Update(Time.deltaTime);

        if (fieldOfView != null)
        {
            fieldOfView.SetOrigin(transform.position);
            fieldOfView.SetAimDirection(GetAimDir());
        }

        Debug.DrawLine(transform.position, transform.position + GetAimDir() * 10f);
    }

    private void FindTargetPlayer()
    {
        if(Detected())
        {
            discoveredCount++;
            if (discoveredCount >= 3)
            {
                Debug.Log("GameOver");
            }
            Debug.Log("HIT!");
            currentDetectTimer = detectTimer;
            StartSeeingPlayer();

            // Hit Player
        } else
        {
            currentDetectTimer = detectTimer;
            state = State.Moving;
            // Hit something else
        }

        /*if (Vector3.Distance(GetPosition(), player.transform.position) < viewDistance)
        {
            // Player inside viewDistance
            Vector3 dirToPlayer = (player.transform.position - GetPosition()).normalized;
            if (Vector3.Angle(GetAimDir(), dirToPlayer) < fov / 2f)
            {
                // Player inside Field of View
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance);
                if (raycastHit2D.collider != null)
                {
                    // Hit something
                    Debug.Log(raycastHit2D.collider.gameObject.GetComponent<PlayerController>());
                    Debug.Log(raycastHit2D.collider.gameObject.layer);
                    if (raycastHit2D.collider.gameObject.transform.tag == "Player") //transform.GetComponent<PlayerController>() != null)
                    {
                        
                    }
                    else
                    {

                    }
                }
            }
        }*/
    }

    private bool Detected()
    {
        if (Vector3.Distance(GetPosition(), player.transform.position) < viewDistance)
        {
            //Debug.Log("ViewDistance: " + viewDistance);
            //Debug.Log("ActualDistance: " + Vector3.Distance(GetPosition(), player.transform.position));
            // Player inside viewDistance
            Vector3 dirToPlayer = (player.transform.position - GetPosition()).normalized;
            if (Vector3.Angle(GetAimDir(), dirToPlayer) < fov / 2f)
            {
                // Player inside Field of View
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance);
                if (raycastHit2D.collider != null)
                {
                    // Hit something
                    if (raycastHit2D.collider.gameObject.transform.tag == "Player") //GetComponent<PlayerController>() != null)
                    {
                        //if(raycastHit2D.point )
                        //Debug.Log("Player detected");
                        return true;
                    }
                    else
                    {
                        //Debug.Log("Kein Player");
                        return false;
                    }
                }
                else
                {
                    //Debug.Log("Keine Collision");
                    return false;
                }
            }
            else
            {
                //Debug.Log("Nicht im Field of View");
                return false;
            }
        }
        else
        {
            //Debug.Log("Nicht in ViewingDistance");
            return false;
        }
    }

    public void StartSeeingPlayer()
    {
        SeePlayer();
    }

    private void SeePlayer()
    {
        Vector3 targetPosition = player.transform.position;
        Vector3 dirToTarget = (targetPosition - GetPosition()).normalized;
        lastMoveDir = dirToTarget;

        if (Detected())
        {
            currentDetectTimer -= Time.deltaTime;
            //Detected();
            //Debug.Log(Detected().ToString());
            //Debug.Log(currentDetectTimer.ToString());
            //animatedWalker.SetMoveVector(Vector3.zero);
            if (currentDetectTimer <= 0f)
            {

                if (Detected())
                {
                    state = State.AttackingPlayer;
                }
                else
                {
                    currentDetectTimer = detectTimer;
                    state = State.Waiting;
                }
            }
            else state = State.Seeing;
        }
        else state = State.Waiting;



    }

    /*public void StartAttackingPlayer()
    {
        AttackPlayer();
    }*/

    private void AttackPlayer()
    {
        /*state = State.Busy;

        Vector3 targetPosition = player.transform.position;
        Vector3 dirToTarget = (targetPosition - GetPosition()).normalized;
        lastMoveDir = dirToTarget;*/



        if (Detected())
        {
            state = State.AttackingPlayer;
        }
        else
            state = State.Moving;

        /*unitAnimation.PlayAnimForced(attackUnitAnim, dirToTarget, 2f, (UnitAnim unitAnim) => {
            // Attack complete
            if (player.IsDead())
            {
                state = State.Moving;
            }
            else
            {
                state = State.AttackingPlayer;
            }
        }, (string trigger) => {
            // Damage Player
            player.Damage(this);
        }, null);

        Vector3 gunEndPointPosition = unitSkeleton.GetBodyPartPosition("MuzzleFlash");
        Shoot_Flash.AddFlash(gunEndPointPosition);
        WeaponTracer.Create(gunEndPointPosition, player.GetPosition());*/
    }

    private void HandleMovement()
    {
        switch (state)
        {
            case State.Waiting:
                waitTimer -= Time.deltaTime;
                //animatedWalker.SetMoveVector(Vector3.zero);
                if (waitTimer <= 0f)
                {
                    state = State.Moving;
                }
                break;
            case State.Moving:
                Vector3 waypoint = waypointList[waypointIndex];

                Vector3 waypointDir = (waypoint - transform.position).normalized;
                lastMoveDir = waypointDir;

                float distanceBefore = Vector3.Distance(transform.position, waypoint);
                //animatedWalker.SetMoveVector(waypointDir);
                transform.position = transform.position + waypointDir * speed * Time.deltaTime;
                float distanceAfter = Vector3.Distance(transform.position, waypoint);

                float arriveDistance = .1f;
                if (distanceAfter < arriveDistance || distanceBefore <= distanceAfter)
                {
                    // Go to next waypoint
                    waitTimer = waitTimeList[waypointIndex];
                    waypointIndex = (waypointIndex + 1) % waypointList.Count;
                    state = State.Waiting;
                }
                break;
            case State.AttackingPlayer:
                Vector3 targetPosition = player.transform.position;
                Vector3 dirToTarget = (targetPosition - GetPosition()).normalized;
                lastMoveDir = dirToTarget;

                float distanceBefore2 = Vector3.Distance(transform.position, targetPosition);
                //animatedWalker.SetMoveVector(waypointDir);
                transform.position = transform.position + dirToTarget * sprintSpeed * Time.deltaTime;
                float distanceAfter2 = Vector3.Distance(transform.position, targetPosition);

                float arriveDistance2 = .1f;
                if (distanceAfter2 < arriveDistance2 || distanceBefore2 <= distanceAfter2)
                {
                    //Dead
                    Debug.Log("Dead");
                }
                break;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetAimDir()
    {
        return lastMoveDir;
    }

}
