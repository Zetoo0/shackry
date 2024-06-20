using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAggro : MonoBehaviour
{
    bool Behind;
    bool InFront;
    float Dot;


    public Transform target;
    public Transform attacker;
    public Vector3 dirToTarget;
    public Vector3 attackerForward;
    NavMeshAgent navMeshAgent;
    Animator anim;

    float distanceToPlayer = Mathf.Infinity;


    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    void LateUpdate()
    {
        attackerForward = attacker.forward;
    }



    void Update()
    {

        dirToTarget = Vector3.Normalize(target.position - attacker.position);
        distanceToPlayer = Vector3.Distance(target.position, attacker.position);

        Dot = Vector3.Dot(attacker.forward, dirToTarget);

        //707 = 45 degree

        Behind = Dot < -0.707;
        InFront = Dot > 0.707;
        Debug.Log("Behind: " + Behind);
        Debug.Log("In Front: " + InFront);
        //Debug.Log("Dot value: " + Dot);
        Debug.Log("Distance = "+ distanceToPlayer);
        /*if(InFront && PlayerInDistance())
        {
            MoveToPlayer();
        }*/

        MoveToPlayer();
    }

    bool PlayerInDistance()
    {
        bool inDistance = false;

        if(distanceToPlayer <= 4)
        {
            inDistance = true;
        }
        else
        {
            inDistance = false;
        }

        return inDistance;
    }

    void MoveToPlayer()
    {
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsRunning", true);
        navMeshAgent.SetDestination(target.position);

    }

}
