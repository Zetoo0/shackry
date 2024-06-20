using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum FootState
{
    OnGround,
    InAir
};

public enum TrigonometryStuffToUse
{
    SIN,
    COS,
    TAN,
    ASIN,
    ACOS,
    ATAN,
    PI,
    NONE
}


public class PlayerMotion : MonoBehaviour
{
    public CharacterController chrController;
    //public float speed = 25.0f;
    Vector3 velocity;
    //public float gravity = -18f;
    public Transform GroundHit;
    public float distance;
    public LayerMask groundType;
    bool onGround;
    public float jump = 2.0f;
    [SerializeField] private float shootDistance;
   public bool isSprinting = false;
    public Vector3 moving;
    float horizontal;
    float vertical;
    public Rigidbody rb;
    Vector2 moveInput;

    public Player player;
    [SerializeField] byte team;
    [SerializeField] string name;
    [SerializeField] byte health;
    [SerializeField] float speed;
    [SerializeField] float gravity;
    [SerializeField] int StartingMoney;

    public float baseSpeed;

    [SerializeField] bool test;

    [SerializeField]ManageTextValues textValues;

    BoxCollider feetColl;

    static byte jumpCount;
    const byte MAX_JUMP_NUM = 2;

    bool IsCanJump;
    public bool isJumpCalled;
    bool isOnGround;

    CapsuleCollider chrColl;

    string currState;

    private const string IDLE_STATE = "male_idle_breath";
    private const string NORMAL_WALK_STATE = "male_move_walk_normal_root_motion";

    [SerializeField] public FallDamage fallDamageCalculator;
    float distanceFromDaGround;
        
    [SerializeField] GameObject mainGO;

    float fallDmgElapsedTime;

    [SerializeField] Transform Enemy;

    [SerializeField]float maxJumpPos;

    [SerializeField] public float gravityMass;
    public static Action onHealthChange;
    public float baseGravityMass;
    public float wallSlidingSpeed;
    /// <summary>
    /// value of the gravity mass addition while the player in the air doin somethin
    /// </summary>
    /// <returns></returns>
    public float additionalGravityMassWhilePlayerInThe;

    /// <summary>
    /// Trigonometry function to use while multiplying and adding gravity mass,
    /// it can be none as well
    /// </summary>
    public TrigonometryStuffToUse gravityMassMultiplierTrigo;

    private FootState _footState;

    public bool isCanJump;

    public bool testForce;
    public void ReceiveInput(Vector2 input)
    {
        moveInput = input;
        //print(input);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        chrColl = GetComponent<CapsuleCollider>();
        CreatePlayer();
    }

    public bool IsOnGround()
    {
        if (fallDamageCalculator.CheckGroundDistance() <= 0.06f)
        {
           // Debug.Log("Fődött vagyok");
           return true;
        }
        else
        {
            return false;
        }
    }

    public void playerGetDamage(float dmg)
    {
        StartCoroutine(player.GetDamage(dmg));
        Debug.Log("Tényleg kaptam az enemytől ennyit:" + dmg);
        onHealthChange?.Invoke();   
    }

    public bool OnGround()
    {
        return fallDamageCalculator.CheckGroundDistance() < 0.5f ? true : false;
    }

    void CheckIfFootIsInTheAir()
    {
        if (chrColl.CompareTag("Ground"))
        {
            _footState = FootState.OnGround;
           // isOnGround = true;
        }
        else
        {
            _footState = FootState.InAir;
            //isOnGround = false;
        }   
        if (!isOnGround)
        {
                rb.velocity = new Vector3(rb.velocity.x, -player.gravity * Time.deltaTime, rb.velocity.z);
        }
    }

    private void CreatePlayer()//később ebbe a paraméterek
    {
        player = new Player(team, name, health, speed, gravity, gameObject, textValues);
    }

    private void Start()
    {
        SetStarts();
    }

