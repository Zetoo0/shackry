using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity;
using Unity.Mathematics;
using UnityEngine.AI;
using UnityEngine.Jobs;
using Random = UnityEngine.Random;
using Range = UnityEngine.SocialPlatforms.Range;

public enum WhatISee
{
    Player,
    Other
}

public enum CouldIAttack
{
    Yes,
    No
}

public enum State
{
    Completed,
    Running
}

public enum MovementState
{
    InPlace,
    OnTheWay
}

public class enemyStateMachine : EntityStateMachine
{
    [SerializeField] EnemyType a_EnemyType;
    [SerializeField] public Terrain terrain;

    //States
    private BaseState currentState;
    BaseState previousState;
    
    public enemyDyingState dyingState;
    public enemyAttackState attackState;
    public enemyIdleState idleState;
    public enemyChaseState chaseState;
    public enemyMovingState movingState;

    public Enemy myEnemy;

    [Header("Enemy Stats")] [SerializeField]
    private string enemyName;

    [SerializeField] private float health;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private byte baseDamage;
    [SerializeField] private float viewDistance;
    [SerializeField] private float chaseRange;

    [SerializeField] public float walkSpeed;
    [SerializeField] public float chaseSpeed;

    [SerializeField] public float baseMovingSpeed;
    [SerializeField] public float baseChaseSpeed;
    [SerializeField] public EnemyMovement enemyMoveset;
    public static Action enemyDying;
    [SerializeField] public bool isDead;
    [SerializeField] public float playerDistance;

    [Header("Decision Makers")] [SerializeField]
    public WhatISee a_WhatISee;

    [SerializeField] public CouldIAttack a_CouldIAttack;
    [SerializeField] public MovementState a_MovementState;
    public State _state;

    //Checkers
    public bool isChasing;
    public bool isAttacking;
    public bool isMoving;
    public bool isIdleing;

    [SerializeField]private float tempAtkRange = 3.0f;

    [SerializeField] Transform _eye;
    [SerializeField] public PlayerMotion player;

    [SerializeField] public Transform trans;

    [Header("Animations")] public Animator anim;
    public string currAnim;
    [SerializeField] public string ATTACK_ANIMATION = "Z_Attack";
    [SerializeField] public string IDLE_ANIMATION = "Z_Walk_InPlace";
    [SerializeField] public string WALK_ANIMATION = "Z_Walk_InPlace";
    [SerializeField] public string CHASE_ANIMATION = "Z_Run_InPlace";
    [SerializeField] public string Death_ANIMATION = "Z_FallingForward";

    //Animation hashes
    public int attack_hash;
    public int walk_hash;
    public int chase_hash;
    public int idle_hash;
    public int death_hash;

    public NavMeshAgent agent;

    public float velocityX;
    public float velocityZ;
    public int velZHash;

    public SoundManager soundManager;
    [SerializeField] public Transform player_position;

