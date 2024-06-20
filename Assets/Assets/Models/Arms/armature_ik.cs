using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class armature_ik : MonoBehaviour
{
    Animator animator;

    public bool isIkActive = false;
    public Transform rightHandObj = null;
    public Transform lookToObj = null;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        if (animator)
        {
            if (isIkActive)
            {
                if (lookToObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookToObj.position);
                }

                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, rightHandObj.rotation);
                }
            }
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,0);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,0);
            animator.SetLookAtWeight(0);
        }
    }
}