    private void SetStarts()
    {
        jumpCount = 0;
        IsCanJump = false;
        baseSpeed = speed;
        baseGravityMass = gravityMass;
        currState = IDLE_STATE;
        _footState = FootState.OnGround;
        fallDmgElapsedTime = 0.0f;
    }
    

    private void LateUpdate()
    {
       // if (!isOnGround) rb.velocity -= new Vector3(rb.velocity.x, gravityMass, rb.velocity.z) ;
    }

    public void IfInAirThenHuzzaleAPicsaba()
    {
        rb.velocity -= new Vector3(rb.velocity.x, gravityMass, rb.velocity.z) ;
    }


    public void Move()
    {
        HandleMovement();
       // CheckMovementConditions();
    }

    public  void HandleMovement()
    {
        horizontal = moveInput.normalized.x * player.movementspeed * Time.deltaTime;
        vertical = moveInput.y * player.movementspeed * Time.deltaTime;

        Vector2 axis = new Vector2(vertical, horizontal);
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0.0f, Camera.main.transform.right.x);
        Vector3 CombinatedDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = CombinatedDirection;
    }

    public void CheckMovementConditions()
    {
        if (IsCanJump)
        {
            Jump();
        }

        if (test)
        {
            StartCoroutine(player.GetDamage(10));
            test = false;
        }

        if (fallDamageCalculator.CheckGroundDistance() > 6.0f)
        {
            Debug.Log("Folldimidzs");
            StartDaFallDamagCalculation();
        }
    }

    void Sprint()
    {
        isSprinting = true;
        
    }

    public void OnJumping()
    {
        isJumpCalled = true;
        isCanJump = true;
     //   StartCoroutine(WaitThreeSecTillCanJumpAgain());

      /* if(jumpCount < MAX_JUMP_NUM)
        {
            IsCanJump = true;
            jumpCount++;
        }
        else
        {
            StartCoroutine(WaitThreeSecTillCanJumpAgain());
        }*/
    }

    IEnumerator WaitThreeSecTillCanJumpAgain()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        isCanJump = false;
        // jumpCount = 0;
    }

    public void JumpYielder()
    {
        StartCoroutine(WaitThreeSecTillCanJumpAgain());
    }
    
    
   public void Jump()
    {
        float jumpPos = Mathf.Sqrt(jump * -1.8f * player.gravity);//velocity.y = Mathf.Sqrt(jump * -2f * player.gravity);
        rb.velocity += new Vector3(rb.velocity.x, jumpPos-2, rb.velocity.z);
      //  _footState = FootState.InAir;
      //IsCanJump = false;
    }

    void MoveM()
    {
        Vector2 axis = new Vector2(vertical, horizontal);
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0.0f, Camera.main.transform.right.x);
        Vector3 CombinatedDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = CombinatedDirection;
    }


    void StartDaFallDamagCalculation()
    {
        
        if (!IsOnGround())
        {
            Debug.Log("ÁÁÁÁÁÁÁ ESEEEEK ilepszd tájm:");
            Debug.Log(fallDmgElapsedTime);
            //Debug.Log(fallDmgElapsedTime);
            fallDmgElapsedTime += Time.deltaTime;
        }

        else if(IsOnGround() && fallDamageCalculator.CheckGroundDistance() < 0.12f)
        {
            player.GetFallDamage(fallDmgElapsedTime * fallDamageCalculator.FallDmgDamageMultiplier * 3);
           // Debug.Log(fallDmgElapsedTime * 3);
            //Debug.Log("Kapott damázs");
            //%%óóDebug.Log(fallDmgElapsedTime);
            //Debug.Log(fallDmgElapsedTime * fallDamageCalculator.FallDmgDamageMultiplier);
            fallDmgElapsedTime = 0.0f;
            Debug.Log("FÁDÜ");
           // Debug.Log("ÁUCS");
        }
    }
    
    
}