    [Header("Set Back variables")]
    [SerializeField] private float afterIntoChaseSetBackTime;//The seconds after invoke the SetEverything back function,
                                                             //to stop chase the player aka getting tired maybe i should
                                                             //rename it to timeGettingTired or set a tired variable to enemy TODO 
    [SerializeField] private Transform _dropPosition;
    [SerializeField] private GameObject dropAmmoGO;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        //  enemyMoveset = GetComponent<EnemyMovement>();
    }

    private void InstanceStates()
    {
        dyingState = new enemyDyingState(this);
        attackState = new enemyAttackState(this);
        idleState = new enemyIdleState(this);
        chaseState = new enemyChaseState(this);
        movingState = new enemyMovingState(this);
    }



    void Start()
    {
        SetStarts();
    }

    void SetStarts()
    {
        InstanceStates();
        CreateEnemy();
       // AnimationHandler.ChangeAnimation(IDLE_ANIMATION, currAnim, out currAnim, anim);
        SetAnimationHashes();
        set_basic_ai_enums();
        // agent.speed = myEnemy.movementSpeed;
        currentState.EnterState();
        StartCoroutine(WaitASecond());
        Debug.Log("beállítva minden");
    }

    //------------------------SETTERS AT START------------------------------

    void CreateEnemy()
    {
        myEnemy = new Enemy(enemyName, health, movementSpeed, gravity,
            enemyType, baseDamage, viewDistance, chaseRange);
    }

    void set_basic_ai_enums()
    {
        a_CouldIAttack = CouldIAttack.No;
        a_WhatISee = WhatISee.Player;
        _state = State.Running;
        currentState = idleState;
        isDead = false;
        isChasing = false;
        _state = State.Completed;
    }

    void SetAnimationHashes()
    {
        attack_hash = Animator.StringToHash(ATTACK_ANIMATION);
        idle_hash = Animator.StringToHash(IDLE_ANIMATION);
        walk_hash = Animator.StringToHash(WALK_ANIMATION);
        chase_hash = Animator.StringToHash(CHASE_ANIMATION);
        death_hash = Animator.StringToHash(Death_ANIMATION);
        velZHash = Animator.StringToHash("VelocityZ");
    }
    //----------------------------------------------------------------------

    void Update()
    {

        if (IsDead())
        {
            enemyDying?.Invoke();
            MaybeDropAmmo();
            gameObject.SetActive(false);
        }

        if (myEnemy.GetIsMeGotSomeDmg())
        {
            if (currentState != chaseState || currentState != attackState)
            {
                agent.velocity = Vector3.right;
                chase_player();
            }
            myEnemy.GotDmgReset();
        }
        
        if (a_see_other_than_player()) Eye();

        if (a_see_player()) SwitchState(chaseState);
        if (a_could_attack()) SwitchState(attackState);

        if (currentState.Equals(attackState))
        {
            Invoke("SetEverythingBack", 1.5f);
        }
        currentState.UpdateState();
    }

    private void MaybeDropAmmo()
    {
        int random = Random.Range(0, 3);
        Debug.Log("Death drop random: " + random);
        if (random >= 1)
        {
            Debug.Log("Ammo Dropped");
            Instantiate(dropAmmoGO, _dropPosition.position, quaternion.identity);
        }
        
    }

    private bool IsDead()
    {
        return (myEnemy.health <= 0);
    }

    private bool a_could_attack()
    {
        return (a_CouldIAttack.Equals(CouldIAttack.Yes));
    }

    private bool a_see_other_than_player()
    {
        return (a_WhatISee.Equals(WhatISee.Other));
    }

    private bool a_see_player()
    {
        return (a_WhatISee.Equals(WhatISee.Player));
    }

    public void Eye()
    {
        //Debug.Log("Nézek egyáltalán?");
        RaycastHit hit;

        if (Physics.Raycast(_eye.position, _eye.transform.TransformDirection(Vector3.forward), out hit, 100.0f))
        {
            Debug.DrawRay(_eye.position, _eye.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.collider.gameObject.CompareTag("Player") && (GetPlayerDist() <= myEnemy.chaseRange && GetPlayerDist() > tempAtkRange))
            {
                chase_player();
            }
            if (hit.collider.gameObject.CompareTag("Player") && (GetPlayerDist() <= tempAtkRange))
            {
                set_player_attack_enums();
            }
            else
            {
                Invoke("SetEverythingBack", 3f);
            }
        }
    }

    private void set_player_attack_enums()
    {
        //anim.SetBool(Animator.StringToHash("IsCanAtk"), true);
        a_WhatISee = WhatISee.Player;
        a_CouldIAttack = CouldIAttack.Yes;
    }

    private void chase_player()
    {
        if (currentState != attackState)
        {
            Debug.Log("láttam");
            playerDistance = Vector3.Distance(transform.position, player_position.position);
            // anim  .SetBool(Animator.StringToHash("IsCanAtk"), false);
            Invoke("SetEverythingBack", 3);
            a_CouldIAttack = CouldIAttack.No;
            a_WhatISee = WhatISee.Player; 
        }
    }

    public void SetEverythingBack()
    {
        a_WhatISee = WhatISee.Other;
        a_CouldIAttack = CouldIAttack.No;
        _state = State.Completed;
    }

    private float GetPlayerDist()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log("Distance:" + dist);
        return dist;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player.playerGetDamage(10f);
            Debug.Log("Kapta a player lul");
            set_attack_enums_look_at_player_and_switch_to_attack_state(collision);
        }
    }

    private void set_attack_enums_look_at_player_and_switch_to_attack_state(Collider collision)
    {
        transform.LookAt(collision.transform);
        a_CouldIAttack = CouldIAttack.Yes;
        a_WhatISee = WhatISee.Player;
    }


    public IEnumerator WaitASecond()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            //Debug.Log("tick");
            //Here will be all check what is only need to check in every second not every frame
            Debug.Log(currAnim);
            Debug.Log(currentState);
            if (a_CouldIAttack.Equals(CouldIAttack.No) && a_WhatISee.Equals(WhatISee.Other) && currentState != movingState)
            {
                SwitchState(movingState);
            }
          /*  if (a_CouldIAttack.Equals(CouldIAttack.No) && a_WhatISee.Equals(WhatISee.Other) &&
                     _state.Equals(State.Completed))
            {
                 AnimationHandler.ChangeAnimation(IDLE_ANIMATION, currAnim, out currAnim, anim);
                 enemyMoveset.ChangeAnimationState(enemyMoveset.IDLE_ANIMATION);
            }*/
        }
    }
    
    public void ChangeAnimationState(string newState)
    {
        if (Animator.StringToHash(newState).Equals(Animator.StringToHash(currAnim)))
        {
            Debug.Log("Returnold már inkább baszom anyád");
            return;
        }

        currAnim = newState;
        anim.Play(Animator.StringToHash(newState));
    }

    public override void SwitchState(BaseState state)
    {
        if (state.IsConditionsMet())
        {
            currentState = state;
            state.EnterState();
        }
    }
    
  
}