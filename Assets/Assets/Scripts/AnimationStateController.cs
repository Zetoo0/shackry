using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;
    int isWalkingHash;
    int isRunningHash;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float distanceToGround;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
    }

    void Update()
    {

        bool forwardPressed = Input.GetKey("w");
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool runPressed = Input.GetKey("left shift");

        if (!isWalking && forwardPressed)
        {
            //if Player press W IsWalking will be true
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {
            //if Player press W IsWalking will be true
            animator.SetBool(isWalkingHash, false);
        }
        if (!isRunning && forwardPressed && runPressed)
        {
            //if Player press W IsWalking will be true
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!forwardPressed || runPressed))
        {
            //if Player press W IsWalking will be true
            animator.SetBool(isRunningHash, false);
        }


    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1.0f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1.0f);

            RaycastHit hit;
            Ray ray = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
            if(Physics.Raycast(ray, out hit, distanceToGround + 1.0f))
            {
                if (hit.transform.CompareTag("Walkable"))
                {
                    Vector3 footPos = hit.point;
                    footPos.y += distanceToGround;
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, footPos);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));
                }
            }
        }
        else
        {
            return;
        }
    }
}
