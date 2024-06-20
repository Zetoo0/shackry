using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//pontos�tani a rotatet
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public Enemy enemy;
    [SerializeField] EnemyType enemyType;
    [SerializeField] string enemyName;
    [SerializeField] bool jump;
    [SerializeField] bool playerSeen;
    [SerializeField] Transform player;
    [SerializeField]public Transform eye;
    [SerializeField] bool test;
    Vector3 velocity;
   public CharacterController enemyChrC;
    string currentAnimationState;
    Rigidbody rb;

    //Rotation
    float rotVal;

    [SerializeField] PlayerMotion playRMov;
    [SerializeField] Transform PlayerPos;
    Player playRmovDotPlayR;

    private float jumpSqrt = 2.0f;
    // Start is called before the first frame update

    bool isEnemyCanAttack;
    bool isChasing;

    // [SerializeField] Animator anim;
    //const string ATTACKSTATE = "Attack";

    //ENEMY ANIM STATE NAMES
    //Headerrel elk�sz�t�s + Serifield, be�r�ssal lul
    private const  string ATTACK_ANIMATION = "Z_Attack";
    private const  string IDLE_ANIMATION = "Z_Idle";
    private const string CHASE_ANIMATION = "Z_Run_InPlace";
    string currAnim;
    public Animator anim;

    bool cannotChase;

    float playerDist;

    float timeElapsedSinceLastAttacked;

    TimeSpan rotateTimeSpan;
    DateTime timeBetweenRotate;

    [SerializeField] float ChaseRange;
    // System.DateTime rotateTimer = 0.0f;
    // System.DateTime timeToWaitToRotate = 3.0f;
    enemyStateMachine statemanager;
    bool canRotate = false;

    private void Awake()
    {
        enemy = new Enemy(enemyName, 100, 3, -19.0f, enemyType, 5, 100.0f,20.0f);//�t�r�s norem�lisan, be�rt �rt�kekre, majd prefabb� alak�t�s(minion?)
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        statemanager = GetComponent<enemyStateMachine>();

    }

    void Start()
    {

        SetStart();

    }

    private void SetStart()
    {
        rotVal = 45.0f;
        enemyChrC = GetComponent<CharacterController>();
        playRmovDotPlayR = playRMov.player;
        isEnemyCanAttack = true;
        currAnim = IDLE_ANIMATION;
        cannotChase = false;
        timeElapsedSinceLastAttacked = 0.0f;
      //  enemyChrC.detectCollisions = true;
        
    }

    // Update is called once per frame  
    void Update()
    {
        CheckDistance();

        //Movement();
    }

    private void Movement()
    {

        //Debug.Log(Vector3.Distance(PlayerPos.position, transform.position));

        //CheckBools();


    }
    private void CheckBools()
    {
        

        if (IsPlayerSeen() && !cannotChase)
        {
            anim.SetBool(Animator.StringToHash("IsPlayerSeen"), true);
            ChasePlayer();
            Invoke("SetPlayerSeenOff", 5);
        }

        if (IsCanJump())
        {
            Jump();
        }

        CheckDistance();
   
    }



    private void LateUpdate()
    {
        if (!enemyChrC.isGrounded)
        {
            velocity.y += enemy.gravity;
            enemyChrC.Move(velocity * Time.deltaTime);
        }

        /* if (!isChasing)
         {
             StartCoroutine(RotateChar());
         }*/
    }

    private bool CheckIfIsPlayerNotSeen()
    {
        return IsPlayerSeen();
    }
    private bool IsPlayerSeen()
    {
        return playerSeen;
    }

    private bool IsCanJump()
    {
        return jump;
    }

    public void SetPlayerSeenOff()
    {
        playerSeen = false;
        anim.SetBool(Animator.StringToHash("IsPlayerSeen"), false);
        anim.SetTrigger(Animator.StringToHash("Idleeee"));

    }

    //Ebbe a classba implement�lom a basic moveseteket az enemyhez, k�s�bb refactoring sz�ks�ges!!!!

    public void ChasePlayer()
    {
        
        
            isChasing = true;
          //  ChangeAnimationState(CHASE_ANIMATION);
            Debug.Log("Chase anim???");
            transform.LookAt(player);
            transform.Translate(new Vector3(0, 0, 1) * enemy.movementSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y, 0.0f);


        // ChangeAnimationState(ATTACKSTATE);

    }

    private void CheckDistance()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(eye.position, transform.forward, out hit, enemy.viewDistance))
        {
            Debug.DrawRay(eye.position, hit.point, Color.red);
            if (hit.collider.gameObject.CompareTag("Player") && (GetPlayerDist() > ChaseRange))
            {
                statemanager.playerDistance = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);
                anim.SetBool(Animator.StringToHash("IsCanAtk"), false);
                statemanager.a_CouldIAttack = CouldIAttack.No;
                statemanager.a_WhatISee = WhatISee.Player;
                //Debug.Log(Vector3.Distance(transform.position, hit.collider.gameObject.transform.position));
                Debug.Log("l�tok bazdki");
             //   playerDist = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);
              //  anim.SetBool(Animator.StringToHash("IsCanAtk"), false);
               // isEnemyCanAttack = false;
                //playerSeen = true;
            } else if(hit.collider.gameObject.CompareTag("Player") && (GetPlayerDist() <= ChaseRange))
            {
                anim.SetBool(Animator.StringToHash("IsCanAtk"), true);
                statemanager.a_WhatISee = WhatISee.Player;
                statemanager.a_CouldIAttack = CouldIAttack.Yes;
                // OnAttackedThePlayer();
                //anim.SetBool(Animator.StringToHash("IsCanAtk"), true);
                /*if (isEnemyCanAttack)
                {
                    StartCoroutine(playRmovDotPlayR.GetDamage(enemy.baseDamage));
                    isEnemyCanAttack = false;
                }
                else
                {
                    Debug.Log("No t�madni");
                }*/

                Debug.Log("t�madnom kell");

            }
            else
            {
                Invoke("SetEverythingBack", 5);

            }
        }
    }

    private void SetEverythingBack()
    {
        statemanager.SetEverythingBack();
    }

    private void OnAttackedThePlayer()
    {
        if(timeElapsedSinceLastAttacked <= 0.0f)
        {
            isEnemyCanAttack = true;
            timeElapsedSinceLastAttacked = 50.0f;
        }
        else
        {
            timeElapsedSinceLastAttacked -= Time.time;
        }
    }

    private float GetPlayerDist()
    {
        return Vector3.Distance(PlayerPos.position, transform.position);
    }


    private void OnDrawGizmos()
    {
    }
    //IDEIGLENESEN OFF
    /*private void OnTriggerEnter(Collider other)
    {
        isEnemyCanAttack = true;
        //Ilyenkor ne tudjon chaselni?, mikor collideol
        if (other.gameObject.CompareTag("Player") && isEnemyCanAttack)
        {/
            //cannotChase = true;
            // ChangeAnimationState(ATTACK_ANIMATION);
            anim.SetBool(Animator.StringToHash("IsCanAtk"), isEnemyCanAttack);
            StartCoroutine(playRmovDotPlayR.GetDamage(enemy.baseDamage));
            StartCoroutine(ChangeAttackBoolie());
            isEnemyCanAttack = false;
            // anim.SetBool(Animator.StringToHash("IsCanAtk"), isEnemyCanAttack);
            //StartCoroutine(ChangeAtkBool());
            print("Oh no the playe got some dmg");
            //cannotChase = false;
        }
        
    }*/

   


    IEnumerator ChangeAttackBoolie()
    {
        Debug.Log("folz atk");
        return new WaitForSecondsRealtime(5.0f);

        
       /* else
        {
            isEnemyCanAttack = true;
            Debug.Log("Tru atk");
            anim.SetBool(Animator.StringToHash("IsCanAtk"), isEnemyCanAttack);
            return new WaitForSecondsRealtime(2.0f);

        }*/

    }

   /* private bool IsCanAttack()
    {
        return StartCoroutine(ChangeAttackBoolie());
        if (!isEnemyCanAttack)
        {
           // StartCoroutine(ChangeAtkBool());
            return false;
        }
        else
        {

            return true;
        }
    }*/

    private IEnumerator ChangeAtkBool()
    {
        if (!isEnemyCanAttack)
        {
            yield return new WaitForSecondsRealtime(2);
            isEnemyCanAttack = true;
        }
        else
        {
            isEnemyCanAttack = false;
        }
    }



    IEnumerator  RotateChar()
    {
        yield return new WaitForSecondsRealtime(3);
        //Quaternion rot3 = Quaternion.Euler(0.0f, (rotVal + 45.0f)%360, 0.0f);
        transform.Rotate(new Vector3(0.0f, 3.22f, 0.0f), Space.Self);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rot3, 2.0f * Time.deltaTime);
        //transform.Rotate(rot.eulerAngles, Space.Self);
        Debug.Log("Rotated");
        //test = false;
       // rotVal += 45.0f; 
       // test = false;
    }
    
    public void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpSqrt * (-2f) * enemy.gravity);
        jump = false;
    }

    public void ChangeAnimationState(string newState)
    {
        if(newState == currAnim)
        {
            Debug.Log("Returnold m�r ink�bb baszom any�d");
            return;
        }
        
        currAnim = newState;
        anim.Play(newState);

    }



}
