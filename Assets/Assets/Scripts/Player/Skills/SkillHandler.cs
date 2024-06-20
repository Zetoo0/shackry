using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    public SkillTimeType skillTimeType;
    private float activeTime;
    public TimeBasedSkill[] timeBasedSkills;
    [SerializeField] GameObject[] EnemiesOnTheMap;
    [SerializeField] GameObject playerGO;
    bool isKeyPressed;

    [SerializeField] Charrrge chargeSkill;
    [SerializeField] GameObject castRayFromHere;
    PlayerMotion playerMovement;
    GameObject enemyObj;

    float baseMovSpeed;

    [SerializeField] Camera cam;

    private int grappableLayerMask;
    private Vector3 shootOrigin;

    public enum PickupState
    {
        PickedUp,
        NotPickedUp
    }

    bool isFastener;
    bool isCharge;

    Player player;

    [SerializeField] private LineRendererHandler lineHandler;
    [SerializeField] private RectTransform crosshair;

    private Vector3 rayOrigin;


    public PickupState state = PickupState.NotPickedUp;
    // Start is called before the first frame update

    private void Awake()
    {
     //   cam = GetComponent<Camera>();
        playerMovement = GetComponent<PlayerMotion>();
        player = playerMovement.player;
        // SetEnemiesOnTheMap();
    }

    void Start()
    {
        isFastener = false;
        baseMovSpeed = player.movementspeed;
        grappableLayerMask = LayerMask.GetMask(StaticLayerNames.grappableLayers);

    }

    private void Update()
    {
        rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        Debug.DrawRay(castRayFromHere.transform.position, castRayFromHere.transform.forward*20.0f, Color.red);

    }

    //CHARGE BASED SKILLS
    public void Charrrge()
    {
        RaycastHit rHit;
        if (Physics.Raycast(castRayFromHere.transform.position, castRayFromHere.transform.forward , out rHit, /*chargeSkill.range*/20.0f, grappableLayerMask))
        {
            Debug.Log(rHit.transform.gameObject.name);

            print("A???");
            print("asd");
          //  if (rHit.collider.gameObject.CompareTag("Enemo"))
           // { 
                lineHandler.SetupLineStartAndEndPosition(rHit.transform.position);
                /*print("Benne van");
                enemyObj = rHit.collider.gameObject;
                HandleCharrge(enemyObj);*/  
           // }

         
        }
    }

    private void HandleCharrge(GameObject enemy)
    {
        chargeSkill.ActivateSkill(playerGO, enemy);
    }

}

//   public void TimeBasedActionPerformed()
   // {

     //   print("Megnyomva time based skill ");
     //   /*switch(KeyCode)
        //{
      /*      case KeyCode.Q:
                print(key);
                Fastener();
                break;
        }*/
   // }
   /* #region FastenerTimeBasedSkill
    public void Fastener()
    {
        Debug.Log("Fastener activated");
        int i = 0;
        activeTime = timeBasedSkills[i].activeTime;
        timeBasedSkills[i].ActivateSkill(player);
        state = PickupState.PickedUp;
        isFastener = true;

    }

    private void HandleFastener(Player player)
    {
        if (activeTime > 0)
        {
            activeTime -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Fastener inactivated");
            player.movementspeed = baseMovSpeed;
            state = PickupState.NotPickedUp;
        }
    }
    #endregion
    private void SearchSkill(KeyCode key)
    {
        print(key);
    }

    public void InstantSkillPerformed()
    {

    }
*/

//}
