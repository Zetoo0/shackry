using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NunStateMaMonoBehavior : EntityStateMachine
{

    private BaseState currentState;

    public NunSummonState  nunSummonState;
    public enemyDyingState nunDyingState;
    public NunHideState nunChaseState;
    
    //animation names
    public  string A_NUN_SUMMON = "summon";
    public  string A_HEAD_SPINNING_1 = "head_spinning_1";
    public  string A_HEAD_SPINNING_2 = "head_spinning_2";
    public  string A_DYING = "dying";
    
    //basic variables
    public Animator anim;
    public string currAnim;

    [SerializeField] private float hp;
    
    [SerializeField]
    NunScare nunDummyAtTheEnemy;

    
    private NunEnemy nunEnemy;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void InstanceStates()
    {
        nunSummonState = new NunSummonState(this);
       // nunDyingState = new enemyDyingState(this);
        nunChaseState = new NunHideState(this);
    }
    
    private void Start()
    {
        SetStarts();
    }

    private void SetStarts()
    {
        InstanceStates();
        nunEnemy = new NunEnemy(hp);
        currentState = nunSummonState;
        currentState.EnterState();
        StartCoroutine(HideSomewhere()); 
    }

    private void Update()
    {
        if (nunEnemy.Dead())
        {
            Debug.Log("Dead nun");
           // SwitchState(nunDyingState);
            
        }
    }

    public override void SwitchState(BaseState state)
    {
        if (state.IsConditionsMet())
        {
            currentState = state;
            currentState.EnterState();
            
        }
    }

    private IEnumerator HideSomewhere()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(10.0f);
           // NunScare.animToPlay = A_HEAD_SPINNING_1;
            SwitchState(nunSummonState);
            Debug.Log("DZSÁMPSZKER");
            nunDummyAtTheEnemy.gameObject.SetActive(true);
        }
    }

    public void CoroutineToHide()
    {
        Debug.Log("Started the coroutine to hude");
        StartCoroutine(HideAfterSummon());
    }
    
    private IEnumerator HideAfterSummon()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        SwitchState(nunChaseState);
    }


    public void PerformAnimation(string animNamae)
    {
        Debug.Log("Performálnom kellene animáciot: ");
        Debug.Log(animNamae);
        anim.Play("summon");
        Debug.Log("Le kellene játszanom mostmár geci");
    }
}
