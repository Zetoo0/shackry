using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Jobs;


public class enemyMovingState : BaseState
{
    Vector3 WhereIAmHeading;
    BaseState previousStateCriterium;
    //NavMeshPath path;
    enemyStateMachine e;
    private Vector3 movementVelocity;
    public enemyMovingState(enemyStateMachine enemy) : base()
    {
        base.state_machine = enemy;
        this.e = (enemyStateMachine)state_machine;
        movementVelocity.x = 1.3f;
    }

    public override void EnterState( )
    {
       /* movementVelocity.y = e.agent.velocity.y;
        movementVelocity.z = e.agent.velocity.z;
        ;*/
       WhereIAmHeading = GetPositionToMove(e);
        Debug.Log(WhereIAmHeading);
        e._state = State.Running;
        e.agent.SetDestination(WhereIAmHeading);
        AnimationHandler.ChangeAnimation(e.WALK_ANIMATION, e.currAnim, out e.currAnim, e.anim);
    }


    public void OnCollisionEnter( )
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState( )
    {
        e.soundManager.PlayAudioAt(SoundManager.Sound.e_Walk,e.transform.position,false);
    }

    

    public void MoveThere(Vector3 position, Transform enemyMov)
    {
        enemyMov.Translate(position*Time.deltaTime,Space.Self);
    }

    public override bool IsConditionsMet( )
    {
        if(e.a_CouldIAttack == CouldIAttack.No && e.a_WhatISee == WhatISee.Other && e._state == State.Completed)
        {
            return true;
        }
        return false;

    }

    public override bool IsCoolingDown()
    {
        return false;
    }

    private Vector3 GetPositionToMove(enemyStateMachine e)
    {
        Debug.Log("E?");
        float RandomizedX = Random.Range(TerrainData.TerrainXPos, TerrainData.TerrainWidth + TerrainData.TerrainXPos);
        float RandomizedZ = Random.Range(TerrainData.TerrainZPos, TerrainData.TerrainLength + TerrainData.TerrainZPos);
//        float YValue = Terrain.activeTerrain.SampleHeight(new Vector3(RandomizedX, 0.0f, RandomizedZ));
        Vector3 retVec = new Vector3(RandomizedX, e.terrain.transform.position.y, RandomizedZ);
        return retVec;
    }

   
}
